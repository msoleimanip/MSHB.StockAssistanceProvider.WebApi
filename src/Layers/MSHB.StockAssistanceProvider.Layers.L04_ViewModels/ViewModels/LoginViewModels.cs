using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSHB.StockAssistanceProvider.Layers.L04_ViewModels.ViewModels
{
    public class LoginViewModels
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
