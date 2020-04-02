using Microsoft.AspNetCore.Http;
using MSHB.StockAssistanceProvider.Layers.L01_Entities.Models;
using MSHB.StockAssistanceProvider.Layers.L04_ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.StockAssistanceProvider.Layers.L03_Services.Contracts
{
    public interface IFileService
    {
        Task<Guid> UploadAsync(User user, IFormFile file);
        Task<DownloadViewModel> DownloadAsync(User user, Guid fileId);
    }
}
