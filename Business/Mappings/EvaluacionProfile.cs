using AutoMapper;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Data.Entities;

namespace Business.Mappings;

public class EvaluacionProfile : Profile
{
    public EvaluacionProfile()
    {
        CreateMap<CreateEvaluacionDto, Evaluacion>();
        CreateMap<Evaluacion, EvaluacionDto>();
        CreateMap<Evaluacion, EvaluacionDetalleDto>();
    }
}