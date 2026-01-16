using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> userAnswer = new List<int>();
        Console.WriteLine("Enter a list of numbers. Type 0 to finish");

        int inputNumber = -1;
        while (inputNumber != 0)
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
            inputNumber = int.Parse(userInput);

            if (inputNumber != 0)
            {
                userAnswer.Add(inputNumber);
            }
        }
        
        int sum = 0;
        foreach (int number in userAnswer)
        {
            sum += number;
        
        }
        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / userAnswer.Count;
        Console.WriteLine($"The average is: {average}");

        int max = userAnswer[0];
        foreach (int number in userAnswer)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The largest number is: {max}");
    }
}