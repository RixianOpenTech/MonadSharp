using System;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using MS.Core;
using MsSystem.Extensions;

namespace MsSystem
{
    public static class _Console
    {
        public static IObservable<Unit> Beep()
        {
            return Observable.FromAsync(() => new Task(Console.Beep)).ToVoid();
        }

        public static IObservable<Unit> Beep(IObservable<Int32> frequency, IObservable<Int32> duration)
        {
            return ObservableExt.ZipExecute(frequency, duration, Console.Beep).ToVoid();
        }

        public static IObservable<Unit> Clear()
        {
            return Observable.FromAsync(() => new Task(Console.Clear)).ToVoid();
        }

        public static IObservable<Unit> ResetColor()
        {
            return Observable.FromAsync(() => new Task(Console.ResetColor)).ToVoid();
        }

        public static IObservable<Unit> MoveBufferArea(
            IObservable<Int32> sourceLeft,
            IObservable<Int32> sourceTop,
            IObservable<Int32> sourceWidth,
            IObservable<Int32> sourceHeight,
            IObservable<Int32> targetLeft,
            IObservable<Int32> targetTop)
        {
            return ObservableExt.ZipExecute(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop, Console.MoveBufferArea).ToVoid();
        }

        public static IObservable<Unit> MoveBufferArea(
            IObservable<Int32> sourceLeft,
            IObservable<Int32> sourceTop,
            IObservable<Int32> sourceWidth,
            IObservable<Int32> sourceHeight,
            IObservable<Int32> targetLeft,
            IObservable<Int32> targetTop,
            IObservable<Char> sourceChar,
            IObservable<ConsoleColor> sourceForeColor,
            IObservable<ConsoleColor> sourceBackColor)
        {
            return ObservableExt.ZipExecute(sourceLeft,
                                            sourceTop,
                                            sourceWidth,
                                            sourceHeight,
                                            targetLeft,
                                            targetTop,
                                            sourceChar,
                                            sourceForeColor,
                                            sourceBackColor,
                                            Console.MoveBufferArea).ToVoid();
        }

        public static IObservable<Unit> SetBufferSize(IObservable<Int32> width, IObservable<Int32> height)
        {
            return ObservableExt.ZipExecute(width, height, Console.SetBufferSize).ToVoid();
        }

        public static IObservable<Unit> SetWindowSize(IObservable<Int32> width, IObservable<Int32> height)
        {
            return ObservableExt.ZipExecute(width, height, Console.SetWindowSize).ToVoid();
        }

        public static IObservable<Unit> SetWindowPosition(IObservable<Int32> left, IObservable<Int32> top)
        {
            return ObservableExt.ZipExecute(left, top, Console.SetWindowPosition).ToVoid();
        }

        public static IObservable<Unit> SetCursorPosition(IObservable<Int32> left, IObservable<Int32> top)
        {
            return ObservableExt.ZipExecute(left, top, Console.SetCursorPosition).ToVoid();
        }

        public static IObservable<ConsoleKeyInfo> ReadKey()
        {
            return Observable.FromAsync(() => Task.FromResult(Console.ReadKey()));
        }

        public static IObservable<ConsoleKeyInfo> ReadKey(IObservable<Boolean> intercept)
        {
            return intercept.Select(Console.ReadKey);
        }

        public static IObservable<Stream> OpenStandardError()
        {
            return Observable.FromAsync(() => Task.FromResult(Console.OpenStandardError()));
        }

        public static IObservable<Stream> OpenStandardError(IObservable<Int32> bufferSize)
        {
            return bufferSize.Select(Console.OpenStandardError);
        }

        public static IObservable<Stream> OpenStandardInput()
        {
            return Observable.FromAsync(() => Task.FromResult(Console.OpenStandardInput()));
        }

        public static IObservable<Stream> OpenStandardInput(IObservable<Int32> bufferSize)
        {
            return bufferSize.Select(Console.OpenStandardInput);
        }

        public static IObservable<Stream> OpenStandardOutput()
        {
            return Observable.FromAsync(() => Task.FromResult(Console.OpenStandardOutput()));
        }

        public static IObservable<Stream> OpenStandardOutput(IObservable<Int32> bufferSize)
        {
            return bufferSize.Select(Console.OpenStandardOutput);
        }

        public static IObservable<Unit> SetIn(IObservable<TextReader> newIn)
        {
            return newIn.Do(Console.SetIn).ToVoid();
        }

        public static IObservable<Unit> SetOut(IObservable<TextWriter> newOut)
        {
            return newOut.Do(Console.SetOut).ToVoid();
        }

        public static IObservable<Unit> SetError(IObservable<TextWriter> newError)
        {
            return newError.Do(Console.SetError).ToVoid();
        }

        public static IObservable<int> Read()
        {
            return Observable.FromAsync(() => Task.FromResult(Console.Read()));
        }

        public static IObservable<string> ReadLine()
        {
            return Observable.FromAsync(() => Task.FromResult(Console.ReadLine()));
        }

        public static IObservable<Unit> WriteLine()
        {
            return Observable.FromAsync(() => new Task(Console.WriteLine)).ToVoid();
        }

