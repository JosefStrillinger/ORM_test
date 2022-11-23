using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_LINQ.Models {
    public class Bill_Article {
        public int Bill_ArticleId { get; set; }
        public Bill Bill { get; set; }
        public Article Article { get; set; }
        public decimal ActPrice { get; set; }

    }
}
