using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FV8H3R_HFT_2021221.Models
{
    [Table("matches")]
    public class Matches
    {
        //id, userid1, userid2

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        public int User_1 { get; set; }
        public int User_2 { get; set; }
        public List<Messages> Messages { get; set; }
        public bool DeletedMatch { get; set; } = false;
    }
}
