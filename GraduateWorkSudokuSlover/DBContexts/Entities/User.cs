using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkSudokuSlover.DBContexts.Entities
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public ICollection<SavingSudoku> SavingSudokus { get; set; }
        [Required, MaxLength(64)]
        public string Login { get; set; }
        [Required, MaxLength(64)]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
