using System;
using System.Reactive.Subjects;

namespace MS.System
{
    public abstract class _Object<T> : IObservable<T>, IDisposable
    {
        private readonly BehaviorSubject<T> valueSubject;
        private IDisposable subscription;

        public _Object(T value)
        {
            this.valueSubject = new BehaviorSubject<T>(value);
        }

        public _Object(IObservable<T> source)
        {
            this.valueSubject = new BehaviorSubject<T>(default(T));
            this.subscription = source.Subscribe(this.valueSubject);
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
    }
}