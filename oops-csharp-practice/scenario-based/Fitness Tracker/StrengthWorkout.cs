using System;

public class StrengthWorkout : Workout
{
    public int Sets { get; set; }

    public StrengthWorkout(string name, int duration, int sets)
        : base(name, duration)
    {
        Sets = sets;
    }

    public override void TrackWorkout()
    {
        Console.WriteLine($"Strength Workout: {Name}, Duration: {DurationInMinutes} mins, Sets: {Sets}");
    }
}
