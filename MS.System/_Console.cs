using System;
using System.IO;
using System.Reactive.Linq;
using System.Threading.Tasks;
using MS.Core;
using MS.System.Extensions;

namespace MS.System
{
    public static class _Console
    {
        public static _Void Beep()
        {
            return Observable.FromAsync(() => new Task(Console.Beep)).ToVoid();
        }

        public static _Void Beep(IObservable<Int32> frequency, IObservable<Int32> duration)
        {
            return ObservableExt.ZipExecute(frequency, duration, Console.Beep).ToVoid();
        }

        public static _Void Clear()
        {
            return Observable.FromAsync(() => new Task(Console.Clear)).ToVoid();
        }

        public static _Void ResetColor()
        {
            return Observable.FromAsync(() => new Task(Console.ResetColor)).ToVoid();
        }

        public static _Void MoveBufferArea(
            IObservable<Int32> sourceLeft,
            IObservable<Int32> sourceTop,
            IObservable<Int32> sourceWidth,
            IObservable<Int32> sourceHeight,
            IObservable<Int32> targetLeft,
            IObservable<Int32> targetTop)
        {
            return ObservableExt.ZipExecute(sourceLeft, sourceTop, sourceWidth, sourceHeight, targetLeft, targetTop, Console.MoveBufferArea).ToVoid();
        }

