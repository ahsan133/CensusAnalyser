using CensusAnalyser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace CensusAnalyserTest
{
    [TestClass]
    public class UnitTest1
    {
        string FILE_PATH = @"C:\Users\bridgelabz\Desktop\CensusAnalyser\CSV files\IndiaStateCensusData.csv";
        string STATE_CODE_FILE_PATH = @"C:\Users\bridgelabz\Desktop\CensusAnalyser\CSV files\IndiaStateCode.csv";
        private string WRONG_FILEPATH = @"C:\Users\bridgelabz\Desktop\CensusAnalyser";
        private string WRONG_FILETYPE = @"C:\Users\bridgelabz\Desktop\CensusAnalyser\CSV files\IndiaStateCensusData.cs";

        [TestMethod]
        public void GivenCensusCSVFile_WhenNumberOfRecordMatch_ThenItShouldReturnTrue()
        {
            int CSVStateRecord = CSVStateCensus.GetCensusRecord(FILE_PATH);
            int StateCensusRecord = StateCensusAnalyser.GetStateCensusRecord(FILE_PATH);
            Assert.AreEqual(CSVStateRecord, StateCensusRecord);
        }

        [TestMethod]
        public void GivenIncorrectPath_WhenCompiled_ThenReturnsException()
        {
            try
            {
                int CSVStateRecord = CSVStateCensus.GetCensusRecord(WRONG_FILEPATH);
                int StateCensusRecord = StateCensusAnalyser.GetStateCensusRecord(WRONG_FILEPATH);
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
                int CSVStateRecord = CSVStateCensus.GetCensusRecord(WRONG_FILETYPE);
                int StateCensusRecord = StateCensusAnalyser.GetStateCensusRecord(WRONG_FILETYPE);
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

            int CSVStateRecord = CSVStates.GetRecord(FILE_PATH);
            int StateCensusRecord = StateCensusAnalyser.GetStateCensusRecord(STATE_CODE_FILE_PATH);
            Assert.AreEqual(CSVStateRecord, StateCensusRecord);
        }

        [TestMethod]
        public void GivenIncorrectPathAndCSVState_WhenCompiled_ThenReturnsException()
        {
            try
            {
                int CSVStateRecord = CSVStates.GetRecord(WRONG_FILEPATH);
                int StateCensusRecord = StateCensusAnalyser.GetStateCensusRecord(WRONG_FILEPATH);
                Assert.AreEqual(CSVStateRecord, StateCensusRecord);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_FILEPATH, ex.Message);
            }
        }

        [TestMethod]
        public void GivenIncorrectFileTypeAndCSVState_WhenCompiled_ThenReturnsException()
        {
            try
            {
                int CSVStateRecord = CSVStates.GetRecord(WRONG_FILETYPE);
                int StateCensusRecord = StateCensusAnalyser.GetStateCensusRecord(WRONG_FILETYPE);
                Assert.AreEqual(CSVStateRecord, StateCensusRecord);
            }
            catch (FileNotFoundException ex)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INCORRECT_FILETYPE, ex.Message);
            }
        }

        [TestMethod]
        public void GivenIncorrectDelimiterAndCSVState_WhenCompiled_ThenReturnsException()
        {
            try
            {
                int CSVStateRecord = CSVStates.GetRecord(STATE_CODE_FILE_PATH);
                int StateCensusRecord = StateCensusAnalyser.GetStateCensusRecord(STATE_CODE_FILE_PATH);
                Assert.AreEqual(CSVStateRecord, StateCensusRecord);
            }
            catch (Exception ex)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.DELIMITER_INCORRECT, ex.Message);
            }
        }

        [TestMethod]
        public void GivenInvalidFileHeaderAndCSVState_WhenCompiled_ThenReturnsException()
        {
            try
            {
                int CSVStateRecord = CSVStates.GetRecord(STATE_CODE_FILE_PATH);
                int StateCensusRecord = StateCensusAnalyser.GetStateCensusRecord(STATE_CODE_FILE_PATH);
                Assert.AreEqual(CSVStateRecord, StateCensusRecord);
            }
            catch (Exception ex)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.HEADER_NOT_MATCH, ex.Message);
            }
        }
    }
}
