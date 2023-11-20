using AutoMapper;
using SimpleLibraryApp.Core.Aggregates.AuthAggregates;

namespace SimpleLibraryApp.Service.Auth.Commands.Register;

public class Mapper: Profile
{
    public Mapper()
    {
        CreateMap<Command, User>().ReverseMap();
    }
}
