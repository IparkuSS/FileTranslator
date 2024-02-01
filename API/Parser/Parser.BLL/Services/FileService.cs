using AutoMapper;
using Parser.BLL.Dtos;
using Parser.BLL.Services.Contracts;
using Parser.DAL.Interfaces.Uow;
using Parser.DAL.Models;

namespace Parser.BLL.Services
{
    public class FileService : IFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FileService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task PostFile(FileDto fileDto)
        {
            var fileDb = _mapper.Map<FileDto, FileDb>(fileDto);

            await _unitOfWork.FileRepository.PostFile(fileDb);
        }
    }
}
