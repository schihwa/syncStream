public class Client
{
    public Client()
    {
        IsHost = false; // Set default value in the constructor
        Name = string.Empty; // Ensure Name is not null
        Picture = string.Empty; // Ensure Picture is not null (if required)
        Party = new PartyManagement(); // Ensure Party is not null (if required)
    }

    public Guid Id { get; set; }
    public Guid PartyId { get; set; }
    public string Name { get; set; }
    public bool IsHost { get; set; }
    public string Picture { get; set; }

    public PartyManagement Party { get; set; }
}
