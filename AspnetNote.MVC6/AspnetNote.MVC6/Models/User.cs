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
        [Required(ErrorMessage = "please input user name")]
        public string UserName { get; set; }
        /// <summary>
        /// User Id
        /// </summary>
        /// 
        [Required(ErrorMessage ="please input user id")]
        public string  UserId { get; set; }

        /// <summary>
        /// User Password
        /// </summary>
        [Required(ErrorMessage = "please input user password")]
        public string UserPassword { get; set; }
    }
}
