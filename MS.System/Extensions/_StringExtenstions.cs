using System;
using System.Reactive.Linq;
using MsSystem;

namespace MsSystem
{
   public static class StringExtensions
   {
      public static IObservable<string> Join(IObservable<System.String> separator, IObservable<System.String[]> value)
      {
         return Observable.Zip(separator, value, System.String.Join);
      }

      public static IObservable<string> Join(IObservable<System.String> separator, IObservable<System.Object[]> values)
      {
         return Observable.Zip(separator, values, System.String.Join);
      }

      //public static IObservable<string> Join<T>(IObservable<System.String> separator, IObservable<IEnumerable`1> values)
      //{
      //   return Observable.Zip(separator, values, System.String.Join<T>);
      //}

      //public static IObservable<string> Join(IObservable<System.String> separator, IObservable<System.Collections.Generic.IEnumerable`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]> values)
      //{
      //   return Observable.Zip(separator, values, System.String.Join);
      //}

      public static IObservable<string> Join(IObservable<System.String> separator, IObservable<System.String[]> value, IObservable<System.Int32> startIndex, IObservable<System.Int32> count)
      {
         return Observable.Zip(separator, value, startIndex, count, System.String.Join);
      }

      public static IObservable<Boolean> Equals(this IObservable<System.String> stringValue, IObservable<System.Object> obj)
      {
         return stringValue.Zip(obj, (stringValueLambda, objLambda) => stringValueLambda.Equals(objLambda));
      }

      //public static IObservable<Boolean> Equals(this IObservable<System.String> stringValue, IObservable<System.String> value)
      //{
      //   return stringValue.Zip(value, (stringValueLambda, valueLambda) => stringValueLambda.Equals(valueLambda));
      //}

      //public static IObservable<Boolean> Equals(this IObservable<System.String> stringValue, IObservable<System.String> value, IObservable<System.StringComparison> comparisonType)
      //{
      //   return stringValue.Zip(value, comparisonType, (stringValueLambda, valueLambda, comparisonTypeLambda) => stringValueLambda.Equals(valueLambda, comparisonTypeLambda));
      //}

      public static IObservable<Boolean> Equals(IObservable<System.String> a, IObservable<System.String> b)
      {
         return Observable.Zip(a, b, System.String.Equals);
      }

      public static IObservable<Boolean> Equals(IObservable<System.String> a, IObservable<System.String> b, IObservable<System.StringComparison> comparisonType)
      {
         return Observable.Zip(a, b, comparisonType, System.String.Equals);
      }

      //public static IObservable<Unit> CopyTo(this IObservable<System.String> stringValue, IObservable<System.Int32> sourceIndex, IObservable<System.Char[]> destination, IObservable<System.Int32> destinationIndex, IObservable<System.Int32> count)
      //{
      //   return stringValue.ZipExecute(sourceIndex, destination, destinationIndex, count, (stringValueLambda, sourceIndexLambda, destinationLambda, destinationIndexLambda, countLambda) => stringValueLambda.CopyTo(sourceIndexLambda, destinationLambda, destinationIndexLambda, countLambda));
      //}

      //public static IObservable<Char>[] ToCharArray(this IObservable<System.String> stringValue)
      //{
      //   return stringValue.Select((stringValueLambda) => stringValueLambda.ToCharArray());
      //}

      //public static IObservable<Char>[] ToCharArray(this IObservable<System.String> stringValue, IObservable<System.Int32> startIndex, IObservable<System.Int32> length)
      //{
      //   return stringValue.Zip(startIndex, length, (stringValueLambda, startIndexLambda, lengthLambda) => stringValueLambda.ToCharArray(startIndexLambda, lengthLambda));
      //}

      public static IObservable<Boolean> IsNullOrEmpty(IObservable<System.String> value)
      {
         return value.Select(System.String.IsNullOrEmpty);
      }

      public static IObservable<Boolean> IsNullOrWhiteSpace(IObservable<System.String> value)
      {
         return value.Select(System.String.IsNullOrWhiteSpace);
      }

      public static IObservable<int> GetHashCode(this IObservable<System.String> stringValue)
      {
         return stringValue.Select((stringValueLambda) => stringValueLambda.GetHashCode());
      }

