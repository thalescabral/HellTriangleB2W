using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HellTriangleB2WApp
{
    public class Program
    {


        static void Main(string[] args)
        {

            int[][] triangle = {
                new int[] { 6 },
                new int[] { 3, 5 },
                new int[] { 9, 7, 1 },
                new int[] { 4, 6, 8, 4 },
            };

            Executar(triangle);
        }

        public static int UserLinq(int[][] triangle)
        {
            return triangle
                .Skip(1)
                .Aggregate(
                new { sum = triangle[0][0], index = 0 },
                (ag, array) => new
                {
                    sum = ag.sum + Math.Max(array[ag.index], array[ag.index + 1]),
                    index = array[ag.index] > array[ag.index + 1] ? ag.index : ag.index + 1,
                },
                ag => ag.sum);
        }

        public static int NoUserLinq(int[][] triangle)
        {
            var sum = triangle[0][0];
            var indexMax = 0;
            for (int i = 1; i < triangle.Length; i++)
            {
                var option1 = triangle[i][indexMax];
                var option2 = triangle[i][indexMax + 1];

                if (option1 > option2)
                {
                    sum += option1;
                }
                else
                {
                    sum += option2;
                    indexMax = indexMax + 1;
                }
            }

            return sum;
        }
        private static void Executar(int[][] triangle)
        {
            var s1 = new Stopwatch();
            s1.Start();
            var valorLinq = UserLinq(triangle);
            s1.Stop();

            var s2 = new Stopwatch();
            s2.Start();
            var valorSemLinq = NoUserLinq(triangle);
            s2.Stop();

            Console.WriteLine("_________________Hell Triangle_______________");
           
            Console.WriteLine($"Resultado da funcão usado Linq : " + valorLinq + " Tempo " + s1.ElapsedMilliseconds);
            Console.WriteLine($"Resultado da funcão sem usar Linq :" + valorSemLinq + " Tempo " + s2.ElapsedMilliseconds);

            Console.WriteLine("_____________________________________________");
           
        }

    }
}
