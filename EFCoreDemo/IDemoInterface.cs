using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo
{
    public interface IDemoInterface
    {
        public string GetName() { return "Fake interface"; }
    }
    public interface IDemoInterface2:IDemoInterface
    {

    }
    


}