      //public static IObservable<string>[] Split(this IObservable<System.String> stringValue, IObservable<System.Char[]> separator)
      //{
      //   return stringValue.Zip(separator, (stringValueLambda, separatorLambda) => stringValueLambda.Split(separatorLambda));
      //}

      //public static IObservable<string>[] Split(this IObservable<System.String> stringValue, IObservable<System.Char[]> separator, IObservable<System.Int32> count)
      //{
      //   return stringValue.Zip(separator, count, (stringValueLambda, separatorLambda, countLambda) => stringValueLambda.Split(separatorLambda, countLambda));
      //}

      //public static IObservable<string>[] Split(this IObservable<System.String> stringValue, IObservable<System.Char[]> separator, IObservable<System.StringSplitOptions> options)
      //{
      //   return stringValue.Zip(separator, options, (stringValueLambda, separatorLambda, optionsLambda) => stringValueLambda.Split(separatorLambda, optionsLambda));
      //}

      //public static IObservable<string>[] Split(this IObservable<System.String> stringValue, IObservable<System.Char[]> separator, IObservable<System.Int32> count, IObservable<System.StringSplitOptions> options)
      //{
      //   return stringValue.Zip(separator, count, options, (stringValueLambda, separatorLambda, countLambda, optionsLambda) => stringValueLambda.Split(separatorLambda, countLambda, optionsLambda));
      //}

      //public static IObservable<string>[] Split(this IObservable<System.String> stringValue, IObservable<System.String[]> separator, IObservable<System.StringSplitOptions> options)
      //{
      //   return stringValue.Zip(separator, options, (stringValueLambda, separatorLambda, optionsLambda) => stringValueLambda.Split(separatorLambda, optionsLambda));
      //}

      //public static IObservable<string>[] Split(this IObservable<System.String> stringValue, IObservable<System.String[]> separator, IObservable<System.Int32> count, IObservable<System.StringSplitOptions> options)
      //{
      //   return stringValue.Zip(separator, count, options, (stringValueLambda, separatorLambda, countLambda, optionsLambda) => stringValueLambda.Split(separatorLambda, countLambda, optionsLambda));
      //}

      public static IObservable<string> Substring(this IObservable<System.String> stringValue, IObservable<System.Int32> startIndex)
      {
         return stringValue.Zip(startIndex, (stringValueLambda, startIndexLambda) => stringValueLambda.Substring(startIndexLambda));
      }

      public static IObservable<string> Substring(this IObservable<System.String> stringValue, IObservable<System.Int32> startIndex, IObservable<System.Int32> length)
      {
         return stringValue.Zip(startIndex, length, (stringValueLambda, startIndexLambda, lengthLambda) => stringValueLambda.Substring(startIndexLambda, lengthLambda));
      }

      public static IObservable<string> Trim(this IObservable<System.String> stringValue, IObservable<System.Char[]> trimChars)
      {
         return stringValue.Zip(trimChars, (stringValueLambda, trimCharsLambda) => stringValueLambda.Trim(trimCharsLambda));
      }

      public static IObservable<string> TrimStart(this IObservable<System.String> stringValue, IObservable<System.Char[]> trimChars)
      {
         return stringValue.Zip(trimChars, (stringValueLambda, trimCharsLambda) => stringValueLambda.TrimStart(trimCharsLambda));
      }

      public static IObservable<string> TrimEnd(this IObservable<System.String> stringValue, IObservable<System.Char[]> trimChars)
      {
         return stringValue.Zip(trimChars, (stringValueLambda, trimCharsLambda) => stringValueLambda.TrimEnd(trimCharsLambda));
      }

      public static IObservable<Boolean> IsNormalized(this IObservable<System.String> stringValue)
      {
         return stringValue.Select((stringValueLambda) => stringValueLambda.IsNormalized());
      }

      public static IObservable<Boolean> IsNormalized(this IObservable<System.String> stringValue, IObservable<System.Text.NormalizationForm> normalizationForm)
      {
         return stringValue.Zip(normalizationForm, (stringValueLambda, normalizationFormLambda) => stringValueLambda.IsNormalized(normalizationFormLambda));
      }

      public static IObservable<string> Normalize(this IObservable<System.String> stringValue)
      {
         return stringValue.Select((stringValueLambda) => stringValueLambda.Normalize());
      }

