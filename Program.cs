using System;
using System.Linq;
using MovieApp.Entities;

namespace MovieApp {
    class Program {
        static void Main (string[] args) {
            // Module1Helper.SelectList();
            // Module1Helper.SelectById();
            // Module1Helper.CreateItem ();
            // Module1Helper.UpdateItem ();
            // Module1Helper.DeleteItem();
            // Module1Helper.SelfAssessment();

            /* var orderedFilms = MoviesContext.Instance.Films.OrderByDescending (s => s.Title);
               foreach (var Film in orderedFilms)
               Console.WriteLine (Film.FilmId + ":" + Film.Title);*/

            //   var FilmsAfter5 =  MoviesContext.Instance.Films.Skip(5);

            // Module2Helper.Sort();
            
           // Module2Helper.Skip();
            Module2Helper.Take();


        }
    }
}