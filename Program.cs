using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace section_cSharp
{
    #region First version - not thread-safe

    //public class Singleton
    //{
    //    private static Singleton instance;
    //    private Singleton() { }
    //    public static Singleton Instance
    //    {
    //        get
    //        {
    //            if (instance == null)
    //            {
    //                instance = new Singleton();
    //            }
    //            return instance;
    //        }
    //    }
    //}

    #endregion

    #region Multi-Threading

    //public sealed class Singleton
    //{
    //    private static Singleton instance = null;
    //    private static readonly object _lock = new object();
    //    Singleton() { }
    //    public static Singleton Instance
    //    {
    //        get
    //        {
    //            lock (_lock)
    //            {
    //                if (instance == null)
    //                {
    //                    instance = new Singleton();
    //                }
    //                return instance;
    //            }
    //        }
    //    }
    //    public void Test()
    //    {
    //        Console.WriteLine("Singleton Test Done");
    //    }
    //} 

    #endregion

    #region Thread-safe without using locks

    //public sealed class Singleton
    //{
    //    private static readonly Singleton instance = new Singleton();
    //    static Singleton() { }
    //    private Singleton() { }
    //    public static Singleton Instance
    //    {
    //        get
    //        {
    //            return instance;
    //        }
    //    }
    //    public void Test()
    //    {
    //        Console.WriteLine("Singleton Test Done");
    //    }
    //} 

    #endregion

    #region pipe and filter

    public static class ExtensionHelper
    {
        public static Func<T1, T3> Chain<T1, T2, T3>(this Func<T1, T2> f1,
            Func<T2, T3> f2)
        {
            return item => f2(f1(item));
        }
    }

    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            #region test singleton class

            //Singleton.Instance.Test();

            #endregion

            #region test pipe and filter

            Func<int, int> f1 = AddOne;
            //var val = f1.Chain(Double).Chain(i => i - 1).Chain(Double)(10);
            var chained3 = f1.Chain(i => i - 1).Chain(AddOne);
            var val = chained3.Chain(Double).Chain(Double)(10);
            Console.WriteLine("the value is : {0}", val);
            Console.ReadLine();

            #endregion


        }

        public static int AddOne(int i)
        {
            return i + 1;
        }

        public static int Double(int i)
        {
            return i * 2;   
        }
    }
}
