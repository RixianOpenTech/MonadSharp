using System.Reactive.Linq;
using System.Reactive.Subjects;
using MS.System;

namespace System
{
   public static class _BooleanExtensions
   {
       public static _Boolean AsBoolean(this IObservable<System.Boolean> source)
       {
           return source as _Boolean ?? new _Boolean(source);
       }

      public static IObservable<System.Int32> GetHashCode(this IObservable<System.Boolean> _Boolean)
      {
         return _Boolean.Select((_BooleanLambda) => _BooleanLambda.GetHashCode());
      }

      public static IObservable<System.String> ToString(this IObservable<System.Boolean> _Boolean)
      {
         return _Boolean.Select((_BooleanLambda) => _BooleanLambda.ToString());
      }

      public static IObservable<System.String> ToString(this IObservable<System.Boolean> _Boolean, IObservable<System.IFormatProvider> provider)
      {
         return _Boolean.Zip(provider, (_BooleanLambda, providerLambda) => _BooleanLambda.ToString(providerLambda));
      }

      public static IObservable<System.Boolean> Equals(this IObservable<System.Boolean> _Boolean, IObservable<System.Object> obj)
      {
         return _Boolean.Zip(obj, (_BooleanLambda, objLambda) => _BooleanLambda.Equals(objLambda));
      }

      public static IObservable<System.Boolean> Equals(this IObservable<System.Boolean> _Boolean, IObservable<System.Boolean> obj)
      {
         return _Boolean.Zip(obj, (_BooleanLambda, objLambda) => _BooleanLambda.Equals(objLambda));
      }

      public static IObservable<System.Int32> CompareTo(this IObservable<System.Boolean> _Boolean, IObservable<System.Object> obj)
      {
         return _Boolean.Zip(obj, (_BooleanLambda, objLambda) => _BooleanLambda.CompareTo(objLambda));
      }

      public static IObservable<System.Int32> CompareTo(this IObservable<System.Boolean> _Boolean, IObservable<System.Boolean> value)
      {
         return _Boolean.Zip(value, (_BooleanLambda, valueLambda) => _BooleanLambda.CompareTo(valueLambda));
      }

      public static _Boolean Parse(IObservable<System.String> value)
      {
         return value.Select(System.Boolean.Parse).AsBoolean();
      }

       public static _Boolean TryParse(IObservable<System.String> value, out _Boolean result)
       {
           var gate = new object();
           var resultSubject = new ReplaySubject<System.Boolean>(1);
           result = resultSubject.AsBoolean();
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
                           })
                       .AsBoolean();
       }

       public static IObservable<System.TypeCode> GetTypeCode(this IObservable<System.Boolean> _Boolean)
      {
         return _Boolean.Select((_BooleanLambda) => _BooleanLambda.GetTypeCode());
      }

      public static IObservable<System.Type> GetType(this IObservable<System.Boolean> _Boolean)
      {
         return _Boolean.Select((_BooleanLambda) => _BooleanLambda.GetType());
      }

   }
}
