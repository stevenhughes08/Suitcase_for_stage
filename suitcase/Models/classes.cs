using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace suitcase.Models
{
    
    public class BaseNamedEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public Guid Id { get; set; }

        [StringLength(80, ErrorMessage="The Length of a name cannot be longer than 80 Characters")]
        [Required]
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
        [Key]
        [Required]
         public Guid PropId { get; set; }

        [Display(Name = "Storage Location")]
        [Required]
        public string StorageLocation { get; set; }
        public ICollection<ActProp> ActProps { get; set; }
    }

     public class Act : BaseNamedEntity
    {
        [Display(Name = "Performance Id")]
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