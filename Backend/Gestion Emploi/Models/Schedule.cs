namespace Gestion_Emploi.Models
{
    public class Schedule : BaseModel
    {
        public List<Lesson> Lessons { get; set; }
        public Classmate Classmate { get; set; }
    }
}
