using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;

namespace MsShellExe
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableExecutable.Main().Wait();
        }
    }
}
