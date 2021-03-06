﻿using Microsoft.EntityFrameworkCore;
using MSHB.StockAssistanceProvider.Layers.L00_BaseModels.exceptions;
using MSHB.StockAssistanceProvider.Layers.L02_DataLayer;
using MSHB.StockAssistanceProvider.Layers.L03_Services.Contracts;
using MSHB.StockAssistanceProvider.Layers.L04_ViewModels.InputForms;
using MSHB.StockAssistanceProvider.Layers.L04_ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Messages.Base;
using MSHB.StockAssistanceProvider.Shared.Common.GuardToolkit;
using MSHB.StockAssistanceProvider.Layers.L01_Entities.Models;
using System.Linq;
using MSHB.StockAssistanceProvider.Shared.Common.DateToolkit;
using MSHB.StockAssistanceProvider.Shared.Common.EnumToolkit;
using MSHB.StockAssistanceProvider.Layers.L01_Entities.Enums;
using DNTPersianUtils.Core;

namespace MSHB.StockAssistanceProvider.Layers.L03_Services.Impls
{
    public class ReportService : IReportService
    {
        private readonly StockAssistanceProviderDbContext _context;
        public ReportService(StockAssistanceProviderDbContext context)
        {
            _context = context;
            _context.CheckArgumentIsNull(nameof(_context));

        }

        public async Task<bool> AddOrUpdateReportStructureAsync(User user, UpdateReportStructureFormModel form)
        {
            try
            {
                var resp = await _context.ReportStructures.FirstOrDefaultAsync(c => c.Id == form.ReportStructureModelId || c.ReportId == form.ReportId);
                if (resp is null && form.ReportStructureModelId != 0)
                {
                    throw new StockAssistanceProviderGlobalException(ReportServiceErrors.ReportStructureNotFoundError);
                }
                if (resp != null)
                {
                    resp.Configuration = form.Configuration;
                    resp.LastUpdatedDateTime = DateTime.Now;
                    resp.ReportId = form.ReportId;
                    _context.ReportStructures.Update(resp);
                }
                else
                {
                    var report = new ReportStructure()
                    {
                        Configuration = form.Configuration,
                        CreationDate = DateTime.Now,
                        LastUpdatedDateTime = DateTime.Now,
                        ReportId = form.ReportId
                    };
                    await _context.ReportStructures.AddAsync(report);
                }
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {

                throw new StockAssistanceProviderGlobalException(ReportServiceErrors.UpdateReportStructureError, ex);
            }
        }
        public async Task<ReportStructureViewModel> GetReportStructureAsync(ReportStructureFormModel reportStructureFormModel)
        {
            try
            {
                var resp = await _context.ReportStructures.FirstOrDefaultAsync(c => c.ReportId == reportStructureFormModel.ReportId);
                if (resp is null)
                {
                    throw new StockAssistanceProviderGlobalException(ReportServiceErrors.ReportStructureNotFoundError);
                }
                return new ReportStructureViewModel()
                {
                    ReportStructureId = resp.Id,
                    Configuration = resp.Configuration,
                    CreationDate = resp.CreationDate,
                    ProtoType = resp.ProtoType,
                    LastUpdatedDateTime = resp.LastUpdatedDateTime,
                    ReportId = resp.ReportId
                };
            }
            catch (Exception ex)
            {

                throw new StockAssistanceProviderGlobalException(ReportServiceErrors.GetReportStructureError, ex);
            }
        }

    }
}
