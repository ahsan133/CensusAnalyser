using CensusAnalyser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace CensusAnalyserTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenCensusCSVFile_WhenNumberOfRecordMatch_ThenItShouldReturnTrue()
        {
            string FILE_PATH = @"C:\Users\bridgelabz\Desktop\CensusAnalyser\CSV files\IndiaStateCensusData.csv";
            int CSVStateRecord = CSVStateCensus.GetCensusRecord(FILE_PATH);
            int StateCensusRecord = StateCensusAnalyser.GetStateCensusRecord(FILE_PATH);
            Assert.AreEqual(CSVStateRecord, StateCensusRecord);
        }

      
    }
}
