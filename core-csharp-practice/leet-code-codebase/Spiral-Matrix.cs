using System.Collections.Generic;

public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;

        List<int> al = new List<int>();

        int strow = 0, edrow = m - 1;
        int stcol = 0, edcol = n - 1;

        while (edrow >= strow && edcol >= stcol)
        {
            // top row
            for (int i = stcol; i <= edcol; i++)
            {
                al.Add(matrix[strow][i]);
            }

            // right column
            for (int j = strow + 1; j <= edrow; j++)
            {
                al.Add(matrix[j][edcol]);
            }

            // bottom row
            if (strow < edrow)
            {
                for (int k = edcol - 1; k >= stcol; k--)
                {
                    al.Add(matrix[edrow][k]);
                }
            }

            // left column
            if (stcol < edcol)
            {
                for (int l = edrow - 1; l > strow; l--)
                {
                    al.Add(matrix[l][strow]);
                }
            }

            strow++;
            stcol++;
            edrow--;
            edcol--;
        }

        return al;
    }
}
