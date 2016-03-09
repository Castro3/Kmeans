using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace K_Means
{
    class FileReader
    {
        private int lineCount;
        private List<double[]> data;

        /// <summary>
        /// Returns the data
        /// </summary>
        public List<double[]> getData
        {
            get
            {
                return data;
            }
        }

        /// <summary>
        /// Reads a file and adds them to our data
        /// </summary>
        /// <param name="filename">name of the file (with the extension) </param>
        /// <param name="delimiter">the character that delimits each file</param>
        public void getDataSet(string filename, char delimiter)
        {
            data = new List<double[]>();
            lineCount = 0;
            using (var reader = File.OpenText(filename))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }

            string[] AllLines = new string[lineCount];
            using (StreamReader sr = File.OpenText(filename))
            {
                int x = 0;
                while (!sr.EndOfStream)
                {
                    AllLines[x] = sr.ReadLine();
                    x += 1;
                }
            }
            Parallel.For(0, AllLines.Length, x =>
            {

                data.Add(convertToDouble(AllLines[x].Split(delimiter)));


            });
        }

        /// <summary>
        /// Converts an array of string to an array of double
        /// </summary>
        /// <param name="data">an aarra of string</param>
        /// <returns>an array of double</returns>
        private double[] convertToDouble(string[] data)
        {
            double[] newData = new double[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                try
                {
                    newData[i] = Convert.ToDouble(data[i]);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return newData;
        }
    }
}
