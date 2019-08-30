using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("FileDescriptor")]
    public class FileDescriptorEntityModel : IBaseHistory
    {
        [Key]
        public int Id { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        [Required]
        public string UniqueFileName { get; set; }

        [ForeignKey("File")]
        public int FileId { get; set; }
        public FileEntityModel File { get; set; }

        [ForeignKey("CreatedByUser")]
        public int? CreatedById { get; set; }
        public UserDbRepoModel CreatedByUser { get; set; }
        public DateTime DateCreated { get; set; }

        [ForeignKey("EditedByUser")]
        public int? EditedById { get; set; }
        public UserDbRepoModel EditedByUser { get; set; }
        public DateTime? DateEdited { get; set; }
    }
}
