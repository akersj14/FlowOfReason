namespace FlowOfReason.Core;

public interface ITrackableData
{
    public string Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastModified { get; set; }
}

public class TrackableData : ITrackableData
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime LastModified { get; set; } = DateTime.UtcNow;
}