      public static IObservable<string> Normalize(this IObservable<System.String> stringValue, IObservable<System.Text.NormalizationForm> normalizationForm)
      {
         return stringValue.Zip(normalizationForm, (stringValueLambda, normalizationFormLambda) => stringValueLambda.Normalize(normalizationFormLambda));
      }

      public static IObservable<int> Compare(IObservable<System.String> strA, IObservable<System.String> strB)
      {
         return Observable.Zip(strA, strB, System.String.Compare);
      }

      public static IObservable<int> Compare(IObservable<System.String> strA, IObservable<System.String> strB, IObservable<System.Boolean> ignoreCase)
      {
         return Observable.Zip(strA, strB, ignoreCase, System.String.Compare);
      }

      public static IObservable<int> Compare(IObservable<System.String> strA, IObservable<System.String> strB, IObservable<System.StringComparison> comparisonType)
      {
         return Observable.Zip(strA, strB, comparisonType, System.String.Compare);
      }

      public static IObservable<int> Compare(IObservable<System.String> strA, IObservable<System.String> strB, IObservable<System.Globalization.CultureInfo> culture, IObservable<System.Globalization.CompareOptions> options)
      {
         return Observable.Zip(strA, strB, culture, options, System.String.Compare);
      }

      public static IObservable<int> Compare(IObservable<System.String> strA, IObservable<System.String> strB, IObservable<System.Boolean> ignoreCase, IObservable<System.Globalization.CultureInfo> culture)
      {
         return Observable.Zip(strA, strB, ignoreCase, culture, System.String.Compare);
      }

      public static IObservable<int> Compare(IObservable<System.String> strA, IObservable<System.Int32> indexA, IObservable<System.String> strB, IObservable<System.Int32> indexB, IObservable<System.Int32> length)
      {
         return Observable.Zip(strA, indexA, strB, indexB, length, System.String.Compare);
      }

      public static IObservable<int> Compare(IObservable<System.String> strA, IObservable<System.Int32> indexA, IObservable<System.String> strB, IObservable<System.Int32> indexB, IObservable<System.Int32> length, IObservable<System.Boolean> ignoreCase)
      {
         return Observable.Zip(strA, indexA, strB, indexB, length, ignoreCase, System.String.Compare);
      }

      public static IObservable<int> Compare(IObservable<System.String> strA, IObservable<System.Int32> indexA, IObservable<System.String> strB, IObservable<System.Int32> indexB, IObservable<System.Int32> length, IObservable<System.Boolean> ignoreCase, IObservable<System.Globalization.CultureInfo> culture)
      {
         return Observable.Zip(strA, indexA, strB, indexB, length, ignoreCase, culture, System.String.Compare);
      }

      public static IObservable<int> Compare(IObservable<System.String> strA, IObservable<System.Int32> indexA, IObservable<System.String> strB, IObservable<System.Int32> indexB, IObservable<System.Int32> length, IObservable<System.Globalization.CultureInfo> culture, IObservable<System.Globalization.CompareOptions> options)
      {
         return Observable.Zip(strA, indexA, strB, indexB, length, culture, options, System.String.Compare);
      }

      public static IObservable<int> Compare(IObservable<System.String> strA, IObservable<System.Int32> indexA, IObservable<System.String> strB, IObservable<System.Int32> indexB, IObservable<System.Int32> length, IObservable<System.StringComparison> comparisonType)
      {
         return Observable.Zip(strA, indexA, strB, indexB, length, comparisonType, System.String.Compare);
      }

      public static IObservable<int> CompareTo(this IObservable<System.String> stringValue, IObservable<System.Object> value)
      {
         return stringValue.Zip(value, (stringValueLambda, valueLambda) => stringValueLambda.CompareTo(valueLambda));
      }

      public static IObservable<int> CompareTo(this IObservable<System.String> stringValue, IObservable<System.String> strB)
      {
         return stringValue.Zip(strB, (stringValueLambda, strBLambda) => stringValueLambda.CompareTo(strBLambda));
      }

      public static IObservable<int> CompareOrdinal(IObservable<System.String> strA, IObservable<System.String> strB)
      {
         return Observable.Zip(strA, strB, System.String.CompareOrdinal);
      }

