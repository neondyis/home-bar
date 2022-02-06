using src.Models;
using src.Repositories.Interfaces;

namespace src.Repositories;

public class MixerRepository: BaseRepository<Mixer>, IMixerRepository
{
    public MixerRepository(BarContext context) : base(context)
    {
    }
}