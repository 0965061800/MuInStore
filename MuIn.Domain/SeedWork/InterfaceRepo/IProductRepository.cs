using MuIn.Domain.Aggregates.ProductAggregate;

namespace MuIn.Domain.SeedWork.InterfaceRepo
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        bool CheckProductExist(int id);

    }
}
