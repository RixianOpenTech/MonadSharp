using System.Reactive.Linq;
using MS.System;

namespace System
{
   public static class _StringExtensions
   {
       public static _String AsString(this IObservable<System.String> source)
       {
           return source as _String ?? new _String(source);
       }

      public static _String Join(IObservable<System.String> separator, IObservable<System.String[]> value)
      {
         return Observable.Zip(separator, value, System.String.Join).AsString();
      }

      public static _String Join(IObservable<System.String> separator, IObservable<System.Object[]> values)
      {
         return Observable.Zip(separator, values, System.String.Join).AsString();
      }

      //public static _String Join<T>(IObservable<System.String> separator, IObservable<IEnumerable`1> values)
      //{
      //   return Observable.Zip(separator, values, System.String.Join<T>);
      //}

      //public static _String Join(IObservable<System.String> separator, IObservable<System.Collections.Generic.IEnumerable`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]> values)
      //{
      //   return Observable.Zip(separator, values, System.String.Join);
      //}

      public static _String Join(IObservable<System.String> separator, IObservable<System.String[]> value, IObservable<System.Int32> startIndex, IObservable<System.Int32> count)
      {
         return Observable.Zip(separator, value, startIndex, count, System.String.Join).AsString();
      }

      public static _Boolean Equals(this IObservable<System.String> _StringValue, IObservable<System.Object> obj)
      {
         return _StringValue.Zip(obj, (_StringValueLambda, objLambda) => _StringValueLambda.Equals(objLambda)).AsBoolean();
      }

      //public static _Boolean Equals(this IObservable<System.String> _StringValue, IObservable<System.String> value)
      //{
      //   return _StringValue.Zip(value, (_StringValueLambda, valueLambda) => _StringValueLambda.Equals(valueLambda)).AsBoolean();
      //}

      //public static _Boolean Equals(this IObservable<System.String> _StringValue, IObservable<System.String> value, IObservable<System.StringComparison> comparisonType)
      //{
      //   return _StringValue.Zip(value, comparisonType, (_StringValueLambda, valueLambda, comparisonTypeLambda) => _StringValueLambda.Equals(valueLambda, comparisonTypeLambda)).AsBoolean();
      //}

      public static _Boolean Equals(IObservable<System.String> a, IObservable<System.String> b)
      {
         return Observable.Zip(a, b, System.String.Equals).AsBoolean();
      }

      public static _Boolean Equals(IObservable<System.String> a, IObservable<System.String> b, IObservable<System.StringComparison> comparisonType)
      {
         return Observable.Zip(a, b, comparisonType, System.String.Equals).AsBoolean();
      }

      //public static _Void CopyTo(this IObservable<System.String> _StringValue, IObservable<System.Int32> sourceIndex, IObservable<System.Char[]> destination, IObservable<System.Int32> destinationIndex, IObservable<System.Int32> count)
      //{
      //   return _StringValue.ZipExecute(sourceIndex, destination, destinationIndex, count, (_StringValueLambda, sourceIndexLambda, destinationLambda, destinationIndexLambda, countLambda) => _StringValueLambda.CopyTo(sourceIndexLambda, destinationLambda, destinationIndexLambda, countLambda));
      //}

      //public static _Char[] ToCharArray(this IObservable<System.String> _StringValue)
      //{
      //   return _StringValue.Select((_StringValueLambda) => _StringValueLambda.ToCharArray());
      //}

      //public static _Char[] ToCharArray(this IObservable<System.String> _StringValue, IObservable<System.Int32> startIndex, IObservable<System.Int32> length)
      //{
      //   return _StringValue.Zip(startIndex, length, (_StringValueLambda, startIndexLambda, lengthLambda) => _StringValueLambda.ToCharArray(startIndexLambda, lengthLambda));
      //}

      public static _Boolean IsNullOrEmpty(IObservable<System.String> value)
      {
         return value.Select(System.String.IsNullOrEmpty).AsBoolean();
      }

      public static _Boolean IsNullOrWhiteSpace(IObservable<System.String> value)
      {
         return value.Select(System.String.IsNullOrWhiteSpace).AsBoolean();
      }

      public static _Int32 GetHashCode(this IObservable<System.String> _StringValue)
      {
         return _StringValue.Select((_StringValueLambda) => _StringValueLambda.GetHashCode()).AsInt32();
      }

