namespace Kartendeck;
public enum Farbe {Herz,Karo,Pik,Kreuz}
public enum Wert {Sieben,Acht,Neun,Zehn,Bube,Dame,König,Ass}
public class Spielkarte (Farbe farbe, Wert wert)
{
    private readonly Farbe _kartenfarbe = farbe;
    private readonly Wert _kartenwert = wert;
    public string GetKarte()
    {
        return $"{_kartenfarbe} {_kartenwert}";
    }
}
public class Kartendeck
{
    public Stack<Spielkarte> deck = new();
    public Kartendeck(){}
    public Kartendeck(Farbe f)
    {
        Deckbuilder(f);
    }
    public void Deckbuilder(Farbe k)
    {
        var alleWerte = Enum.GetValues<Wert>();
        foreach (Wert w in alleWerte) 
        { 
            deck.Push(new Spielkarte(k, w)); 
        } 
    }
    public static void WriteDeck(Kartendeck k)
    {
        foreach (Spielkarte spielkarte in k.deck)
        {
            System.Console.WriteLine(spielkarte.GetKarte());
        }
    }
    public static Stack<Spielkarte> Zusammenfassen(Stack<Spielkarte> deck1, Stack<Spielkarte> deck2)
    {
        Stack<Spielkarte> newDeck = new();
        int zähler = deck1.Count;
        for (int i = 0; i < zähler; i++)
        {
            newDeck.Push(deck1.Pop());
            newDeck.Push(deck2.Pop());
        }
        return newDeck;
    }
    public static Stack<Spielkarte>[] In4Teilen(Stack<Spielkarte> deck)
    {
        Stack<Spielkarte>[] teile = new Stack<Spielkarte>[4];
        for (int i = 0; i < 4; i++)
        {
            Stack<Spielkarte> zwischenspeicher = new();
            for (int j = 0; j < 4; j++)
            {
                zwischenspeicher.Push(deck.Pop());
            }
            teile[i] = zwischenspeicher;
        }
        return teile;
    }
    public static Stack<Spielkarte> KartenLegen(Stack<Spielkarte>[] deck)
    {
        for (int i = 0; i < 4; i++)
        {
            deck[2].Push(deck[0].Pop());
        }
        for (int i = 0; i < 4; i++)
        {
            deck[3].Push(deck[1].Pop());
        }
        for (int i = 0; i < 8; i++)
        {
            deck[3].Push(deck[2].Pop());
        }
        return deck[3];
    }
    public static List<Stack<Spielkarte>> Teilstapel(Stack<Spielkarte>deck , int anzahl)
    {
        List<Stack<Spielkarte>> newdeck = new();
        for (int i = 0; i < anzahl; i++)
        {
            Stack<Spielkarte> teilstapel = new();
            for (int j = 0; j < deck.Count / anzahl; j++)
            {
                teilstapel.Push(deck.Pop());
            }
            newdeck.Add(teilstapel);
        }
        return newdeck;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Kartendeck herzDeck = new(Farbe.Herz), pikDeck = new(Farbe.Pik);
        // Kartendeck.WriteDeck(herzDeck);
        // Kartendeck.WriteDeck(pikDeck);
        Kartendeck Hauptdeck = new();
        Hauptdeck.deck = Kartendeck.Zusammenfassen(herzDeck.deck, pikDeck.deck);
        // Kartendeck.WriteDeck(Hauptdeck);
        Hauptdeck.deck = Kartendeck.KartenLegen(Kartendeck.In4Teilen(Hauptdeck.deck));
        Kartendeck.WriteDeck(Hauptdeck);
    }
}
