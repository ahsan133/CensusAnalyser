using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CensusAnalyser
{
    public class CSVConvert
    {
        string path;
        public CSVConvert(string path)
        {
            this.path = path;
        }
        public string SortByState()
        {
            var list = JsonConvert.DeserializeObject<List<CensusDAO>>(CsvToJSON());
            var orderedList = list.OrderBy(x => x.State);
            return JsonConvert.SerializeObject(orderedList);
        }
        public string SortByStateCode()
        {
            var listOfStateCode = JsonConvert.DeserializeObject<List<CensusDAO>>(CsvToJSON());
            var descListOfStateCode = listOfStateCode.OrderBy(x => x.StateCode);
            return JsonConvert.SerializeObject(descListOfStateCode);
        }
        public string SortByStatePopullation()
        {
            var listOb = JsonConvert.DeserializeObject<List<CensusDAO>>(CsvToJSON());
            var sortedList = listOb.OrderBy(x => x.Population);
            return JsonConvert.SerializeObject(sortedList);
        }
        public string SortByStatePopullationDensity()
        {
            var listOb = JsonConvert.DeserializeObject<List<CensusDAO>>(CsvToJSON());
            var sortedList = listOb.OrderBy(x => x.DensityPerSqKm);
            return JsonConvert.SerializeObject(sortedList);
        }

        public string SortByStateLagestArea()
        {
            var listOb = JsonConvert.DeserializeObject<List<CensusDAO>>(CsvToJSON());
            var sortedList = listOb.OrderBy(x => x.AreaInSqKm);
            return JsonConvert.SerializeObject(sortedList);
        }

        public string SortUSCensusDataByPopulousState()
        {
            var listOb = JsonConvert.DeserializeObject<List<CSVUSSensusModel>>(CsvToJSON());
            var sortedList = listOb.OrderBy(x => x.Population);
            return JsonConvert.SerializeObject(sortedList);
        }

        public string SortUSCensusDataByPopulousDensity()
        {
            var listOb = JsonConvert.DeserializeObject<List<CSVUSSensusModel>>(CsvToJSON());
            var sortedList = listOb.OrderBy(x => x.PopulationDensity);
            return JsonConvert.SerializeObject(sortedList);
        }

        public string SortUSCensusDataByTotalArea()
        {
            var listOb = JsonConvert.DeserializeObject<List<CSVUSSensusModel>>(CsvToJSON());
            var sortedList = listOb.OrderBy(x => x.TotalArea);
            return JsonConvert.SerializeObject(sortedList);
        }

        public string SortUSCensusDataByWaterArea()
        {
            var listOb = JsonConvert.DeserializeObject<List<CSVUSSensusModel>>(CsvToJSON());
            var sortedList = listOb.OrderBy(x => x.WaterArea);
            return JsonConvert.SerializeObject(sortedList);
        }

        public string SortUSCensusDataByLandArea()
        {
            var listOb = JsonConvert.DeserializeObject<List<CensusDAO>>(CsvToJSON());
            var sortedList = listOb.OrderBy(x => x.LandArea);
            return JsonConvert.SerializeObject(sortedList);
        }

        public string CsvToJSON()
        {
            var csv = new List<string[]>();
            var lines = File.ReadAllLines(path);

            foreach (string line in lines)
                csv.Add(line.Split(','));

            var properties = lines[0].Split(',');

            var listObjResult = new List<Dictionary<string, string>>();

            for (int rows = 1; rows < lines.Length; rows++)
            {
                var objResult = new Dictionary<string, string>();
                for (int columns = 0; columns < properties.Length; columns++)
                    objResult.Add(properties[columns], csv[rows][columns]);

                listObjResult.Add(objResult);
            }

            return JsonConvert.SerializeObject(listObjResult);
        }

        public string MostPopulatedState()
        {
            string jsonFile;
            var listOb = JsonConvert.DeserializeObject<List<CensusDAO>>(CsvToJSON());
            if (path.EndsWith("IndiaStateCensusData.csv"))
            {
                var sortedList = listOb.OrderByDescending(x => x.Population).ThenByDescending(x => x.DensityPerSqKm);
                jsonFile = JsonConvert.SerializeObject(sortedList);
            }
            else
            {
                var sortedList = listOb.OrderByDescending(x => x.Population).ThenByDescending(x => x.PopulationDensity);
                jsonFile = JsonConvert.SerializeObject(sortedList);
            }
            
            JArray jArray = JArray.Parse(jsonFile);
            return jArray[0]["State"].ToString();
        }
    }
}
