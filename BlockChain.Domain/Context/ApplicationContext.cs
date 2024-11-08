﻿using BlockChain.Domain.Models.DataBase;
using BlockChain.Domain.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BlockChain.Domain.Context;

public class ApplicationContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
}