      public static IObservable<int> CompareOrdinal(IObservable<System.String> strA, IObservable<System.Int32> indexA, IObservable<System.String> strB, IObservable<System.Int32> indexB, IObservable<System.Int32> length)
      {
         return Observable.Zip(strA, indexA, strB, indexB, length, System.String.CompareOrdinal);
      }

      public static IObservable<Boolean> Contains(this IObservable<System.String> stringValue, IObservable<System.String> value)
      {
         return stringValue.Zip(value, (stringValueLambda, valueLambda) => stringValueLambda.Contains(valueLambda));
      }

      public static IObservable<Boolean> EndsWith(this IObservable<System.String> stringValue, IObservable<System.String> value)
      {
         return stringValue.Zip(value, (stringValueLambda, valueLambda) => stringValueLambda.EndsWith(valueLambda));
      }

      public static IObservable<Boolean> EndsWith(this IObservable<System.String> stringValue, IObservable<System.String> value, IObservable<System.StringComparison> comparisonType)
      {
         return stringValue.Zip(value, comparisonType, (stringValueLambda, valueLambda, comparisonTypeLambda) => stringValueLambda.EndsWith(valueLambda, comparisonTypeLambda));
      }

      public static IObservable<Boolean> EndsWith(this IObservable<System.String> stringValue, IObservable<System.String> value, IObservable<System.Boolean> ignoreCase, IObservable<System.Globalization.CultureInfo> culture)
      {
         return stringValue.Zip(value, ignoreCase, culture, (stringValueLambda, valueLambda, ignoreCaseLambda, cultureLambda) => stringValueLambda.EndsWith(valueLambda, ignoreCaseLambda, cultureLambda));
      }

      public static IObservable<int> IndexOf(this IObservable<System.String> stringValue, IObservable<System.Char> value)
      {
         return stringValue.Zip(value, (stringValueLambda, valueLambda) => stringValueLambda.IndexOf(valueLambda));
      }

      public static IObservable<int> IndexOf(this IObservable<System.String> stringValue, IObservable<System.Char> value, IObservable<System.Int32> startIndex)
      {
         return stringValue.Zip(value, startIndex, (stringValueLambda, valueLambda, startIndexLambda) => stringValueLambda.IndexOf(valueLambda, startIndexLambda));
      }

      public static IObservable<int> IndexOf(this IObservable<System.String> stringValue, IObservable<System.Char> value, IObservable<System.Int32> startIndex, IObservable<System.Int32> count)
      {
         return stringValue.Zip(value, startIndex, count, (stringValueLambda, valueLambda, startIndexLambda, countLambda) => stringValueLambda.IndexOf(valueLambda, startIndexLambda, countLambda));
      }

      public static IObservable<int> IndexOfAny(this IObservable<System.String> stringValue, IObservable<System.Char[]> anyOf)
      {
         return stringValue.Zip(anyOf, (stringValueLambda, anyOfLambda) => stringValueLambda.IndexOfAny(anyOfLambda));
      }

      public static IObservable<int> IndexOfAny(this IObservable<System.String> stringValue, IObservable<System.Char[]> anyOf, IObservable<System.Int32> startIndex)
      {
         return stringValue.Zip(anyOf, startIndex, (stringValueLambda, anyOfLambda, startIndexLambda) => stringValueLambda.IndexOfAny(anyOfLambda, startIndexLambda));
      }

      public static IObservable<int> IndexOfAny(this IObservable<System.String> stringValue, IObservable<System.Char[]> anyOf, IObservable<System.Int32> startIndex, IObservable<System.Int32> count)
      {
         return stringValue.Zip(anyOf, startIndex, count, (stringValueLambda, anyOfLambda, startIndexLambda, countLambda) => stringValueLambda.IndexOfAny(anyOfLambda, startIndexLambda, countLambda));
      }

      public static IObservable<int> IndexOf(this IObservable<System.String> stringValue, IObservable<System.String> value)
      {
         return stringValue.Zip(value, (stringValueLambda, valueLambda) => stringValueLambda.IndexOf(valueLambda));
      }

