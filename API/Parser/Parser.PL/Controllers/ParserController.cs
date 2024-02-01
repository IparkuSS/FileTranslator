using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parser.BLL.Dtos;
using Parser.BLL.Services.Contracts;
using Parser.PL.Models;
using Parser.PL.Properties;
using Serilog;

namespace Parser.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParserController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public ParserController(IFileService fileService, IMapper mapper)
        {
            _fileService = fileService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostFile(FileVm fileVm)
        {
            try
            {
                var fileDto = _mapper.Map<FileVm, FileDto>(fileVm);
                await _fileService.PostFile(fileDto);

            }
            catch (Exception ex)
            {
                Log.Error(string.Format(Resources.ErrorInPostParserFormat, ex.Message));
            }


            return Ok();
        }

    }
}
