namespace PrevisionBackend.DTO
{
    public class SystemVersionCreateDto
    {
        public string Nom { get; set; }
        public List<VersionCreateDto> VersionCreateDtos { get; set; }
    }


    public class VersionCreateDto
    {
        public string Name { get; set; }
        public int StartDay { get; set; } //0-6 sunday to saturday
        public int EndDay { get; set; }
       
    }

    public class SystemVersionReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<VersionReadDto> VersionReadDtos { get; set; }
    }

    public class VersionReadDto
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StartDay { get; set; } //0-6 sunday to saturday
        public int EndDay { get; set; }

    }

}
