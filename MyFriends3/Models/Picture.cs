using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFriends3.Models
{
    [Table("Pictures")]
    public class Picture
    {
        [Key]
        public int PictureId { get; set; }
        [NotMapped] 
        public string? PictureName { get; set; }

        public int UserId { get; set; }
        
        public User User { get; set; } = null!;

        public byte[] PictureByte { get; set; }

        [NotMapped]
        public IFormFile SetImage
        {
            get { return null; }
            set
            {
                PictureByte = AddImage(value);
            }
            
        }

        public byte[]? AddImage(IFormFile file) // קובץ המכיל תמונה מטופס html
        {
            if (file == null) return null;

            // יצירת מקום בזיכרון במכיל קובץ
            MemoryStream stream = new MemoryStream();
            // העתקת הקובץ למקום בזיכרון
            file.CopyTo(stream);
            // הפיכת המיקום בזיכרון לבייטים ושליחתם לפונקיצה הבאה
            return stream.ToArray();

        }

    

        

    }
}
