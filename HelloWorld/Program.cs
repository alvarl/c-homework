using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using RatesComponent;

namespace HelloWorld
{

  class Program
  {
    static void Main(string[] args)
    {
      if (args.Length > 0)
      {
        float amountInEEK = float.Parse(args[0]);
        Console.WriteLine("Rates for amount EEK " + amountInEEK);
        Rates rates = new Rates();
        foreach (String key in rates.rates.Keys)
        {
          Console.WriteLine(key + " = " + rates.rates[key]);
        }
      }
      else {
        Console.WriteLine("Submit amount in EEK as argument!");
      }
    }
  }
}
