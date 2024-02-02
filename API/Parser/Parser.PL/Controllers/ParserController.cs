using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parser.BLL.Dtos;
using Parser.BLL.Services.Contracts;
using Parser.PL.Models;
using Parser.PL.Properties;
using Parser.PL.Services.Contracts;
using Serilog;

namespace Parser.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParserController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly Func<string, IParser> _parserFactory;

        public ParserController(IFileService fileService, IMapper mapper, Func<string, IParser> parserFactory)
        {
            _fileService = fileService;
            _mapper = mapper;
            _parserFactory = parserFactory;
        }

        [HttpPost]
        public async Task<IActionResult> PostFile(FileVm fileVm)
        {
            try
            {
                IParser factory = _parserFactory(Path.GetExtension(fileVm.Name));
                string contentText = factory.ReadContentFile(memStream);



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
