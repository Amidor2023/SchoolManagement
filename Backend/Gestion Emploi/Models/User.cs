namespace Gestion_Emploi.Models
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Reference { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
