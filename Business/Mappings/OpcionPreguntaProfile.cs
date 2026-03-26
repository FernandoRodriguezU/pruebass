using AutoMapper;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Data.Entities;

namespace Business.Mappings;

public class OpcionPreguntaProfile : Profile
{
    public OpcionPreguntaProfile()
    {
        CreateMap<CreateOpcionPreguntaDto, OpcionPregunta>();
        CreateMap<OpcionPregunta, OpcionPreguntaDto>();
    }
}