using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Zadaca
{
    class Program 
    {

        static void Main(string[] args)
        {            
            
            Console.WriteLine("bla");
            IGenericList<string> stringList = new GenericList<string>(); 
            stringList.Add("Hello"); 
            stringList.Add("World"); 
            stringList.Add("!");
            foreach (string value in stringList) { Console.WriteLine(value); }
            Console.Read();
        }
    }
}