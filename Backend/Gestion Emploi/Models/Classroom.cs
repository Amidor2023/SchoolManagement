namespace Gestion_Emploi.Models
{
    public class Classroom : BaseModel
    {
        public int Number { get; set; }
        public int Floor { get; set; }
        public bool Free { get; set; }
    }
}