      public static IObservable<int> IndexOf(this IObservable<System.String> stringValue, IObservable<System.String> value, IObservable<System.Int32> startIndex)
      {
         return stringValue.Zip(value, startIndex, (stringValueLambda, valueLambda, startIndexLambda) => stringValueLambda.IndexOf(valueLambda, startIndexLambda));
      }

      public static IObservable<int> IndexOf(this IObservable<System.String> stringValue, IObservable<System.String> value, IObservable<System.Int32> startIndex, IObservable<System.Int32> count)
      {
         return stringValue.Zip(value, startIndex, count, (stringValueLambda, valueLambda, startIndexLambda, countLambda) => stringValueLambda.IndexOf(valueLambda, startIndexLambda, countLambda));
      }

      public static IObservable<int> IndexOf(this IObservable<System.String> stringValue, IObservable<System.String> value, IObservable<System.StringComparison> comparisonType)
      {
         return stringValue.Zip(value, comparisonType, (stringValueLambda, valueLambda, comparisonTypeLambda) => stringValueLambda.IndexOf(valueLambda, comparisonTypeLambda));
      }

      public static IObservable<int> IndexOf(this IObservable<System.String> stringValue, IObservable<System.String> value, IObservable<System.Int32> startIndex, IObservable<System.StringComparison> comparisonType)
      {
         return stringValue.Zip(value, startIndex, comparisonType, (stringValueLambda, valueLambda, startIndexLambda, comparisonTypeLambda) => stringValueLambda.IndexOf(valueLambda, startIndexLambda, comparisonTypeLambda));
      }

      public static IObservable<int> IndexOf(this IObservable<System.String> stringValue, IObservable<System.String> value, IObservable<System.Int32> startIndex, IObservable<System.Int32> count, IObservable<System.StringComparison> comparisonType)
      {
         return stringValue.Zip(value, startIndex, count, comparisonType, (stringValueLambda, valueLambda, startIndexLambda, countLambda, comparisonTypeLambda) => stringValueLambda.IndexOf(valueLambda, startIndexLambda, countLambda, comparisonTypeLambda));
      }

      public static IObservable<int> LastIndexOf(this IObservable<System.String> stringValue, IObservable<System.Char> value)
      {
         return stringValue.Zip(value, (stringValueLambda, valueLambda) => stringValueLambda.LastIndexOf(valueLambda));
      }

      public static IObservable<int> LastIndexOf(this IObservable<System.String> stringValue, IObservable<System.Char> value, IObservable<System.Int32> startIndex)
      {
         return stringValue.Zip(value, startIndex, (stringValueLambda, valueLambda, startIndexLambda) => stringValueLambda.LastIndexOf(valueLambda, startIndexLambda));
      }

      public static IObservable<int> LastIndexOf(this IObservable<System.String> stringValue, IObservable<System.Char> value, IObservable<System.Int32> startIndex, IObservable<System.Int32> count)
      {
         return stringValue.Zip(value, startIndex, count, (stringValueLambda, valueLambda, startIndexLambda, countLambda) => stringValueLambda.LastIndexOf(valueLambda, startIndexLambda, countLambda));
      }

      public static IObservable<int> LastIndexOfAny(this IObservable<System.String> stringValue, IObservable<System.Char[]> anyOf)
      {
         return stringValue.Zip(anyOf, (stringValueLambda, anyOfLambda) => stringValueLambda.LastIndexOfAny(anyOfLambda));
      }

      public static IObservable<int> LastIndexOfAny(this IObservable<System.String> stringValue, IObservable<System.Char[]> anyOf, IObservable<System.Int32> startIndex)
      {
         return stringValue.Zip(anyOf, startIndex, (stringValueLambda, anyOfLambda, startIndexLambda) => stringValueLambda.LastIndexOfAny(anyOfLambda, startIndexLambda));
      }

      public static IObservable<int> LastIndexOfAny(this IObservable<System.String> stringValue, IObservable<System.Char[]> anyOf, IObservable<System.Int32> startIndex, IObservable<System.Int32> count)
      {
         return stringValue.Zip(anyOf, startIndex, count, (stringValueLambda, anyOfLambda, startIndexLambda, countLambda) => stringValueLambda.LastIndexOfAny(anyOfLambda, startIndexLambda, countLambda));
      }

