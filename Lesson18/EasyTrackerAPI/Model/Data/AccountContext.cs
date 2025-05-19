using Microsoft.EntityFrameworkCore;

public class AccountContext : DbContext
{
    public AccountContext(DbContextOptions<AccountContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(user => user.ID);
    }
}

public class Responce
{
    public User user = new User("1");
    public bool IsAutorized;

    public Responce(User _user, bool _IsAutorized)
    {
        user = _user;
        IsAutorized = _IsAutorized;
    }
}