      //public static _String[] Split(this IObservable<System.String> _StringValue, IObservable<System.Char[]> separator)
      //{
      //   return _StringValue.Zip(separator, (_StringValueLambda, separatorLambda) => _StringValueLambda.Split(separatorLambda));
      //}

      //public static _String[] Split(this IObservable<System.String> _StringValue, IObservable<System.Char[]> separator, IObservable<System.Int32> count)
      //{
      //   return _StringValue.Zip(separator, count, (_StringValueLambda, separatorLambda, countLambda) => _StringValueLambda.Split(separatorLambda, countLambda));
      //}

      //public static _String[] Split(this IObservable<System.String> _StringValue, IObservable<System.Char[]> separator, IObservable<System.StringSplitOptions> options)
      //{
      //   return _StringValue.Zip(separator, options, (_StringValueLambda, separatorLambda, optionsLambda) => _StringValueLambda.Split(separatorLambda, optionsLambda));
      //}

      //public static _String[] Split(this IObservable<System.String> _StringValue, IObservable<System.Char[]> separator, IObservable<System.Int32> count, IObservable<System.StringSplitOptions> options)
      //{
      //   return _StringValue.Zip(separator, count, options, (_StringValueLambda, separatorLambda, countLambda, optionsLambda) => _StringValueLambda.Split(separatorLambda, countLambda, optionsLambda));
      //}

      //public static _String[] Split(this IObservable<System.String> _StringValue, IObservable<System.String[]> separator, IObservable<System.StringSplitOptions> options)
      //{
      //   return _StringValue.Zip(separator, options, (_StringValueLambda, separatorLambda, optionsLambda) => _StringValueLambda.Split(separatorLambda, optionsLambda));
      //}

      //public static _String[] Split(this IObservable<System.String> _StringValue, IObservable<System.String[]> separator, IObservable<System.Int32> count, IObservable<System.StringSplitOptions> options)
      //{
      //   return _StringValue.Zip(separator, count, options, (_StringValueLambda, separatorLambda, countLambda, optionsLambda) => _StringValueLambda.Split(separatorLambda, countLambda, optionsLambda));
      //}

      public static _String Substring(this IObservable<System.String> _StringValue, IObservable<System.Int32> startIndex)
      {
         return _StringValue.Zip(startIndex, (_StringValueLambda, startIndexLambda) => _StringValueLambda.Substring(startIndexLambda)).AsString();
      }

      public static _String Substring(this IObservable<System.String> _StringValue, IObservable<System.Int32> startIndex, IObservable<System.Int32> length)
      {
         return _StringValue.Zip(startIndex, length, (_StringValueLambda, startIndexLambda, lengthLambda) => _StringValueLambda.Substring(startIndexLambda, lengthLambda)).AsString();
      }

      public static _String Trim(this IObservable<System.String> _StringValue, IObservable<System.Char[]> trimChars)
      {
         return _StringValue.Zip(trimChars, (_StringValueLambda, trimCharsLambda) => _StringValueLambda.Trim(trimCharsLambda)).AsString();
      }

      public static _String TrimStart(this IObservable<System.String> _StringValue, IObservable<System.Char[]> trimChars)
      {
         return _StringValue.Zip(trimChars, (_StringValueLambda, trimCharsLambda) => _StringValueLambda.TrimStart(trimCharsLambda)).AsString();
      }

      public static _String TrimEnd(this IObservable<System.String> _StringValue, IObservable<System.Char[]> trimChars)
      {
         return _StringValue.Zip(trimChars, (_StringValueLambda, trimCharsLambda) => _StringValueLambda.TrimEnd(trimCharsLambda)).AsString();
      }

      public static _Boolean IsNormalized(this IObservable<System.String> _StringValue)
      {
         return _StringValue.Select((_StringValueLambda) => _StringValueLambda.IsNormalized()).AsBoolean();
      }

      public static _Boolean IsNormalized(this IObservable<System.String> _StringValue, IObservable<System.Text.NormalizationForm> normalizationForm)
      {
         return _StringValue.Zip(normalizationForm, (_StringValueLambda, normalizationFormLambda) => _StringValueLambda.IsNormalized(normalizationFormLambda)).AsBoolean();
      }

      public static _String Normalize(this IObservable<System.String> _StringValue)
      {
         return _StringValue.Select((_StringValueLambda) => _StringValueLambda.Normalize()).AsString();
      }

