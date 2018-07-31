using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Entities
{
    [Table ("Actor")]
    public partial class Actor
    {
        public Actor()
        {
            FilmActor = new HashSet<FilmActor>();
        }

        public int ActorId { get; set; }

        [StringLength (45)]
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public ICollection<FilmActor> FilmActor { get; set; }
    }
}
