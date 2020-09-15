using System;
using System.IO;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {
        public static int GetStateCensusRecord(string filePath)
        {
            string[] CensusData = File.ReadAllLines(filePath);
            return CensusData.Length - 1;
        }

        public static void PrintData(string filePath)
        {
            string[] numberOfRecords = File.ReadAllLines(filePath);
            foreach (var element in numberOfRecords)
            {
                Console.WriteLine(element);
            }
        }
    }
}
