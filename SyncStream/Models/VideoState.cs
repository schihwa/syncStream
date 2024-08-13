public class VideoState
{
    public VideoState()
    {
        PartyId = Guid.Empty; // Default value for Guid
        Status = string.Empty; // Ensure Status is not null
        Time = TimeSpan.Zero; // Default value for TimeSpan
        Party = new PartyManagement(); // Ensure Party is not null
    }

    public Guid PartyId { get; set; }
    public string Status { get; set; }
    public TimeSpan Time { get; set; }

    public PartyManagement Party { get; set; }
}
