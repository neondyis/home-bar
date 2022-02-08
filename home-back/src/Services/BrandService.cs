using src.Repositories.Interfaces;

namespace src.Services;

public class BrandService
{
    private IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }
    
    
}