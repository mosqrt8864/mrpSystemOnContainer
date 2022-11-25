using AutoMapper;

namespace LayeredArchitecture.Commons.Mappings;
public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}