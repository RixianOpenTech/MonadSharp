using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using MS.Core;
using MsSystem;

namespace Testbed
{
    /*
    class Sample
    {
	    unit Work()
	    {
		    int x = 5;
		    if (x < 10)
		    {
			    foreach(int i in [0..x])
			    {
				    Console.WriteLine(i);
			    }
		    }
		    else
		    {
		    }
		    x = 10;
	    }
    }
     */
    
    class Sample
    {
        public static IObservable<Unit> Work()
        {
            return Observable.Create<Unit>(observer =>
                                           {
                                               IObservable<int> x = Observable.Return(5);
                                               return x.Select(xVal => Observable.If(() => xVal < 10,
                                                                              Observable.Generate(0, i => i < xVal, i => i + 1, i => i)
                                                                                        .Select(i => _Console.WriteLine(Observable.Return(i))).Flatten(),
                                                                              Observable.Return(Unit.Default))).Flatten().ContinueWith(
                                                                       Observable.Return(Unit.Default).Do(_ => x = Observable.Return(10)))
                                                       .Subscribe(observer);
                                           });
        }
    }
}
