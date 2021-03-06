﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSHB.StockAssistanceProvider.Layers.L03_Services.Contracts;
using MSHB.StockAssistanceProvider.Layers.L04_ViewModels.InputForms;
using MSHB.StockAssistanceProvider.Presentation.WebCore;
using MSHB.StockAssistanceProvider.Shared.Common.GuardToolkit;

namespace MSHB.StockAssistanceProvider.Presentation.WebUI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [Authorize(Roles = "Report")]
    public class ReportController : BaseController
    {
        private IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
            _reportService.CheckArgumentIsNull(nameof(_reportService));

        }

        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Report-GetReportStructure")]
        public async Task<IActionResult> GetReportStructure([FromBody] ReportStructureFormModel reportStructureFormModel)
        {
            return Ok(GetRequestResult(await _reportService.GetReportStructureAsync(reportStructureFormModel)));
        }
        [HttpGet("[action]"), HttpPost("[action]")]
        [Authorize(Roles = "Report-AddOrUpdateReportStructure")]
        public async Task<IActionResult> UpdateReportStructure([FromBody] UpdateReportStructureFormModel form)
        {
            var result =
                await _reportService.AddOrUpdateReportStructureAsync(HttpContext.GetUser(), form);
            return Ok(GetRequestResult(result));
        }

      
    }
}
