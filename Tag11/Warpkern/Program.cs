namespace Warpkern;
class View 
{
    Warpkern warp;
    public View(Warpkern warp)
    {
        this.warp = warp;
        this.warp.TempChanged += WarpTempChanged!;
        this.warp.TempCritical += WarpTempChanged!;
    }
    public void WarpTempChanged(object sender, MyEventArgs e) 
    {
        Console.Clear();
        Console.WriteLine(e.Operation+ " ");
    }
    public void ShowData() 
    {
        Console.WriteLine($"Warpkerntemperatur: {warp.GetData()}");
    }
}
public class MyEventArgs(string op) : EventArgs 
{
    public string Operation { get; } = op;
}
public class Warpkern
{
public event EventHandler<MyEventArgs>? TempChanged;
public event EventHandler<MyEventArgs>? TempCritical;

    private int _warpkerntemperatur = 0;
    public void LowerTemp(int wert)
    {
        TempChanged!.Invoke(this,new MyEventArgs($"Die Temperatur fällt von {_warpkerntemperatur} auf: {wert}°"));
        _warpkerntemperatur = wert;
    }
    public void RaiseTemp(int wert)
    {
        TempChanged!.Invoke(this,new MyEventArgs($"Die Temperatur steigt von {_warpkerntemperatur} auf: {wert}°"));
        _warpkerntemperatur = wert;
    }
    public void CriticalTemp(int wert)
    {
        TempCritical!.Invoke(this, new MyEventArgs($"Die Temperatur liegt bei {wert} und ist im kritschen Bereich!"));
        _warpkerntemperatur = wert;
    }
    public int GetData()
    {
        return _warpkerntemperatur;
    }

}
class Program
{
    static void Main(string[] args)
    {
    Warpkern w = new();
    View v = new(w);
    v.ShowData();
    int i = 0;
    do 
    {
        i = Convert.ToInt32(Console.ReadLine());
            if (i >= 500)
            {
                w.CriticalTemp(i);
            }
            else if (i < w.GetData()) 
            {
                w.LowerTemp(i);
            }
            else if (i > w.GetData())
            {
                w.RaiseTemp(i);
            }
    } while (i != 0);
    }
}
