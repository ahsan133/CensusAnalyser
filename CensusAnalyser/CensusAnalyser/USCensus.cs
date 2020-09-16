using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class USCensus
    {
        public static void GetUSCensusData(string path)
        {
            if (!path.EndsWith(".csv"))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INCORRECT_FILETYPE, "Invalid File Name");
            }

            string[] CensusData = File.ReadAllLines(path);
            foreach (var element in CensusData)
            {
                Console.WriteLine(element);
            }
        }
    }
}
