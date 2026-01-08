class Program
{
    static void Main()
    {
        MovieDoublyLinkedList movies = new MovieDoublyLinkedList();

        movies.AddAtEnd("Inception", "Christopher Nolan", 2010, 8.8);
        movies.AddAtBeginning("Interstellar", "Christopher Nolan", 2014, 8.6);
        movies.AddAtPosition(2, "The Dark Knight", "Christopher Nolan", 2008, 9.0);

        Console.WriteLine("All Movies (Forward):");
        movies.DisplayForward();

        Console.WriteLine("\nAll Movies (Reverse):");
        movies.DisplayReverse();

        Console.WriteLine("\nSearch by Director:");
        movies.SearchByDirector("Christopher Nolan");

        Console.WriteLine("\nUpdate Rating:");
        movies.UpdateRating("Inception", 9.1);

        Console.WriteLine("\nRemove Movie:");
        movies.RemoveByTitle("Interstellar");

        Console.WriteLine("\nFinal List:");
        movies.DisplayForward();
    }
}