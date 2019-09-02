using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class FileDownloadServiceModel : IBaseModel
    {
        public int Id { get; set; }

        public string Data { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public string FileContentType { get; set; }

        public string UniqueFileName { get; set; }
    }
}
