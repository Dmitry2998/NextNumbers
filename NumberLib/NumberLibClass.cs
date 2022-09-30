namespace NumberLib
{
  public class NextNumber
  {
    //54321999 => 534 + 1 + 2999 => 53412999
    private static int GetSplitIndex(string numberText)
    {
      for(int i = numberText.Length -2; i >=0;--i)
      {
        if (numberText[i + 1] < numberText[i])
          return i;
      }
      return -1;
    }
    public static long NextSmallerNumber(long number)
    {
      string numberText = number.ToString();
      int splitIndex = GetSplitIndex(numberText);

      if (splitIndex < 0)
        return -1;

      char[] reorder = numberText.Substring(splitIndex).ToCharArray();
      int nextLowerIndex = reorder.Select((ch, index) => (ch, index))
        .Where(pair => pair.Item1 < reorder[0])
        .OrderByDescending(pair => pair.Item1)
        .First().Item2;

      char temp = reorder[0];
      reorder[0] = reorder[nextLowerIndex];
      reorder[nextLowerIndex] = temp;

      string result = String.Join("", numberText.Take(splitIndex)) + reorder[0] + 
        String.Join("", reorder.Skip(1).OrderByDescending(ch => ch));

      if (result[0] == '0')
        return -1;

      return Convert.ToInt64(result);
    }
  }
}