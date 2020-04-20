using System;
using System.Collections.Generic;


namespace suitcase.Models.ViewModels
{
    public class PerformanceDetailsViewModel
    {
        public Performance PerformanceName { get; set; }
    
        public List<ActDetailsViewModel> ActsDetails { get; set; }

    }

    public class ActDetailsViewModel
    {
        public Act ActName { get; set;}
        public List<ActPerformer> PerformerName { get; set; }

        public List<ActProp> Props { get; set; }

    }
}