      public static _String Normalize(this IObservable<System.String> _StringValue, IObservable<System.Text.NormalizationForm> normalizationForm)
      {
         return _StringValue.Zip(normalizationForm, (_StringValueLambda, normalizationFormLambda) => _StringValueLambda.Normalize(normalizationFormLambda)).AsString();
      }

      public static _Int32 Compare(IObservable<System.String> strA, IObservable<System.String> strB)
      {
         return Observable.Zip(strA, strB, System.String.Compare).AsInt32();
      }

      public static _Int32 Compare(IObservable<System.String> strA, IObservable<System.String> strB, IObservable<System.Boolean> ignoreCase)
      {
         return Observable.Zip(strA, strB, ignoreCase, System.String.Compare).AsInt32();
      }

      public static _Int32 Compare(IObservable<System.String> strA, IObservable<System.String> strB, IObservable<System.StringComparison> comparisonType)
      {
         return Observable.Zip(strA, strB, comparisonType, System.String.Compare).AsInt32();
      }

      public static _Int32 Compare(IObservable<System.String> strA, IObservable<System.String> strB, IObservable<System.Globalization.CultureInfo> culture, IObservable<System.Globalization.CompareOptions> options)
      {
         return Observable.Zip(strA, strB, culture, options, System.String.Compare).AsInt32();
      }

      public static _Int32 Compare(IObservable<System.String> strA, IObservable<System.String> strB, IObservable<System.Boolean> ignoreCase, IObservable<System.Globalization.CultureInfo> culture)
      {
         return Observable.Zip(strA, strB, ignoreCase, culture, System.String.Compare).AsInt32();
      }

      public static _Int32 Compare(IObservable<System.String> strA, IObservable<System.Int32> indexA, IObservable<System.String> strB, IObservable<System.Int32> indexB, IObservable<System.Int32> length)
      {
         return Observable.Zip(strA, indexA, strB, indexB, length, System.String.Compare).AsInt32();
      }

      public static _Int32 Compare(IObservable<System.String> strA, IObservable<System.Int32> indexA, IObservable<System.String> strB, IObservable<System.Int32> indexB, IObservable<System.Int32> length, IObservable<System.Boolean> ignoreCase)
      {
         return Observable.Zip(strA, indexA, strB, indexB, length, ignoreCase, System.String.Compare).AsInt32();
      }

      public static _Int32 Compare(IObservable<System.String> strA, IObservable<System.Int32> indexA, IObservable<System.String> strB, IObservable<System.Int32> indexB, IObservable<System.Int32> length, IObservable<System.Boolean> ignoreCase, IObservable<System.Globalization.CultureInfo> culture)
      {
         return Observable.Zip(strA, indexA, strB, indexB, length, ignoreCase, culture, System.String.Compare).AsInt32();
      }

      public static _Int32 Compare(IObservable<System.String> strA, IObservable<System.Int32> indexA, IObservable<System.String> strB, IObservable<System.Int32> indexB, IObservable<System.Int32> length, IObservable<System.Globalization.CultureInfo> culture, IObservable<System.Globalization.CompareOptions> options)
      {
         return Observable.Zip(strA, indexA, strB, indexB, length, culture, options, System.String.Compare).AsInt32();
      }

      public static _Int32 Compare(IObservable<System.String> strA, IObservable<System.Int32> indexA, IObservable<System.String> strB, IObservable<System.Int32> indexB, IObservable<System.Int32> length, IObservable<System.StringComparison> comparisonType)
      {
         return Observable.Zip(strA, indexA, strB, indexB, length, comparisonType, System.String.Compare).AsInt32();
      }

      public static _Int32 CompareTo(this IObservable<System.String> _StringValue, IObservable<System.Object> value)
      {
         return _StringValue.Zip(value, (_StringValueLambda, valueLambda) => _StringValueLambda.CompareTo(valueLambda)).AsInt32();
      }

      public static _Int32 CompareTo(this IObservable<System.String> _StringValue, IObservable<System.String> strB)
      {
         return _StringValue.Zip(strB, (_StringValueLambda, strBLambda) => _StringValueLambda.CompareTo(strBLambda)).AsInt32();
      }

      public static _Int32 CompareOrdinal(IObservable<System.String> strA, IObservable<System.String> strB)
      {
         return Observable.Zip(strA, strB, System.String.CompareOrdinal).AsInt32();
      }

