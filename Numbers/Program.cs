using static NumberLib.NextNumber;
using static System.Console;
internal class Program
{
  private static void Main(string[] args)
  {
    WriteLine("This app is takes a positive integer number and returns the next smaller positive integer containing the same digits");
    Write("Please, write a integer positive number:");
    if (long.TryParse(ReadLine(), out long number) is false)
      throw new FormatException();
    WriteLine($"The next smaller number is: {NextSmallerNumber(number)}");
  }
}