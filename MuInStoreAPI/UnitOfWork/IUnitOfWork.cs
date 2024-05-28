using MuInStoreAPI.Repository.IRepository;

namespace MuInStoreAPI.UnitOfWork
{
	public interface IUnitOfWork
	{
		IProductRepository ProductRepository { get; }
		ICategoryRepository CategoryRepository { get; }
		IFeatureRepository FeatureRepository { get; }
		IBrandRepository BrandRepository { get; }
		ICommentRepository CommentRepository { get; }
		IPaymentRepository PaymentRepository { get; }
		IOrderRepository OrderRepository { get; }
		IOrderDetailRepository OrderDetailRepository { get; }
		IProductSkuRepository ProductSkuRepository { get; }
		IColorRepository ColorRepository { get; }
		Task BeginTransactionAsync();
		Task CommitAsync();
		Task RollbackAsync();
		Task Save();
	}
}
