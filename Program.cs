using System;
using System.Linq;
using MovieApp.Entities;

namespace MovieApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var context = new MoviesContext();
            Console.WriteLine(context.Films.Count().ToString());
        }
    }
}
