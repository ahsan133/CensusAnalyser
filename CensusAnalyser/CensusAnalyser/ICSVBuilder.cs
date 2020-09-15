using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public interface ICSVBuilder
    {
        public void CheckForException(char exceptionType);
    }
}
