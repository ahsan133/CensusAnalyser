using CensusAnalyser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace CensusAnalyserTest
{
    [TestClass]
    public class UnitTest1
    {
        string FILE_PATH = @"C:\Users\bridgelabz\Desktop\CensusAnalyser\CSV files\IndiaStateCensusData.csv";
        string STATE_CODE_FILE_PATH = @"C:\Users\bridgelabz\Desktop\CensusAnalyser\CSV files\IndiaStateCode.csv";
        string US_SENSUS_FILE_PATH = @"C:\Users\bridgelabz\Desktop\CensusAnalyser\CSV files\USCensusData.csv";
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
            CensusAnalyserException exception = Assert.ThrowsException<CensusAnalyserException>(() => CSVStates.GetRecord(STATE_CODE_FILE_PATH));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.DELIMITER_INCORRECT, exception.type);
        }

        [TestMethod]
        public void GivenInvalidFileHeaderAndCSVState_WhenCompiled_ThenReturnsException()
        {
            CensusAnalyserException exception = Assert.ThrowsException<CensusAnalyserException>(() => CSVStates.GetFileHeader(STATE_CODE_FILE_PATH));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.HEADER_NOT_MATCH, exception.type);
        }

        [TestMethod]
        public void GivenIndianStateCensusData_WhenLoaded_ThenShouldReturnStateSortedResult()
        {
            CSVConvert jsonState = new CSVConvert(FILE_PATH);
            string jsonData = jsonState.SortByState();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["State"].ToString();
            Assert.AreEqual("Andhra Pradesh", firstValueFromCsv);
        }

        [TestMethod]
        public void GivenIndianStateCodeData_WhenLoaded_ThenShouldReturnStateSortedResult()
        {
            CSVConvert jsonState = new CSVConvert(STATE_CODE_FILE_PATH);
            string jsonData = jsonState.SortByState();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["StateCode"].ToString();
            Assert.AreEqual("AD", firstValueFromCsv);
        }

        [TestMethod]
        public void GivenIndianStateCodeData_WhenLoaded_ThenShouldReturnSortedResultByPopulation()
        {
            CSVConvert jsonState = new CSVConvert(FILE_PATH);
            string jsonData = jsonState.SortByStatePopullation();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["Population"].ToString();
            Assert.AreEqual("1052567", firstValueFromCsv);
        }

        [TestMethod]
        public void GivenIndianStateCodeData_WhenLoaded_ThenShouldReturnSortedResultByPopulationDensity()
        {
            CSVConvert jsonState = new CSVConvert(FILE_PATH);
            string jsonData = jsonState.SortByStatePopullationDensity();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["DensityPerSqKm"].ToString();
            Assert.AreEqual("1029", firstValueFromCsv);
        }

        [TestMethod]
        public void GivenIndianStateCodeData_WhenLoaded_ThenShouldReturnSortedResultByArea()
        {
            CSVConvert jsonState = new CSVConvert(FILE_PATH);
            string jsonData = jsonState.SortByStatePopullationDensity();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["AreaInSqKm"].ToString();
            Assert.AreEqual("3702", firstValueFromCsv);
        }

        [TestMethod]
        public void UCStateCodeData_WhenLoaded_ThenShouldReturnSortedResultByPopulation()
        {
            CSVConvert jsonState = new CSVConvert(US_SENSUS_FILE_PATH);
            string jsonData = jsonState.SortUSCensusDataByPopulousState();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["Population"].ToString();
            Assert.AreEqual("1052567", firstValueFromCsv);
        }

        [TestMethod]
        public void UCStateCodeDataPopulationDensity_WhenLoaded_ThenShouldReturnSortedResultByPopulationDensity()
        {
            CSVConvert jsonState = new CSVConvert(US_SENSUS_FILE_PATH);
            string jsonData = jsonState.SortUSCensusDataByPopulousDensity();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["PopulationDensity"].ToString();
            Assert.AreEqual("0.46", firstValueFromCsv);
        }

        [TestMethod]
        public void UCStateCodeDataTotalArea_WhenLoaded_ThenldReturnSortedResultByTotalArea()
        {
            CSVConvert jsonState = new CSVConvert(US_SENSUS_FILE_PATH);
            string jsonData = jsonState.SortUSCensusDataByTotalArea();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["TotalArea"].ToString();
            Assert.AreEqual("104655.80", firstValueFromCsv);
        }

        [TestMethod]
        public void UCStateCodeDataWaterArea_WhenLoaded_ThenShouldReturnSortedResultByWaterArea()
        {
            CSVConvert jsonState = new CSVConvert(US_SENSUS_FILE_PATH);
            string jsonData = jsonState.SortUSCensusDataByWaterArea();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["WaterArea"].ToString();
            Assert.AreEqual("1026.21", firstValueFromCsv);
        }

        [TestMethod]
        public void UCStateCodeDataLandArea_WhenLoaded_ThenShouldReturnSortedResultByLandArea()
        {
            CSVConvert jsonState = new CSVConvert(US_SENSUS_FILE_PATH);
            string jsonData = jsonState.SortUSCensusDataByWaterArea();
            JArray jArray = JArray.Parse(jsonData);
            string firstValueFromCsv = jArray[0]["LandArea"].ToString();
            Assert.AreEqual("294207.53", firstValueFromCsv);
        }
    }
}
