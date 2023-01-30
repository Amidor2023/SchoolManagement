namespace Gestion_Emploi.Models
{
    public class Classmate : BaseModel // exemple 2 eme eco 3
    {
        public int Level { get; set; }
        public Section Section { get; set; }
        public int Index { get; set; }
        public string Description { get; set; }
        public List<Student> Students { get; set; }
    }

    public enum Section
    {
        Common,
        Economy,
        Literary,
        Computering,
        Mathematic,
        Sciences,
        Sport,
        Technique
    }
}
