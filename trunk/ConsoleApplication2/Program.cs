using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CinemateAPI;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new CinemateApi("29561d6e194051af52c5c6959c107f9df8804dbf")
                          {ApiKey = "9ea8780481b19c151ec3b9d8d983c9a804b70218"};
            var res = api.GetMovieInfo(2194);
        }
    }
}
