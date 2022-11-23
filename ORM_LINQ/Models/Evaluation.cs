using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_LINQ.Models {

    [Table(name:"evaluations")]
    public class Evaluation {
        [Key]
        [Column(name:"evaluation_id")]
        public int MyEvaluationId { get; set; }
        [Required]
        [MaxLength(2000)]
        [Column(name:"evaluation_text")]
        public string Text { get; set; }
        [Required]
        [Column(name:"stars")]
        public int Stars { get; set; }

        // Navigations-Property
        public Article Article { get; set; }
    }
}
