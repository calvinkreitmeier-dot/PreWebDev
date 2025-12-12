using System.Reflection.Metadata;

namespace Wasserstand1;
public class Füllstandevent(int op) : EventArgs 
{
    public int Id { get; } = op;
}
class Schiff
{
    Fluss _fluss;
    string _name;
    public Schiff(string name, Fluss fluss)
    {
        _fluss = fluss;
        _name = name;
        _fluss.NiedrigerFüllstand += Anhalten!;
        _fluss.HoherFüllstand += Anhalten!;
        _fluss.NormalerFüllstand += Anhalten!;
        
    }
    public void Anhalten(object sender, Füllstandevent e)
    {
        Console.WriteLine(e.Id switch
        {
            1 => $"Die {_name} bliebt aufgrund des niedrigen Füllstandes des {_fluss._name} stehen",
            2 => $"Die {_name} bliebt aufgrund des hohen Füllstandes des {_fluss._name} stehen",
            _ => $"Die {_name} befährt den {_fluss._name}"
        });
    }
}
class Fluss (string name)
{
    public event EventHandler<Füllstandevent>? NiedrigerFüllstand;
    public event EventHandler<Füllstandevent>? HoherFüllstand;
    public event EventHandler<Füllstandevent>? NormalerFüllstand;
    public string _name {get; } = name;
    int _füllstand; 
    public void RandFullstand()
    {
        Random rng = new();
        _füllstand = rng.Next(100,10001);
        CheckFüllstand();
    }
    private void CheckFüllstand()
    {
        if (_füllstand < 250)
        {
            NiedrigerFüllstand!.Invoke(this, new Füllstandevent(1));
        }
        else if (_füllstand > 8000)
        {
            HoherFüllstand!.Invoke(this, new Füllstandevent(2));
        }
        else
        {
            NormalerFüllstand!.Invoke(this, new Füllstandevent(3));
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Fluss f = new("Anduin");
        Schiff a = new("Númerrámar", f);
        Schiff b = new("Vingilot",f);
        string check;
    do
        {
            Console.Clear();
            f.RandFullstand();
            check = Console.ReadLine()!;
        } while(check != "stopp");
    }
}
