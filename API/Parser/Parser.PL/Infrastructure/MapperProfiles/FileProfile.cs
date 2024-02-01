using AutoMapper;
using Parser.BLL.Dtos;
using Parser.DAL.Models;
using Parser.PL.Models;

namespace Parser.PL.Infrastructure.MapperProfiles
{
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<FileDb, FileDto>().ReverseMap();
            CreateMap<FileVm, FileDto>().ReverseMap();
        }
    }
}

