using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObservableWrapperGenerator
{
    public static class NewGenerator
    {
        class MethodSignature
        {
            public Type ClassType { get; set; }
            public MethodInfo Info { get; set; }
            public Type ReturnType { get; set; }
            public string Name { get; set; }
            public bool IsStatic { get; set; }
            public List<ParameterSignature> ParameterSignatures { get; set; }
        }

        class ParameterSignature
        {
            public Type Type { get; set; }
            public string Name { get; set; }
        }

        private static void AppendLineIndented(this StringBuilder builder, int indentationLevel, string value)
        {
            builder.AppendLine(Enumerable.Repeat(indentation, indentationLevel).Aggregate(string.Concat) + value);
        }

        private static void AppendFormatIndented(this StringBuilder builder, int indentationLevel, string format, params object[] args)
        {
            builder.AppendFormat(Enumerable.Repeat(indentation, indentationLevel).Aggregate(string.Concat) + format + Environment.NewLine, args);
        }

        private const string indentation = "   ";

        public static string GenerateClassWrapper(Type type)
        {
            var isTypeStatic = type.IsAbstract && type.IsSealed;

            var sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Reactive.Threading.Tasks;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine("using System.Reactive.Linq;");
            sb.AppendLine("using Wrappers;");
            sb.AppendLine();
            sb.AppendFormat("namespace {0}{1}", type.Namespace, Environment.NewLine);
            sb.AppendLine("{");
            sb.AppendFormatIndented(1, "public static class _{0}", type.Name);
            sb.AppendLineIndented(1, "{");

            foreach (var method in type.GetRuntimeMethods().Where(m => m.IsPublic && !m.IsSpecialName))
            {
                var methodSignature = new MethodSignature();
                methodSignature.ClassType = type;
                methodSignature.Info = method;
                methodSignature.Name = method.Name;
                methodSignature.ReturnType = method.ReturnType;
                methodSignature.IsStatic = method.IsStatic;
                methodSignature.ParameterSignatures = method.GetParameters().Select(p => new ParameterSignature
                                                                                         {
                                                                                             Name = p.Name,
                                                                                             Type = p.ParameterType
                                                                                         }).ToList();
                string wrappedMethod = GenerateWrappedMethod(methodSignature);
                sb.AppendLine(wrappedMethod);
            }

            sb.AppendLineIndented(1, "}");
            sb.AppendLine("}");
            return sb.ToString();
        }

        private static string GenerateWrappedMethod(MethodSignature methodSignature)
        {
            var sb = new StringBuilder();

            sb.AppendFormatIndented(2, "public static {0} {1}{2}({3})",
                GenerateReturn(methodSignature),
                methodSignature.Name,
                GenerateGenericArguments(methodSignature),
                GenerateParameters(methodSignature));

            sb.AppendLineIndented(2, "{");
            sb.AppendFormatIndented(3, "return {0};", GenerateMethodBody(methodSignature));
            sb.AppendLineIndented(2, "}");
            
            return sb.ToString();
        }

        private static string GenerateGenericArguments(MethodSignature methodSignature)
        {
            var genericArguments = methodSignature.Info.GetGenericArguments();
            if (genericArguments.Any())
            {
                var arguments = genericArguments.Select(a => a.Name).Aggregate((left, right) => string.Format("{0}, {1}", left, right));
                return string.Format("<{0}>", arguments);
            }

            return string.Empty;
        }

        private static string GenerateReturn(MethodSignature methodSignature)
        {
            string returnType = methodSignature.ReturnType.FullName;
            if (methodSignature.ReturnType == typeof (void) || methodSignature.ReturnType == typeof(Task))
            {
                returnType = typeof (Unit).FullName;
            }
            else if (methodSignature.ReturnType.IsGenericParameter)
            {
                returnType = methodSignature.ReturnType.Name;
            }
            else if (methodSignature.ReturnType.IsSubclassOf(typeof (Task)))
            {
                var genericArgument = methodSignature.ReturnType.GetGenericArguments().Single();
                if (genericArgument.IsGenericParameter)
                    returnType = genericArgument.Name;
                else
                    returnType = genericArgument.FullName;
            }

            return string.Format("IObservable<{0}>", returnType);
        }

        private static string GenerateParameters(MethodSignature methodSignature)
        {
            var parameterStrings = new List<string>();
            if (!methodSignature.IsStatic)
            {
                parameterStrings.Add(string.Format("this IObservable<{0}> _{1}", methodSignature.ClassType.FullName, methodSignature.ClassType.Name));
            }

            if (methodSignature.ParameterSignatures.Any())
            {
                foreach (var parameterSignature in methodSignature.ParameterSignatures)
                {
                    string parameterType;
                    if (parameterSignature.Type.IsGenericParameter || parameterSignature.Type.ContainsGenericParameters)
                        parameterType = parameterSignature.Type.Name;
                    else
                        parameterType = parameterSignature.Type.FullName;

                    parameterStrings.Add(string.Format("IObservable<{0}> {1}", parameterType, parameterSignature.Name));
                }
            }

            if (parameterStrings.Any())
            {
                return parameterStrings.Aggregate((left, right) => string.Format("{0}, {1}", left, right));
            }

            return string.Empty;
        }


        //=====================================================================


        private static string GenerateMethodBody(MethodSignature methodSignature)
        {
            var sb = new StringBuilder();

            var genericArguments = GenerateGenericArguments(methodSignature);
            var lambdaParameters = GenerateLambdaParameters(methodSignature);

            if (!methodSignature.IsStatic)
            {
                var instanceParameterName = string.Format("_{0}", methodSignature.ClassType.Name);
                var instanceLambdaName = string.Format("{0}Lambda", instanceParameterName);
                //sb.Append(instanceParameterName);

                if (!methodSignature.ParameterSignatures.Any())
                {
                    if (methodSignature.ReturnType == typeof (Task) || methodSignature.ReturnType.IsSubclassOf(typeof (Task)))
                    {
                        //_MyClass.Select((_MyClassLambda) => _MyClassLambda.Work2().ToObservable()).SelectMany(o => o);
                        sb.AppendFormat("{0}.Select(({1}) => {1}.{2}{3}().ToObservable()).SelectMany(o => o)",
                            instanceParameterName,
                            instanceLambdaName,
                            methodSignature.Name,
                            genericArguments);
                    }
                    else if (methodSignature.ReturnType == typeof (void))
                    {
                        //_MyClass.Do((_MyClassLambda) => _MyClassLambda.Work()).ToUnit();
                        sb.AppendFormat("{0}.Do(({1}) => {1}.{2}{3}()).ToUnit()",
                            instanceParameterName,
                            instanceLambdaName,
                            methodSignature.Name,
                            genericArguments);
                    }
                    else
                    {
                        //_MyClass.Select((_MyClassLambda) => _MyClassLambda.Work3());
                        sb.AppendFormat("{0}.Select(({1}) => {1}.{2}{3}())",
                            instanceParameterName,
                            instanceLambdaName,
                            methodSignature.Name,
                            genericArguments);
                    }
                }
                //else if (methodSignature.ParameterSignatures.Count == 1)
                //{
                //    if (methodSignature.ReturnType == typeof(Task) || methodSignature.ReturnType.IsSubclassOf(typeof(Task)))
                //    {
                //        //_MyClass.Zip(x, (_MyClassLambda, xLambda) => _MyClassLambda.Work2(xLambda).ToObservable()).SelectMany(o => o);
                //        sb.AppendFormat("{0}.Zip({1}, ({2}, {3}) => {2}.{4}{5}({3}).ToObservable()).SelectMany(o => o)",
                //                        instanceParameterName,
                //                        methodSignature.ParameterSignatures.Select(p => p.Name)
                //                                       .Aggregate((left, right) => string.Format("{0}, {1}", left, right)),
                //                        instanceLambdaName,
                //                        lambdaParameters,
                //                        methodSignature.Name,
                //                        genericArguments);
                //    }
                //    else if (methodSignature.ReturnType == typeof(void))
                //    {
                //        sb.AppendFormat("");
                //    }
                //    else
                //    {
                //        sb.AppendFormat("");
                //    }
                //}
                else //Multiple Parameters
                {
                    if (methodSignature.ReturnType == typeof(Task) || methodSignature.ReturnType.IsSubclassOf(typeof(Task)))
                    {
                        sb.AppendFormat("{0}.Zip({1}, ({2}, {3}) => {2}.{4}{5}({3}).ToObservable()).SelectMany(o => o)",
                                        instanceParameterName,
                                        methodSignature.ParameterSignatures.Select(p => p.Name)
                                                       .Aggregate((left, right) => string.Format("{0}, {1}", left, right)),
                                        instanceLambdaName,
                                        lambdaParameters,
                                        methodSignature.Name,
                                        genericArguments);
                    }
                    else if (methodSignature.ReturnType == typeof(void))
                    {
                        //_MyClass.ZipExecute(x, (_MyClassLambda, xLambda) => _MyClassLambda.Work(xLambda));
                        sb.AppendFormat("{0}.ZipExecute({1}, ({2}, {3}) => {2}.{4}{5}({3}))",
                                        instanceParameterName,
                                        methodSignature.ParameterSignatures.Select(p => p.Name)
                                                       .Aggregate((left, right) => string.Format("{0}, {1}", left, right)),
                                        instanceLambdaName,
                                        lambdaParameters,
                                        methodSignature.Name,
                                        genericArguments);
                    }
                    else
                    {
                        //_MyClass.Zip(x, (_MyClassLambda, xLambda) => _MyClassLambda.Work3(xLambda));
                        sb.AppendFormat("{0}.Zip({1}, ({2}, {3}) => {2}.{4}{5}({3}))",
                                        instanceParameterName,
                                        methodSignature.ParameterSignatures.Select(p => p.Name)
                                                       .Aggregate((left, right) => string.Format("{0}, {1}", left, right)),
                                        instanceLambdaName,
                                        lambdaParameters,
                                        methodSignature.Name,
                                        genericArguments);
                    }
                }
            }
            else
            {
                if (!methodSignature.ParameterSignatures.Any())
                {
                    if (methodSignature.ReturnType == typeof(Task) || methodSignature.ReturnType.IsSubclassOf(typeof(Task)))
                    {
                        if (string.IsNullOrWhiteSpace(genericArguments))
                        {
                            sb.AppendFormat("Observable.FromAsync(() => {0}.{1}())",
                                            methodSignature.ClassType.FullName,
                                            methodSignature.Name);
                        }
                        else
                        {
                            sb.AppendFormat("Observable.FromAsync({0}.{1}{2})",
                                            methodSignature.ClassType.FullName,
                                            methodSignature.Name,
                                            genericArguments);
                        }
                    }
                    else if (methodSignature.ReturnType == typeof(void))
                    {
                        sb.AppendFormat("Observable.FromAsync(() => new Task({0}.{1}{2}))",
                                        methodSignature.ClassType.FullName,
                                        methodSignature.Name,
                                        genericArguments);
                    }
                    else
                    {
                        sb.AppendFormat("Observable.FromAsync(() => Task.FromResult({0}.{1}{2}()))",
                                        methodSignature.ClassType.FullName,
                                        methodSignature.Name,
                                        genericArguments);
                    }
                }
                else if (methodSignature.ParameterSignatures.Count == 1)
                {
                    if (methodSignature.ReturnType == typeof (Task) || methodSignature.ReturnType.IsSubclassOf(typeof (Task)))
                    {
                        //return x.Select((XL) => MyClass.Work16<T1, TResult>(XL).ToObservable()).SelectMany(o => o);
                        sb.AppendFormat("{0}.Select(({1}) => {2}.{3}{4}({1}).ToObservable()).SelectMany(o => o)",
                                        methodSignature.ParameterSignatures.Single().Name,
                                        lambdaParameters,
                                        methodSignature.ClassType.FullName,
                                        methodSignature.Name,
                                        genericArguments);
                    }
                    else if (methodSignature.ReturnType == typeof (void))
                    {
                        //return x.Do(MyClass.Work5).ToUnit();
                        sb.AppendFormat("{0}.Do({1}.{2}{3}).ToUnit()",
                                        methodSignature.ParameterSignatures.Single().Name,
                                        methodSignature.ClassType.FullName,
                                        methodSignature.Name,
                                        genericArguments);
                    }
                    else
                    {
                        //x.Select(MyClass.Work15<T1, TResult>);
                        sb.AppendFormat("{0}.Select({1}.{2}{3})",
                                        methodSignature.ParameterSignatures.Single().Name,
                                        methodSignature.ClassType.FullName,
                                        methodSignature.Name,
                                        genericArguments);
                    }
                }
                else //Multiple Parameters
                {
                    if (methodSignature.ReturnType == typeof(Task) || methodSignature.ReturnType.IsSubclassOf(typeof(Task)))
                    {
                        //Observable.Zip(x, y, (xLambda, yLambda) => MyClass.Work14<T1, T2>(xLambda, yLambda).ToObservable()).SelectMany(o => o);
                        sb.AppendFormat("Observable.Zip({0}, ({1}) => {2}.{3}{4}({1}).ToObservable()).SelectMany(o => o)",
                            methodSignature.ParameterSignatures.Select(p => p.Name).Aggregate((left, right) => string.Format("{0}, {1}", left, right)),
                            lambdaParameters,
                            methodSignature.ClassType.FullName,
                            methodSignature.Name,
                            genericArguments);
                    }
                    else if (methodSignature.ReturnType == typeof(void))
                    {
                        //ObservableEx.ZipExecute(x, y, (xLambda, yLambda) => MyClass.Work5(xLambda, yLambda));
                        //sb.AppendFormat("ObservableEx.ZipExecute({0}, ({1}) => {2}.{3}{4}({1}))",
                        //    methodSignature.ParameterSignatures.Select(p => p.Name).Aggregate((left, right) => string.Format("{0}, {1}", left, right)),
                        //    lambdaParameters,
                        //    methodSignature.ClassType.FullName,
                        //    methodSignature.Name,
                        //    genericArguments);
                        sb.AppendFormat("ObservableEx.ZipExecute({0}, {1}.{2}{3})",
                            methodSignature.ParameterSignatures.Select(p => p.Name).Aggregate((left, right) => string.Format("{0}, {1}", left, right)),
                            methodSignature.ClassType.FullName,
                            methodSignature.Name,
                            genericArguments);
                    }
                    else
                    {
                        //Observable.Zip(x, y, (xLambda, yLambda) => ObservableWrapperGenerator.MyClass.Work15<T1, T2, TResult>(xLambda, yLambda));
                        //sb.AppendFormat("Observable.Zip({0}, ({1}) => {2}.{3}{4}({1}))",
                        //    methodSignature.ParameterSignatures.Select(p => p.Name).Aggregate((left, right) => string.Format("{0}, {1}", left, right)),
                        //    lambdaParameters,
                        //    methodSignature.ClassType.FullName,
                        //    methodSignature.Name,
                        //    genericArguments);
                        sb.AppendFormat("Observable.Zip({0}, {1}.{2}{3})",
                            methodSignature.ParameterSignatures.Select(p => p.Name).Aggregate((left, right) => string.Format("{0}, {1}", left, right)),
                            methodSignature.ClassType.FullName,
                            methodSignature.Name,
                            genericArguments);
                    }
                }
            }

            return sb.ToString();
        }

        private static string GenerateLambdaParameters(MethodSignature methodSignature)
        {
            var lambdaParameterNameList = methodSignature.ParameterSignatures.Select(p => string.Format("{0}Lambda", p.Name)).ToList();
            var lambdaParameterNames = string.Empty;
            if (lambdaParameterNameList.Any())
                lambdaParameterNames = lambdaParameterNameList.Aggregate((left, right) => string.Format("{0}, {1}", left, right));
            return lambdaParameterNames;
        }
    }
}
