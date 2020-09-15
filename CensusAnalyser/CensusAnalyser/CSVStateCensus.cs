using System;
using System.Collections.Generic;
using System.IO;

namespace CensusAnalyser
{
    public class CSVStateCensus
    {
        public static int GetCensusRecord(string path)
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
