using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreativeAgency.Services
{
    public class MemoryService
    {
        private ILogger<MemoryService> _logger;

        public MemoryService(ILogger<MemoryService> logger)
        {
            _logger = logger;

        }

        public void BloatMemory()
        {

            List<string> items = new List<string>();
            string large = new string('?', 1000 * 512 * 1024); //1000 megabyte
            for (long i = 0; i < 10000000000; i++)
            {
                large = String.Join("*^", items.Select(i => i));
                items.Add(large);
                _logger.LogInformation("Extra Large object for {i}", i);
            }

        }

    }
}