      public static _Int32 CompareOrdinal(IObservable<System.String> strA, IObservable<System.Int32> indexA, IObservable<System.String> strB, IObservable<System.Int32> indexB, IObservable<System.Int32> length)
      {
         return Observable.Zip(strA, indexA, strB, indexB, length, System.String.CompareOrdinal).AsInt32();
      }

      public static _Boolean Contains(this IObservable<System.String> _StringValue, IObservable<System.String> value)
      {
         return _StringValue.Zip(value, (_StringValueLambda, valueLambda) => _StringValueLambda.Contains(valueLambda)).AsBoolean();
      }

      public static _Boolean EndsWith(this IObservable<System.String> _StringValue, IObservable<System.String> value)
      {
         return _StringValue.Zip(value, (_StringValueLambda, valueLambda) => _StringValueLambda.EndsWith(valueLambda)).AsBoolean();
      }

      public static _Boolean EndsWith(this IObservable<System.String> _StringValue, IObservable<System.String> value, IObservable<System.StringComparison> comparisonType)
      {
         return _StringValue.Zip(value, comparisonType, (_StringValueLambda, valueLambda, comparisonTypeLambda) => _StringValueLambda.EndsWith(valueLambda, comparisonTypeLambda)).AsBoolean();
      }

      public static _Boolean EndsWith(this IObservable<System.String> _StringValue, IObservable<System.String> value, IObservable<System.Boolean> ignoreCase, IObservable<System.Globalization.CultureInfo> culture)
      {
         return _StringValue.Zip(value, ignoreCase, culture, (_StringValueLambda, valueLambda, ignoreCaseLambda, cultureLambda) => _StringValueLambda.EndsWith(valueLambda, ignoreCaseLambda, cultureLambda)).AsBoolean();
      }

      public static _Int32 IndexOf(this IObservable<System.String> _StringValue, IObservable<System.Char> value)
      {
         return _StringValue.Zip(value, (_StringValueLambda, valueLambda) => _StringValueLambda.IndexOf(valueLambda)).AsInt32();
      }

      public static _Int32 IndexOf(this IObservable<System.String> _StringValue, IObservable<System.Char> value, IObservable<System.Int32> startIndex)
      {
         return _StringValue.Zip(value, startIndex, (_StringValueLambda, valueLambda, startIndexLambda) => _StringValueLambda.IndexOf(valueLambda, startIndexLambda)).AsInt32();
      }

      public static _Int32 IndexOf(this IObservable<System.String> _StringValue, IObservable<System.Char> value, IObservable<System.Int32> startIndex, IObservable<System.Int32> count)
      {
         return _StringValue.Zip(value, startIndex, count, (_StringValueLambda, valueLambda, startIndexLambda, countLambda) => _StringValueLambda.IndexOf(valueLambda, startIndexLambda, countLambda)).AsInt32();
      }

      public static _Int32 IndexOfAny(this IObservable<System.String> _StringValue, IObservable<System.Char[]> anyOf)
      {
         return _StringValue.Zip(anyOf, (_StringValueLambda, anyOfLambda) => _StringValueLambda.IndexOfAny(anyOfLambda)).AsInt32();
      }

      public static _Int32 IndexOfAny(this IObservable<System.String> _StringValue, IObservable<System.Char[]> anyOf, IObservable<System.Int32> startIndex)
      {
         return _StringValue.Zip(anyOf, startIndex, (_StringValueLambda, anyOfLambda, startIndexLambda) => _StringValueLambda.IndexOfAny(anyOfLambda, startIndexLambda)).AsInt32();
      }

      public static _Int32 IndexOfAny(this IObservable<System.String> _StringValue, IObservable<System.Char[]> anyOf, IObservable<System.Int32> startIndex, IObservable<System.Int32> count)
      {
         return _StringValue.Zip(anyOf, startIndex, count, (_StringValueLambda, anyOfLambda, startIndexLambda, countLambda) => _StringValueLambda.IndexOfAny(anyOfLambda, startIndexLambda, countLambda)).AsInt32();
      }

      public static _Int32 IndexOf(this IObservable<System.String> _StringValue, IObservable<System.String> value)
      {
         return _StringValue.Zip(value, (_StringValueLambda, valueLambda) => _StringValueLambda.IndexOf(valueLambda)).AsInt32();
      }

