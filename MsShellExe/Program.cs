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
