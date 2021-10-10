using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class StorageReference : BaseEntityWithAudit
    {
        public Guid RefId { get; set; }
        public Provider Provider { get; set; }
        public string FileName { get; set; }
        public string FileExtention { get; set; }
        public string ContentType { get; set; }
        public int FileSize { get; set; }
        public string Path { get; set; }
    }


    public enum Provider
    {
        AzureStorage,
        Aws,
        GCP,
        FileServer
    }
}