      public static _Int32 IndexOf(this IObservable<System.String> _StringValue, IObservable<System.String> value, IObservable<System.Int32> startIndex)
      {
         return _StringValue.Zip(value, startIndex, (_StringValueLambda, valueLambda, startIndexLambda) => _StringValueLambda.IndexOf(valueLambda, startIndexLambda)).AsInt32();
      }

      public static _Int32 IndexOf(this IObservable<System.String> _StringValue, IObservable<System.String> value, IObservable<System.Int32> startIndex, IObservable<System.Int32> count)
      {
         return _StringValue.Zip(value, startIndex, count, (_StringValueLambda, valueLambda, startIndexLambda, countLambda) => _StringValueLambda.IndexOf(valueLambda, startIndexLambda, countLambda)).AsInt32();
      }

      public static _Int32 IndexOf(this IObservable<System.String> _StringValue, IObservable<System.String> value, IObservable<System.StringComparison> comparisonType)
      {
         return _StringValue.Zip(value, comparisonType, (_StringValueLambda, valueLambda, comparisonTypeLambda) => _StringValueLambda.IndexOf(valueLambda, comparisonTypeLambda)).AsInt32();
      }

      public static _Int32 IndexOf(this IObservable<System.String> _StringValue, IObservable<System.String> value, IObservable<System.Int32> startIndex, IObservable<System.StringComparison> comparisonType)
      {
         return _StringValue.Zip(value, startIndex, comparisonType, (_StringValueLambda, valueLambda, startIndexLambda, comparisonTypeLambda) => _StringValueLambda.IndexOf(valueLambda, startIndexLambda, comparisonTypeLambda)).AsInt32();
      }

      public static _Int32 IndexOf(this IObservable<System.String> _StringValue, IObservable<System.String> value, IObservable<System.Int32> startIndex, IObservable<System.Int32> count, IObservable<System.StringComparison> comparisonType)
      {
         return _StringValue.Zip(value, startIndex, count, comparisonType, (_StringValueLambda, valueLambda, startIndexLambda, countLambda, comparisonTypeLambda) => _StringValueLambda.IndexOf(valueLambda, startIndexLambda, countLambda, comparisonTypeLambda)).AsInt32();
      }

      public static _Int32 LastIndexOf(this IObservable<System.String> _StringValue, IObservable<System.Char> value)
      {
         return _StringValue.Zip(value, (_StringValueLambda, valueLambda) => _StringValueLambda.LastIndexOf(valueLambda)).AsInt32();
      }

      public static _Int32 LastIndexOf(this IObservable<System.String> _StringValue, IObservable<System.Char> value, IObservable<System.Int32> startIndex)
      {
         return _StringValue.Zip(value, startIndex, (_StringValueLambda, valueLambda, startIndexLambda) => _StringValueLambda.LastIndexOf(valueLambda, startIndexLambda)).AsInt32();
      }

      public static _Int32 LastIndexOf(this IObservable<System.String> _StringValue, IObservable<System.Char> value, IObservable<System.Int32> startIndex, IObservable<System.Int32> count)
      {
         return _StringValue.Zip(value, startIndex, count, (_StringValueLambda, valueLambda, startIndexLambda, countLambda) => _StringValueLambda.LastIndexOf(valueLambda, startIndexLambda, countLambda)).AsInt32();
      }

      public static _Int32 LastIndexOfAny(this IObservable<System.String> _StringValue, IObservable<System.Char[]> anyOf)
      {
         return _StringValue.Zip(anyOf, (_StringValueLambda, anyOfLambda) => _StringValueLambda.LastIndexOfAny(anyOfLambda)).AsInt32();
      }

      public static _Int32 LastIndexOfAny(this IObservable<System.String> _StringValue, IObservable<System.Char[]> anyOf, IObservable<System.Int32> startIndex)
      {
         return _StringValue.Zip(anyOf, startIndex, (_StringValueLambda, anyOfLambda, startIndexLambda) => _StringValueLambda.LastIndexOfAny(anyOfLambda, startIndexLambda)).AsInt32();
      }

      public static _Int32 LastIndexOfAny(this IObservable<System.String> _StringValue, IObservable<System.Char[]> anyOf, IObservable<System.Int32> startIndex, IObservable<System.Int32> count)
      {
         return _StringValue.Zip(anyOf, startIndex, count, (_StringValueLambda, anyOfLambda, startIndexLambda, countLambda) => _StringValueLambda.LastIndexOfAny(anyOfLambda, startIndexLambda, countLambda)).AsInt32();
      }