        public static _Void MoveBufferArea(
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

        public static _Void SetBufferSize(IObservable<Int32> width, IObservable<Int32> height)
        {
            return ObservableExt.ZipExecute(width, height, Console.SetBufferSize).ToVoid();
        }

        public static _Void SetWindowSize(IObservable<Int32> width, IObservable<Int32> height)
        {
            return ObservableExt.ZipExecute(width, height, Console.SetWindowSize).ToVoid();
        }

        public static _Void SetWindowPosition(IObservable<Int32> left, IObservable<Int32> top)
        {
            return ObservableExt.ZipExecute(left, top, Console.SetWindowPosition).ToVoid();
        }

        public static _Void SetCursorPosition(IObservable<Int32> left, IObservable<Int32> top)
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

        public static _Stream OpenStandardError()
        {
            return new _Stream(Observable.FromAsync(() => Task.FromResult(Console.OpenStandardError())));
        }

        public static _Stream OpenStandardError(IObservable<Int32> bufferSize)
        {
            return new _Stream(bufferSize.Select(Console.OpenStandardError));
        }

        public static _Stream OpenStandardInput()
        {
            return new _Stream(Observable.FromAsync(() => Task.FromResult(Console.OpenStandardInput())));
        }

        public static _Stream OpenStandardInput(IObservable<Int32> bufferSize)
        {
            return new _Stream(bufferSize.Select(Console.OpenStandardInput));
        }

        public static _Stream OpenStandardOutput()
        {
            return new _Stream(Observable.FromAsync(() => Task.FromResult(Console.OpenStandardOutput())));
        }

        public static _Stream OpenStandardOutput(IObservable<Int32> bufferSize)
        {
            return new _Stream(bufferSize.Select(Console.OpenStandardOutput));
        }

        public static _Void SetIn(IObservable<TextReader> newIn)
        {
            return newIn.Do(Console.SetIn).ToVoid();
        }

        public static _Void SetOut(IObservable<TextWriter> newOut)
        {
            return newOut.Do(Console.SetOut).ToVoid();
        }

        public static _Void SetError(IObservable<TextWriter> newError)
        {
            return newError.Do(Console.SetError).ToVoid();
        }

        public static _Int32 Read()
        {
            return Observable.FromAsync(() => Task.FromResult(Console.Read())).AsInt32();
        }

        public static _String ReadLine()
        {
            return Observable.FromAsync(() => Task.FromResult(Console.ReadLine())).AsString();
        }

        public static _Void WriteLine()
        {
            return Observable.FromAsync(() => new Task(Console.WriteLine)).ToVoid();
        }

        public static _Void WriteLine(IObservable<Boolean> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static _Void WriteLine(IObservable<Char> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static _Void WriteLine(IObservable<Char[]> buffer)
        {
            return buffer.Do(Console.WriteLine).ToVoid();
        }

        public static _Void WriteLine(IObservable<Char[]> buffer, IObservable<Int32> index, IObservable<Int32> count)
        {
            return ObservableExt.ZipExecute(buffer, index, count, Console.WriteLine).ToVoid();
        }

        public static _Void WriteLine(IObservable<Decimal> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static _Void WriteLine(IObservable<Double> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static _Void WriteLine(IObservable<Single> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static _Void WriteLine(IObservable<Int32> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static _Void WriteLine(IObservable<UInt32> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static _Void WriteLine(IObservable<Int64> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static _Void WriteLine(IObservable<UInt64> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static _Void WriteLine(IObservable<Object> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static _Void WriteLine(IObservable<String> value)
        {
            return value.Do(Console.WriteLine).ToVoid();
        }

        public static _Void WriteLine(IObservable<String> format, IObservable<Object> arg0)
        {
            return ObservableExt.ZipExecute(format, arg0, Console.WriteLine).ToVoid();
        }

        public static _Void WriteLine(IObservable<String> format, IObservable<Object> arg0, IObservable<Object> arg1)
        {
            return ObservableExt.ZipExecute(format, arg0, arg1, Console.WriteLine).ToVoid();
        }

        public static _Void WriteLine(IObservable<String> format, IObservable<Object> arg0, IObservable<Object> arg1, IObservable<Object> arg2)
        {
            return ObservableExt.ZipExecute(format, arg0, arg1, arg2, Console.WriteLine).ToVoid();
        }

        public static _Void WriteLine(
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

        public static _Void WriteLine(IObservable<String> format, IObservable<Object[]> arg)
        {
            return ObservableExt.ZipExecute(format, arg, Console.WriteLine).ToVoid();
        }

        public static _Void Write(IObservable<String> format, IObservable<Object> arg0)
        {
            return ObservableExt.ZipExecute(format, arg0, Console.Write).ToVoid();
        }

        public static _Void Write(IObservable<String> format, IObservable<Object> arg0, IObservable<Object> arg1)
        {
            return ObservableExt.ZipExecute(format, arg0, arg1, Console.Write).ToVoid();
        }

        public static _Void Write(IObservable<String> format, IObservable<Object> arg0, IObservable<Object> arg1, IObservable<Object> arg2)
        {
            return ObservableExt.ZipExecute(format, arg0, arg1, arg2, Console.Write).ToVoid();
        }

        public static _Void Write(
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

        public static _Void Write(IObservable<String> format, IObservable<Object[]> arg)
        {
            return ObservableExt.ZipExecute(format, arg, Console.Write).ToVoid();
        }

        public static _Void Write(IObservable<Boolean> value)
        {
            return value.Do(Console.Write).ToVoid();
        }

        public static _Void Write(IObservable<Char> value)
        {
            return value.Do(Console.Write).ToVoid();
        }

        public static _Void Write(IObservable<Char[]> buffer)
        {
            return buffer.Do(Console.Write).ToVoid();
        }

        public static _Void Write(IObservable<Char[]> buffer, IObservable<Int32> index, IObservable<Int32> count)
        {
            return ObservableExt.ZipExecute(buffer, index, count, Console.Write).ToVoid();
        }

        public static _Void Write(IObservable<Double> value)
        {
            return value.Do(Console.Write).ToVoid();
        }

        public static _Void Write(IObservable<Decimal> value)
        {
            return value.Do(Console.Write).ToVoid();
        }

        public static _Void Write(IObservable<Single> value)
        {
            return value.Do(Console.Write).ToVoid();
        }

        public static _Void Write(IObservable<Int32> value)
        {
            return value.Do(Console.Write).ToVoid();
        }

        public static _Void Write(IObservable<UInt32> value)
        {
            return value.Do(Console.Write).ToVoid();
        }

        public static _Void Write(IObservable<Int64> value)
        {
            return value.Do(Console.Write).ToVoid();
        }

        public static _Void Write(IObservable<UInt64> value)
        {
            return value.Do(Console.Write).ToVoid();
        }

        public static _Void Write(IObservable<Object> value)
        {
            return value.Do(Console.Write).ToVoid();
        }

        public static _Void Write(IObservable<String> value)
        {
            return value.Do(Console.Write).ToVoid();
        }
    }
}
