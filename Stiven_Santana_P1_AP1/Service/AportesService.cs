using Microsoft.EntityFrameworkCore;
using Stiven_Santana_P1_AP1.DAL;
using Stiven_Santana_P1_AP1.Modelo;
using System.Linq.Expressions;

namespace Stiven_Santana_P1_AP1.Service
{
    public class AportesService
    {
        private readonly IDbContextFactory<Contexto> DbFactory;

        public AportesService(IDbContextFactory<Contexto> dbFactory)
        {
            DbFactory = dbFactory;
        }

        public async Task<bool> Guardar(Aportes aporte)
        {
            if (!await Existe(aporte.AporteId))
            {
                return await Insertar(aporte);
            }
            else
            {
                return await Modificar(aporte);
            }
        }

        private async Task<bool> Existe(int aporteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aportes.AnyAsync(a => a.AporteId == aporteId);
        }

        private async Task<bool> Insertar(Aportes aporte)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Aportes.Add(aporte);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Aportes aporte)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(aporte);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<Aportes?> Buscar(int aporteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aportes.FirstOrDefaultAsync(a => a.AporteId == aporteId);
        }

        public async Task<bool> Eliminar(int aporteId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aportes
                .Where(a => a.AporteId == aporteId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Aportes>> Listar(Expression<Func<Aportes, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Aportes.Where(criterio).AsNoTracking().ToListAsync();
        }

        // Método para obtener todos los aportes sin filtro
        public async Task<List<Aportes>> ObtenerTodosAsync()
        {
            return await Listar(a => true);
        }
    }
}
