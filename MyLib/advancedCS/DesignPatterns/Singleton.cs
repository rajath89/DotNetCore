using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.advancedCS.DesignPatterns
{
    //No Thread Safe Singleton
    public sealed class Singleton1
    {
        private Singleton1() { }
        private static Singleton1 instance = null;
        public static Singleton1 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton1();
                }
                return instance;
            }
        }
    }

    //Thread Safety Singleton
    public sealed class Singleton2
    {
        Singleton2() { }
        private static readonly object Lock = new object();
        private static Singleton2 instance = null;
        public static Singleton2 Instance
        {
            get
            {
                lock (Lock)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton2();
                        }
                        return instance;
                    }
            }
        }
    }

    //Thread Safety Singleton using Double-Check Locking
    public sealed class Singleton3
    {
        Singleton3() { }
        private static readonly object Lock = new object ();
    private static Singleton3 instance = null;
        public static Singleton3 Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (Lock)
                        {
                            if (instance == null)
                            {
                                instance = new Singleton3();
                            }
                        }
                }
                return instance;
            }
        }
    }

    //Thread Safe Singleton without using locks and no lazy instantiation
    public sealed class Singleton4
    {
        private static readonly Singleton4 instance = new Singleton4();
        static Singleton4()
        {
        }
        private Singleton4()
        {
        }
        public static Singleton4 Instance
        {
            get
            {
                return instance;
            }
        }
    }

    //Using .NET 4's Lazy<T> type
    public sealed class Singleton5
    {
        private Singleton5()
        {
        }
        private static readonly Lazy<Singleton5> lazy = new Lazy<Singleton5>(() => new Singleton5());
        public static Singleton5 Instance
        {
            get
            {
                return lazy.Value;
            }
        }
    }

    internal class Singleton
    {
        public static void TestExample()
        {

        }
    }
}
