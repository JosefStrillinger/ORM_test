using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_LINQ.Models {
    

    // m:n-Beziehungen
    // SQL: müssen immer in 2 1:n Beziehungen aufgelöst werden

    // 2 Fälle 
    //      1.Fall: wenn in der Zwischentaelle keine zusätzlichen Felder notwendig sind, muss keine Zwischenklasse erzeugt werden
    //      2. Fall: werden in der Zwischentabelle weitere Felder benötigt, muss die Zwischenklasse programmiert werden

    // m:n zwischen Customer und Address
    //      ein Customer kann mehrere Adressen angeben und an einer Adresse können mehrere Customer leben
    // es sind keine Zusatzfelder in der Zwischentabelle notwendig
    
    // => es ist pro Klasse (Customer und Address) jeweils eine Liste der gegenüberliegenden Klasse notwendig
    public class Address {

        public int MyAddressId { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        // usw. 

        // Navigationsproperty
        public List<Customer> Customers { get; set; } = new List<Customer>();

    }
}
