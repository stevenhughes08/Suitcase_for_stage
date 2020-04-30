using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace suitcase.Models
{
    
    public class BaseNamedEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        public string Name { get; set; }
    }

    public class Performer : BaseNamedEntity
    {
        public string HeadShotUrl { get; set; }
        public ICollection<ActPerformer> ActPerformers { get; set; }
    }

    public class Prop : BaseNamedEntity
    {   
<<<<<<< HEAD
        
        // public Guid PropId { get; set; }

        [Display(Name = "Storage Location")]
=======
        public Guid PropId { get; set; }
>>>>>>> parent of 5d9934e... Working with the view Model
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
    }

    public class ActProp
    {
        public Guid ActId { get; set; }
        [ForeignKey("Act.Id")]
        public Act Act { get; set; }
        public Guid PropId { get; set; }
        [ForeignKey("Prop.Id")]
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