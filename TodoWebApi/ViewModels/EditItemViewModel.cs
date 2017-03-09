using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoWebApi.ViewModels
{
    public class EditItemViewModel
    {
        [Required]
        public int? Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required]
        public bool IsComplete { get; set; }
    }
}