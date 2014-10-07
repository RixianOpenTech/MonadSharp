using System.Globalization;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using MS.System;

namespace System
{
   public static class _CharExtensions
   {
       public static _Char AsChar(this IObservable<System.Char> source)
       {
           return source as _Char ?? new _Char(source);
       }

      public static _Int32 GetHashCode(this IObservable<System.Char> _CharValue)
      {
         return _CharValue.Select((_CharValueLambda) => _CharValueLambda.GetHashCode()).AsInt32();
      }

      public static _Boolean Equals(this IObservable<System.Char> _CharValue, IObservable<System.Object> obj)
      {
         return _CharValue.Zip(obj, (_CharValueLambda, objLambda) => _CharValueLambda.Equals(objLambda)).AsBoolean();
      }

      public static _Boolean Equals(this IObservable<System.Char> _CharValue, IObservable<System.Char> obj)
      {
         return _CharValue.Zip(obj, (_CharValueLambda, objLambda) => _CharValueLambda.Equals(objLambda)).AsBoolean();
      }

      public static _Int32 CompareTo(this IObservable<System.Char> _CharValue, IObservable<System.Object> value)
      {
         return _CharValue.Zip(value, (_CharValueLambda, valueLambda) => _CharValueLambda.CompareTo(valueLambda)).AsInt32();
      }

      public static _Int32 CompareTo(this IObservable<System.Char> _CharValue, IObservable<System.Char> value)
      {
         return _CharValue.Zip(value, (_CharValueLambda, valueLambda) => _CharValueLambda.CompareTo(valueLambda)).AsInt32();
      }

      public static _String ToString(this IObservable<System.Char> _CharValue, IObservable<System.IFormatProvider> provider)
      {
         return _CharValue.Zip(provider, (_CharValueLambda, providerLambda) => _CharValueLambda.ToString(providerLambda)).AsString();
      }

      public static _String ToString(IObservable<System.Char> c)
      {
         return c.Select(System.Char.ToString).AsString();
      }

      public static _Char Parse(IObservable<System.String> s)
      {
         return s.Select(System.Char.Parse).AsChar();
      }

       public static _Boolean TryParse(IObservable<System.String> s, out _Char result)
       {
           var gate = new object();
           var resultSubject = new ReplaySubject<System.Char>(1);
           result = resultSubject.AsChar();
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
                   .AsBoolean();
       }

       public static _Boolean IsDigit(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsDigit).AsBoolean();
      }

      public static _Boolean IsLetter(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsLetter).AsBoolean();
      }

      public static _Boolean IsWhiteSpace(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsWhiteSpace).AsBoolean();
      }

      public static _Boolean IsUpper(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsUpper).AsBoolean();
      }

      public static _Boolean IsLower(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsLower).AsBoolean();
      }

      public static _Boolean IsPunctuation(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsPunctuation).AsBoolean();
      }

      public static _Boolean IsLetterOrDigit(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsLetterOrDigit).AsBoolean();
      }

      public static _Char ToUpper(IObservable<System.Char> c, IObservable<System.Globalization.CultureInfo> culture)
      {
         return Observable.Zip(c, culture, System.Char.ToUpper).AsChar();
      }

      public static _Char ToUpper(IObservable<System.Char> c)
      {
         return c.Select(System.Char.ToUpper).AsChar();
      }

      public static _Char ToUpperInvariant(IObservable<System.Char> c)
      {
         return c.Select(System.Char.ToUpperInvariant).AsChar();
      }

      public static _Char ToLower(IObservable<System.Char> c, IObservable<System.Globalization.CultureInfo> culture)
      {
         return Observable.Zip(c, culture, System.Char.ToLower).AsChar();
      }

      public static _Char ToLower(IObservable<System.Char> c)
      {
         return c.Select(System.Char.ToLower).AsChar();
      }

      public static _Char ToLowerInvariant(IObservable<System.Char> c)
      {
         return c.Select(System.Char.ToLowerInvariant).AsChar();
      }

      public static IObservable<TypeCode> GetTypeCode(this IObservable<System.Char> _CharValue)
      {
          return _CharValue.Select((_CharValueLambda) => _CharValueLambda.GetTypeCode());
      }

      public static _Boolean IsControl(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsControl).AsBoolean();
      }

      public static _Boolean IsControl(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsControl).AsBoolean();
      }

      public static _Boolean IsDigit(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsDigit).AsBoolean();
      }

      public static _Boolean IsLetter(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsLetter).AsBoolean();
      }

      public static _Boolean IsLetterOrDigit(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsLetterOrDigit).AsBoolean();
      }

      public static _Boolean IsLower(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsLower).AsBoolean();
      }

      public static _Boolean IsNumber(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsNumber).AsBoolean();
      }

      public static _Boolean IsNumber(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsNumber).AsBoolean();
      }

      public static _Boolean IsPunctuation(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsPunctuation).AsBoolean();
      }

      public static _Boolean IsSeparator(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsSeparator).AsBoolean();
      }

      public static _Boolean IsSeparator(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsSeparator).AsBoolean();
      }

      public static _Boolean IsSurrogate(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsSurrogate).AsBoolean();
      }

      public static _Boolean IsSurrogate(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsSurrogate).AsBoolean();
      }

      public static _Boolean IsSymbol(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsSymbol).AsBoolean();
      }

      public static _Boolean IsSymbol(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsSymbol).AsBoolean();
      }

      public static _Boolean IsUpper(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsUpper).AsBoolean();
      }

      public static _Boolean IsWhiteSpace(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsWhiteSpace).AsBoolean();
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

      public static _Boolean IsHighSurrogate(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsHighSurrogate).AsBoolean();
      }

      public static _Boolean IsHighSurrogate(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsHighSurrogate).AsBoolean();
      }

      public static _Boolean IsLowSurrogate(IObservable<System.Char> c)
      {
         return c.Select(System.Char.IsLowSurrogate).AsBoolean();
      }

      public static _Boolean IsLowSurrogate(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsLowSurrogate).AsBoolean();
      }

      public static _Boolean IsSurrogatePair(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.IsSurrogatePair).AsBoolean();
      }

      public static _Boolean IsSurrogatePair(IObservable<System.Char> highSurrogate, IObservable<System.Char> lowSurrogate)
      {
         return Observable.Zip(highSurrogate, lowSurrogate, System.Char.IsSurrogatePair).AsBoolean();
      }

      public static _String ConvertFromUtf32(IObservable<System.Int32> utf32)
      {
         return utf32.Select(System.Char.ConvertFromUtf32).AsString();
      }

      public static _Int32 ConvertToUtf32(IObservable<System.Char> highSurrogate, IObservable<System.Char> lowSurrogate)
      {
         return Observable.Zip(highSurrogate, lowSurrogate, System.Char.ConvertToUtf32).AsInt32();
      }

      public static _Int32 ConvertToUtf32(IObservable<System.String> s, IObservable<System.Int32> index)
      {
         return Observable.Zip(s, index, System.Char.ConvertToUtf32).AsInt32();
      }

      public static IObservable<Type> GetType(this IObservable<System.Char> _CharValue)
      {
          return _CharValue.Select((_CharValueLambda) => _CharValueLambda.GetType());
      }
   }
}
