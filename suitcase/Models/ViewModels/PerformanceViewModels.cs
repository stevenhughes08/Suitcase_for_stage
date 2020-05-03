using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using suitcase.Models;


namespace suitcase.Models.ViewModels 
{
    public class PerformanceDetailsViewModel
    {
      

        // public PerformanceDetailsViewModel(Performance performance)
        // {
        //     PerformanceId = performance.Id;
        //     PerformanceName = performance.Name;

        // }

        public Guid PerformanceId { get; set; }
        public string PerformanceName { get; set; }

        public List<ActDetailsViewModel> ActDetailsViewModels { get; set; }
    }

    public class ActDetailsViewModel
    {
        public Guid ActId { get; set; }
        public string ActName { get; set; }

        public string PerformerName { get; set; }

        public string PropName { get; set; }
    }
}
