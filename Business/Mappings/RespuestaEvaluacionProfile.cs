
using AutoMapper;
using Business.DTOs.Responses;
using Data.Entities;

namespace Business.Mappings;

public class RespuestaEvaluacionProfile : Profile
{
    public RespuestaEvaluacionProfile()
    {
        CreateMap<RespuestaEvaluacion, RespuestaEvaluacionDto>();
    }
}