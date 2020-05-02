using System.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace suitcase.Models
{
    
    public class BaseNamedEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }
       
    }

    public class Performer : BaseNamedEntity
    {
        public string HeadShotUrl { get; set; }
        public ICollection<ActPerformer> ActPerformers { get; set; }
    }

    public class Prop
    {   
        public Prop()
        {
            this.Acts = new HashSet<Act>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PropId { get; set; }
        [Required]

        [Display(Name="Prop Name")]
        public String Name { get; set; }
        [Required]



        [Display(Name = "Storage Location")]
        public string StorageLocation { get; set; }
        public ICollection<Act> Acts { get; set; }
    }

     public class Act : BaseNamedEntity
    {
        public Act()
        {
            this.Props = new HashSet<Prop>();
        }
        public Guid PerformanceId { get; set; }
        public Performance Performance { get; set; }
        public ICollection<Prop> Props { get; set; }
        public ICollection<Performance> Performances { get; set; }
        public ICollection<Performer> Performers {get; set; }
    
        
    }
    public class Performance : BaseNamedEntity
    {       
        public ICollection<Act> Acts { get; set; }
    }

    // public class ActProp
    // {
    //     public Guid ActId { get; set; }
    //     [ForeignKey("ActId")]
    //     public Act Act { get; set; }
    //     public Guid PropId { get; set; }
    //     [ForeignKey("PropId")]
    //     public Prop Prop { get; set; }
    
    // }

    // public class ActPerformer 
    // {
    //   public Guid PerformerId { get; set; }
    //     [ForeignKey("PerformerId")]
    //     public Performer Performer { get; set; }
    //     public Guid ActId { get; set; }
    //     [ForeignKey("ActId")]
    //     public Act Act { get; set; }

    // }

}