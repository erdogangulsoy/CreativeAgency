using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreativeAgency.Models
{
    public class LogConfigSection
    {
        public string PathFormat { get; set; }
        public long FileSizeLimitBytes { get; set; }
        public int? RetainedFileCountLimit { get; set; }
    }
}
