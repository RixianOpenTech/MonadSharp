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
    }
}
