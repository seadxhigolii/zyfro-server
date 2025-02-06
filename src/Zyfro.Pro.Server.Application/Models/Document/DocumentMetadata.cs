namespace Zyfro.Pro.Server.Application.Models.Document
{
    public class DocumentMetadata
    {
        public string DocumentId { get; set; }
        public bool IsArchived { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
    }

}
