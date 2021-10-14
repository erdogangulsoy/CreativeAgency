using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreativeAgency.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Context;

namespace CreativeAgency.Pages
{
    public class AboutModel : PageModel
    {
       
        
        private readonly MemoryService memoryService;
        

        

        public AboutModel(MemoryService memoryService)
        {
            
           
            this.memoryService = memoryService;
        }

        public void OnGet()
        {
           
            memoryService.BloatMemory();
           
            
        }
    }
}
