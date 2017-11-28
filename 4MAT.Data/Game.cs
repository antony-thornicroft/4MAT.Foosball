using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _4MAT.Data
{
    public class Game
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime KickOff { get; set; }

        public virtual Player RedPlayer { get; set; }

        public virtual Player BluePlayer { get; set; }

        public int RedScore { get; set; }
        public int BlueScore { get; set; }

        public Outcome Outcome { get; set; }

    }

    public enum Outcome
    {
        RedWins,
        BlueLoses,
        Draw
    }

}