      public static _Int32 LastIndexOf(this IObservable<System.String> _StringValue, IObservable<System.String> value)
      {
         return _StringValue.Zip(value, (_StringValueLambda, valueLambda) => _StringValueLambda.LastIndexOf(valueLambda)).AsInt32();
      }

      public static _Int32 LastIndexOf(this IObservable<System.String> _StringValue, IObservable<System.String> value, IObservable<System.Int32> startIndex)
      {
         return _StringValue.Zip(value, startIndex, (_StringValueLambda, valueLambda, startIndexLambda) => _StringValueLambda.LastIndexOf(valueLambda, startIndexLambda)).AsInt32();
      }

      public static _Int32 LastIndexOf(this IObservable<System.String> _StringValue, IObservable<System.String> value, IObservable<System.Int32> startIndex, IObservable<System.Int32> count)
      {
         return _StringValue.Zip(value, startIndex, count, (_StringValueLambda, valueLambda, startIndexLambda, countLambda) => _StringValueLambda.LastIndexOf(valueLambda, startIndexLambda, countLambda)).AsInt32();
      }

      public static _Int32 LastIndexOf(this IObservable<System.String> _StringValue, IObservable<System.String> value, IObservable<System.StringComparison> comparisonType)
      {
         return _StringValue.Zip(value, comparisonType, (_StringValueLambda, valueLambda, comparisonTypeLambda) => _StringValueLambda.LastIndexOf(valueLambda, comparisonTypeLambda)).AsInt32();
      }

      public static _Int32 LastIndexOf(this IObservable<System.String> _StringValue, IObservable<System.String> value, IObservable<System.Int32> startIndex, IObservable<System.StringComparison> comparisonType)
      {
         return _StringValue.Zip(value, startIndex, comparisonType, (_StringValueLambda, valueLambda, startIndexLambda, comparisonTypeLambda) => _StringValueLambda.LastIndexOf(valueLambda, startIndexLambda, comparisonTypeLambda)).AsInt32();
      }

      public static _Int32 LastIndexOf(this IObservable<System.String> _StringValue, IObservable<System.String> value, IObservable<System.Int32> startIndex, IObservable<System.Int32> count, IObservable<System.StringComparison> comparisonType)
      {
         return _StringValue.Zip(value, startIndex, count, comparisonType, (_StringValueLambda, valueLambda, startIndexLambda, countLambda, comparisonTypeLambda) => _StringValueLambda.LastIndexOf(valueLambda, startIndexLambda, countLambda, comparisonTypeLambda)).AsInt32();
      }

      public static _String PadLeft(this IObservable<System.String> _StringValue, IObservable<System.Int32> totalWidth)
      {
         return _StringValue.Zip(totalWidth, (_StringValueLambda, totalWidthLambda) => _StringValueLambda.PadLeft(totalWidthLambda)).AsString();
      }

      public static _String PadLeft(this IObservable<System.String> _StringValue, IObservable<System.Int32> totalWidth, IObservable<System.Char> paddingChar)
      {
         return _StringValue.Zip(totalWidth, paddingChar, (_StringValueLambda, totalWidthLambda, paddingCharLambda) => _StringValueLambda.PadLeft(totalWidthLambda, paddingCharLambda)).AsString();
      }

      public static _String PadRight(this IObservable<System.String> _StringValue, IObservable<System.Int32> totalWidth)
      {
         return _StringValue.Zip(totalWidth, (_StringValueLambda, totalWidthLambda) => _StringValueLambda.PadRight(totalWidthLambda)).AsString();
      }

      public static _String PadRight(this IObservable<System.String> _StringValue, IObservable<System.Int32> totalWidth, IObservable<System.Char> paddingChar)
      {
         return _StringValue.Zip(totalWidth, paddingChar, (_StringValueLambda, totalWidthLambda, paddingCharLambda) => _StringValueLambda.PadRight(totalWidthLambda, paddingCharLambda)).AsString();
      }

      public static _Boolean StartsWith(this IObservable<System.String> _StringValue, IObservable<System.String> value)
      {
         return _StringValue.Zip(value, (_StringValueLambda, valueLambda) => _StringValueLambda.StartsWith(valueLambda)).AsBoolean();
      }

