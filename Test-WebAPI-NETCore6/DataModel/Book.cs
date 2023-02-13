using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_WebAPI_NETCore6.DataModel
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string? Title { get; set; }
        [MaxLength(1000)]
        public string? Description { get; set; }

        public DateTime PublishDay { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [ForeignKey("AuthorBook")]
        public int AuthorId { get; set; }

        public  Author AuthorBook { get; set; }
            

    }
}
