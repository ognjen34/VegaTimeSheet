using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Domain.Models;

namespace TimeSheet.WebApi.DTOs.Requests
{
    public class UpdateClientRequest
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Adress { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string City { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Zip { get; set; }
        [Required]
        public string CountryId { get; set; }
    }
}
