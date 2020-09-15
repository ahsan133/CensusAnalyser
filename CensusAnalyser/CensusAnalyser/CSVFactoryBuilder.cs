using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public class CSVFactoryBuilder : ICSVBuilder
    {
        public void CheckForException(char exceptionType)
        {
            switch (exceptionType)
            {
                case 'H':
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.HEADER_NOT_MATCH, "Invalid Header");
                case 'W':
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILEPATH, "Invalid File Path");
                case 'N':
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INCORRECT_FILETYPE, "Invalid File Name");
                case 'D':
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.DELIMITER_INCORRECT, "Delimiter Incorrect");
                default:
                    break;
            }
        }
    }
}
