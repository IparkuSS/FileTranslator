using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Serilog;
using Translator.PL.Models;
using Translator.PL.Properties;

namespace Translator.PL.Controllers
{
    [Route("api/translator")]
    [ApiController]
    public class TranslatorController : ControllerBase
    {
        public TranslatorController() { }

        [HttpPost]
        public async Task<IActionResult> TranslateFile(FileVm fileVm)
        {
            try
            {
                var api = new OpenAI_API.OpenAIAPI("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");
                var result = await api.Chat.CreateChatCompletionAsync($"translate text to " +
                                                                      $"{fileVm.TranslateLanguage.GetDisplayName()}" +
                                                                      $"text - {fileVm.DataText}");



            }
            catch (Exception ex)
            {
                Log.Error(string.Format(Resources.ErrorInPostTranslateFormat, ex.Message));

                return BadRequest(ex.Message);
            }


            return Ok();
        }
    }
}
