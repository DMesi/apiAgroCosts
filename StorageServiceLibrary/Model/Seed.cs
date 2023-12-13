using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageServiceLibrary.Model
{
    public class Seed
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Seed { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Note { get; set; } = string.Empty;
    }
}
