using System;
using System.Linq;
using System.Numerics;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using MsSystem;

namespace Testbed
{
    public static class Euler
    {
        public static IObservable<int> Problem1()
        {
            var threes = Observable.Generate(3, i => i < 1000, i => i + 3, i => i);
            var fives = Observable.Generate(5, i => i < 1000, i => i + 5, i => i);
            var all = threes.Concat(fives).Distinct();
            return all.Aggregate((left, right) => left + right);
        }

        public static IObservable<BigInteger> Problem2()
        {
            return Observable.Generate(new Tuple<BigInteger, BigInteger>(1, 2),
                                       tuple => tuple.Item2 < 4000000,
                                       tuple => Tuple.Create(tuple.Item2, tuple.Item1 + tuple.Item2),
                                       tuple => tuple.Item2)
                             .Where(value => value % 2 == 0)
                             .Aggregate((left, right) => left + right);
        }

        public static IObservable<BigInteger> Problem3()
        {
            var xValues = Observable.Range(100, 899).Select(value => new BigInteger(value));
            var yValues = Observable.Range(100, 899).Select(value => new BigInteger(value));
            var palindromes = from x in xValues
                              from y in yValues
                              let z = x * y
                              let zString = z.ToString()
                              let reversedZ = new string(zString.Reverse().ToArray())
                              where zString == reversedZ
                              select z;
            var maxPalindrom = palindromes.Max();
            return maxPalindrom;
        }
    }
}
