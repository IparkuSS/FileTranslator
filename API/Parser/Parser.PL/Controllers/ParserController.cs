using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parser.BLL.Dtos;
using Parser.BLL.Services.Contracts;
using Parser.PL.Models;
using Parser.PL.Properties;
using Parser.PL.Services.Contracts;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Parser.PL.Controllers
{
    [Route("api/parser")]
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
                IParser factory = _parserFactory(fileVm.Extension);
                string contentText = factory.ReadContentFile(fileVm.DataBytes);
                var fileDto = _mapper.Map<FileVm, FileDto>(fileVm, opt =>
                {
                    opt.AfterMap((src, dest) =>
                    {
                        dest.DataText = contentText;
                    });
                });

                await _fileService.PostFile(fileDto);

            }
            catch (Exception ex)
            {
                Log.Error(string.Format(Resources.ErrorInPostParserFormat, ex.Message));

                return BadRequest(ex.Message);
            }


            return Ok();
        }

    }
}
