using System;

class Program
{
    static void Main()
    {
        SocialNetwork network = new SocialNetwork();

        network.AddUser(1, "Tushar", 21);
        network.AddUser(2, "Rahul", 22);
        network.AddUser(3, "Amit", 20);
        network.AddUser(4, "Neha", 21);

        network.AddFriendConnection(1, 2);
        network.AddFriendConnection(1, 3);
        network.AddFriendConnection(2, 3);
        network.AddFriendConnection(3, 4);

        network.DisplayFriends(1);
        network.FindMutualFriends(1, 2);

        network.SearchByName("Amit");
        network.CountFriends();

        network.RemoveFriendConnection(1, 2);
        network.DisplayFriends(1);
    }
}
