using CensusAnalyser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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

        [TestMethod]
        public void GivenIncorrectPath_WhenCompiled_ThenReturnsException()
        {
            try
            {
                string FILE_PATH = @"C:\Users\bridgelabz\Desktop\CensusAnalyser";
                int CSVStateRecord = CSVStateCensus.GetCensusRecord(FILE_PATH);
                int StateCensusRecord = StateCensusAnalyser.GetStateCensusRecord(FILE_PATH);
                Assert.AreEqual(CSVStateRecord, StateCensusRecord);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILEPATH, ex.Message);
            }
        }

        [TestMethod]
        public void GivenIncorrectFileType_WhenCompiled_ThenReturnsException()
        {
            try
            {
                string FILE_PATH = @"C:\Users\bridgelabz\Desktop\CensusAnalyser\CSV files\IndiaStateCensusData.cs";
                int CSVStateRecord = CSVStateCensus.GetCensusRecord(FILE_PATH);
                int StateCensusRecord = StateCensusAnalyser.GetStateCensusRecord(FILE_PATH);
                Assert.AreEqual(CSVStateRecord, StateCensusRecord);
            }
            catch (FileNotFoundException ex)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INCORRECT_FILETYPE, ex.Message);
            }
        }

        [TestMethod]
        public void GivenIncorrectDelimiter_WhenCompiled_ThenReturnsException()
        {
            try
            {
                string FILE_PATH = @"C:\Users\bridgelabz\Desktop\CensusAnalyser\CSV files\IndiaStateCensusData.csV";
                int CSVStateRecord = CSVStateCensus.GetCensusRecord(FILE_PATH);
                int StateCensusRecord = StateCensusAnalyser.GetStateCensusRecord(FILE_PATH);
                Assert.AreEqual(CSVStateRecord, StateCensusRecord);
            }
            catch (IOException ex)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.DELIMITER_INCORRECT, ex.Message);
            }
        }

        [TestMethod]
        public void GivenInvalidFileHeader_WhenCompiled_ThenReturnsException()
        {
            try
            {
                string FILE_PATH = @"C:\Users\bridgelabz\Desktop\CensusAnalyser\CSV files\IndiaStateCensusData.csV";
                int CSVStateRecord = CSVStateCensus.GetCensusRecord(FILE_PATH);
                int StateCensusRecord = StateCensusAnalyser.GetStateCensusRecord(FILE_PATH);
                Assert.AreEqual(CSVStateRecord, StateCensusRecord);
            }
            catch (IOException ex)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.HEADER_NOT_MATCH, ex.Message);
            }
        }

        [TestMethod]
        public void GivenCensusCSVFileAndCSVState_WhenNumberOfRecordMatch_ThenItShouldReturnTrue()
        {
            string FILE_PATH = @"C:\Users\bridgelabz\Desktop\CensusAnalyser\CSV files\IndiaStateCode.csv";
            int CSVStateRecord = CSVStates.GetRecord(FILE_PATH);
            int StateCensusRecord = StateCensusAnalyser.GetStateCensusRecord(FILE_PATH);
            Assert.AreEqual(CSVStateRecord, StateCensusRecord);
        }

        public void GivenIncorrectPathAndCSVState_WhenCompiled_ThenReturnsException()
        {
            try
            {
                string FILE_PATH = @"C:\Users\bridgelabz\Desktop\CensusAnalyser";
                int CSVStateRecord = CSVStates.GetRecord(FILE_PATH);
                int StateCensusRecord = StateCensusAnalyser.GetStateCensusRecord(FILE_PATH);
                Assert.AreEqual(CSVStateRecord, StateCensusRecord);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILEPATH, ex.Message);
            }
        }
    }
}
