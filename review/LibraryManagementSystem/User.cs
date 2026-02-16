public abstract class User
{
    protected Library library;

    public User(Library library)
    {
        this.library = library;
    }

    public abstract void ShowMenu();
}
