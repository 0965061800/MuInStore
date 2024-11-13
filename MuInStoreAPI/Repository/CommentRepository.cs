using MuIn.Infrastructure;
using MuInStoreAPI.Models;
using MuInStoreAPI.Repository.IRepository;

namespace MuInStoreAPI.Repository
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly MuInDbContext _context;
        public CommentRepository(MuInDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