      public static IObservable<int> LastIndexOf(this IObservable<System.String> stringValue, IObservable<System.String> value)
      {
         return stringValue.Zip(value, (stringValueLambda, valueLambda) => stringValueLambda.LastIndexOf(valueLambda));
      }

      public static IObservable<int> LastIndexOf(this IObservable<System.String> stringValue, IObservable<System.String> value, IObservable<System.Int32> startIndex)
      {
         return stringValue.Zip(value, startIndex, (stringValueLambda, valueLambda, startIndexLambda) => stringValueLambda.LastIndexOf(valueLambda, startIndexLambda));
      }

      public static IObservable<int> LastIndexOf(this IObservable<System.String> stringValue, IObservable<System.String> value, IObservable<System.Int32> startIndex, IObservable<System.Int32> count)
      {
         return stringValue.Zip(value, startIndex, count, (stringValueLambda, valueLambda, startIndexLambda, countLambda) => stringValueLambda.LastIndexOf(valueLambda, startIndexLambda, countLambda));
      }

      public static IObservable<int> LastIndexOf(this IObservable<System.String> stringValue, IObservable<System.String> value, IObservable<System.StringComparison> comparisonType)
      {
         return stringValue.Zip(value, comparisonType, (stringValueLambda, valueLambda, comparisonTypeLambda) => stringValueLambda.LastIndexOf(valueLambda, comparisonTypeLambda));
      }

      public static IObservable<int> LastIndexOf(this IObservable<System.String> stringValue, IObservable<System.String> value, IObservable<System.Int32> startIndex, IObservable<System.StringComparison> comparisonType)
      {
         return stringValue.Zip(value, startIndex, comparisonType, (stringValueLambda, valueLambda, startIndexLambda, comparisonTypeLambda) => stringValueLambda.LastIndexOf(valueLambda, startIndexLambda, comparisonTypeLambda));
      }

      public static IObservable<int> LastIndexOf(this IObservable<System.String> stringValue, IObservable<System.String> value, IObservable<System.Int32> startIndex, IObservable<System.Int32> count, IObservable<System.StringComparison> comparisonType)
      {
         return stringValue.Zip(value, startIndex, count, comparisonType, (stringValueLambda, valueLambda, startIndexLambda, countLambda, comparisonTypeLambda) => stringValueLambda.LastIndexOf(valueLambda, startIndexLambda, countLambda, comparisonTypeLambda));
      }

      public static IObservable<string> PadLeft(this IObservable<System.String> stringValue, IObservable<System.Int32> totalWidth)
      {
         return stringValue.Zip(totalWidth, (stringValueLambda, totalWidthLambda) => stringValueLambda.PadLeft(totalWidthLambda));
      }

      public static IObservable<string> PadLeft(this IObservable<System.String> stringValue, IObservable<System.Int32> totalWidth, IObservable<System.Char> paddingChar)
      {
         return stringValue.Zip(totalWidth, paddingChar, (stringValueLambda, totalWidthLambda, paddingCharLambda) => stringValueLambda.PadLeft(totalWidthLambda, paddingCharLambda));
      }

      public static IObservable<string> PadRight(this IObservable<System.String> stringValue, IObservable<System.Int32> totalWidth)
      {
         return stringValue.Zip(totalWidth, (stringValueLambda, totalWidthLambda) => stringValueLambda.PadRight(totalWidthLambda));
      }

      public static IObservable<string> PadRight(this IObservable<System.String> stringValue, IObservable<System.Int32> totalWidth, IObservable<System.Char> paddingChar)
      {
         return stringValue.Zip(totalWidth, paddingChar, (stringValueLambda, totalWidthLambda, paddingCharLambda) => stringValueLambda.PadRight(totalWidthLambda, paddingCharLambda));
      }

      public static IObservable<Boolean> StartsWith(this IObservable<System.String> stringValue, IObservable<System.String> value)
      {
         return stringValue.Zip(value, (stringValueLambda, valueLambda) => stringValueLambda.StartsWith(valueLambda));
      }

      public static IObservable<Boolean> StartsWith(this IObservable<System.String> stringValue, IObservable<System.String> value, IObservable<System.StringComparison> comparisonType)
      {
         return stringValue.Zip(value, comparisonType, (stringValueLambda, valueLambda, comparisonTypeLambda) => stringValueLambda.StartsWith(valueLambda, comparisonTypeLambda));
      }

