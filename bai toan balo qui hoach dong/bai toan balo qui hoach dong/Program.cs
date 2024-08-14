using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        int W = 50;

        
        int n = 4;

       
        int[] weights = { 10, 20, 30, 40 };
        
        int[] values = { 60, 100, 120, 160 };

        
        int[] dp = new int[W + 1];
       
        int[] itemTrack = new int[W + 1];

       
        for (int i = 0; i < n; i++)
        {
            for (int w = weights[i]; w <= W; w++)
            {
                if (dp[w] < dp[w - weights[i]] + values[i])
                {
                    dp[w] = dp[w - weights[i]] + values[i];
                    itemTrack[w] = i; 
                }
            }
        }

       
        Console.WriteLine("Giá trị tối đa có thể đạt được là: " + dp[W]);

       
        Console.WriteLine("Chi tiết đồ vật được chọn:");

        int currentWeight = W;
        while (currentWeight > 0)
        {
            int itemIndex = itemTrack[currentWeight];
            int itemWeight = weights[itemIndex];
            int itemValue = values[itemIndex];

          
            int quantity = currentWeight / itemWeight;
            Console.WriteLine($"Đồ vật {itemIndex + 1}: Trọng lượng = {itemWeight}, Giá trị = {itemValue}, Số lượng = {quantity}");

           
            currentWeight -= itemWeight * quantity;
            Console.ReadLine();
        }
    }
}
