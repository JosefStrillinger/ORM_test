using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_LINQ.Models {

    // Beispiel 2
    // 1:n-Beziehungen
    // ein Artikel kann beliebig viele Evaluation's haben
    // und eine Evaluation gehört genau zu einem Artikel


    public class Article {
        //PK
        public int ArticleId { get; set; }
        public string Name { get; set; }
        // usw.

        // Naviagtions-Property
        // aufgrund der List in Artikel erkennt EF, dass es sich um eine 1:n Beziehung handelt
        public List<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
        public List<Bill_Article> Bill_Articles { get; set; } = new List<Bill_Article>();

        // ctor + methoden
    }
}
