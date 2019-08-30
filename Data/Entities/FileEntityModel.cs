using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("Files")]
    public class FileEntityModel : IBaseModel
    {
        public int Id { get; set; }

        public string Data { get; set; }

        public FileDescriptorEntityModel Descriptor { get; set; }
    }
}
