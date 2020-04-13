using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace suitcase.Models
{
    
    public class BaseNamedEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class Performer : BaseNamedEntity
    {
        public string HeadShotUrl { get; set; }
        public ICollection<ActPerformer> ActPerformers { get; set; }
    }

    public class Prop : BaseNamedEntity
    {   
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PropId { get; set; }
        public string StorageLocation { get; set; }
        public ICollection<ActProp> ActProps { get; set; }
    }

     public class Act : BaseNamedEntity
    {
        public Guid PerformanceId { get; set; }
        public Performance Performance { get; set; }
        public ICollection<ActPerformer> ActPerformers { get; set; }
        public ICollection<ActProp> ActProps { get; set; }
        
    }
    public class Performance : BaseNamedEntity
    {       
        public ICollection<Act> Acts { get; set; }

        public static implicit operator Performance(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class ActProp
    {
        public Guid ActId { get; set; }
        [ForeignKey("ActId")]
        public Act Act { get; set; }
        public Guid PropId { get; set; }
        [ForeignKey("PropId")]
        public Prop Prop { get; set; }
    
    }

    public class ActPerformer 
    {
      public Guid PerformerId { get; set; }
        [ForeignKey("PerformerId")]
        public Performer Performer { get; set; }
        public Guid ActId { get; set; }
        [ForeignKey("ActId")]
        public Act Act { get; set; }

    }

}