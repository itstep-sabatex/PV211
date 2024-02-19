using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorDemo
{
    internal class TestMonitor
    {

       volatile public  int Counter; //32 - 64

        private object lockObject = new object();

        public string Name { get; set; }//32 - 64
        int Increment(int value,string s)
        {
            s = s + " ";
            return value+int.Parse(s);


        }

        void IncrementCounter()
        {
            lock (lockObject) 
            {
                Counter++;

            }
        }


        void IncrementCounterMonitor()
        {
            Monitor.Enter(lockObject); Monitor.TryEnter(lockObject,1000);
            Counter++;
            Monitor.Exit(lockObject);
        }


        public void IncrementInTwoThread(int count)
        {
            var trs = new List<Thread>();
            for (int i = 0; i < 8; i++)
            {
                var tr = new Thread(() => { for (int i = 0; i < count; i++) IncrementCounter(); });
                tr.Start();
                trs.Add(tr);
            }
             while (trs.Any(s=>s.IsAlive)) { Thread.Sleep(100); }
        }

    }
}