      public static IObservable<Boolean> StartsWith(this IObservable<System.String> stringValue, IObservable<System.String> value, IObservable<System.Boolean> ignoreCase, IObservable<System.Globalization.CultureInfo> culture)
      {
         return stringValue.Zip(value, ignoreCase, culture, (stringValueLambda, valueLambda, ignoreCaseLambda, cultureLambda) => stringValueLambda.StartsWith(valueLambda, ignoreCaseLambda, cultureLambda));
      }

      public static IObservable<string> ToLower(this IObservable<System.String> stringValue)
      {
         return stringValue.Select((stringValueLambda) => stringValueLambda.ToLower());
      }

      public static IObservable<string> ToLower(this IObservable<System.String> stringValue, IObservable<System.Globalization.CultureInfo> culture)
      {
         return stringValue.Zip(culture, (stringValueLambda, cultureLambda) => stringValueLambda.ToLower(cultureLambda));
      }

      public static IObservable<string> ToLowerInvariant(this IObservable<System.String> stringValue)
      {
         return stringValue.Select((stringValueLambda) => stringValueLambda.ToLowerInvariant());
      }

      public static IObservable<string> ToUpper(this IObservable<System.String> stringValue)
      {
         return stringValue.Select((stringValueLambda) => stringValueLambda.ToUpper());
      }

      public static IObservable<string> ToUpper(this IObservable<System.String> stringValue, IObservable<System.Globalization.CultureInfo> culture)
      {
         return stringValue.Zip(culture, (stringValueLambda, cultureLambda) => stringValueLambda.ToUpper(cultureLambda));
      }

      public static IObservable<string> ToUpperInvariant(this IObservable<System.String> stringValue)
      {
         return stringValue.Select((stringValueLambda) => stringValueLambda.ToUpperInvariant());
      }

      public static IObservable<string> ToString(this IObservable<System.String> stringValue)
      {
         return stringValue.Select((stringValueLambda) => stringValueLambda.ToString());
      }

      public static IObservable<string> ToString(this IObservable<System.String> stringValue, IObservable<System.IFormatProvider> provider)
      {
         return stringValue.Zip(provider, (stringValueLambda, providerLambda) => stringValueLambda.ToString(providerLambda));
      }

      public static IObservable<object> Clone(this IObservable<System.String> stringValue)
      {
         return stringValue.Select((stringValueLambda) => stringValueLambda.Clone());
      }

      public static IObservable<string> Trim(this IObservable<System.String> stringValue)
      {
         return stringValue.Select((stringValueLambda) => stringValueLambda.Trim());
      }

      public static IObservable<string> Insert(this IObservable<System.String> stringValue, IObservable<System.Int32> startIndex, IObservable<System.String> value)
      {
         return stringValue.Zip(startIndex, value, (stringValueLambda, startIndexLambda, valueLambda) => stringValueLambda.Insert(startIndexLambda, valueLambda));
      }

      public static IObservable<string> Replace(this IObservable<System.String> stringValue, IObservable<System.Char> oldChar, IObservable<System.Char> newChar)
      {
         return stringValue.Zip(oldChar, newChar, (stringValueLambda, oldCharLambda, newCharLambda) => stringValueLambda.Replace(oldCharLambda, newCharLambda));
      }

      public static IObservable<string> Replace(this IObservable<System.String> stringValue, IObservable<System.String> oldValue, IObservable<System.String> newValue)
      {
         return stringValue.Zip(oldValue, newValue, (stringValueLambda, oldValueLambda, newValueLambda) => stringValueLambda.Replace(oldValueLambda, newValueLambda));
      }

      public static IObservable<string> Remove(this IObservable<System.String> stringValue, IObservable<System.Int32> startIndex, IObservable<System.Int32> count)
      {
         return stringValue.Zip(startIndex, count, (stringValueLambda, startIndexLambda, countLambda) => stringValueLambda.Remove(startIndexLambda, countLambda));
      }

      public static IObservable<string> Remove(this IObservable<System.String> stringValue, IObservable<System.Int32> startIndex)
      {
         return stringValue.Zip(startIndex, (stringValueLambda, startIndexLambda) => stringValueLambda.Remove(startIndexLambda));
      }

