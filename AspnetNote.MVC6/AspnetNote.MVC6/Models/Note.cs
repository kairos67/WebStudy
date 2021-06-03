using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetNote.MVC6.Models
{
    public class Note
    {
        /// <summary>
        /// Note No
        /// </summary>
        [Key]
        public int NoteNo { get; set; }

        [Required(ErrorMessage = "please input Note Title")]
        public string NoteTitle { get; set; }
        
        [Required(ErrorMessage = "please input Note Content")]
        public string NoteContents { get; set; }
        
        [Required]
        public int UserNo { get; set; }
        
        [ForeignKey("UserNo")]
        public virtual User User { get; set; }
    }
}
