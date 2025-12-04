namespace Baumarkt;

class Baumarkt
{
    Dictionary<string, List<string>> Kunden = [];
    public void AddKunde(string kundennummer, List<string> einkaufsliste)
    {
        Kunden.Add(kundennummer, einkaufsliste);
    }
    public void ShowKunden()
    {
        foreach (var kunde in Kunden)
        {
            System.Console.WriteLine($"Kundennummer: {kunde.Key}");
            foreach (var artikel in kunde.Value)
            {
                System.Console.WriteLine($" - {artikel}");
            }
        }
    }
    Dictionary<string, List<string>> Artikel = [];
    public void AddArtikel(string artikelname, List<string> kundennummern)
    {
        if (Artikel.TryGetValue(artikelname, out List<string>? value))
        {
            value.AddRange(kundennummern);
        }
        else
        {
        Artikel.Add(artikelname, kundennummern);
        }
    }
    public void ShowArtikel()
    {
        foreach (var artikel in Artikel)
        {
            System.Console.WriteLine($"Artikel: {artikel.Key}");
            foreach (var kundennummer in artikel.Value)
            {
                System.Console.WriteLine($" - {kundennummer}");
            }
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Baumarkt markt = new();
        string liste = "0123; Hammer, Dübel, Nägel\n"
            + "4711; Kantholz, Säge, Nägel, Leim\n"
            + "8698; Schrauben, Dübel, Hänge-WC\n"
            + "9876; Fischfutter, Hammer, Säge\n"
            + "4862; Kantholz, Säge\n"
            + "3179; Schrauben, Schraubenzieher, Dübel\n"
            + "7410; Leim, Fischfutter\n"
            + "8520; Hänge-WC, Nägel, Säge";
        string[] lines = liste.Split('\n');

        foreach (string line in lines)
        {
            string[] parts = line.Split(';');
            string kundennummer = parts[0];
            List<string> einkaufsliste = parts[1].Split(',').Select(item => item.Trim()).ToList();
            markt.AddKunde(kundennummer, einkaufsliste);
        }
        markt.ShowKunden();
        foreach (string line in lines)
        {
            string[] parts = line.Split(';');
            string kundennummer = parts[0];
            string [] artikelNamen = parts[1].Split(',').Select(item => item.Trim()).ToArray();
            foreach (string artikelname in artikelNamen)
            {
                markt.AddArtikel(artikelname, [kundennummer]);
            }
        }
        markt.ShowArtikel();
    }
}
