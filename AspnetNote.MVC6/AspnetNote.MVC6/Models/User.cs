using System.ComponentModel.DataAnnotations;

namespace AspnetNote.MVC6.Models
{
    public class User
    {
        /// <summary>
        /// User No
        /// </summary>
        [Key] //PK
        public int UserNo { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// User Id
        /// </summary>
        /// 
        [Required]
        public string  UserId { get; set; }

        /// <summary>
        /// User Password
        /// </summary>
        [Required]
        public string UserPassword { get; set; }
    }
}
