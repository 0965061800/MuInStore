using Microsoft.EntityFrameworkCore.Storage;
using MuInStoreAPI.Data;
using MuInStoreAPI.Repository;
using MuInStoreAPI.Repository.IRepository;

namespace MuInStoreAPI.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private ApplicationDbContext _context;
		public IProductRepository ProductRepository { get; private set; }
		public ICategoryRepository CategoryRepository { get; private set; }
		public IFeatureRepository FeatureRepository { get; private set; }
		public IBrandRepository BrandRepository { get; private set; }
		public ICommentRepository CommentRepository { get; private set; }
		public IPaymentRepository PaymentRepository { get; private set; }
		public IOrderRepository OrderRepository { get; private set; }
		public IOrderDetailRepository OrderDetailRepository { get; private set; }
		public IProductSkuRepository ProductSkuRepository { get; private set; }
		private IDbContextTransaction _transaction;



		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
			ProductRepository = new ProductRepository(_context);
			CategoryRepository = new CategoryRepository(_context);
			FeatureRepository = new FeatureRepository(_context);
			BrandRepository = new BrandRepository(_context);
			CommentRepository = new CommentRepository(_context);
			PaymentRepository = new PaymentRepository(_context);
			OrderRepository = new OrderRepository(_context);
			OrderDetailRepository = new OrderDetailRepository(_context);
			ProductSkuRepository = new ProductSkuRepository(_context);
		}
		public async Task Save()
		{
			await _context.SaveChangesAsync();
		}
		public async Task BeginTransactionAsync()
		{
			_transaction = await _context.Database.BeginTransactionAsync();
		}
		public async Task RollbackAsync()
		{
			await _transaction.RollbackAsync();
		}
		public async Task CommitAsync()
		{
			await _transaction.CommitAsync();
		}
	}
}
