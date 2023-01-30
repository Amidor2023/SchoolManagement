namespace Gestion_Emploi.Models
{
    public class Lesson : BaseModel // seances => Exemple : seance a 10h de duree 2 heures avec l'enseignate Roua avec la classe 3 Info 2 dans la salle S1
    {
        public DateTime StartAt { get; set; } // 10h
        public int Duration { get; set; } // 2 heures
        public Course Course { get; set; } // Info
        public Teacher Teacher { get; set; } // Roua
        public Classroom Classroom { get; set; } // S1
        public Classmate Classmate { get; set; } // 3 Info 2
        public Schedule Schedule { get; set; }
    }
}
