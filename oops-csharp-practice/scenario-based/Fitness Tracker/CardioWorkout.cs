using System;

public class CardioWorkout : Workout
{
    public double DistanceInKm { get; set; }

    public CardioWorkout(string name, int duration, double distance)
        : base(name, duration)
    {
        DistanceInKm = distance;
    }

    public override void TrackWorkout()
    {
        Console.WriteLine($"Cardio Workout: {Name}, Duration: {DurationInMinutes} mins, Distance: {DistanceInKm} km");
    }
}
