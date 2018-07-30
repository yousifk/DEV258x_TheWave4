using System;
using System.Collections.Generic;

namespace MovieApp.Entities
{
    public partial class FilmActor
    {
        public int FilmId { get; set; }
        public int ActorId { get; set; }

        public Actor Actor { get; set; }
        public Film Film { get; set; }
    }
}
