using System;
using System.Data.Entity;
using System.Linq;
using ConsoleTables;
using MovieApp.Entities;
using MovieApp.Extensions;
using MovieApp.Models.Models;

namespace MovieApp {
    public static class Module1Helper {
        internal static void SelectList () {
            var actors = MoviesContext.Instance.Actors.Select (a => a.Copy<Actor, ActorModel> ());
            ConsoleTable.From (actors).Write ();

            var films = MoviesContext.Instance.Films.Select (f => f.Copy<Film, FilmModel> ());
            ConsoleTable.From (films).Write ();
        }

        internal static void SelectById () {
            Console.WriteLine ("Enter an Actor ID");
            var actorId = Console.ReadLine ().ToInt ();
            var actor = MoviesContext.Instance.Actors.SingleOrDefault (a => a.ActorId == actorId);
            if (actor == null) {
                Console.WriteLine ($"Actor with ID {actorId} not found.");
            } else {
                Console.WriteLine ($"ID: {actor.ActorId}  Name: {actor.FirstName} {actor.LastName}");
            }

            Console.WriteLine ("Enter a Film Title");
            var title = Console.ReadLine ();
            var film = MoviesContext.Instance.Films.FirstOrDefault (f => f.Title.Contains (title));
            if (film == null) {
                Console.WriteLine ($"Film with Title {title} not found.");
            } else {
                Console.WriteLine ($"ID: {film.FilmId}  Title: {film.Title}  Year: {film.ReleaseYear}  Rating: {film.Rating}");
            }
        }
        internal static void CreateItem () {
            // Actor code omitted for brevity

            Console.WriteLine ("Add a Film");

            Console.WriteLine ("Enter a Title");
            var title = Console.ReadLine ();

            Console.WriteLine ("Enter a Description");
            var description = Console.ReadLine ();

            Console.WriteLine ("Enter a Release Year");
            var year = Console.ReadLine ().ToInt ();

            Console.WriteLine ("Enter a Rating");
            var rating = Console.ReadLine ();

            var film = new Film { Title = title, Description = description, ReleaseYear = year, Rating = rating };

            MoviesContext.Instance.Films.Add (film);

            MoviesContext.Instance.SaveChanges ();

            var films = MoviesContext.Instance.Films
                .Where (f => f.FilmId == film.FilmId)
                .Select (f => f.Copy<Film, FilmModel> ());
            ConsoleTable.From (films).Write ();
        }

        internal static void UpdateItem () {
            // update actor code removed for brevity

            Console.WriteLine ("Update a Film");

            Console.WriteLine ("Enter a Film ID");
            var filmId = Console.ReadLine ().ToInt ();

            var film = MoviesContext.Instance.Films
                .SingleOrDefault (a => a.FilmId == filmId);
            if (film == null) {
                Console.WriteLine ($"Film with id {filmId} not found");
            } else {
                ConsoleTable.From (new [] { film.Copy<Film, FilmModel> () })
                    .Write ();

                Console.WriteLine ("Enter the Title");
                var title = Console.ReadLine ().Trim ();

                Console.WriteLine ("Enter the Release Year");
                var releaseYear = Console.ReadLine ().ToInt ();

                Console.WriteLine ("Enter the Rating");
                var rating = Console.ReadLine ().Trim ();

                if (!string.IsNullOrWhiteSpace (title) && film.Title != title) {
                    film.Title = title;
                }

                if (releaseYear > 0 && film.ReleaseYear != releaseYear) {
                    film.ReleaseYear = releaseYear;
                }

                if (!string.IsNullOrWhiteSpace (rating) && film.Rating != rating) {
                    film.Rating = rating;
                }

                MoviesContext.Instance.SaveChanges ();

                var films = MoviesContext.Instance.Films
                    .Where (a => a.FilmId == filmId)
                    .Select (a => a.Copy<Film, FilmModel> ());
                ConsoleTable.From (films).Write ();
            }
        }

        internal static void DeleteItem () {
            // delete actor code removed for brevity

            Console.WriteLine ("Delete a Film");

            Console.WriteLine ("Enter Film Title search");
            var title = Console.ReadLine ();

            var film = MoviesContext.Instance.Films
                .FirstOrDefault (f => f.Title.Contains (title));

            if (film == null) {
                Console.WriteLine ($"Film with title that contains '{title}' not found");
            } else {
                ConsoleTable.From (new [] { film.Copy<Film, FilmModel> () }).Write ();
                Console.WriteLine ("Are you sure you want to delete this film?");
                if (Console.ReadKey ().Key == ConsoleKey.Y) {
                    MoviesContext.Instance.Films.Remove (film);

                    MoviesContext.Instance.SaveChanges ();

                    WriteFilms ();
                } else {
                    Console.WriteLine (" No Films deleted");
                }
            }
        }

        public static void SelfAssessment () {
            SelectListOfFilms (false);
            for (int i = 1; i <= 5; i++)
                MoviesContext.Instance.Films.Add (new Film { Title = "Test Film " });
            SelectListOfFilms (true);

            foreach (var film in MoviesContext.Instance.Films.Where (a => a.FilmId % 2 == 0))
                film.Title = "Awesome " + film.Title;
            SelectListOfFilms (true);

            foreach (var film in MoviesContext.Instance.Films.Where (a => a.Title.Contains ("Test Film")))
                MoviesContext.Instance.Films.Remove (film);
            SelectListOfFilms (true);

            foreach (var film in MoviesContext.Instance.Films.Where (a => a.Title.Contains ("Awesome"))) {
                film.Title = film.Title.Replace ("Awesome ", "");
            }
            SelectListOfFilms (true);

        }
        private static void WriteActors () {
            var actors = MoviesContext.Instance.Actors
                .Select (a => a.Copy<Actor, ActorModel> ());
            ConsoleTable.From (actors).Write ();
        }

        private static void WriteFilms () {
            var films = MoviesContext.Instance.Films
                .Select (f => f.Copy<Film, FilmModel> ());
            ConsoleTable.From (films).Write ();
        }

        private static void SelectListOfFilms (Boolean isApplyed) {
            if (isApplyed) MoviesContext.Instance.SaveChanges ();
            var films = MoviesContext.Instance.Films.Select (f => f.Copy<Film, FilmModel> ());
            ConsoleTable.From (films).Write ();
        }

        public static void MakeTableFilms (DbSet<Film> films) {
            var filmsO = films.Select (f => f.Copy<Film, FilmModel> ());
            ConsoleTable.From (filmsO).Write ();
        }

    }
}