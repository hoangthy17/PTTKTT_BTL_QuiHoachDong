using System;

class Program
{
    const int INF = int.MaxValue / 2;

    static void Main(string[] args)
    {
        int[,] graph = {
            { 0, 2, 9, INF },
            { 1, 0, 6, 4 },
            { INF, 7, 0, 8 },
            { 6, 3, INF, 0 }
        };

        int n = graph.GetLength(0);
        int[,] dp = new int[1 << n, n];


        for (int i = 0; i < (1 << n); i++)
        {
            for (int j = 0; j < n; j++)
            {
                dp[i, j] = INF;
            }
        }


        dp[1, 0] = 0;


        for (int mask = 1; mask < (1 << n); mask++)
        {
            for (int u = 0; u < n; u++)
            {
                if ((mask & (1 << u)) == 0) continue;
                for (int v = 0; v < n; v++)
                {
                    if ((mask & (1 << v)) != 0 || graph[u, v] == INF) continue;

                    dp[mask | (1 << v), v] = Math.Min(dp[mask | (1 << v), v], dp[mask, u] + graph[u, v]);
                }
            }
        }

        int result = INF;
        for (int i = 1; i < n; i++)
        {
            result = Math.Min(result, dp[(1 << n) - 1, i] + graph[i, 0]);
        }

        if (result >= INF)
        {
            Console.WriteLine("Khong co chu trinh Hamilton kha thi.");
        }
        else
        {
            Console.WriteLine("Đo dai chu trinh Hamilton nho nhat la: " + result);
        }
    }
}
