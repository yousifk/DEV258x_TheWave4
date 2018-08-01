using System;
using System.Linq;
using System.Linq.Expressions;
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
            var films = MoviesContext.Instance.Films
                .OrderBy (f => f.Title)
                .Skip (0)
                .Select (f => f.Copy<Film, FilmModel> ());
            ConsoleTable.From (films).Write ();
        }
        public static void Take () {
            var films = MoviesContext.Instance.Films
                .OrderBy (f => f.FilmId)
                .Take (5)
                .Select (f => f.Copy<Film, FilmModel> ());
            ConsoleTable.From (films).Write ();
        }
        public static void Paging () {
            Console.WriteLine ("Enter a page size:");
            var pageSize = Console.ReadLine ().ToInt ();

            Console.WriteLine ("Enter a page number:");
            var pageNumber = Console.ReadLine ().ToInt ();

            Console.WriteLine ("Enter a sort column:");
            Console.WriteLine ("\ti - Film ID");
            Console.WriteLine ("\tt - Title");
            Console.WriteLine ("\ty - Year");
            Console.WriteLine ("\tr - Rating");
            var key = Console.ReadKey ();

            Console.WriteLine ();

            var films = MoviesContext.Instance.Films
                .OrderBy (GetSort (key))
                .Skip ((pageNumber - 1) * pageSize)
                .Take (pageSize)
                .Select (f => f.Copy<Film, FilmModel> ());
            ConsoleTable.From (films).Write ();
        }

        private static Expression<Func<Film, object>> GetSort (ConsoleKeyInfo info) {
            switch (info.Key) {
                case ConsoleKey.I:
                    return f => f.FilmId;
                case ConsoleKey.Y:
                    return f => f.ReleaseYear;
                case ConsoleKey.R:
                    return f => f.Rating;
                default:
                    return f => f.Title;
            }
        }

        public static void LambdaBasics () {
            var films = MoviesContext.Instance.Films
                .Where (f => f.FilmId == 4)
                .Select (f => f.Copy<Film, FilmModel> ());
            ConsoleTable.From (films).Write ();

            var search = "g";
            var films1 = MoviesContext.Instance.Films
                .Where (f => f.Title.Contains (search))
                .OrderByDescending (f => f.Title)
                .Select (f => f.Copy<Film, FilmModel> ());
            ConsoleTable.From (films1).Write ();
        }
        public static void MigrationAddColumn () {
            var film = MoviesContext.Instance.Films
                .FirstOrDefault (f => f.Title.Contains ("the first avenger"));
            if (film != null) {
                Console.WriteLine ($"Updating film with id {film.FilmId}");
                film.Runtime = 124;
                MoviesContext.Instance.SaveChanges ();
            }

            var films = MoviesContext.Instance.Films
                .Select (f => f.Copy<Film, FilmModel> ());
            ConsoleTable.From (films).Write ();
        }
    }
}