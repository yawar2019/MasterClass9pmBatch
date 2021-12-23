using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLinqApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5 };
            string[] b = { "james", "radha","virat", "Dilip", "Keshav" };


            //var result = a.Where(s => s > 2);
            //var result = b.Contains("veirat");
            var result = b.OrderByDescending(x=>x);




            // var result = from n in a
            //              //where n>2 && n<4
            //               orderby n descending select n;
            // //  var result2 = result.Sum();
            foreach (var item in result)
            {
                Console.WriteLine(item);

            }
            //Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
