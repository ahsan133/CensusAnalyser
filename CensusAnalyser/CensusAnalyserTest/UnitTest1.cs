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
            CensusAnalyserException exception = Assert.ThrowsException<CensusAnalyserException>(() => CSVStateCensus.WrongPath(FILE_PATH, WRONG_FILEPATH));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILEPATH, exception.type);
        }

        [TestMethod]
        public void GivenIncorrectFileType_WhenCompiled_ThenReturnsException()
        {
            CensusAnalyserException exception = Assert.ThrowsException<CensusAnalyserException>(() => CSVStateCensus.GetCensusRecord(WRONG_FILETYPE));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILETYPE, exception.type);
        }

        [TestMethod]
        public void GivenIncorrectDelimiter_WhenCompiled_ThenReturnsException()
        {
            CensusAnalyserException exception = Assert.ThrowsException<CensusAnalyserException>(() => CSVStateCensus.GetCensusRecord(FILE_PATH));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.DELIMITER_INCORRECT, exception.type);
        }

        [TestMethod]
        public void GivenInvalidFileHeader_WhenCompiled_ThenReturnsException()
        {
            CensusAnalyserException exception = Assert.ThrowsException<CensusAnalyserException>(() => CSVStateCensus.GetFileHeader(FILE_PATH));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.HEADER_NOT_MATCH, exception.type);
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
            CensusAnalyserException exception = Assert.ThrowsException<CensusAnalyserException>(() => CSVStates.WrongPath(FILE_PATH, WRONG_FILEPATH));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILEPATH, exception.type);
        }

        [TestMethod]
        public void GivenIncorrectFileTypeAndCSVState_WhenCompiled_ThenReturnsException()
        {
            CensusAnalyserException exception = Assert.ThrowsException<CensusAnalyserException>(() => CSVStates.GetRecord(WRONG_FILETYPE));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILETYPE, exception.type);
        }

        [TestMethod]
        public void GivenIncorrectDelimiterAndCSVState_WhenCompiled_ThenReturnsException()
        {
            CensusAnalyserException exception = Assert.ThrowsException<CensusAnalyserException>(() => CSVStates.GetRecord(FILE_PATH));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.DELIMITER_INCORRECT, exception.type);
        }

        [TestMethod]
        public void GivenInvalidFileHeaderAndCSVState_WhenCompiled_ThenReturnsException()
        {
            CensusAnalyserException exception = Assert.ThrowsException<CensusAnalyserException>(() => CSVStates.GetFileHeader(FILE_PATH));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.HEADER_NOT_MATCH, exception.type);
        }
    }
}
