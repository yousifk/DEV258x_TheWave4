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
            var films = MoviesContext.Instance.Films
                .OrderBy (f => f.Title)
                .Skip (3)
                .Select (f => f.Copy<Film, FilmModel> ());
            ConsoleTable.From (films).Write ();
        }
        public static void Take () {
            var films = MoviesContext.Instance.Films
                .OrderBy (f => f.Title)
                .Take (5)
                .Select (f => f.Copy<Film, FilmModel> ());
            ConsoleTable.From (films).Write ();
        }
        public static void Paging () {
            var pageSize = 5;
            var pageNumber = 2;
            var films = MoviesContext.Instance.Films
                .OrderBy (f => f.Title)
                .Skip ((pageNumber - 1) * pageSize)
                .Take (pageSize)
                .Select (f => f.Copy<Film, FilmModel> ());
            ConsoleTable.From (films).Write ();
        }

    }
}