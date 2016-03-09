using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Means
{
    class Kmeans
    {
        #region functions
        public Kmeans(List<double[]> data, int nbcluster, int initial)
        {
            if (nbcluster > 1)
            {

            }
            else
            {
                Console.WriteLine("There's only 1 cluster....");
            }
        }

        private List<Cluster> initialisation(List<double[]> data, int nbcluster)
        {
            List<double[]> dataCopy = new List<double[]>(data);
            List<Cluster> clusterList = new List<Cluster>();
            int dataSize = data.Count;
            for (int i = nbcluster; i > 1; i--)
            {
                Random rnd = new Random();
                int clusterSize = rnd.Next(1, dataSize - nbcluster + 1);
                List<double[]> clusterData = new List<double[]>();
                for (int j = 0; j < clusterSize; j++)
                {
                    clusterData.Add(getAndRemove(dataCopy, rnd.Next(0, dataSize-2)));
                }
                clusterList.Add(new Cluster(clusterData));
                dataSize -= clusterSize;
            }
            clusterList.Add(new Cluster(dataCopy));

            return clusterList;
        }

        private double[] getAndRemove(List<double[]> data, int index)
        {
            double[] currentData = data.ElementAt(index);
            data.RemoveAt(index);
            return currentData;
        }

        private bool checkSimilarity(List<Cluster> clusterlist, List<Cluster> curCluster)
        {
            bool result = false;

            int similarityCounter = 0;
            for (int j = 0; j < clusterlist.Count; j++)
            {
                for (int k = 0; k < curCluster.Count; k++)
                {
                    if (clusterlist[j].CompareTo(curCluster[k]))
                    {
                        similarityCounter++;
                    }
                }
            }
            if (similarityCounter == curCluster.Count)
            {
                return true;
            }

            return result;
        }
        #endregion

        #region Test
        public Kmeans()
        {
        }

        public void initTest()
        {
            FileReader file = new FileReader();
            file.getDataSet("dataTest.txt", ',');
            List<double[]> data = file.getData;
            List<Cluster> clusterList = initialisation(data, 3);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\nCluster n" + i + 1);
                foreach (double[] dd in clusterList.ElementAt(i).getCluster())
                {
                    for (int j = 0; j < dd.Length - 1; j++)
                    {
                        Console.Write(dd[j] + ";");
                    }
                    Console.Write(dd[dd.Length - 1] + "\n");
                }
            }
        }

        public void checkSimilarityTest()
        {
            FileReader file = new FileReader();
            file.getDataSet("dataTest.txt", ',');
            List<double[]> data = file.getData;
            List<Cluster> clusterList = initialisation(data, 3);
            List<List<Cluster>> clusterPrec = new List<List<Cluster>>();
            clusterPrec.Add(clusterList);
            int counter = 0;
            for (int i = 0; i < 100; i++)
            {
                bool same = true;
                while (same)
                {
                    same = true;
                    List<Cluster> newList = initialisation(data, 3);
                    Console.WriteLine(i);
                    for (int j = 0; j < clusterPrec.Count; j++)
                    {
                        if (checkSimilarity(clusterPrec[j], newList))
                        {
                            counter++;
                        }
                        else
                        {
                            same = false;
                            clusterPrec.Add(newList);
                        }
                    }
                }

            }
            Console.WriteLine(counter);

        }
        #endregion
    }
}
