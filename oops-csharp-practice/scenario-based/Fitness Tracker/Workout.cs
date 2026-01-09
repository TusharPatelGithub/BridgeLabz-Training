public abstract class Workout : ITrackable
{
    public string Name { get; set; }
    public int DurationInMinutes { get; set; }

    public Workout(string name, int duration)
    {
        Name = name;
        DurationInMinutes = duration;
    }

    public abstract void TrackWorkout();
}
