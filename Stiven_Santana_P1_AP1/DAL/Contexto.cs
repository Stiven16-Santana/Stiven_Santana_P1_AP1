using Microsoft.EntityFrameworkCore;
using Stiven_Santana_P1_AP1.Modelo;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Stiven_Santana_P1_AP1.DAL;

public class Contexto : DbContext 
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Aportes> Aportes { get; set; }
}
