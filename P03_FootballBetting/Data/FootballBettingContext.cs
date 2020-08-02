using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        DbSet<Bet> Bets { get; set; }

        DbSet<Color> Colors { get; set; }

        DbSet<Country> Countries { get; set; }

        DbSet<Game> Games { get; set; }

        DbSet<Player> Players { get; set; }

        DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        DbSet<Position> Positions { get; set; }

        DbSet<Team> Teams { get; set; }

        DbSet<Town> Towns { get; set; }

        DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=FootballBetting;Integrated Security=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(ps => new { ps.GameId, ps.PlayerId });

            modelBuilder.Entity<Team>()
                .HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(t => t.PrimaryKitColorId);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(t => t.SecondaryKitColorId);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.HomeTeam)
                .WithMany(ht => ht.HomeGames)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(g => g.HomeTeamId);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.AwayTeam)
                .WithMany(at => at.AwayGames)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(g => g.AwayTeamId);
        }
    }
}
