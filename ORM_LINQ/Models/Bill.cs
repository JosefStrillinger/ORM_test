using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_LINQ.Models {
    public class Bill {
        public int BillId { get; set; }
        public DateTime Date { get; set; }
        public List<Bill_Article> Bill_Articles { get; set; } = new List<Bill_Article>();

    }
}
