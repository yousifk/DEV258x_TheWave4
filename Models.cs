 namespace MovieApp.Models {
 	public class ActorModel {
 		public int ActorId { get; set; }
 		public string FirstName { get; set; }
 		public string LastName { get; set; }
 	}
 	public class FilmModel {
 		public int FilmId { get; set; }
 		public string Title { get; set; }
 		public int? ReleaseYear { get; set; }
 		public string Rating { get; set; }
 	}
 }