        public static IObservable<Unit> WriteLine(IObservable<Boolean> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static IObservable<Unit> WriteLine(IObservable<Char> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static IObservable<Unit> WriteLine(IObservable<Char[]> buffer)
        {
            return buffer.Do(Console.WriteLine).ToVoid();
        }

        public static IObservable<Unit> WriteLine(IObservable<Char[]> buffer, IObservable<Int32> index, IObservable<Int32> count)
        {
            return ObservableExt.ZipExecute(buffer, index, count, Console.WriteLine).ToVoid();
        }

        public static IObservable<Unit> WriteLine(IObservable<Decimal> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static IObservable<Unit> WriteLine(IObservable<Double> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static IObservable<Unit> WriteLine(IObservable<Single> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static IObservable<Unit> WriteLine(IObservable<Int32> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static IObservable<Unit> WriteLine(IObservable<UInt32> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static IObservable<Unit> WriteLine(IObservable<Int64> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static IObservable<Unit> WriteLine(IObservable<UInt64> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static IObservable<Unit> WriteLine(IObservable<Object> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static IObservable<Unit> WriteLine<T>(IObservable<T> value)
        {
            return value.Do(t => Console.WriteLine(t)).ToVoid();
        }

        public static IObservable<Unit> WriteLine(IObservable<String> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static IObservable<Unit> WriteLine(IObservable<String> format, IObservable<Object> arg0)
        {
            return ObservableExt.ZipExecute(format, arg0, Console.WriteLine).ToVoid();
        }

        public static IObservable<Unit> WriteLine(IObservable<String> format, IObservable<Object> arg0, IObservable<Object> arg1)
        {
            return ObservableExt.ZipExecute(format, arg0, arg1, Console.WriteLine).ToVoid();
        }

        public static IObservable<Unit> WriteLine(IObservable<String> format, IObservable<Object> arg0, IObservable<Object> arg1, IObservable<Object> arg2)
        {
            return ObservableExt.ZipExecute(format, arg0, arg1, arg2, Console.WriteLine).ToVoid();
        }

        public static IObservable<Unit> WriteLine(
            IObservable<String> format,
            IObservable<Object> arg0,
            IObservable<Object> arg1,
            IObservable<Object> arg2,
            IObservable<Object> arg3)
        {
            return ObservableExt.ZipExecute(format, arg0, arg1, arg2, arg3,
                (formatLambda, arg0Lambda, arg1Lambda, arg2Lambda, arg3Lambda) =>
                    Console.WriteLine(formatLambda, arg0Lambda, arg1Lambda, arg2Lambda, arg3Lambda)).ToVoid();
        }

        public static IObservable<Unit> WriteLine(IObservable<String> format, IObservable<Object[]> arg)
        {
            return ObservableExt.ZipExecute(format, arg, Console.WriteLine).ToVoid();
        }

        public static IObservable<Unit> Write(IObservable<String> format, IObservable<Object> arg0)
        {
            return ObservableExt.ZipExecute(format, arg0, Console.Write).ToVoid();
        }

        public static IObservable<Unit> Write(IObservable<String> format, IObservable<Object> arg0, IObservable<Object> arg1)
        {
            return ObservableExt.ZipExecute(format, arg0, arg1, Console.Write).ToVoid();
        }

        public static IObservable<Unit> Write(IObservable<String> format, IObservable<Object> arg0, IObservable<Object> arg1, IObservable<Object> arg2)
        {
            return ObservableExt.ZipExecute(format, arg0, arg1, arg2, Console.Write).ToVoid();
        }

        public static IObservable<Unit> Write(
            IObservable<String> format,
            IObservable<Object> arg0,
            IObservable<Object> arg1,
            IObservable<Object> arg2,
            IObservable<Object> arg3)
        {
            return ObservableExt.ZipExecute(format, arg0, arg1, arg2, arg3,
                (formatLambda, arg0Lambda, arg1Lambda, arg2Lambda, arg3Lambda) =>
                    Console.Write(formatLambda, arg0Lambda, arg1Lambda, arg2Lambda, arg3Lambda)).ToVoid();
        }

        public static IObservable<Unit> Write(IObservable<String> format, IObservable<Object[]> arg)
        {
            return ObservableExt.ZipExecute(format, arg, Console.Write).ToVoid();
        }

        public static IObservable<Unit> Write(IObservable<Boolean> value)
        {
            return value.Do(Console.Write).ToVoid();
        }

        public static IObservable<Unit> Write(IObservable<Char> value)
        {
            return value.Do(Console.Write).ToVoid();
        }

        public static IObservable<Unit> Write(IObservable<Char[]> buffer)
        {
            return buffer.Do(Console.Write).ToVoid();
        }

        public static IObservable<Unit> Write(IObservable<Char[]> buffer, IObservable<Int32> index, IObservable<Int32> count)
        {
            return ObservableExt.ZipExecute(buffer, index, count, Console.Write).ToVoid();
        }

        public static IObservable<Unit> Write(IObservable<Double> value)
        {
            return value.Do(Console.Write).ToVoid();
        }

        public static IObservable<Unit> Write(IObservable<Decimal> value)
        {
            return value.Do(Console.Write).ToVoid();
        }

        public static IObservable<Unit> Write(IObservable<Single> value)
        {
            return value.Do(Console.Write).ToVoid();
        }

        public static IObservable<Unit> Write(IObservable<Int32> value)
        {
            return value.Do(Console.Write).ToVoid();
        }

        public static IObservable<Unit> Write(IObservable<UInt32> value)
        {
            return value.Do(Console.Write).ToVoid();
        }

        public static IObservable<Unit> Write(IObservable<Int64> value)
        {
            return value.Do(Console.Write).ToVoid();
        }

        public static IObservable<Unit> Write(IObservable<UInt64> value)
        {
            return value.Do(Console.Write).ToVoid();
        }

        public static IObservable<Unit> Write(IObservable<Object> value)
        {
            return value.Do(Console.Write).ToVoid();
        }

        public static IObservable<Unit> Write(IObservable<String> value)
        {
            return value.Do(Console.Write).ToVoid();
        }
    }
}