      public static IObservable<string> Format(IObservable<System.String> format, IObservable<System.Object> arg0)
      {
         return Observable.Zip(format, arg0, System.String.Format);
      }

      public static IObservable<string> Format(IObservable<System.String> format, IObservable<System.Object> arg0, IObservable<System.Object> arg1)
      {
         return Observable.Zip(format, arg0, arg1, System.String.Format);
      }

      public static IObservable<string> Format(IObservable<System.String> format, IObservable<System.Object> arg0, IObservable<System.Object> arg1, IObservable<System.Object> arg2)
      {
         return Observable.Zip(format, arg0, arg1, arg2, System.String.Format);
      }

      public static IObservable<string> Format(IObservable<System.String> format, IObservable<System.Object[]> args)
      {
         return Observable.Zip(format, args, System.String.Format);
      }

      public static IObservable<string> Format(IObservable<System.IFormatProvider> provider, IObservable<System.String> format, IObservable<System.Object[]> args)
      {
         return Observable.Zip(provider, format, args, System.String.Format);
      }

      public static IObservable<string> Copy(IObservable<System.String> str)
      {
         return str.Select(System.String.Copy);
      }

      public static IObservable<string> Concat(IObservable<System.Object> arg0)
      {
         return arg0.Select(a => System.String.Concat(a));
      }

      public static IObservable<string> Concat(IObservable<System.Object> arg0, IObservable<System.Object> arg1)
      {
         return Observable.Zip(arg0, arg1, System.String.Concat);
      }

      public static IObservable<string> Concat(IObservable<System.Object> arg0, IObservable<System.Object> arg1, IObservable<System.Object> arg2)
      {
         return Observable.Zip(arg0, arg1, arg2, System.String.Concat);
      }

      public static IObservable<string> Concat(IObservable<System.Object> arg0, IObservable<System.Object> arg1, IObservable<System.Object> arg2, IObservable<System.Object> arg3)
      {
         return Observable.Zip(arg0, arg1, arg2, arg3, (a0, a1, a2, a3) => System.String.Concat(a0, a1, a2, a3));
      }

      public static IObservable<string> Concat(IObservable<System.Object[]> args)
      {
         return args.Select(a => System.String.Concat(a));
      }

      //public static IObservable<string> Concat<T>(IObservable<IEnumerable`1> values)
      //{
      //   return values.Select(System.String.Concat<T>);
      //}

      //public static IObservable<string> Concat(IObservable<System.Collections.Generic.IEnumerable`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]> values)
      //{
      //   return values.Select(System.String.Concat);
      //}

      public static IObservable<string> Concat(IObservable<System.String> str0, IObservable<System.String> str1)
      {
          return Observable.Zip(str0, str1, System.String.Concat);
      }

      public static IObservable<string> Concat(IObservable<System.String> str0, IObservable<System.String> str1, IObservable<System.String> str2)
      {
          return Observable.Zip(str0, str1, str2, System.String.Concat);
      }

      public static IObservable<string> Concat(IObservable<System.String> str0, IObservable<System.String> str1, IObservable<System.String> str2, IObservable<System.String> str3)
      {
          return Observable.Zip(str0, str1, str2, str3, System.String.Concat);
      }

      public static IObservable<string> Concat(IObservable<System.String[]> values)
      {
          return values.Select(v => System.String.Concat(v));
      }

      public static IObservable<string> Intern(IObservable<System.String> str)
      {
          return str.Select(System.String.Intern);
      }

      public static IObservable<string> IsInterned(IObservable<System.String> str)
      {
          return str.Select(System.String.IsInterned);
      }

      public static IObservable<TypeCode> GetTypeCode(this IObservable<System.String> stringValue)
      {
          return stringValue.Select((stringValueLambda) => stringValueLambda.GetTypeCode());
      }

      public static IObservable<CharEnumerator> GetEnumerator(this IObservable<System.String> stringValue)
      {
          return stringValue.Select((stringValueLambda) => stringValueLambda.GetEnumerator());
      }

      public static IObservable<Type> GetType(this IObservable<System.String> stringValue)
      {
          return stringValue.Select((stringValueLambda) => stringValueLambda.GetType());
      }

   }
}
