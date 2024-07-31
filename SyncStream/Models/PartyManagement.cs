public class PartyManagement
{
    public Guid Id { get; set; }
    public Guid HostId { get; set; }
    public int NumberOfPeople { get; set; }
    public string Password { get; set; }

    public Client Host { get; set; }
    public ICollection<Client> Clients { get; set; }
    public ICollection<VideoState> VideoStates { get; set; }
}



