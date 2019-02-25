using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            servant s = new servant("127.0.0.1", 5050);
            s.OnSetStatus += print;
        }
        static void print(string s,int i)
        {
            Console.WriteLine(i+" "+s);
        }
    }
}
