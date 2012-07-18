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
            var api = new CinemateApi("Anubis", "toortoor");

            var res1 = api.GetProfile();
            var res2 = api.GetUpdatelist();
            var res3 = api.GetWatchlist();
        }
    }
}
