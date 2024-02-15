using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorDemo
{
    internal class TestMonitor
    {

        public int Counter { get; set; } //32 - 64

        public string Name { get; set; }//32 - 64
        int Increment(int value,string s)
        {
            s = s + " ";
            return value+int.Parse(s);


        }

        void IncrementCounter()
        {
             Counter++;
        }


        void IncrementInTwoThread(int count)
        {
            tr1 = new Thread(() => {for (int i=0;i<count/2;i++) Inc })
        }

    }
}
