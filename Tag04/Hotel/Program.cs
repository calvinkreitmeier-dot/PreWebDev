namespace Hotel;
class Room
{
    public string _roomNumber { get; }
    public string _roomType { get; }
    public string _guestName { get; }
    public string _guestCity { get; }

    public Room(string roomNumber, string roomType, string guestName, string guestCity)
    {
        _roomNumber = roomNumber;
        _roomType = roomType;
        _guestName = guestName;
        _guestCity = guestCity;
    }
    public string GetInfo()
    {
        return $"Room Number: {_roomNumber}, Room Type: {_roomType}, Guest Name: {_guestName}, Guest City: {_guestCity}";
    }
}
class Hotel
{
    public Dictionary<string, Room> Rooms {get; } = [] ;
    public void AddRoom(Room room)
    {
        Rooms.Add(room._roomNumber,room);
    }
    public void GetInfoAllRooms()
    {
        foreach (var room in Rooms.Values)
        {
            System.Console.WriteLine(room.GetInfo());
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Hotel hotel = new();
        string text = "15;D;Peter Schmidt;Wuppertal\n"
            + "17;D;Hans Meier;Düsseldorf\n"
            + "23;E;Regina Schulz;Mettmann\n"
            + "31;D;Kathrin Müller;Erkrath\n"
            + "32;E;Rudolf Kramer;Witten\n"
            + "35;E;Anne Kunze;Bremen";
        string[] lines = text.Split('\n');
        foreach (string line in lines)
        {
            string[] parts = line.Split(';');
            string roomNumber = parts[0];
            string roomType = parts[1];
            string guestName = parts[2];
            string guestCity = parts[3];
            hotel.AddRoom(new Room(roomNumber, roomType, guestName, guestCity));
        }
        hotel.GetInfoAllRooms();
    }
}
