

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ORM_LINQ.Models;
using ORM_LINQ.Models.DB;

namespace ORM_LINQ {
    public class Program {

        // ORM ... Object Relation Mapper
        //      es werden die Objekte (Klassen, Instanzen in C#) auf Tabellen (Relationen) gemappt
        //      das Mapping macht der ORM (C#: EntityFramework)
        //  dadurch sind keine SQL-Befehle mehr notwendig (kein create tablem 

        private static async Task Main(string[] args) {
            using (EFContext dbContext = new EFContext()) {
                
                // WICHTIG: der neue Customer befindet sich nur im RAM
                //      aber noch nicht in der DAB-Tabelle
                dbContext.Customers.Add(new Customer() {
                    Firstname = "Niklas", Department = 'W', Lastname="Sillaber", Birthdate = new DateTime(2003, 9,18),
                    Gender = Gender.male, IsMale = true, Salary = 2091.09m, City = "Innsbruck"
                });
                
                await SaveToDB(dbContext);

                // Daten ändern - ID = 1
                await ChangeUserData(dbContext, 1);

                // Fabian Sillaber (ID=1) löschen
                Customer fabian = dbContext.Customers.Find(1);
                if(fabian != null) {
                    dbContext.Customers.Remove(fabian);
                    await SaveToDB(dbContext);
                    Console.WriteLine("Fabian wurde gelöscht!");
                } else {
                    Console.WriteLine("Person mit ID=1 existiert nicht!");
                }

                // 2 Artikel inkl. ein/mehrere Evaluations erzeugen
                // und in der DB abspeichern

                Article a1 = new Article { Name="Artikel 1"};
                Evaluation e1 = new Evaluation { Article = a1, Text = "Sehr gut", Stars = 5 };
                Evaluation e2 = new Evaluation { Article = a1, Text = "Gut", Stars = 3 };

                a1.Evaluations.Add(e1);
                a1.Evaluations.Add(e2);
                dbContext.Articles.Add(a1);

                await SaveToDB(dbContext);


                // Abfrage
                // den Artikel mit der Id=4 inkl. Evaluations suchen und ausgeben
                var article = dbContext.Articles.Where(a => a.ArticleId == 4).Select(a => new Article { ArticleId = a.ArticleId, Name = a.Name, Evaluations = a.Evaluations }).FirstOrDefault();

                if (article != null) {
                    Console.WriteLine($"{article.ArticleId} - {article.Name}");
                    foreach (var e in article.Evaluations) {
                        Console.WriteLine(e.Text);
                    }
                }
                

                // Lösung Lehrer
                // Include ... damit die angegebenen Daten der Tabelle Evaluations aus der DB
                //      geladen werden
                var articleLehrer = (from a in dbContext.Articles.Include(a => a.Evaluations)
                               where a.ArticleId == 4 
                               select a).FirstOrDefault();
                if (articleLehrer != null) {
                    Console.WriteLine($"{articleLehrer.ArticleId} - {articleLehrer.Name}");
                    foreach (var e in articleLehrer.Evaluations) {
                        Console.WriteLine(e.Text);
                    }
                } else {
                    Console.WriteLine("kein Artikel gefunden!");
                }

                // m: n verwenden

                Address ad1 = new Address { City = "Wiesing", PostalCode = "6210" };
                Address ad2 = new Address { City = "Innsbruck", PostalCode = "6020" };
                Customer c1 = new Customer { Firstname = "Fabian", Lastname = "Steinlechner",City="Wiesing", Gender = Gender.male, IsMale = true, };
                Customer c2 = new Customer { Firstname = "Niklas", Lastname = "Sillaber", City ="Innsbruck",Gender = Gender.male, IsMale = true, };
                Customer c3 = new Customer { Firstname = "Daniel", Lastname = "Unterwurzacher", City = "Innsbruck", Gender = Gender.male, IsMale = true, };
                Customer c4 = new Customer { Firstname = "Josef", Lastname = "Strillinger", City = "Innsbruck", Gender = Gender.male, IsMale = true, };
                ad1.Customers.Add(c1);
                ad1.Customers.Add(c2);
                ad2.Customers.Add(c3);
                ad2.Customers.Add(c4);

                c4.Addresses.Add(ad1);
                c4.Addresses.Add(ad2);

                dbContext.Customers.Add(c1);
                dbContext.Customers.Add(c2);
                dbContext.Customers.Add(c3);
                dbContext.Customers.Add(c4);
                dbContext.Addresses.Add(ad1);
                dbContext.Addresses.Add(ad2);
                await SaveToDB(dbContext);


                Bill b1 = new Bill { Date = new DateTime(2022, 10, 10) };
                Bill b2 = new Bill { Date = new DateTime(2022, 10, 10) };

                Article a10 = new Article { Name = "BillArticle" };

                Bill_Article bill_Article = new Bill_Article { Article = a10, Bill = b1, ActPrice = 2.5m};

                dbContext.Articles.Add(a10);
                dbContext.Bill.Add(b1);
                dbContext.Bill.Add(b2);
                dbContext.Bill_Articles.Add(bill_Article);
                await SaveToDB(dbContext);








            }

        }

        private static async Task ChangeUserData(EFContext context, int id) {

            Customer c = context.Customers.Find(id);

            // der Customer mit der angeg. Id wurde gefunden
            
            if(c != null) {
                // Daten wurden nur im RAM geändert
                c.Firstname = "Fabian";
                await SaveToDB(context);

            }

        }

        private static async Task SaveToDB(DbContext context) {
            try {
                // WICHTIG: erst mit SaveChanges() werden alle Änderungen, Löschungen, neue Datensätze, usw. 
                //      an die DB übertragen
                await context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                Console.WriteLine("Fehler: Auf die Daten wurde konkurrent zugegriffen!");
            } catch (DbUpdateException e) {
                Console.WriteLine("Fehler: Daten konnten nicht upgedatet werden!");
            } catch (OperationCanceledException) {
                Console.WriteLine("Fehler: Operation wurde abgebrochen!");
            }
        }
    }
}