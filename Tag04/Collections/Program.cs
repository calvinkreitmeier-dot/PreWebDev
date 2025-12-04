using System.ComponentModel;

namespace Collections;

class Job (string Title, string Requester, TimeSpan Timeframe)
{
private string _title = Title;
private string _requester = Requester;
private TimeSpan _timeframe = Timeframe;
public string GetInfo()
    {
        return $"Title: {_title}, Requester: {_requester}, Timeframe: {_timeframe}";
    }
}
class JobVerwaltung
{
    private readonly Queue<Job> jobs = new();
    public void Addjob(string Title, string Requester, TimeSpan Timeframe)
    {
        if (string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Requester))
        {
            throw new ArgumentException("Alle Datenfelder müssen ausgefüllt sein.");
        }
        Job job = new(Title, Requester, Timeframe); 
        jobs.Enqueue(job);
    }
    public void GetJobDone()
    {
        if (jobs.Count == 0)
        {
            throw new InvalidOperationException("Es sind keine Jobs mehr in der Liste.");
        }
        System.Console.WriteLine("Auftrag abgeschossen: " + jobs.First().GetInfo());
        jobs.Dequeue();
        System.Console.WriteLine($"Es sind noch {jobs.Count} Jobs in der Liste.");
    }
    public void ShowAllJobs()
    {
        if (jobs.Count == 0)
        {
            throw new InvalidOperationException("Es sind keine Jobs in der Liste.");
        }
        foreach (var job in jobs)
        {
            System.Console.WriteLine(job.GetInfo());
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        JobVerwaltung verwaltung = new();
        try 
        {
        verwaltung.Addjob("Website erstellen", "Max Mustermann", new TimeSpan(15,30,0));
        verwaltung.Addjob("Datenbank einrichten", "Erika Musterfrau", new TimeSpan(20,11,7));
        verwaltung.Addjob("App entwickeln", "Hans Beispiel", new TimeSpan(45,0,0));
        verwaltung.ShowAllJobs();
        verwaltung.GetJobDone();
        verwaltung.GetJobDone();
        verwaltung.ShowAllJobs();
        } 
        catch (ArgumentException ex) 
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}
