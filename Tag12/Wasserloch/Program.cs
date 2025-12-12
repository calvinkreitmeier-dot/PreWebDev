namespace Wasserloch;
class Fluchttier 
{
    Wächtertier _wächter;
        public Fluchttier(Wächtertier wächter)
    {
        _wächter = wächter;
        _wächter.RaubkatzeKommt += Fliehen!;
    }
        public void Fliehen(object sender, EventArgs e) 
    {
        System.Console.WriteLine("Fluchttiere fliehen!");
    }
}
class Kampftier
{
    Wächtertier _wächter;
        public Kampftier(Wächtertier wächter)
    {
        _wächter = wächter;
        _wächter.RaubkatzeKommt += Kämpfen!;
    }
        public void Kämpfen(object sender, EventArgs e) 
    {
        System.Console.WriteLine("Kampftiere Kämpfen!");
    }
}
class Tarntier
{
        Wächtertier _wächter;
        public Tarntier(Wächtertier wächter)
    {
        _wächter = wächter;
        _wächter.RaubkatzeKommt += Tarnen!;
    }
        public void Tarnen(object sender, EventArgs e) 
    {
        System.Console.WriteLine("Tarntiere tarnen sich!");
    }
}
class RaubkatzeEventArgs(string info) : EventArgs
{
    public string _info {get; } = info;
}
class Wächtertier()
{
    public event EventHandler? RaubkatzeKommt;
    public void OnRaubkatzeKommt()
    {
        System.Console.WriteLine("Raubkatze kommt!");
        RaubkatzeKommt!.Invoke(this, new EventArgs());
    }
}
class Program
{
    static void Main(string[] args)
    {
        Wächtertier w = new();
        Tarntier t = new(w);
        Fluchttier f = new(w);
        Kampftier k = new(w);
        w.OnRaubkatzeKommt();
    }
}
