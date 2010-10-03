using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace RatesComponent
{
  class Rates
  {
    public Dictionary<String, float> rates = new Dictionary<String, float>();

    public Rates(string url)
    {
      WebRequest request = WebRequest.Create(url);
      WebResponse response = request.GetResponse();
      StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
      String date = reader.ReadLine();
      String line;
      while ((line = reader.ReadLine()) != null)
      {
        if (line.Contains(';'))
        {
          line = new Regex("[^A-Z;0-9,]").Replace(line, "");
          Console.WriteLine(line);
          string[] parts = line.Split(new char[] { ';' }, 2);
          rates.Add(parts[0], float.Parse(parts[1]));
        }
      };
      response.Close();
    }
  }
}
