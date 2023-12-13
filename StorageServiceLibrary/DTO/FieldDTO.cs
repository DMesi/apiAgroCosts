using StorageServiceLibrary.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageServiceLibrary.DTO
{
    public class FieldDTO
    {
        
        public int Id_plan { get; set; }
        public DateTime Year { get; set; }

        public string FieldRefId { get; set; }
        [ForeignKey("FieldRefId")]
        public Field Field { get; set; }    // include

        public int SeedRefId { get; set; }
        [ForeignKey("SeedRefId")]
        public Seed Seed { get; set; }    // include
        public double Ha { get; set; }
        public double J { get; set; }
        public string? Note { get; set; } = string.Empty;

    }
}
