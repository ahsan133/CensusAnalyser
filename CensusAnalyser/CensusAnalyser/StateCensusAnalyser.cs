using System;
using System.Collections.Generic;
using System.IO;

namespace CensusAnalyser
{
    public class StateCensusAnalyser
    {
        public static int GetStateCensusRecord(string filePath)
        {
            try
            {
                int count = 0;
                string[] CensusData = File.ReadAllLines(filePath);
                List<string> recordsList = new List<string>();
                foreach (var elements in CensusData)
                {
                    count++;
                    recordsList.Add(elements);
                }

                return recordsList.Count - 1;
            }
            catch (DirectoryNotFoundException e)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILEPATH, e.Message);
            }
            catch (FileNotFoundException e)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INCORRECT_FILETYPE, e.Message);
            }
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
