using System;

namespace Zyfro.Pro.Server.Application.Models.Document
{
    public class DocumentMetadata
    {
        public string DocumentId { get; set; }
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string Version { get; set; }
        public string Date { get; set; }
        public string FileName { get; set; }
        public string Status { get; set; }
    }

}
