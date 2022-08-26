using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class WeakRefNet
    {
        static void Main(string[] args)
        {
            //string input = "PI/25";
            //string patten = @"[^0-9]+\)";
            //for (int i = 0; i <= 1; i++)
            //{
            //    DateTime temp = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(i * -1);
            //    Console.WriteLine("A:" + temp.ToString("yyyyMM"));
            //}

            // 正常參考一個物件，只要該參考持續存在，該物件就不會被記憶體回收
            MyClass strongReference = new MyClass("Strong Reference Object");
            // 表示弱式參考，即在參考物件的同時，仍允許系統透過記憶體回收來回收該物件。
            WeakReference weakReference = new WeakReference(new MyClass("Weak Reference Object"));
            Console.WriteLine($"正常使用的參考物件為 {strongReference.Name}");
            Console.WriteLine($"弱式參考物件是否還存在 {weakReference.IsAlive}");
            Console.WriteLine($"弱式參考物件為 {(weakReference.Target as MyClass).Name}");
            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
            Console.WriteLine("強制進行記憶體回收，等候三秒鐘...");
            GC.Collect(2);
            Thread.Sleep(3000);
            Console.WriteLine($"正常使用的參考物件為 {strongReference.Name}");
            Console.WriteLine($"弱式參考物件是否還存在 {weakReference.IsAlive}");
            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();

            ReAccessWeakReference(strongReference, weakReference);

            Console.WriteLine($"正常使用的參考物件為 {strongReference.Name}");
            Console.WriteLine($"弱式參考物件是否還存在 {weakReference.IsAlive}");
            Console.WriteLine($"弱式參考物件為 {(weakReference.Target as MyClass).Name}");
            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();


            Console.Read(); 
        }
        static void ReAccessWeakReference(MyClass strongReference, WeakReference weakReference)
        {
            if (weakReference.Target == null)
            {
                Console.WriteLine("因為弱式參考的物件不存在了，所以重新取得該弱式參考物件...");
                weakReference.Target = new MyClass("再次產生的 Weak Reference Object");
            }

        }

    }



    public class MyClass
    {
        public string Name { get; set; }
        public MyClass(string name)
        {
            Name = name;
            Console.WriteLine($"----------> MyClass類別產生一個物件 : {Name}");
        }
        ~MyClass()
        {
            Console.WriteLine($"==========> MyClass類別的一個物件被記憶體回收了 : {Name}");
        }
    }

}
