using AutoMapper;
using MakaanFrontToBack.DTOs.Agents;
using MakaanFrontToBack.Models;

namespace MakaanFrontToBack.Helpers.Mapper.Agents;

public class AgentsMapper : Profile
{
    public AgentsMapper()
    {
        CreateMap<CreateAgentDto, Agent>().ReverseMap();
    }
}
