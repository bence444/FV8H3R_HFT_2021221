using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FV8H3R_HFT_2021221.Models
{
    [Table("messages")]
    public class Messages
    {
        //id, matchid (conversation), sender, msg, deleted

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        public int MatchId { get; set; }

        public int SenderId { get; set; }

        public string MessagesSent { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
