public class VideoState
{
    public Guid PartyId { get; set; }
    public string Status { get; set; }
    public TimeSpan Time { get; set; }

    public PartyManagement Party { get; set; }
}