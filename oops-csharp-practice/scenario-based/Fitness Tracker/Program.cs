using System;

class Program
{
    static void Main()
    {
        UserProfile user = new UserProfile("Tushar");

        Workout cardio = new CardioWorkout("Running", 30, 5.0);
        Workout strength = new StrengthWorkout("Weight Training", 45, 4);

        user.AddWorkout(cardio);
        user.AddWorkout(strength);

        user.ShowWorkoutHistory();
    }
}
