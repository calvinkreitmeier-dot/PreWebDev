using System.Data.Common;

namespace Questboard;

abstract class Item
{
    string _name ="";
}
abstract class Weapon : Item{}
class Sword : Weapon{}
class Armor : Item{}
class Consumable : Item{}
class Quest (string title, string description, int wisdom, List<Item> requiredItem)
{
    public string _title {get ;} = title;
    public string _description {get ;} = description;
    public int _wisdom {get ;} = wisdom;
    public List<Item> _requiredItems {get ;} = requiredItem;
}
class Journal
{
    Dictionary<string, Quest>? _questlist;
}
class Hobbit{}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
