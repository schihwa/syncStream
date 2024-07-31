public class Client
{
    public Guid Id { get; set; }
    public Guid PartyId { get; set; }
    public string Name { get; set; }
    public bool IsHost { get; set; }
    public string Picture { get; set; }

    public PartyManagement Party { get; set; }
}