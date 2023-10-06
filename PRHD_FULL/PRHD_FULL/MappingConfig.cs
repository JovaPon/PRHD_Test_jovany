using AutoMapper;
using PRHD_FULL.Modelos;
using PRHD_FULL.Modelos.Dto;

namespace PRHD_FULL
{
    public class MappingConfig : Profile
    {

        public MappingConfig() 
        {
            CreateMap<Case, CaseDto>().ReverseMap();
            CreateMap<LaboratoryTest, LaboratoryTestDto>().ReverseMap();
            CreateMap<LaboratoryTestDto, LaboratoryTestServiceDto>().ReverseMap();
        }
        
    }
}
