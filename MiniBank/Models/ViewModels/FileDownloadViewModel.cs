using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Models.ViewModels
{
    public class FileDownloadViewModel
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public string FileContentType { get; set; }

        public string UniqueFileName { get; set; }
    }
}
