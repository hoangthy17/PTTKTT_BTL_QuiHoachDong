using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTKTT_BTL_QHD
{

    class Program
    {
        static void Main()
        {
            // Nhập trọng lượng tối đa của ba lô
            Console.WriteLine("Nhap trong luong to da cua balo:");
            int W = int.Parse(Console.ReadLine());

            // Nhập số lượng đồ vật
            Console.WriteLine("Nhap so luong do vat:");
            int n = int.Parse(Console.ReadLine());

            // Khai báo mảng trọng lượng và giá trị
            int[] weights = new int[n];
            int[] values = new int[n];

            // Nhập trọng lượng và giá trị cho từng đồ vật
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap trong luong va gia tri do vat {i + 1}:");
                string[] inputs = Console.ReadLine().Split();
                weights[i] = int.Parse(inputs[0]);
                values[i] = int.Parse(inputs[1]);
            }

            // Tính giá trị lớn nhất có thể đạt được
            int maxValue = Knapsack(W, weights, values);

            // In kết quả
            Console.WriteLine($"Gia tri lon nhat co the dat duoc la: {maxValue}");
        }

        static int Knapsack(int W, int[] weights, int[] values)
        {
            int n = weights.Length;
            int[,] dp = new int[n + 1, W + 1];

            // Xây dựng bảng DP
            for (int i = 1; i <= n; i++)
            {
                for (int w = 1; w <= W; w++)
                {
                    if (weights[i - 1] <= w)
                    {
                        // Chọn giữa việc không lấy đồ vật i hoặc lấy đồ vật i
                        dp[i, w] = Math.Max(dp[i - 1, w], dp[i - 1, w - weights[i - 1]] + values[i - 1]);
                    }
                    else
                    {
                        dp[i, w] = dp[i - 1, w];
                    }
                }
            }

            return dp[n, W];
        }
    }

}
