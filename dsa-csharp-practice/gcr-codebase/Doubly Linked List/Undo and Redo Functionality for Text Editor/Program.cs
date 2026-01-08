class Program
{
    static void Main()
    {
        TextEditorHistory editor = new TextEditorHistory(10);

        editor.AddState("Hello");
        editor.AddState("Hello World");
        editor.AddState("Hello World!");
        editor.DisplayCurrentState();

        editor.Undo();
        editor.DisplayCurrentState();

        editor.Undo();
        editor.DisplayCurrentState();

        editor.Redo();
        editor.DisplayCurrentState();

        editor.AddState("Hello C# World");
        editor.DisplayCurrentState();

        editor.Redo(); // Should not work
    }
}