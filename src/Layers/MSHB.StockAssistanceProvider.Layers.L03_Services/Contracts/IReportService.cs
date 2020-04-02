using MSHB.StockAssistanceProvider.Layers.L01_Entities.Models;
using MSHB.StockAssistanceProvider.Layers.L04_ViewModels.InputForms;
using MSHB.StockAssistanceProvider.Layers.L04_ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.StockAssistanceProvider.Layers.L03_Services.Contracts
{
    public interface IReportService
    {
        Task<ReportStructureViewModel> GetReportStructureAsync(ReportStructureFormModel reportStructureFormModel);
        Task<bool> AddOrUpdateReportStructureAsync(User user, UpdateReportStructureFormModel form);
    }
}
