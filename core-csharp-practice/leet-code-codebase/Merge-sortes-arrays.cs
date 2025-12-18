public class Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int idx = m + n - 1;
        int a = m - 1;
        int b = n - 1;

        while (a >= 0 && b >= 0)
        {
            if (nums2[b] >= nums1[a])
            {
                nums1[idx] = nums2[b];
                idx--;
                b--;
            }
            else
            {
                nums1[idx] = nums1[a];
                idx--;
                a--;
            }
        }

        while (b >= 0)
        {
            nums1[idx] = nums2[b];
            idx--;
            b--;
        }
    }
}
