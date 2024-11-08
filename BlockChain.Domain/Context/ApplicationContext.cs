using BlockChain.Domain.Models.DataBase;
using BlockChain.Domain.Models.Request;
using BlockChain.Domain.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Action = BlockChain.Domain.Models.DataBase.Action;

namespace BlockChain.Domain.Context;

public class ApplicationContext: DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<ActionViewModel>()
        //     .HasKey(b => b.Id);
        // modelBuilder.Entity<HashData>().HasKey(b => b.Id);
        // modelBuilder.Entity<HashServiceModel>()
        //     .HasKey(h => h.Id); // Указываем, что Id является первичным ключом
        // modelBuilder.Entity<MessageData>()
        //     .HasKey(h => h.Id); 
        // modelBuilder.Entity<ActionViewModel>()
        //     .HasKey(a => a.Id); // Указываем, что Id является первичным ключом
        //
        // modelBuilder.Entity<HashServiceModel>()
        //     .HasOne(h => h.ActionsViewModel)
        //     .WithOne() // Указываем, что это один к одному
        //     .HasForeignKey<ActionViewModel>(a => a.Id); // Указываем внешний ключ, если необходимо
        //
        // modelBuilder.Entity<ActionViewModel>()
        //     .HasOne(a => a.sender) // Указываем, что у ActionViewModel есть одно навигационное свойство sender
        //     .WithMany() // Указываем, что у HashData может быть много ActionViewModel
        //     .HasForeignKey("SenderId"); // Укажите здесь имя внешнего ключа, если он есть
        
        // modelBuilder.Entity<BlockViewModel>()
        //     .HasMany(b => b.Actions)
        //     .WithOne() // Указываем навигационное свойство
        //     .HasForeignKey("dbId")
        //     .OnDelete(DeleteBehavior.Cascade);
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Block> Blocks { get; set; }
    
    public DbSet<Action> BlockActions { get; set; }
    
}