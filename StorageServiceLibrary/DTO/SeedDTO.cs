using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageServiceLibrary.DTO
{
    public class SeedDTO
    {
      
        public int Id_Seed { get; set; }

        [Required(ErrorMessage = "ERROR: please fill the required fields (name).")]
        public string Name { get; set; } = string.Empty;
        public string? Note { get; set; } = string.Empty;
    }
}
