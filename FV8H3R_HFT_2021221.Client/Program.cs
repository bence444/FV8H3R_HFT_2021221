using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FV8H3R_HFT_2021221.Client
{
    class Program
    {
        public static void Main(string[] args)
        {
            RestService service = new RestService("http://localhost:48623");
        }
    }
}
