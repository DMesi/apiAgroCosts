using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageServiceLibrary.DTO
{
    public class CategoryDTO
    {

        
        public int Id_Category { get; set; }

        public int TypeCategory { get; set; }   // 1 CategorySeed , 2 CategoryProtection, 3 CategoryFuel, 4 fertilizer, 5 other

        public string TypeCategoryName { get; set; } = string.Empty; //CategorySeed ...

        public int SubTypeCegory { get; set; }

        public string SubTypeCegoryName { get; set; } = string.Empty; // Corn, Wheat, Soyabeen



    }
}
