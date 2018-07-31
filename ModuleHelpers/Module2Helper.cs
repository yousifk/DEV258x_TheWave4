using System;
using System.Linq;
using ConsoleTables;
using MovieApp.Entities;
using MovieApp.Extensions;
using MovieApp.Models.Models;

namespace MovieApp {
    public static class Module2Helper {
        public static void Sort () {
            var actors = MoviesContext.Instance.Actors
                .OrderBy (a => a.LastName)
                .Select (a => a.Copy<Actor, ActorModel> ());
            ConsoleTable.From (actors).Write ();

            var films = MoviesContext.Instance.Films
                .OrderBy (f => f.Rating)
                .ThenBy (f => f.ReleaseYear)
                .ThenBy (f => f.Title)
                .Select (f => f.Copy<Film, FilmModel> ());
            ConsoleTable.From (films).Write ();
        }
        public static void SortDescending () {
            var films = MoviesContext.Instance.Films
                .OrderByDescending (f => f.Rating)
                .ThenBy (f => f.Title)
                .Select (f => f.Copy<Film, FilmModel> ());
            ConsoleTable.From (films).Write ();
        }
        public static void Skip () {
            Console.WriteLine (nameof (Skip));
        }
        public static void Take () {
            Console.WriteLine (nameof (Take));
        }
        public static void Paging () {
            Console.WriteLine (nameof (Paging));
        }

    }
}