using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CreativeAgency.Pages
{
    public class PortfolioModel : PageModel
    {
        public void OnGet()
        {
            throw new ArgumentNullException("Portfolio ID bulunamadi");
        }
    }
}
