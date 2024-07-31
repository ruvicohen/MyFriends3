using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFriends3.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public List<Picture>? UserPicture { get; set; }
        public byte[]? ProfilePicture { get; set; }

        //public int? ProfilePictureId { get; set; }
        
        //public Picture? Avatar { get; set; }
        [NotMapped]
        public IFormFile? SetImage
        {
            get { return null; }
            set
            {
                ProfilePicture = AddImage(value);
            }
        }

        [NotMapped]
        public IFormFile? SetImageToList
        {
            get { return null; }
            set
            {
                if (value != null)
                {
                    if (UserPicture == null)
                    {
                        UserPicture = new List<Picture>();
                    }

                    UserPicture.Add(new Picture
                    {
                        UserId = Id,
                        PictureByte = AddImage(value)
                    });
                }
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
