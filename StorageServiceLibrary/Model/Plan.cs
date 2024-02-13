using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageServiceLibrary.Model
{
    public class Plan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_plan { get; set; }
        public string Id_User { get; set; }
        public DateTime Year { get; set; }

        public int FieldRefId { get; set; }
        [ForeignKey("FieldRefId")]
        public Field Field { get; set; }    // include

        public int CategoryRefId { get; set; }
        [ForeignKey("CategoryRefId")]
        public Category Category { get; set; }    // include

        public int ReproMaterialRefId { get; set; }
        [ForeignKey("ReproMaterialRefId")]
        public ReproMaterial ReproMaterial { get; set; }    // include
       
        public double Ha { get; set; }
        public double Ar { get; set; }
        public double M { get; set; }
        public double Yields { get; set; }
        public double Price { get; set; }
        public string? Note { get; set; } = string.Empty;
       

    }
}
