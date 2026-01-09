using System;
using System.Collections.Generic;

public class UserProfile
{
    public string UserName { get; set; }
    private List<Workout> workouts;

    public UserProfile(string userName)
    {
        UserName = userName;
        workouts = new List<Workout>();
    }

    public void AddWorkout(Workout workout)
    {
        workouts.Add(workout);
    }

    public void ShowWorkoutHistory()
    {
        Console.WriteLine($"Workout history for {UserName}:");

        foreach (Workout workout in workouts)
        {
            workout.TrackWorkout(); // Polymorphism
        }
    }
}
