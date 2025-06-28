using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace desafio_web.Models
{
    public class UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : DbContext(options)
    {
        public DbSet<UsuarioModel> UsuarioModels => Set<UsuarioModel>();
    }
    
}