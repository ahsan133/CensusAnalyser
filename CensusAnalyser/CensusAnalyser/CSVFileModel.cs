﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public class CSVFileModel
    {
        public string State { get; set; }
        public string Population { get; set; }
        public string AreaInSqKm { get; set; }
        public string DensityPerSqKm { get; set; }
    }
}