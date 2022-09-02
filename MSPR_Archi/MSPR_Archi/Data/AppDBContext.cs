using Microsoft.EntityFrameworkCore;
using MSPR_Archi.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
namespace MSPR_Archi.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
           
        }
        public DbSet<TokenModel> tokens { get; set; } 
    }
}
