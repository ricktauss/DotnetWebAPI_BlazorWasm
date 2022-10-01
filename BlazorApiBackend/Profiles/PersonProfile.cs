using AutoMapper;

namespace WebApiBackend.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Task<Person>, Task<PersonDto>>();
            CreateMap<Task<IEnumerable<Person>>, Task<IEnumerable<PersonDto>>>();
        }
    }
}
