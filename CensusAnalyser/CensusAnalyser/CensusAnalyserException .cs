using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public class CensusAnalyserException : Exception
    {
        public ExceptionType type;

        public enum ExceptionType
        {
            INVALID_FILEPATH, INCORRECT_FILETYPE, DELIMITER_INCORRECT, HEADER_NOT_MATCH
        }
        
        public CensusAnalyserException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
