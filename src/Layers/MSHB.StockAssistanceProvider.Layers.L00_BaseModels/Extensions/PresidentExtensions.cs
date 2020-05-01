using MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Constants.Authority;
using MSHB.StockAssistanceProvider.Layers.L01_Entities.Enums;
using MSHB.StockAssistanceProvider.Layers.L01_Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L00_BaseModels.Extensions
{
    public static class PresidentExtensions
    {
        public static bool IsAdmin(this User user)
        {
            return  user.UserType == UserType.Admin ? true : false;
        }
    }
}
