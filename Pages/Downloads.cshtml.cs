using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CreativeAgency.Pages
{
    public class DownloadsModel : PageModel
    {
        public void OnGet()
        {
            throw new FileNotFoundException("File not found");
        }
    }
}
