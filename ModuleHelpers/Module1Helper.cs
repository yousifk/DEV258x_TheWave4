using System;
using System.Linq;
using MovieApp.Entities;
using MovieApp.Extensions;

namespace MovieApp {
    public static class Module1Helper {
        internal static void SelectList () {
            Console.WriteLine (nameof (SelectList));
        }

        internal static void SelectById () {
            Console.WriteLine ("Enter an Actor ID");
            var actorId = Console.ReadLine ().ToInt ();
            Console.WriteLine (actorId + "");
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
            Console.WriteLine (nameof (CreateItem));
        }

        internal static void UpdateItem () {
            Console.WriteLine (nameof (UpdateItem));
        }

        internal static void DeleteItem () {
            Console.WriteLine (nameof (DeleteItem));
        }
    }
}