using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Means
{
    class Program
    {

        static void Main(string[] args)
        {
            
            FileReader fileReader = new FileReader();
            Kmeans kmeans = new Kmeans();
            kmeans.checkSimilarityTest();

            Outils outils = new Outils();
            outils.test();
            
            Console.ReadKey();
        }

        
    }
}
