using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Means
{
    class Cluster
    {
        private List<double[]> clusterData;

        public Cluster(List<double[]> data)
        {
            clusterData = data;
        }

        public List<double[]> getCluster()
        {
            return clusterData;
        }

        public bool CompareTo(object obj)
        {
            int similarityCounter = 0;
            Cluster other = (Cluster)obj;
            if (clusterData.Count != other.clusterData.Count)
            {
                return false;
            }
            for (int i = 0; i < clusterData.Count; i++)
            {
                for (int j = 0; j < other.getCluster().Count; j++)
                {
                    if (Enumerable.SequenceEqual(clusterData[i], other.getCluster()[j]))
                    {
                        similarityCounter++;
                    }
                }
            }
            return similarityCounter == clusterData.Count;
        }




    }
}
