using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoWebApi.ViewModels
{
    public class CreateItemViewModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}