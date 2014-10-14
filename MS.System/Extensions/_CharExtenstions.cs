using System;
using System.Globalization;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using MsSystem;

namespace MsSystem
{
   public static class CharExtensions
   {
      public static IObservable<int> GetHashCode(this IObservable<System.Char> charValue)
      {
         return charValue.Select((charValueLambda) => charValueLambda.GetHashCode());
      }

      public static IObservable<Boolean> Equals(this IObservable<System.Char> charValue, IObservable<System.Object> obj)
      {
         return charValue.Zip(obj, (charValueLambda, objLambda) => charValueLambda.Equals(objLambda));
      }

      public static IObservable<Boolean> Equals(this IObservable<System.Char> charValue, IObservable<System.Char> obj)
      {
         return charValue.Zip(obj, (charValueLambda, objLambda) => charValueLambda.Equals(objLambda));
      }

      public static IObservable<int> CompareTo(this IObservable<System.Char> charValue, IObservable<System.Object> value)
      {
         return charValue.Zip(value, (charValueLambda, valueLambda) => charValueLambda.CompareTo(valueLambda));
      }

      public static IObservable<int> CompareTo(this IObservable<System.Char> charValue, IObservable<System.Char> value)
      {
         return charValue.Zip(value, (charValueLambda, valueLambda) => charValueLambda.CompareTo(valueLambda));
      }

      public static IObservable<string> ToString(this IObservable<System.Char> charValue, IObservable<System.IFormatProvider> provider)
      {
         return charValue.Zip(provider, (charValueLambda, providerLambda) => charValueLambda.ToString(providerLambda));
      }

      public static IObservable<string> ToString(IObservable<System.Char> c)
      {
         return c.Select(System.Char.ToString);
      }

      public static IObservable<Char> Parse(IObservable<System.String> s)
      {
         return s.Select(System.Char.Parse);
      }

       public static IObservable<Boolean> TryParse(IObservable<System.String> s, out IObservable<Char> result)
       {
           var gate = new object();
           var resultSubject = new ReplaySubject<System.Char>(1);
           result = resultSubject.AsObservable();
           return s.Select(valueLambda =>
                           {
                               char tempResult;
                               bool parseResult = char.TryParse(valueLambda, out tempResult);
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
                   ;
       }

       public static IObservable<Boolean> IsDigit(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsDigit);
      }

      public static IObservable<Boolean> IsLetter(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsLetter);
      }

      public static IObservable<Boolean> IsWhiteSpace(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsWhiteSpace);
      }

      public static IObservable<Boolean> IsUpper(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsUpper);
      }

      public static IObservable<Boolean> IsLower(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsLower);
      }

      public static IObservable<Boolean> IsPunctuation(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsPunctuation);
      }

      public static IObservable<Boolean> IsLetterOrDigit(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsLetterOrDigit);
      }

      public static IObservable<Char> ToUpper(IObservable<System.Char> c, IObservable<System.Globalization.CultureInfo> culture)
      {
         return Observable.Zip(c, culture, System.Char.ToUpper);
      }

      public static IObservable<Char> ToUpper(IObservable<System.Char> c)
      {
         return c.Select(System.Char.ToUpper);
      }

      public static IObservable<Char> ToUpperInvariant(IObservable<System.Char> c)
      {
         return c.Select(System.Char.ToUpperInvariant);
      }

      public static IObservable<Char> ToLower(IObservable<System.Char> c, IObservable<System.Globalization.CultureInfo> culture)
      {
         return Observable.Zip(c, culture, System.Char.ToLower);
      }

      public static IObservable<Char> ToLower(IObservable<System.Char> c)
      {
         return c.Select(System.Char.ToLower);
      }

      public static IObservable<Char> ToLowerInvariant(IObservable<System.Char> c)
      {
         return c.Select(System.Char.ToLowerInvariant);
      }

      public static IObservable<TypeCode> GetTypeCode(this IObservable<System.Char> charValue)
      {
          return charValue.Select((charValueLambda) => charValueLambda.GetTypeCode());
      }

      public static IObservable<Boolean> IsControl(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsControl);
      }

      public static IObservable<Boolean> IsControl(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsControl);
      }

      public static IObservable<Boolean> IsDigit(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsDigit);
      }

      public static IObservable<Boolean> IsLetter(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsLetter);
      }

      public static IObservable<Boolean> IsLetterOrDigit(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsLetterOrDigit);
      }

      public static IObservable<Boolean> IsLower(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsLower);
      }

      public static IObservable<Boolean> IsNumber(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsNumber);
      }

      public static IObservable<Boolean> IsNumber(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsNumber);
      }

      public static IObservable<Boolean> IsPunctuation(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsPunctuation);
      }

      public static IObservable<Boolean> IsSeparator(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsSeparator);
      }

      public static IObservable<Boolean> IsSeparator(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsSeparator);
      }

      public static IObservable<Boolean> IsSurrogate(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsSurrogate);
      }

      public static IObservable<Boolean> IsSurrogate(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsSurrogate);
      }

      public static IObservable<Boolean> IsSymbol(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsSymbol);
      }

      public static IObservable<Boolean> IsSymbol(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsSymbol);
      }

      public static IObservable<Boolean> IsUpper(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsUpper);
      }

      public static IObservable<Boolean> IsWhiteSpace(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsWhiteSpace);
      }

      public static IObservable<UnicodeCategory> GetUnicodeCategory(IObservable<System.Char> c)
      {
          return c.Select(System.Char.GetUnicodeCategory);
      }

      public static IObservable<UnicodeCategory> GetUnicodeCategory(IObservable<System.String> s, IObservable<System.Int32> index)
      {
          return Observable.Zip(s, index, System.Char.GetUnicodeCategory);
      }

      public static IObservable<Double> GetNumericValue(IObservable<System.Char> c)
      {
          return c.Select(System.Char.GetNumericValue);
      }

      public static IObservable<Double> GetNumericValue(IObservable<System.String> s, IObservable<System.Int32> index)
      {
          return Observable.Zip(s, index, System.Char.GetNumericValue);
      }

      public static IObservable<Boolean> IsHighSurrogate(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsHighSurrogate);
      }

      public static IObservable<Boolean> IsHighSurrogate(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsHighSurrogate);
      }

      public static IObservable<Boolean> IsLowSurrogate(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsLowSurrogate);
      }

      public static IObservable<Boolean> IsLowSurrogate(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsLowSurrogate);
      }

      public static IObservable<Boolean> IsSurrogatePair(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsSurrogatePair);
      }

      public static IObservable<Boolean> IsSurrogatePair(IObservable<System.Char> highSurrogate, IObservable<System.Char> lowSurrogate)
      {
         return Observable.Zip(highSurrogate, lowSurrogate, System.Char.IsSurrogatePair);
      }

      public static IObservable<string> ConvertFromUtf32(IObservable<System.Int32> utf32)
      {
         return utf32.Select(System.Char.ConvertFromUtf32);
      }

      public static IObservable<int> ConvertToUtf32(IObservable<System.Char> highSurrogate, IObservable<System.Char> lowSurrogate)
      {
         return Observable.Zip(highSurrogate, lowSurrogate, System.Char.ConvertToUtf32);
      }

      public static IObservable<int> ConvertToUtf32(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.ConvertToUtf32);
      }

      public static IObservable<Type> GetType(this IObservable<System.Char> charValue)
      {
          return charValue.Select((charValueLambda) => charValueLambda.GetType());
      }
   }
}
