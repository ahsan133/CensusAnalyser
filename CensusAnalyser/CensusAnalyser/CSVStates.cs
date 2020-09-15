using System.IO;

namespace CensusAnalyser
{
    public class CSVStates
    {
        public static int GetRecord(string path)
        {
            int count = 0;
            string[] CensusData = File.ReadAllLines(path);
            foreach (var data in CensusData)
            {
                count++;
            }
            return count - 1;
        }
    }
}
