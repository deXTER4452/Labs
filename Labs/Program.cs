public class Client
{
    public string Name { get; set; }
    public long CreditCard { get; set; }
    public List<Reservation> Reservations { get; set; }

}

public class Reservation
{
    public DateTime Date { get; set; }
    public int Occupants { get; set; }
    public bool isCurrent { get; set; }
    public Client client { get; set; }
    public Room room { get; set; }
}

public class Room
{
    public string Number { get; set; }
    public int Capacity { get; set; }
    public bool Occupied { get; set; }
    public List<Reservation> Reservations;
}

public class Hotel
{
    public string Name { get; set; }

    public string Address { get; set; }

    public List<Room> Rooms { get; set; }

    public List<Client> Clients { get; set; }

    public List<Reservation> Reservations { get; set; }
}