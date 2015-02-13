using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsSystem;
using MsSystem.Extensions;
using MS.Core;

namespace MonadSharp.Compiler.Tests
{
    [TestClass]
    public class RandomTests
    {
        [TestMethod]
        async public Task TestMethod1()
        {
            var _1 = ObservableExt.Range(Observable.Return(0), Observable.Return(10), x =>
            {
                var _3 = _Console.Write(Observable.Return("Your number is: "));
                var _4 = _Console.WriteLine(x);
                return ObservableEx.ForkJoin(_3, _4).ToVoid();
            });
            await _1;
        }

        [TestMethod]
        async public Task TestMethod2()
        {
            var b = Observable.Return(true);
            var ifRes = ObservableExt.If(b, 
                _Console.WriteLine(Observable.Return("This is true...")));
            await ifRes;
        }

        [TestMethod]
        async public Task TestMethod3()
        {
            var _1 = ObservableExt.If(Observable.Return(true), () =>
            {
                var _3 = _Console.WriteLine(Observable.Return("This is true..."));
                return ObservableEx.ForkJoin(_3).ToVoid();
            });
        }
    }
}
