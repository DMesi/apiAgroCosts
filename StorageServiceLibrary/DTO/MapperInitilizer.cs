using AutoMapper;
using StorageServiceLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageServiceLibrary.DTO
{
    public class MapperInitilizer : Profile
    {

        public MapperInitilizer() {

            CreateMap<Field, FieldDTO>().ReverseMap();
            CreateMap<Plan, PlanDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<ReproMaterial, ReproMaterialDTO>().ReverseMap();
           
        }   
    }
}
