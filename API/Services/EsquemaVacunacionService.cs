using API.Domain.IRepositories;
using API.Domain.IServices;
using API.Domain.Models;

namespace API.Services;

public class EsquemaVacunacionService : IEsquemaVacunacionService
{
    private readonly IEsquemaVacunacionRepository _esquemaRepository;
    private readonly IVacunaRepository _vacunaRepository;
    private readonly ISueroRepository _sueroRepository;
    private readonly IDiluyenteRepository _diluyenteRepository;
    private readonly IJeringaRepository _jeringaRepository;

    public EsquemaVacunacionService(
        IEsquemaVacunacionRepository esquemaRepository,
        IVacunaRepository vacunaRepository,
        ISueroRepository sueroRepository,
        IDiluyenteRepository diluyenteRepository,
        IJeringaRepository jeringaRepository)
    {
        _esquemaRepository = esquemaRepository;
        _vacunaRepository = vacunaRepository;
        _sueroRepository = sueroRepository;
        _diluyenteRepository = diluyenteRepository;
        _jeringaRepository = jeringaRepository;
    }

    public async Task RegistrarEsquemaAsync(EsquemaVacunacion esquemaVacunacion)
    {
        foreach (var detalle in esquemaVacunacion.Detalles)
        {
            if (detalle.VacunaId.HasValue)
                await _vacunaRepository.DescontarInventarioAsync(detalle.VacunaId.Value, detalle.CantidadUtilizada);

            if (detalle.SueroId.HasValue)
                await _sueroRepository.DescontarInventarioAsync(detalle.SueroId.Value, detalle.CantidadUtilizada);

            if (detalle.DiluyenteId.HasValue)
                await _diluyenteRepository.DescontarInventarioAsync(detalle.DiluyenteId.Value, detalle.CantidadUtilizada);

            if (detalle.JeringaId.HasValue)
                await _jeringaRepository.DescontarInventarioAsync(detalle.JeringaId.Value, detalle.CantidadUtilizada);
        }

        await _esquemaRepository.AddAsync(esquemaVacunacion);
    }

    public async Task<EsquemaVacunacion> GetEsquemaConDetallesAsync(int esquemaId)
    {
        return await _esquemaRepository.GetEsquemaConDetallesAsync(esquemaId);
    }
}
