    using AutoMapper;
using Business.DTOs.Responses;
using Data.Entities;

namespace Business.Mappings;

public class IntentoEvaluacionProfile : Profile
{
    public IntentoEvaluacionProfile()
    {
        CreateMap<IntentoEvaluacion, IntentoEvaluacionDto>();
    }
}