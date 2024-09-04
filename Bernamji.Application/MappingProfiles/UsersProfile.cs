using AutoMapper;
using bernamji.Core.Entities;
using Bernamji.Application.Resources;

namespace Bernamji.Application.MappingProfiles;

public class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<User, UserResource>();
        //CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));
    }
}