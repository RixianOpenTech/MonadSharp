using System.Threading.Tasks;

namespace WrapperGenerator.Console
{
    public class MyClass
    {
        public void Work()
        {
        }

        public void Work(int x)
        {
        }

        public void Work(int x, string y)
        {
        }

        public void Work(int x, string y, params short[] z)
        {
        }

        public Task Work2()
        {
            return Task.Run(() => { });
        }

        public Task Work2(int x)
        {
            return Task.Run(() => { });
        }

        public Task Work2(int x, string y)
        {
            return Task.Run(() => { });
        }

        public Task Work2(int x, string y, params short[] z)
        {
            return Task.Run(() => { });
        }

        public bool Work3()
        {
            return false;
        }

        public bool Work3(int x)
        {
            return false;
        }

        public bool Work3(int x, string y)
        {
            return false;
        }

        public bool Work3(int x, string y, params short[] z)
        {
            return false;
        }

        public Task<bool> Work4()
        {
            return Task.FromResult(false);
        }

        public Task<bool> Work4(int x)
        {
            return Task.FromResult(false);
        }

        public Task<bool> Work4(int x, string y)
        {
            return Task.FromResult(false);
        }

        public Task<bool> Work4(int x, string y, params short[] z)
        {
            return Task.FromResult(false);
        }

        public static void Work5()
        {
        }

        public static void Work5(int x)
        {
        }

        public static void Work5(int x, string y)
        {
        }

        public static void Work5(int x, string y, params short[] z)
        {
        }

        public static Task Work6()
        {
            return Task.Run(() => { });
        }

        public static Task Work6(int x)
        {
            return Task.Run(() => { });
        }

        public static Task Work6(int x, string y)
        {
            return Task.Run(() => { });
        }

        public static Task Work6(int x, string y, params short[] z)
        {
            return Task.Run(() => { });
        }

        public static bool Work7()
        {
            return false;
        }

        public static bool Work7(int x)
        {
            return false;
        }

        public static bool Work7(int x, string y)
        {
            return false;
        }

        public static bool Work7(int x, string y, params short[] z)
        {
            return false;
        }

        public static Task<bool> Work8()
        {
            return Task.FromResult(false);
        }

        public static Task<bool> Work8(int x)
        {
            return Task.FromResult(false);
        }

        public static Task<bool> Work8(int x, string y)
        {
            return Task.FromResult(false);
        }

        public static Task<bool> Work8(int x, string y, params short[] z)
        {
            return Task.FromResult(false);
        }

    //===============================================

        public void Work9()
        {
        }

        public void Work9<T1>(T1 x)
        {
        }

        public void Work9<T1, T2>(T1 x, T2 y)
        {
        }

        public void Work9<T1, T2, T3>(T1 x, T2 y, params T3[] z)
        {
        }

        public Task Work10()
        {
            return Task.Run(() => { });
        }

        public Task Work10<T1>(T1 x)
        {
            return Task.Run(() => { });
        }

        public Task Work10<T1, T2>(T1 x, T2 y)
        {
            return Task.Run(() => { });
        }

        public Task Work10<T1, T2, T3>(T1 x, T2 y, params T3[] z)
        {
            return Task.Run(() => { });
        }

        public TResult Work11<TResult>()
        {
            return default(TResult);
        }

        public TResult Work11<T1, TResult>(T1 x)
        {
            return default(TResult);
        }

        public TResult Work11<T1, T2, TResult>(T1 x, T2 y)
        {
            return default(TResult);
        }

        public TResult Work11<T1, T2, T3, TResult>(T1 x, T2 y, params T3[] z)
        {
            return default(TResult);
        }

        public Task<TResult> Work12<TResult>()
        {
            return Task.FromResult(default(TResult));
        }

        public Task<TResult> Work12<T1, TResult>(T1 x)
        {
            return Task.FromResult(default(TResult));
        }

        public Task<TResult> Work12<T1, T2, TResult>(T1 x, T2 y)
        {
            return Task.FromResult(default(TResult));
        }

        public Task<TResult> Work12<T1, T2, T3, TResult>(T1 x, T2 y, params T3[] z)
        {
            return Task.FromResult(default(TResult));
        }

        public static void Work13()
        {
        }

        public static void Work13<T1>(T1 x)
        {
        }

        public static void Work13<T1, T2>(T1 x, T2 y)
        {
        }

        public static void Work13<T1, T2, T3>(T1 x, T2 y, params T3[] z)
        {
        }

        public static Task Work14()
        {
            return Task.Run(() => { });
        }

        public static Task Work14<T1>(T1 x)
        {
            return Task.Run(() => { });
        }

        public static Task Work14<T1, T2>(T1 x, T2 y)
        {
            return Task.Run(() => { });
        }

        public static Task Work14<T1, T2, T3>(T1 x, T2 y, params T3[] z)
        {
            return Task.Run(() => { });
        }

        public static TResult Work15<TResult>()
        {
            return default(TResult);
        }

        public static TResult Work15<T1, TResult>(T1 x)
        {
            return default(TResult);
        }

        public static TResult Work15<T1, T2, TResult>(T1 x, T2 y)
        {
            return default(TResult);
        }

        public static TResult Work15<T1, T2, T3, TResult>(T1 x, T2 y, params T3[] z)
        {
            return default(TResult);
        }

        public static Task<TResult> Work16<TResult>()
        {
            return Task.FromResult(default(TResult));
        }

        public static Task<TResult> Work16<T1, TResult>(T1 x)
        {
            return Task.FromResult(default(TResult));
        }

        public static Task<TResult> Work16<T1, T2, TResult>(T1 x, T2 y)
        {
            return Task.FromResult(default(TResult));
        }

        public static Task<TResult> Work16<T1, T2, T3, TResult>(T1 x, T2 y, params T3[] z)
        {
            return Task.FromResult(default(TResult));
        }
    }
}
