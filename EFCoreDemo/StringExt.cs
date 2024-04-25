using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo
{
    public static class StringExt
    {
        public static string DefaultStr(this string str)
        {
            return "Default str";
        }
    }
}
