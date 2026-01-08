public class UserNode
{
    public int UserId;
    public string Name;
    public int Age;

    public FriendNode Friends;   // Singly linked list of friend IDs
    public UserNode Next;        // Next user in user list

    public UserNode(int userId, string name, int age)
    {
        UserId = userId;
        Name = name;
        Age = age;
        Friends = null;
        Next = null;
    }
}
