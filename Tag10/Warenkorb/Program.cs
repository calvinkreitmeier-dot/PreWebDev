using AufgabeWarenkorb;

namespace Warenkorb;

class Program
{
    public static void Aufgabe1()
    {
    Kunde[] kunden = Kunde.GetKundenListe();
	Produkt[] produkte = Produkt.GetProduktListe();
    var kundennamen = kunden.Select(kunde => (kunde.Name,kunde.Ort) );
    var deutschebestellungen = kunden.Where(kunde => kunde.Land == Länder.Germany).Select(kunde => kunde);
    var jederzweite = kunden.Where((kunde, idx) => idx % 2 == 1);
    var sortiertunter20 = produkte.Where(produkt => produkt.Preis < 20).OrderByDescending(produkt => produkt.Preis);
    var namelandsort = kunden.OrderBy(kunde => kunde.Land).ThenBy(kunde=>kunde.Name);
    var grouplands = kunden.GroupBy(kunde=>kunde.Land);
    var nameprodukt = produkte.GroupBy(produkt=>produkt.Name[0]).Select(gruppe => gruppe.Select(prod => prod.Name));
    var joinall = from kunde in kunden from bestellung in kunde.Bestellungen join prod in produkte on bestellung.ProduktNr equals prod.ProduktNr select new 
    { 
        daten = $"Name: {prod.Name}, Produkt ID: {bestellung.ProduktNr}, Anzahl: {bestellung.Anzahl}, Preis: {prod.Preis}, Monat: {bestellung.Monat}, Versendet?: {bestellung.Versendet}" 
    };
    var datenkunden = kunden.Select(kunde => (kunde.Name, kunde.Ort, kunde.Bestellungen.Length));
    var allepreise = produkte.Select(prod => prod.Preis);
    var preisprokunde = from kunde in kunden from bestellung in kunde.Bestellungen join prod in produkte on bestellung.ProduktNr equals prod.ProduktNr group new { kunde, bestellung, prod } by kunde.Name into gruppe select new
    {
        daten = $"Name: {gruppe.Key} Gesamtbetrag der Bestellungen: {gruppe.Sum(x => x.bestellung.Anzahl * x.prod.Preis)}"
    };
    foreach (var kunde in kundennamen){System.Console.WriteLine(kunde.ToString());}
    System.Console.WriteLine();
    foreach (var kunde in deutschebestellungen){System.Console.WriteLine(kunde.ToString());}
    System.Console.WriteLine();
    foreach (var kunde in jederzweite){System.Console.WriteLine(kunde.ToString());}
    System.Console.WriteLine();
    foreach (var produkt in sortiertunter20){System.Console.WriteLine(produkt.Name + " " + produkt.Preis);}
    System.Console.WriteLine();
    foreach (var kunde in namelandsort){System.Console.WriteLine(kunde.Land + " " + kunde.Name);}
    System.Console.WriteLine();
    foreach (var gruppe in grouplands){System.Console.WriteLine($"Land: {gruppe.Key}"); foreach (var kunde in gruppe) System.Console.WriteLine(kunde.ToString());}
    System.Console.WriteLine();
    foreach (var group in nameprodukt){System.Console.WriteLine($"Anfangsbuchstabe: {group.First()[0]}"); foreach (var name in group) System.Console.WriteLine(name);}
    System.Console.WriteLine();
    foreach (var item in joinall){System.Console.WriteLine(item.daten);}
    System.Console.WriteLine();
    foreach (var (Name, Ort, Length) in datenkunden) System.Console.WriteLine($"Name: {Name} Ort: {Ort}, Anzahl der Bestellungen: {Length}");
    System.Console.WriteLine();
    System.Console.WriteLine($"Der Preis aller Produkte liegt bei: {allepreise.Sum()}");
    System.Console.WriteLine();
    foreach (var kunde in preisprokunde) System.Console.WriteLine(kunde.daten);
    }

    static void Main(string[] args)
    {
        Aufgabe1();

    }
}
