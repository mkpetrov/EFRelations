﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Player
    {
        public int PlayerId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public short SquadNumber { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }

        public Team Team { get; set; }

        [ForeignKey(nameof(Position))]
        public int PositionId { get; set; }

        public Position Position { get; set; }

        public bool IsInjured { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; } = new HashSet<PlayerStatistic>();
    }
}
