using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Means
{
    /// <summary>
    /// This class contains the tools functions, that is to say what we'll use to perform some steps of K-Means algorithm.
    /// </summary>
    class Outils
    {
        #region functions

        /// <summary>
        /// This functions computes the barycentre of a cluster.
        /// </summary>
        /// <param name="cluster">This is the cluster which we're going to compute the barycentre.</param>
        /// <returns>The function returns an array of double, each double value is a coordinate of the barycentre
        /// (the number of coordinates depends on the dimension of the cluster), the final array is the barycentre.</returns>
        public double[] Barycentre(Cluster cluster)
        {
            double[] bary;
            List<double[]> liste = cluster.getCluster();
            bary = new double[liste[0].Length];

            for (int i = 0; i < liste.Count; i++)
            {
                //for(int j = 0; j < liste[0].Length; j++)
                //{
                //    bary += liste[j];
                //}

                for (int j = 0; j < liste[i].Length; j++)
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

        /// <summary>
        /// This functions computes the distance between a point in a cluster and the associated barycentre.
        /// </summary>
        /// <param name="point">This array of double is a point (each double is a coordinate and the array is the point).</param>
        /// <param name="barycentre">This array of double is a barycentre (each double is a coordinate and the array is the barycentre).</param>
        /// <returns>The function returns a double, that is the distance between the point and the barycentre passed in parameters.</returns>
        public double Distance(double[] point, double[] barycentre)
        {
            double distance = 0;

            for (int i = 0; i < point.Length; i++)
            {
                distance += Math.Pow(point[i] - barycentre[i], 2);
            }

            return distance;
        }

        /// <summary>
        /// This functions computes the variance of our repartition of clusters.
        /// We first calculate the dispersion intra-class of each cluster.
        /// We then do the sum of all these dispersions intra-class in order to get the final dispersion intra-class.
        /// This final DIC is the variance.
        /// </summary>
        /// <param name="liste">This is a list of clusters that describes the repartition generated in the first step of the algorithm.
        /// Indeed, each cluster in this list is a cluster containing its own points.</param>
        /// <returns>The function returns a double, that is the variance.</returns>
        public double Variance(List<Cluster> liste)
        {
            double variance = 0;
            List<double[]> truc;

            foreach(Cluster cluster in liste)
            {
                truc = cluster.getCluster();

                foreach(double[] point in truc)
                {
                    variance += Distance(point, Barycentre(cluster));
                }
            }

            return variance;
        }
        #endregion

        #region test
        public void test()
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
            Cluster cluster = new Cluster(listee);
            //foreach(double[] listeDouble in listee)
            //{
            //    foreach(double nombre in listeDouble)
            //    {
            //        Console.Write(nombre + " ");
            //    }
            //    Console.Write("\n");
            //}

            double[] barycentre;
            barycentre = Barycentre(cluster);

            Console.Write("Le barycentre test est : ");

            foreach (double nombre in barycentre)
            {
                Console.Write(nombre + " ");
            }

            Console.WriteLine('\n');

            double distance;
            distance = Distance(array3, barycentre);

            Console.WriteLine("La distance entre le premier point test et le barycentre test est : " + distance);

            Console.WriteLine('\n');

            List<Cluster> liste = new List<Cluster>();
            List<double[]> liste1 = new List<double[]>();
            List<double[]> liste2 = new List<double[]>();
            liste1.Add(array3);
            liste1.Add(array4);
            liste2.Add(array5);
            Cluster cluster1 = new Cluster(liste1);
            Cluster cluster2 = new Cluster(liste2);
            liste.Add(cluster1);
            liste.Add(cluster2);

            double variance = Variance(liste);
            Console.WriteLine("La variance test est : " + variance);

            Console.ReadKey();
        }
        #endregion
    }
}
