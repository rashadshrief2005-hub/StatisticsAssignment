using System;

namespace StatisticsAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] data = { 115, 182, 191, 31, 196, 1099, 5, 172, 10, 179, 83, 21, 20, 21, 186, 177, 195, 193, 188, 199, 62, 109, 105, 183, 110 };

            Array.Sort(data);
            int n = data.Length;

            double sum = 0;
            foreach (double val in data) { sum += val; }
            double mean = sum / n;

            double mode = data[0];
            int maxCount = 0;
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < n; j++)
                {
                    if (data[j] == data[i]) count++;
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    mode = data[i];
                }
            }

            double p20 = GetPercentile(data, 20);
            double p50 = GetPercentile(data, 50); 
            double q1 = GetPercentile(data, 25);
            double q3 = GetPercentile(data, 75);

            double sumSquares = 0;
            foreach (double val in data)
            {
                sumSquares += Math.Pow(val - mean, 2);
            }
            double variance = sumSquares / n;

            double range = data[n - 1] - data[0];

            double iqr = q3 - q1;

            double stdDev = Math.Sqrt(variance);

            double sumDev = 0;
            foreach (double val in data)
            {
                sumDev += (val - mean);
            }

            Console.WriteLine("Assignment 1 Results:");
            Console.WriteLine($"Mean: {mean:F2}");
            Console.WriteLine($"Mode: {mode}");
            Console.WriteLine($"Median/P50/Q2: {p50:F2}");
            Console.WriteLine($"Variance: {variance:F2}");
            Console.WriteLine($"P20: {p20:F2}");
            Console.WriteLine($"Q3: {q3:F2}");
            Console.WriteLine($"Range: {range}");
            Console.WriteLine($"IQR: {iqr:F2}");
            Console.WriteLine($"Std Deviation: {stdDev:F2}");
            Console.WriteLine($"Sum of Deviations: {sumDev:F2}");

            Console.WriteLine("\nAssignment 2: Outlier Check");
            double lowerBound = q1 - 1.5 * iqr;
            double upperBound = q3 + 1.5 * iqr;

            foreach (double val in data)
            {
                if (val < lowerBound || val > upperBound)
                    Console.WriteLine($"Value {val}: OUTLIER");
                else
                    Console.WriteLine($"Value {val}: Normal");
            }

            Console.ReadKey();
        }

        static double GetPercentile(double[] sortedData, double percentile)
        {
            double rank = (percentile / 100) * (sortedData.Length - 1);
            int index = (int)rank;
            double fraction = rank - index;

            if (index + 1 < sortedData.Length)
                return sortedData[index] + (fraction * (sortedData[index + 1] - sortedData[index]));

            return sortedData[index];
        }
    }
}