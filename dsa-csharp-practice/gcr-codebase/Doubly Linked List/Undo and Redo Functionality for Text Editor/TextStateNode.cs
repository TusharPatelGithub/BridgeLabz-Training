using System;

class TextStateNode
{
    public string Content;
    public TextStateNode Prev;
    public TextStateNode Next;

    public TextStateNode(string content)
    {
        Content = content;
        Prev = null;
        Next = null;
    }
}