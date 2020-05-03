using suitcase.Models;
using suitcase.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace suitcase.Models.ViewModels
{
   public class InputFormsViewModel
   {
       public Performance Performance {get; set;}
       public Act Act { get; set; }

       public Performer Performer { get; set; }

       public Prop Prop { get; set; }

   }

}