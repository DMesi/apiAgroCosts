﻿using StorageServiceLibrary.Model;
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


       
        public int Id_Field { get; set; }
        public string Id_User { get; set; }
        public string Field_number { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Ha { get; set; }
        public double Ar { get; set; }
        public double M { get; set; }
        public string? Link { get; set; } = string.Empty;
        public string? Note { get; set; } = string.Empty;

    }
}
