using Serilog.Events;

namespace CreativeAgency.Models
{
    class LogConfig
    {
        /// <summary>
        /// Yapılandırma dosyası bölüm adı
        /// </summary>
        public const string ENTRY_NAME = "Log";

        public LogEventLevel MinimumLevel { get; set; }

        public LogConfigSection ApplicationLog { get; set; }

        public LogConfigSection AuditLog { get; set; }
    }
}
