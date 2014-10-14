//using System;
//using System.Linq;
//using System.Reactive.Linq;

//namespace MsSystem
//{
//    public class IObservable<string> : IObservable<object><string>
//    {
//        public IObservable<string>(string value)
//            : base(value)
//        {
//        }

//        public IObservable<string>(IObservable<string> source)
//            : base(source)
//        {
//        }

//        public static IObservable<string> Empty
//        {
//            get { return string.Empty; }
//        }

//        public static implicit operator IObservable<string>(string value)
//        {
//            return new IObservable<string>(value);
//        }

//        public static implicit operator IObservable<object>(IObservable<string> value)
//        {
//            return new IObservable<object>(value);
//        }
//    }
//}
