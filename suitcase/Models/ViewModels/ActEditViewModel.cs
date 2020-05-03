using System;
using System.Collections.Generic;
using suitcase.Models;

namespace suitcase.Models.ViewModels
{
    public class ActEditViewModel
    {
        public Guid Id { get; set; }
        public Guid ActId { get; set; }
        public String ActName { get; set; }
        public Prop PropName { get; set; } 
    }
}