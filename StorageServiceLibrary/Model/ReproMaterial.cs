using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageServiceLibrary.Model
{
    public class ReproMaterial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Repro { get; set; }
        public string Id_User { get; set; }

        public DateTime Year { get; set; }


        public int CategoryRefId { get; set; }
        [ForeignKey("CategoryRefId")]
        public Category Category { get; set; }

        public string Sort { get; set; } = string.Empty;

        public string UoM { get; set; } = string.Empty;

        public double Price { get; set; }

        public double Quantity { get; set; }

        public string? Note { get; set; } = string.Empty;
    }
}
