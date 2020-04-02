using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSHB.StockAssistanceProvider.Layers.L03_Services.Contracts;
using MSHB.StockAssistanceProvider.Presentation.WebCore;
using MSHB.StockAssistanceProvider.Presentation.WebUI.filters;
using MSHB.StockAssistanceProvider.Shared.Common.GuardToolkit;

namespace MSHB.StockAssistanceProvider.Presentation.WebUI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [Authorize(Roles = "File")]
    public class FileController : BaseController
    {

        private IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
            _fileService.CheckArgumentIsNull(nameof(_fileService));
        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "File-UploadFile")]
        [DisableRequestSizeLimit]

        public async Task<IActionResult> Upload(IFormFile file)
        {
            return Ok(GetRequestResult(await _fileService.UploadAsync(HttpContext.GetUser(), file)));
        }
        [HttpGet("[action]/{fileId}"), HttpPost("[action]/{fileId}")]
        [AllowAnonymous]

        public async Task<IActionResult> Download(Guid fileId)
        {
            var response = await _fileService.DownloadAsync(HttpContext.GetUser(), fileId);
            if (response.Memory is null)
                return Ok();
            return File(response.Memory, response.ContentType, response.FileName,true);


        }


    }
}