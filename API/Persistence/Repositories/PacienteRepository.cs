using API.Domain.IRepositories;
using API.Domain.Models;
using API.Persistence.Context;

namespace API.Persistence.Repositories
{
    public class PacienteRepository : Repository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(AplicationDbContext context) : base(context)
        {
        }

        // Implementar métodos adicionales si son necesarios
    }
}
