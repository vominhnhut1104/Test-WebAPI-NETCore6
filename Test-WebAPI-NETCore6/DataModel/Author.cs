using System.ComponentModel.DataAnnotations;

namespace Test_WebAPI_NETCore6.DataModel
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string? FirstName { get; set; }
        [MaxLength(255)]

        public string? LastName { get; set; }
        [MaxLength(255)]
        public string? Email { get; set; }

        public int Age { get; set; }
        public DateTime DOB { get; set; }

        [MaxLength(1000)]
        public string? Address { get; set; }

        


    }
}
