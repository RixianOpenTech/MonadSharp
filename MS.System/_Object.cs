using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace MS.System
{
    public abstract class _Object<T> : IObservable<T>, IDisposable
    {
        private readonly BehaviorSubject<T> valueSubject;
        private IDisposable subscription;
        private IConnectableObservable<T> source;
        private IDisposable connection;

        public _Object(T value)
        {
            this.valueSubject = new BehaviorSubject<T>(value);
        }

        public _Object(IObservable<T> source)
        {
            this.valueSubject = new BehaviorSubject<T>(default(T));
            this.source = source.Publish();
            this.subscription = this.source.Subscribe(this.valueSubject);
        }

        public IObservable<T> Value
        {
            get { return this.valueSubject; }
        }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.ResetSubscription();
            this.valueSubject.Dispose();
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (this.source != null && this.connection == null)
                this.connection = this.source.Connect();

            return this.valueSubject.Subscribe(observer);
        }

        public void SetValue(T value)
        {
            this.valueSubject.OnNext(value);
        }

        public T GetValue()
        {
            return this.valueSubject.Value;
        }

        public void SetValue(IObservable<T> value)
        {
            this.ResetSubscription();
            this.subscription = value.Subscribe(this.valueSubject);
        }

        private void ResetSubscription()
        {
            if (this.subscription != null)
                this.subscription.Dispose();
        }
    }

    public class _Object : _Object<object>
    {
        public _Object(object value)
            : base(value)
        {
        }

        public _Object(IObservable<object> source)
            : base(source)
        {
        }

        public static _Object Create(IObservable<object> source)
        {
            return new _Object(source);
        }
    }
}