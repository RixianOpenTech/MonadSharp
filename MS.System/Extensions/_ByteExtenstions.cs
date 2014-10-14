using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace MsSystem
{
    public static class _ByteExtensions
    {
        public static IObservable<System.Int32> CompareTo(this IObservable<System.Byte> _Byte, IObservable<System.Object> value)
        {
            return _Byte.Zip(value, (_ByteLambda, valueLambda) => _ByteLambda.CompareTo(valueLambda));
        }

        public static IObservable<System.Int32> CompareTo(this IObservable<System.Byte> _Byte, IObservable<System.Byte> value)
        {
            return _Byte.Zip(value, (_ByteLambda, valueLambda) => _ByteLambda.CompareTo(valueLambda));
        }

        public static IObservable<System.Boolean> Equals(this IObservable<System.Byte> _Byte, IObservable<System.Object> obj)
        {
            return _Byte.Zip(obj, (_ByteLambda, objLambda) => _ByteLambda.Equals(objLambda));
        }

        public static IObservable<System.Boolean> Equals(this IObservable<System.Byte> _Byte, IObservable<System.Byte> obj)
        {
            return _Byte.Zip(obj, (_ByteLambda, objLambda) => _ByteLambda.Equals(objLambda));
        }

        public static IObservable<System.Int32> GetHashCode(this IObservable<System.Byte> _Byte)
        {
            return _Byte.Select((_ByteLambda) => _ByteLambda.GetHashCode());
        }

        public static IObservable<System.Byte> Parse(IObservable<System.String> s)
        {
            return s.Select(System.Byte.Parse);
        }

        public static IObservable<System.Byte> Parse(IObservable<System.String> s, IObservable<System.Globalization.NumberStyles> style)
        {
            return Observable.Zip(s, style, System.Byte.Parse);
        }

        public static IObservable<System.Byte> Parse(IObservable<System.String> s, IObservable<System.IFormatProvider> provider)
        {
            return Observable.Zip(s, provider, System.Byte.Parse);
        }

        public static IObservable<System.Byte> Parse(
            IObservable<System.String> s,
            IObservable<System.Globalization.NumberStyles> style,
            IObservable<System.IFormatProvider> provider)
        {
            return Observable.Zip(s, style, provider, System.Byte.Parse);
        }

        public static IObservable<System.Boolean> TryParse(IObservable<System.String> s, out IObservable<System.Byte> result)
        {
            var gate = new object();
            var resultSubject = new ReplaySubject<byte>(1);
            result = resultSubject;
            return s.Select(value =>
                            {
                                byte tempResult;
                                bool parseResult = byte.TryParse(value, out tempResult);
                                if (parseResult)
                                {
                                    lock (gate)
                                    {
                                        resultSubject.OnNext(tempResult);
                                    }
                                }
                                return parseResult;
                            })
                    .Do(_ => { },
                        () =>
                        {
                            lock (gate)
                            {
                                resultSubject.OnCompleted();
                            }
                        });
        }

        public static IObservable<System.Boolean> TryParse(IObservable<System.String> s, IObservable<System.Globalization.NumberStyles> style, IObservable<System.IFormatProvider> provider, out IObservable<System.Byte> result)
        {
            var gate = new object();
            var resultSubject = new ReplaySubject<byte>(1);
            result = resultSubject;
            return s.Zip(style, provider, (sLambda, styleLambda, providerLambda) =>
                            {
                                byte tempResult;
                                bool parseResult = byte.TryParse(sLambda, styleLambda, providerLambda, out tempResult);
                                if (parseResult)
                                {
                                    lock (gate)
                                    {
                                        resultSubject.OnNext(tempResult);
                                    }
                                }
                                return parseResult;
                            })
                    .Do(_ => { },
                        () =>
                        {
                            lock (gate)
                            {
                                resultSubject.OnCompleted();
                            }
                        });
        }

        public static IObservable<System.String> ToString(this IObservable<System.Byte> _Byte)
        {
            return _Byte.Select((_ByteLambda) => _ByteLambda.ToString());
        }

        public static IObservable<System.String> ToString(this IObservable<System.Byte> _Byte, IObservable<System.String> format)
        {
            return _Byte.Zip(format, (_ByteLambda, formatLambda) => _ByteLambda.ToString(formatLambda));
        }

        public static IObservable<System.String> ToString(this IObservable<System.Byte> _Byte, IObservable<System.IFormatProvider> provider)
        {
            return _Byte.Zip(provider, (_ByteLambda, providerLambda) => _ByteLambda.ToString(providerLambda));
        }

        public static IObservable<System.String> ToString(
            this IObservable<System.Byte> _Byte,
            IObservable<System.String> format,
            IObservable<System.IFormatProvider> provider)
        {
            return _Byte.Zip(format, provider, (_ByteLambda, formatLambda, providerLambda) => _ByteLambda.ToString(formatLambda, providerLambda));
        }

        public static IObservable<System.TypeCode> GetTypeCode(this IObservable<System.Byte> _Byte)
        {
            return _Byte.Select((_ByteLambda) => _ByteLambda.GetTypeCode());
        }

        public static IObservable<System.Type> GetType(this IObservable<System.Byte> _Byte)
        {
            return _Byte.Select((_ByteLambda) => _ByteLambda.GetType());
        }

    }
}