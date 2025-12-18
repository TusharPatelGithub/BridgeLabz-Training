public class Solution
{
    public void MoveZeroes(int[] arr)
    {
        int j = 0;
        int count = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != 0)
            {
                arr[j++] = arr[i];
            }
            else
            {
                count++;
            }
        }

        for (int i = j; i < arr.Length; i++)
        {
            arr[i] = 0;
        }
    }
}
