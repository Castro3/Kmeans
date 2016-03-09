using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Means
{
    class Program
    {
        #region variables
        private List<String[]> maliste;
        #endregion

        static void Main(string[] args)
        {
            //List<Double[]> maliste = new List<double[]>
            //{
            //     {1, 2, 3, 4),
            //     ( 2, 3, 1, 5),
            //     ( 3, 6, 2, 4)
            //};

            List<int> digits = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //foreach (int truc in digits)
            //{
            //    Console.Write(truc);
            //    Console.Write(" ");
            //}

            int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

            //foreach (int nombre in array2D)
            //{
            //    Console.Write(nombre);
            //    Console.Write(" ");
            //}

            //Console.WriteLine(array2D[0,0]);
            //Console.WriteLine(array2D[1, 0]);
            //Console.WriteLine();
            //Console.WriteLine(array2D.Length);

            //int[] barycentre;

            //for (int i = 0; i < 4; i++)
            //{
            //    for (int j = 0; j < 2; j++)
            //    {
            //        //barycentre[j] = 1;
            //    }
            //}

            double[] array3;
            array3 = new double[] { 1, 3, 3, 0 };
            double[] array4;
            array4 = new double[] { 2, 3, 1, 3 };
            double[] array5;
            array5 = new double[] { 3, 0, 2, 3 };

            //foreach(double item in array3)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine();
            //}

            List<double[]> listee;
            listee = new List<double[]>();
            listee.Add(array3);
            listee.Add(array4);
            listee.Add(array5);

            //foreach(double[] listeDouble in listee)
            //{
            //    foreach(double nombre in listeDouble)
            //    {
            //        Console.Write(nombre + " ");
            //    }
            //    Console.Write("\n");
            //}

            double[] barycentre;
            Program a;
            a = new Program();
            barycentre = a.Barycentre(listee);

            Console.Write("Le barycentre test est : ");

            foreach(double nombre in barycentre)
            {
                Console.Write(nombre + " ");
            }

            Console.WriteLine('\n');

            double distance;
            Program b;
            b = new Program();
            distance = b.Distance(array3, barycentre);

            Console.WriteLine("La distance entre le premier point test et le barycentre test est : " + distance);

                Console.ReadKey();
        }

        //public String[] Barycentre(List<String[]> liste)
        //    {
        //        return ( "Hello", "World");
        //    }

        public double[] Barycentre(List<double[]> liste)
        {
            double[] bary;
            bary = new double[liste[0].Length];

            for(int i = 0; i < liste.Count; i++)
            {
                //for(int j = 0; j < liste[0].Length; j++)
                //{
                //    bary += liste[j];
                //}
                
                    for(int j = 0; j < liste[i].Length; j++)
                    {
                        bary[j] += liste[i][j];
                    }
                
            }

            for (int k = 0; k < bary.Length; k++)
            {
                bary[k] /= liste.Count;
            }

                return bary;
        }

        public double Distance(double[] point, double[] barycentre)
        {
            double distance = 0;

            for (int i = 0; i < point.Length; i++)
            {
                distance += Math.Pow(point[i] - barycentre[i], 2);
            }
            
            return distance;
        }

        public double Variance(List<double[]> liste)
        {
            return 0;
        }
    }
}
