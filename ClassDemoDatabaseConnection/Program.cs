// See https://aka.ms/new-console-template for more information
using ClassDemoDatabaseConnection;
using ClassDemoDatabaseConnection.model;

DBWorker worker = new DBWorker();


Console.WriteLine("====  Alle Personer ====");
List<Person> personer = worker.GetAll();
foreach (Person p in personer)
{
    Console.WriteLine(p);
}


Console.WriteLine("====  Person id 3 findes ====");
Console.WriteLine(worker.GetById(3));

Console.WriteLine("====  Person id 10 findes IKKE ====");
Console.WriteLine(worker.GetById(10));


Console.WriteLine("====  Opret Person ====");
Person person = new Person(-1,"Peter","66557744","Roskilde");
Console.WriteLine(worker.Create(person));

Console.WriteLine("====  Opdater Person ====");
Person UpdatePerson = new Person(person.Id, "Peter Levinsky", "66557744", "Roskilde");
Console.WriteLine(worker.Update(person.Id, UpdatePerson));

Console.WriteLine("====  Slet Person ====");
Console.WriteLine(worker.Delete(person.Id));


















