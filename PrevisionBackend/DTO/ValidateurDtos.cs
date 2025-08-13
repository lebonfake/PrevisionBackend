namespace PrevisionBackend.DTO
{
    public class ValidateurCreateDto
    {
        public int UserId { get; set; } 
    }

    public class ValidateurReadDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
    }

}
