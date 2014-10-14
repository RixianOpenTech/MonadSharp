//using System;

//namespace MsSystem
//{
//    public class IObservable<Char> : IObservable<object><Char>
//    {
//        public IObservable<Char>(Char value)
//            : base(value)
//        {
//        }

//        public IObservable<Char>(IObservable<Char> source)
//            : base(source)
//        {
//        }

//        public static implicit operator IObservable<Char>(Char value)
//        {
//            return new IObservable<Char>(value);
//        }
//    }
//}