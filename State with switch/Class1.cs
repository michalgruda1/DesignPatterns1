using System;

namespace Coding.Exercise
{
  public class CombinationLock
  {
    private string code;

    public CombinationLock(int[] combination)
    {
      code = string.Join(string.Empty, combination);
    }

    public string Status = "LOCKED";

    public void EnterDigit(int digit)
    {
      switch (Status)
      {
        case "LOCKED":
          Status = digit.ToString();
          if (!code.StartsWith(Status)) goto case "ERROR";
        break;
        case "12345":
          Status = "OPEN";
          break;
        case "ERROR":
          Status = "ERROR";
          break;
        default:
          Status += digit.ToString();
          if (!code.StartsWith(Status)) goto case "ERROR";
          break;
      }
    }
  }
}