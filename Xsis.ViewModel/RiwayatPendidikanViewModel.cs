using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xsis.ViewModel
{
    public class RiwayatPendidikanViewModel
    {
        public long id { get; set; }

        public long created_by { get; set; }

        public Nullable<DateTime> created_on { get; set; }


        public Nullable<long> modified_by { get; set; }

        public Nullable<DateTime> modified_on { get; set; }


        public Nullable<long> deleted_by { get; set; }

        public Nullable<DateTime> deleted_on { get; set; }


        public Boolean is_delete { get; set; }


        public Nullable<long> biodata_id { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string school_name { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string city { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string country { get; set; }

        public Nullable<long> education_level_id { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        public string entry_year { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        public string graduation_year { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string major { get; set; }

        public Nullable<double> gpa { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(1000)]
        public string notes { get; set; }


        public Nullable<int> order { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string judul_ta { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(5000)]
        public string deskripsi_ta { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        public string education_level_name { get; set; }  //tambahan untuk menyimpan nama
    }
}
