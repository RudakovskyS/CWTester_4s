using CWTester.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace CWTester.DataBase
{
    public class TesterContext : DbContext
    {
        public TesterContext() : base("name=TesterContext"){ }
        public DbSet<UserAuth> UserAuths { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tests> Tests { get; set; }
        public DbSet<TestResults> TestResults { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<QuestionResult> QuestionResults { get; set; }
        public DbSet<PlannedTests> PlannedTests { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Groups> Groups { get; set; }
    }
}