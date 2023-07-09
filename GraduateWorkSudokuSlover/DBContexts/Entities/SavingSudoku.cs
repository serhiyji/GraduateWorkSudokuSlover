using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkSudokuSlover.DBContexts.Entities
{
    public partial class SavingSudoku
    {
        [Key]
        public int ID { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
        [Required, MaxLength(64)]
        public string Name { get; set; }
        [Required]
        public string Data { get; set; }
        public DateTime Time { get; set; }
    }

    // For View
    public partial class SavingSudoku
    {
        public string _Time => Time.ToShortDateString() + " " +Time.ToShortTimeString();
    }
}
