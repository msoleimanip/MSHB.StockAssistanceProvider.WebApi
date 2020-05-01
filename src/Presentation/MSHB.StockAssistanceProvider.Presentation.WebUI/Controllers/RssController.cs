using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Messages.Base;
using MSHB.StockAssistanceProvider.Layers.L00_BaseModels.exceptions;
using MSHB.StockAssistanceProvider.Layers.L04_ViewModels.ViewModels;

namespace MSHB.StockAssistanceProvider.Presentation.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RssController : BaseController
    {

        [HttpGet("[action]")]
        [ResponseCache(Duration = 300)]
        public async Task<IActionResult> GetNews()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://www.boursenews.ir/");
                // List all Names.    
                HttpResponseMessage response = client.GetAsync("fa/rss/14").Result;  // Blocking call!    
                if (response.IsSuccessStatusCode)
                {
                    string xmlString = await response.Content.ReadAsStringAsync();

                    XmlSerializer serializer = new XmlSerializer(typeof(Rss), new XmlRootAttribute("rss"));
                    StringReader stringReader = new StringReader(xmlString);
                    Rss rss = (Rss)serializer.Deserialize(stringReader);

                    return Ok(GetRequestResult(rss));
                }
                else
                    throw new StockAssistanceProviderGlobalException(RssServiceErrors.ConnectionError);
            }
            catch (Exception ex)
            {
                throw new StockAssistanceProviderGlobalException(RssServiceErrors.ConnectionError, ex);
            }
        }
    }
}