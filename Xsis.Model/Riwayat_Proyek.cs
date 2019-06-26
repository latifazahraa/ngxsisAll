using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xsis.Model
{

    [Table("x_riwayat_proyek")]
    public class Riwayat_Proyek
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public long created_by { get; set; }

        [Column(TypeName = "DateTime")]
        [Required(AllowEmptyStrings = false)]
        public DateTime created_on { get; set; }

        public Nullable<long> modified_by { get; set; }

        [Column(TypeName = "DateTime")]
        public Nullable<DateTime> modified_on { get; set; }

        public Nullable<long> deleted_by { get; set; }

        [Column(TypeName = "DateTime")]
        public Nullable<DateTime> deleted_on { get; set; }

        public Boolean is_delete { get; set; }

        public long riwayat_pekerjaan_id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string start_year { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string start_month { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string project_name { get; set; }

        public Nullable<int> project_duration { get; set; }

        public Nullable<long> time_period_id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string client { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string project_position { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(1000)]
        public string description { get; set; }

    }
}