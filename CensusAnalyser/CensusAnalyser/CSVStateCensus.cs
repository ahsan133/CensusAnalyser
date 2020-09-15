using System;
using System.Collections.Generic;
using System.IO;

namespace CensusAnalyser
{
    public class CSVStateCensus
    {
        public static int GetCensusRecord(string path)
        {
            if (!path.EndsWith(".csv"))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INCORRECT_FILETYPE, "Invalid File Name");
            }
            int count = 0;
            string[] CensusData = File.ReadAllLines(path);
            foreach (var data in CensusData)
            {
                if (!data.Contains(":"))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.DELIMITER_INCORRECT, "Delimeter is Incorrect ");
                }
                count++;
            }
            return count - 1; 
        }

        public static void WrongPath(string path, string wrongPath)
        {
            if (path != wrongPath)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILEPATH, "Invalid File Path");
            }
        }  

        public static void GetFileHeader(string filePath)
        {
            string[] csvData = File.ReadAllLines(filePath);
            string CSV_DATA_HEADER = "State, Population, AreaInSqKm, DensityPerSqKm";
            if (csvData[0] != CSV_DATA_HEADER)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.HEADER_NOT_MATCH, "Header Invalid");
            }
        }
    }
}
