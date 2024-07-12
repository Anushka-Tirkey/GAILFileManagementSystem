using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FILESMGMT.Models
{
    public class Files
    {
        [Key]
        public int FileId { get; set; }

        [NotMapped]
        public string FileName => $"{File_type.ToString().Substring(0, 3)}/{Open_Date:yyyy-MM-dd}/{Vendor_name}/{Contract_No}";
        //public string FileName => $"{File_type.ToString().Substring(0, 3)}/{Open_Date:yyyy-MM-dd}/{Vendor_name}/{Contract_No}/{FileId}";

        [Column("File Type", TypeName = "varchar(20)")]
        public File_type File_type { get; set; }

        [Column("Description", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "File description is required.")]
        public string Description { get; set; }
        [Column("Open_Date", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Open Date is required.")]
        public DateTime Open_Date { get; set; }
        [Column("Closed_Date", TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Closed Date is required.")]
        public DateTime Closed_Date { get; set; }
        [Column("Contract_No", TypeName = "int")]
        [Required(ErrorMessage = "Contract number is required.")]
        public int Contract_No { get; set; }
        [Column("Vendor_name", TypeName = "varchar(100)")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Vendor name must be between 3 and 15 characters.")]
        public string Vendor_name { get; set; }
        [Column("Vendor_address", TypeName = "varchar(100)")]
        [Required]
        public string Vendor_address { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [Column("Status", TypeName = "varchar(100)")]
        public string Status { get; set; }
    }

    public enum File_type
    {
        Miscellaneous, Approval, Warranty, AMC
    }
}
//using System;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Xml.Linq;

//namespace FILESMGMT.Models
//{
//    public class Files
//    {
//        [Key]
//        public int FileId { get; set; }

//        public string FileName => $"{File_type} - {Open_Date} - {Vendor_name} - {Contract_No} - {FileId}";

//        [Column("File Type", TypeName = "varchar(20)")]
//        public File_type File_type { get; set; }

//        [Column("Description", TypeName = "varchar(100)")]
//        [Required(ErrorMessage = "File description is required.")]
//        public string Description { get; set; }

//        //public long? FileSize { get; set; }

//        [Required(ErrorMessage = "Open Date is required.")]
//        public DateTime Open_Date { get; set; }

//        [Required(ErrorMessage = "Closed Date is required.")]
//        public DateTime Closed_Date { get; set; }

//        [Required(ErrorMessage = "Contract number is required.")]
//        public int Contract_No { get; set; }

//        [StringLength(15, MinimumLength = 3, ErrorMessage = "Vendor name must be between 3 and 15 characters.")]
//        public string Vendor_name { get; set; }

//        public string Vendor_address { get; set; }
//        //public string FilePath { get; set; }

//        [Required(ErrorMessage = "Status is required.")]
//        [Column("Status", TypeName = "varchar(100)")]
//        public string Status { get; set; }

//    }

//    public enum File_type
//    {
//        Miscellaneous, Approval, Warranty, AMC
//    }
//}
