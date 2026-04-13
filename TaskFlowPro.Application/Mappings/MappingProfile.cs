using AutoMapper;
using TaskFlowPro.Application.DTOs;
using TaskFlowPro.Domain.Entities;

namespace TaskFlowPro.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TaskItem, TaskDto>().ReverseMap();
    }
}
