using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_LINQ.Models {
    
    // Vereinfachung: nur automatische Properties
    //      keine normalen Prop., ctor's, ToString()

    // EF (EntityFramework) arbeitet mit Konventionen
    //      das bedeutet: es ist normalerweise keine Konfiguration notwendig, wenn man bestimmte Namenskonventionen einhält

    // Bsp1.: eine alleinstehende Tabelle (customers)


    // Convention over Configuration ... 
    //      es muss wenig konfiguriert werden, wenn man sich an die Konventionen hält
    //      z.B PK muss Klassenname*Id oder Id lauten
    //  man kann bei Bedarf aber trotzdem alles konfigurieren
    public class Customer {

        // PK: muss entweder Id oder <Klassenname>ID lauten
        public int CustomerId { get; set; } // DB: int und Name des Properties (CustomerID)
        public string Firstname { get; set; } // DB: varchar(max) - longtext, Firstname
        public string Lastname { get; set; } 
        public DateTime Birthdate { get; set; } // DB: datetime
        public bool IsMale { get; set; }    
        public decimal Salary { get; set; } 
        public char Department { get; set; }
        public Gender Gender { get; set; }

        public string City { get; set; }

        // Navigationsproperty
        public List<Address> Addresses { get; set; } = new List<Address>();

        // ctor's + ToString()

    }
}
