using System;
using System.Linq;
using MovieApp.Entities;

namespace MovieApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Module1Helper.SelectList();
            Module1Helper.SelectById();

            var context = new MoviesContext();
            Console.WriteLine(context.Films.Count().ToString());
        }
    }
}