      public static _Boolean StartsWith(this IObservable<System.String> _StringValue, IObservable<System.String> value, IObservable<System.StringComparison> comparisonType)
      {
         return _StringValue.Zip(value, comparisonType, (_StringValueLambda, valueLambda, comparisonTypeLambda) => _StringValueLambda.StartsWith(valueLambda, comparisonTypeLambda)).AsBoolean();
      }

      public static _Boolean StartsWith(this IObservable<System.String> _StringValue, IObservable<System.String> value, IObservable<System.Boolean> ignoreCase, IObservable<System.Globalization.CultureInfo> culture)
      {
         return _StringValue.Zip(value, ignoreCase, culture, (_StringValueLambda, valueLambda, ignoreCaseLambda, cultureLambda) => _StringValueLambda.StartsWith(valueLambda, ignoreCaseLambda, cultureLambda)).AsBoolean();
      }

      public static _String ToLower(this IObservable<System.String> _StringValue)
      {
         return _StringValue.Select((_StringValueLambda) => _StringValueLambda.ToLower()).AsString();
      }

      public static _String ToLower(this IObservable<System.String> _StringValue, IObservable<System.Globalization.CultureInfo> culture)
      {
         return _StringValue.Zip(culture, (_StringValueLambda, cultureLambda) => _StringValueLambda.ToLower(cultureLambda)).AsString();
      }

      public static _String ToLowerInvariant(this IObservable<System.String> _StringValue)
      {
         return _StringValue.Select((_StringValueLambda) => _StringValueLambda.ToLowerInvariant()).AsString();
      }

      public static _String ToUpper(this IObservable<System.String> _StringValue)
      {
         return _StringValue.Select((_StringValueLambda) => _StringValueLambda.ToUpper()).AsString();
      }

      public static _String ToUpper(this IObservable<System.String> _StringValue, IObservable<System.Globalization.CultureInfo> culture)
      {
         return _StringValue.Zip(culture, (_StringValueLambda, cultureLambda) => _StringValueLambda.ToUpper(cultureLambda)).AsString();
      }

      public static _String ToUpperInvariant(this IObservable<System.String> _StringValue)
      {
         return _StringValue.Select((_StringValueLambda) => _StringValueLambda.ToUpperInvariant()).AsString();
      }

      public static _String ToString(this IObservable<System.String> _StringValue)
      {
         return _StringValue.Select((_StringValueLambda) => _StringValueLambda.ToString()).AsString();
      }

      public static _String ToString(this IObservable<System.String> _StringValue, IObservable<System.IFormatProvider> provider)
      {
         return _StringValue.Zip(provider, (_StringValueLambda, providerLambda) => _StringValueLambda.ToString(providerLambda)).AsString();
      }

      public static _Object Clone(this IObservable<System.String> _StringValue)
      {
         return new _Object(_StringValue.Select((_StringValueLambda) => _StringValueLambda.Clone()));
      }

      public static _String Trim(this IObservable<System.String> _StringValue)
      {
         return _StringValue.Select((_StringValueLambda) => _StringValueLambda.Trim()).AsString();
      }

      public static _String Insert(this IObservable<System.String> _StringValue, IObservable<System.Int32> startIndex, IObservable<System.String> value)
      {
         return _StringValue.Zip(startIndex, value, (_StringValueLambda, startIndexLambda, valueLambda) => _StringValueLambda.Insert(startIndexLambda, valueLambda)).AsString();
      }

      public static _String Replace(this IObservable<System.String> _StringValue, IObservable<System.Char> oldChar, IObservable<System.Char> newChar)
      {
         return _StringValue.Zip(oldChar, newChar, (_StringValueLambda, oldCharLambda, newCharLambda) => _StringValueLambda.Replace(oldCharLambda, newCharLambda)).AsString();
      }

      public static _String Replace(this IObservable<System.String> _StringValue, IObservable<System.String> oldValue, IObservable<System.String> newValue)
      {
         return _StringValue.Zip(oldValue, newValue, (_StringValueLambda, oldValueLambda, newValueLambda) => _StringValueLambda.Replace(oldValueLambda, newValueLambda)).AsString();
      }

      public static _String Remove(this IObservable<System.String> _StringValue, IObservable<System.Int32> startIndex, IObservable<System.Int32> count)
      {
         return _StringValue.Zip(startIndex, count, (_StringValueLambda, startIndexLambda, countLambda) => _StringValueLambda.Remove(startIndexLambda, countLambda)).AsString();
      }

