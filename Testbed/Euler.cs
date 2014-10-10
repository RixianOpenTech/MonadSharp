using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using MS.System;

namespace Testbed
{
    public static class Euler
    {
        public static _Int32 Problem1()
        {
            _Int32 threes = Observable.Generate(3, i => i < 1000, i => i + 3, i => i).AsInt32();
            _Int32 fives = Observable.Generate(5, i => i < 1000, i => i + 5, i => i).AsInt32();
            _Int32 all = threes.Concat(fives).Distinct().AsInt32();
            return all.Aggregate((left, right) => left + right).AsInt32();
        }

        public static _BigInteger Problem2()
        {
            var evenTerms = new ReplaySubject<_BigInteger>();
            _BigInteger x = 1;
            _BigInteger y = 2;
            evenTerms.OnNext(y);

            //Subject<_BigInteger> newTerms = new Subject<_BigInteger>();
            var result = Observable.While(() =>
                                          {
                                              var newTerm = x + y;
                                              x.SetValue(y);
                                              y.SetValue(newTerm);
                                              if ((newTerm % new _BigInteger(2)).GetValue() == 0)
                                                  evenTerms.OnNext(newTerm);
                                              return y.GetValue() < 4000000;
                                          },
                                          evenTerms)
                                   .Aggregate((left, right) => left + right);

            //for (; y < 4000000;)
            //{
            //    var newTerm = x + y;
            //    x = y;
            //    y = newTerm;
            //    if (newTerm % 2 == 0)
            //        evenTerms.Add(newTerm);
            //}
            return result.FirstAsync().ToTask().Result;
        }
    }
}
