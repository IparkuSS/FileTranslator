using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Parser.PL.Controllers
{
    public class BaseController : ControllerBase
    {
        protected async Task<T> GetResult<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<T>();

                return content;
            }

            var contentError = await response.Content.ReadAsStringAsync();

            throw new Exception(contentError);
        }
    }
}
