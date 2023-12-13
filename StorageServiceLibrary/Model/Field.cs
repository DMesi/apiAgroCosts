using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageServiceLibrary.Model
{
    public class Field
    {

        [Key]
        public string Id_Field { get; set; }        
        public string Name { get; set; } = string.Empty;
        public double Ha { get; set; }
        public double J { get; set; }
        public string Link { get; set; } = string.Empty;
        public string? Note { get; set; } = string.Empty;

    }
}
