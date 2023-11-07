using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace AssignmentTask2AppDev
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ProcessButton_Click(object sender, RoutedEventArgs e)
        {
            int[] firstNumbers;
            string firstErrorMessage = GetNumbers(FirstNumbersInput.Text, out firstNumbers);

            int[] secondNumbers;
            string secondErrorMessage = GetNumbers(SecondNumbersInput.Text, out secondNumbers);

            if (!string.IsNullOrEmpty(firstErrorMessage) || !string.IsNullOrEmpty(secondErrorMessage))
            {
                PrimesResultTextBlock.Text = (string.IsNullOrEmpty(firstErrorMessage) ? "" : firstErrorMessage + "\n") +
                                             (string.IsNullOrEmpty(secondErrorMessage) ? "" : secondErrorMessage);
            }
            else
            {
                List<int> primes1 = GetPrimes(firstNumbers[0], firstNumbers[1]);
                List<int> primes2 = GetPrimes(secondNumbers[0], secondNumbers[1]);

                PrimesResultTextBlock.Text = $"Primes between {Math.Min(firstNumbers[0], firstNumbers[1])}-{Math.Max(firstNumbers[0], firstNumbers[1])}: {string.Join(",", primes1)}\n" +
                                              $"Primes between {Math.Min(secondNumbers[0], secondNumbers[1])}-{Math.Max(secondNumbers[0], secondNumbers[1])}: {string.Join(",", primes2)}";
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            FirstNumbersInput.Text = "";
            SecondNumbersInput.Text = "";
            PrimesResultTextBlock.Text = "";
        }

        private string GetNumbers(string input, out int[] numbers)
        {
            numbers = new int[2];
            string[] inputNumbers = input.Split(',');

            if (inputNumbers.Length != 2 || !int.TryParse(inputNumbers[0], out numbers[0]) || !int.TryParse(inputNumbers[1], out numbers[1]))
            {
                return "Invalid input. Please enter two integers separated by a comma.";
            }

            return null;
        }

        private List<int> GetPrimes(int start, int end)
        {
            List<int> primes = new List<int>();
            for (int i = Math.Min(start, end); i <= Math.Max(start, end); i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes;
        }

        private bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }
}