      public static _String Remove(this IObservable<System.String> _StringValue, IObservable<System.Int32> startIndex)
      {
         return _StringValue.Zip(startIndex, (_StringValueLambda, startIndexLambda) => _StringValueLambda.Remove(startIndexLambda)).AsString();
      }

      public static _String Format(IObservable<System.String> format, IObservable<System.Object> arg0)
      {
         return Observable.Zip(format, arg0, System.String.Format).AsString();
      }

      public static _String Format(IObservable<System.String> format, IObservable<System.Object> arg0, IObservable<System.Object> arg1)
      {
         return Observable.Zip(format, arg0, arg1, System.String.Format).AsString();
      }

      public static _String Format(IObservable<System.String> format, IObservable<System.Object> arg0, IObservable<System.Object> arg1, IObservable<System.Object> arg2)
      {
         return Observable.Zip(format, arg0, arg1, arg2, System.String.Format).AsString();
      }

      public static _String Format(IObservable<System.String> format, IObservable<System.Object[]> args)
      {
         return Observable.Zip(format, args, System.String.Format).AsString();
      }

      public static _String Format(IObservable<System.IFormatProvider> provider, IObservable<System.String> format, IObservable<System.Object[]> args)
      {
         return Observable.Zip(provider, format, args, System.String.Format).AsString();
      }

      public static _String Copy(IObservable<System.String> str)
      {
         return str.Select(System.String.Copy).AsString();
      }

      public static _String Concat(IObservable<System.Object> arg0)
      {
         return arg0.Select(a => System.String.Concat(a)).AsString();
      }

      public static _String Concat(IObservable<System.Object> arg0, IObservable<System.Object> arg1)
      {
         return Observable.Zip(arg0, arg1, System.String.Concat).AsString();
      }

      public static _String Concat(IObservable<System.Object> arg0, IObservable<System.Object> arg1, IObservable<System.Object> arg2)
      {
         return Observable.Zip(arg0, arg1, arg2, System.String.Concat).AsString();
      }

      public static _String Concat(IObservable<System.Object> arg0, IObservable<System.Object> arg1, IObservable<System.Object> arg2, IObservable<System.Object> arg3)
      {
         return Observable.Zip(arg0, arg1, arg2, arg3, (a0, a1, a2, a3) => System.String.Concat(a0, a1, a2, a3)).AsString();
      }

      public static _String Concat(IObservable<System.Object[]> args)
      {
         return args.Select(a => System.String.Concat(a)).AsString();
      }

      //public static _String Concat<T>(IObservable<IEnumerable`1> values)
      //{
      //   return values.Select(System.String.Concat<T>);
      //}

      //public static _String Concat(IObservable<System.Collections.Generic.IEnumerable`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]> values)
      //{
      //   return values.Select(System.String.Concat);
      //}

      public static _String Concat(IObservable<System.String> str0, IObservable<System.String> str1)
      {
          return Observable.Zip(str0, str1, System.String.Concat).AsString();
      }

      public static _String Concat(IObservable<System.String> str0, IObservable<System.String> str1, IObservable<System.String> str2)
      {
          return Observable.Zip(str0, str1, str2, System.String.Concat).AsString();
      }

      public static _String Concat(IObservable<System.String> str0, IObservable<System.String> str1, IObservable<System.String> str2, IObservable<System.String> str3)
      {
          return Observable.Zip(str0, str1, str2, str3, System.String.Concat).AsString();
      }

      public static _String Concat(IObservable<System.String[]> values)
      {
          return values.Select(v => System.String.Concat(v)).AsString();
      }

      public static _String Intern(IObservable<System.String> str)
      {
          return str.Select(System.String.Intern).AsString();
      }

      public static _String IsInterned(IObservable<System.String> str)
      {
          return str.Select(System.String.IsInterned).AsString();
      }

      public static IObservable<TypeCode> GetTypeCode(this IObservable<System.String> _StringValue)
      {
          return _StringValue.Select((_StringValueLambda) => _StringValueLambda.GetTypeCode());
      }

      public static IObservable<CharEnumerator> GetEnumerator(this IObservable<System.String> _StringValue)
      {
          return _StringValue.Select((_StringValueLambda) => _StringValueLambda.GetEnumerator());
      }

      public static IObservable<Type> GetType(this IObservable<System.String> _StringValue)
      {
          return _StringValue.Select((_StringValueLambda) => _StringValueLambda.GetType());
      }

   }
}
