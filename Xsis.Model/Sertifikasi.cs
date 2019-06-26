using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xsis.Model
{
    [Table("x_sertifikasi")]
    public class Sertifikasi
    {
        [Key]

        // ID AUTO INCREAMENT PRIMARY KEY
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long id { get; set; }

        public long created_by { get; set; }

        public Nullable<DateTime> created_on { get; set; }


        public Nullable<long> modified_by { get; set; }

        public Nullable<DateTime> modified_on { get; set; }


        public Nullable<long> deleted_by { get; set; }

        public Nullable<DateTime> deleted_on { get; set; }


        public Boolean is_delete { get; set; }


        public Nullable<long> biodata_id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(200)]
        public string certificate_name { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string publisher { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string valid_start_year { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string valid_start_month { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string until_year { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string until_month { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(1000)]
        public string notes { get; set; }
    }
}