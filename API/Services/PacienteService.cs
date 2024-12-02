using API.Domain.IRepositories;
using API.Domain.IServices;
using API.Domain.Models;

namespace API.Services;

public class PacienteService : BaseService<Paciente>, IPacienteService
{
    public PacienteService(IPacienteRepository pacienteRepository) : base(pacienteRepository)
    {
    }

    // Implementar métodos adicionales específicos para Paciente si son necesarios
}
