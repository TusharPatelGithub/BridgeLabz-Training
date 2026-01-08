using System;

public class SocialNetwork
{
    private UserNode head;

    // Add a new user
    public void AddUser(int id, string name, int age)
    {
        UserNode newUser = new UserNode(id, name, age);
        newUser.Next = head;
        head = newUser;
    }

    // Find user by ID
    private UserNode FindUser(int userId)
    {
        UserNode temp = head;
        while (temp != null)
        {
            if (temp.UserId == userId)
                return temp;
            temp = temp.Next;
        }
        return null;
    }

    // Add friend connection (bidirectional)
    public void AddFriendConnection(int user1, int user2)
    {
        UserNode u1 = FindUser(user1);
        UserNode u2 = FindUser(user2);

        if (u1 == null || u2 == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        u1.Friends = AddFriend(u1.Friends, user2);
        u2.Friends = AddFriend(u2.Friends, user1);

        Console.WriteLine("Friend connection added.");
    }

    private FriendNode AddFriend(FriendNode head, int friendId)
    {
        FriendNode newNode = new FriendNode(friendId);
        newNode.Next = head;
        return newNode;
    }

    // Remove friend connection
    public void RemoveFriendConnection(int user1, int user2)
    {
        UserNode u1 = FindUser(user1);
        UserNode u2 = FindUser(user2);

        if (u1 == null || u2 == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        u1.Friends = RemoveFriend(u1.Friends, user2);
        u2.Friends = RemoveFriend(u2.Friends, user1);

        Console.WriteLine("Friend connection removed.");
    }

    private FriendNode RemoveFriend(FriendNode head, int friendId)
    {
        if (head == null)
            return null;

        if (head.FriendId == friendId)
            return head.Next;

        FriendNode temp = head;
        while (temp.Next != null && temp.Next.FriendId != friendId)
            temp = temp.Next;

        if (temp.Next != null)
            temp.Next = temp.Next.Next;

        return head;
    }

    // Display all friends of a user
    public void DisplayFriends(int userId)
    {
        UserNode user = FindUser(userId);
        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        Console.Write($"Friends of {user.Name}: ");
        FriendNode temp = user.Friends;

        if (temp == null)
        {
            Console.WriteLine("No friends.");
            return;
        }

        while (temp != null)
        {
            Console.Write(temp.FriendId + " ");
            temp = temp.Next;
        }
        Console.WriteLine();
    }

    // Find mutual friends
    public void FindMutualFriends(int user1, int user2)
    {
        UserNode u1 = FindUser(user1);
        UserNode u2 = FindUser(user2);

        if (u1 == null || u2 == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        Console.Write("Mutual Friends: ");
        FriendNode f1 = u1.Friends;
        bool found = false;

        while (f1 != null)
        {
            if (IsFriend(u2.Friends, f1.FriendId))
            {
                Console.Write(f1.FriendId + " ");
                found = true;
            }
            f1 = f1.Next;
        }

        if (!found)
            Console.Write("None");

        Console.WriteLine();
    }

    private bool IsFriend(FriendNode head, int id)
    {
        while (head != null)
        {
            if (head.FriendId == id)
                return true;
            head = head.Next;
        }
        return false;
    }

    // Search user by ID
    public void SearchById(int id)
    {
        UserNode user = FindUser(id);
        if (user != null)
            Console.WriteLine($"Found: {user.UserId}, {user.Name}, {user.Age}");
        else
            Console.WriteLine("User not found.");
    }

    // Search user by Name
    public void SearchByName(string name)
    {
        UserNode temp = head;
        bool found = false;

        while (temp != null)
        {
            if (temp.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Found: {temp.UserId}, {temp.Name}, {temp.Age}");
                found = true;
            }
            temp = temp.Next;
        }

        if (!found)
            Console.WriteLine("User not found.");
    }

    // Count number of friends for each user
    public void CountFriends()
    {
        UserNode temp = head;
        while (temp != null)
        {
            int count = 0;
            FriendNode f = temp.Friends;
            while (f != null)
            {
                count++;
                f = f.Next;
            }
            Console.WriteLine($"{temp.Name} has {count} friends.");
            temp = temp.Next;
        }
    }
}
