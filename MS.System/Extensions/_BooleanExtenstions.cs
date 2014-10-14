using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using MsSystem;

namespace MsSystem
{
   public static class BooleanExtensions
   {
      public static IObservable<System.Int32> GetHashCode(this IObservable<System.Boolean> value)
      {
         return value.Select((valueLambda) => valueLambda.GetHashCode());
      }

      public static IObservable<System.String> ToString(this IObservable<System.Boolean> value)
      {
         return value.Select((valueLambda) => valueLambda.ToString());
      }

      public static IObservable<System.String> ToString(this IObservable<System.Boolean> value, IObservable<System.IFormatProvider> provider)
      {
         return value.Zip(provider, (valueLambda, providerLambda) => valueLambda.ToString(providerLambda));
      }

      public static IObservable<System.Boolean> Equals(this IObservable<System.Boolean> value, IObservable<System.Object> obj)
      {
         return value.Zip(obj, (valueLambda, objLambda) => valueLambda.Equals(objLambda));
      }

      public static IObservable<System.Boolean> Equals(this IObservable<System.Boolean> value, IObservable<System.Boolean> obj)
      {
         return value.Zip(obj, (valueLambda, objLambda) => valueLambda.Equals(objLambda));
      }

      public static IObservable<System.Int32> CompareTo(this IObservable<System.Boolean> value, IObservable<System.Object> obj)
      {
         return value.Zip(obj, (valueLambda, objLambda) => valueLambda.CompareTo(objLambda));
      }

      public static IObservable<System.Int32> CompareTo(this IObservable<System.Boolean> source, IObservable<System.Boolean> value)
      {
         return source.Zip(value, (sourceLambda, valueLambda) => sourceLambda.CompareTo(valueLambda));
      }

      public static IObservable<Boolean> Parse(IObservable<System.String> value)
      {
          return value.Select(System.Boolean.Parse);
      }

       public static IObservable<Boolean> TryParse(IObservable<System.String> value, out IObservable<Boolean> result)
       {
           var gate = new object();
           var resultSubject = new ReplaySubject<System.Boolean>(1);
           result = resultSubject.AsObservable();
           return value.Select(valueLambda =>
                               {
                                   bool tempResult;
                                   bool parseResult = bool.TryParse(valueLambda, out tempResult);
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

       public static IObservable<System.TypeCode> GetTypeCode(this IObservable<System.Boolean> value)
      {
         return value.Select((valueLambda) => valueLambda.GetTypeCode());
      }

      public static IObservable<System.Type> GetType(this IObservable<System.Boolean> value)
      {
         return value.Select((valueLambda) => valueLambda.GetType());
      }

   }
}
