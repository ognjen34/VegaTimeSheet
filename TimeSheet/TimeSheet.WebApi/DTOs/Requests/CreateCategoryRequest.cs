using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.WebApi.DTOs.Requests
{
    public class CreateCategoryRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name {  get; set; }
    }
}
