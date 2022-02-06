using src.Models;
using src.Repositories.Interfaces;

namespace src.Repositories;

public class MeasurementRepository: BaseRepository<Measurement>, IMeasurementRepository
{
    public MeasurementRepository(BarContext context) : base(context)
    {
    }
}