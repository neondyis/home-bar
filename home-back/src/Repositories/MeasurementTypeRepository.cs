using src.Models;
using src.Repositories.Interfaces;

namespace src.Repositories;

public class MeasurementTypeRepository: BaseRepository<MeasurementType>, IMeasurementTypeRepository
{
    public MeasurementTypeRepository(BarContext context) : base(context)
    {
    }
}