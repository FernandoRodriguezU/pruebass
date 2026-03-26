using AutoMapper;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Data.Entities;

namespace Business.Mappings;

public class PreguntaEvaluacionProfile : Profile
{
    public PreguntaEvaluacionProfile()
    {
        CreateMap<CreatePreguntaEvaluacionDto, PreguntaEvaluacion>();
        CreateMap<PreguntaEvaluacion, PreguntaEvaluacionDto>();
    }
}