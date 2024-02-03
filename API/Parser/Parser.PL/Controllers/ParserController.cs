using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Parser.BLL.Dtos;
using Parser.BLL.Services.Contracts;
using Parser.PL.HttpClients;
using Parser.PL.Models;
using Parser.PL.Models.Settings;
using Parser.PL.Properties;
using Parser.PL.Services.Contracts;
using Serilog;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Parser.PL.Controllers
{
    [Route("api/parser")]
    [ApiController]
    public class ParserController : BaseController
    {
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly Func<string, IParser> _parserFactory;
        private readonly TranslatorSettings _translatorSettings;
        private readonly TranslatorHttpClient _translatorHttpClient;

        public ParserController(IFileService fileService, IMapper mapper,
            Func<string, IParser> parserFactory, IOptions<TranslatorSettings> translatorSettingsOptions,
            TranslatorHttpClient translatorHttpClient)
        {
            _fileService = fileService;
            _mapper = mapper;
            _parserFactory = parserFactory;
            _translatorSettings = translatorSettingsOptions.Value;
            _translatorHttpClient = translatorHttpClient;
        }

        [HttpPost]
        public async Task<IActionResult> PostFile(FileVm fileVm)
        {
            try
            {
                IParser factory = _parserFactory(fileVm.Extension);
                var contentTextFile = factory.ReadContentFile(fileVm.DataBytes);
                await PostFileInDb(fileVm, contentTextFile);

                var fileApiTranslator = await GetFileTranslatedText(contentTextFile, fileVm);
                var newByteData = factory.ModifyAndCreateDocument(fileVm.DataBytes, fileApiTranslator.DataText);

                return Ok(newByteData);
            }
            catch (Exception ex)
            {
                Log.Error(string.Format(Resources.ErrorInPostParserFormat, ex.Message));

                return BadRequest(ex.Message);
            }
        }

        private async Task PostFileInDb(FileVm fileVm, string contentText)
        {
            var fileDto = _mapper.Map<FileVm, FileDto>(fileVm, opt =>
            {
                opt.AfterMap((src, dest) =>
                {
                    dest.DataText = contentText;
                });
            });

            await _fileService.PostFile(fileDto);
        }

        private async Task<FileApiTranslator> GetFileTranslatedText(string contentTextFile, FileVm fileVm)
        {
            var fileApiTranslator = new FileApiTranslator
            {
                DataText = contentTextFile,
                TranslateLanguage = fileVm.TranslateLanguage
            };

            string json = JsonConvert.SerializeObject(fileApiTranslator);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await _translatorHttpClient.PostAsync(_translatorHttpClient.BaseAddress, httpContent);

            return await GetResult<FileApiTranslator>(response);
        }

    }
}
