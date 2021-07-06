//// -----------------------------------------------------------------------
//// <copyright file="DbContextLocal.cs" company="Fluent.Infrastructure">
////     Copyright © Fluent.Infrastructure. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------
/// This is a test file created by Fluent Infrastructure in order to 
/// illustrate its operation.
/// See more at: https://github.com/dn32/Fluent.Infrastructure/wiki
////-----------------------------------------------------------------------

using System.Data.Entity;
using Fluent.Infrastructure.FluentDBContext;
using FoodAPIv1.Models;

namespace FoodAPIv1.DataBase 
{
    public class DbContextLocal : DBContext
    {
        public DbContextLocal() : base(@"Data Source=foodDB4411.mssql.somee.com;Initial Catalog=foodDB4411;Persist Security Info=True;User ID=M_Emad4411_SQLLogin_1;Password=gnha2tlvtz") { }

        public DbSet<Forum> Forum { get; set; }
    }
}