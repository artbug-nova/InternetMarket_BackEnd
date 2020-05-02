using InternetMarketBackEnd.Application.Interfaces;
using InternetMarketBackEnd.Domain.Entity;
using InternetMarketBackEnd.Domain.Services.Common;
using InternetMarketBackEnd.Infra.Repository.Common;

namespace InternetMarketBackEnd.Domain.Services
{
    public class CategoryAppService : Service<Category>, ICategoryAppService
    {
        public CategoryAppService(ICategoryRepository repository) : base(repository) { }
    }
}
