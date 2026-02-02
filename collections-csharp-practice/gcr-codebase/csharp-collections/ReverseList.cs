using System.Collections;
public class ReverseList
{
    public static void Main(string[] args)
    {
        //inserting dummy values
        ArrayList arrayList = new ArrayList();
        arrayList.Add(10);
        arrayList.Add(20);
        arrayList.Add(30);
        arrayList.Add(40);
        arrayList.Add(50);
        //inserting dummy values
        LinkedList<int> linkedList = new LinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        list.AddLast(4);
        //calling method by creating obj
        ReverseList obj = new ReverseList();
        obj.ListReverse(arrayList);
        obj.LinkedListReverse(linkedList);
    }
    //method to reverse a linked list
    public void LinkedListReverse(LinkedList<int> linkedList)
    {
        LinkedList<int> reversed = new LinkedList<int>();
        foreach (int item in linkedList)
        {
            reversed.AddFirst(item); 
        }
        foreach (int item in reversed)
        {
            Console.WriteLine(item);
        }
    }
    //method to reverse and array list
    public void ListReverse(ArrayList list)
    {
        int start = 0;
        int end = list.Count - 1;
        while (start < end)
        {
            object temp = list[start];
            list[start] = list[end];
            list[end] = temp;
            start++;
            end--;
        }
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}
