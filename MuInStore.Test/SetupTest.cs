using AutoFixture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using MuInStoreAPI.Controllers;
using MuInStoreAPI.Models;
using MuInStoreAPI.Repository.IRepository;
using MuInStoreAPI.Service;
using MuInStoreAPI.UnitOfWork;

namespace MuInStore.Test
{
    public class SetupTest
    {
        protected readonly CategoryController _categoryController;
        protected readonly ProductController _productController;
        protected readonly AccountController _accountController;
        protected readonly ProductSkuController _productSkuController;
        protected readonly CheckoutController _checkoutController;
        protected readonly OrderController _orderController;
        protected readonly BrandController _brandController;
        protected readonly CartController _cartController;
        protected readonly CommentController _commentController;
        protected readonly UserController _userController;
        protected readonly ColorController _colorController;

        protected readonly Mock<IUnitOfWork> _mockUnitOfWork;
        protected readonly Mock<ICategoryRepository> _mockCategoryRepo;
        protected readonly Mock<IProductRepository> _mockProductRepo;
        protected readonly Mock<IProductSkuRepository> _mockProductSkuRepo;
        protected readonly Mock<IBrandRepository> _mockBrandRepo;
        protected readonly Mock<IOrderRepository> _mockOrderRepo;
        protected readonly Mock<ICommentRepository> _mockCommentRepo;
        protected readonly Mock<IColorRepository> _mockColorRepo;

        protected readonly Mock<UserManager<AppUser>> _mockUserManager;
        protected readonly Mock<SignInManager<AppUser>> _mockSignInManager;
        protected readonly Mock<ITokenService> _mockTokenService;


        protected readonly Fixture _fixture;
        // protected readonly ApplicationDbContext _context;
        public SetupTest()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(x => _fixture.Behaviors.Remove(x));

            // _context = new ApplicationDbContext()
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockCategoryRepo = new Mock<ICategoryRepository>();
            _mockProductRepo = new Mock<IProductRepository>();
            _mockProductSkuRepo = new Mock<IProductSkuRepository>();
            _mockBrandRepo = new Mock<IBrandRepository>();
            _mockOrderRepo = new Mock<IOrderRepository>();
            _mockCommentRepo = new Mock<ICommentRepository>();
            _mockColorRepo = new Mock<IColorRepository>();

            _mockUserManager = new Mock<UserManager<AppUser>>(
               Mock.Of<IUserStore<AppUser>>(), null, null, null, null, null, null, null, null);

            _mockSignInManager = new Mock<SignInManager<AppUser>>(
                _mockUserManager.Object,
                Mock.Of<IHttpContextAccessor>(),
                Mock.Of<IUserClaimsPrincipalFactory<AppUser>>(),
                null, null, null, null);

            _mockTokenService = new Mock<ITokenService>();

            _mockUnitOfWork.Setup(x => x.CategoryRepository).Returns(_mockCategoryRepo.Object);
            _mockUnitOfWork.Setup(x => x.ProductRepository).Returns(_mockProductRepo.Object);
            _mockUnitOfWork.Setup(x => x.ProductSkuRepository).Returns(_mockProductSkuRepo.Object);
            _mockUnitOfWork.Setup(x => x.BrandRepository).Returns(_mockBrandRepo.Object);
            _mockUnitOfWork.Setup(x => x.OrderRepository).Returns(_mockOrderRepo.Object);
            _mockUnitOfWork.Setup(x => x.CommentRepository).Returns(_mockCommentRepo.Object);
            _mockUnitOfWork.Setup(x => x.ColorRepository).Returns(_mockColorRepo.Object);

            _categoryController = new CategoryController(_mockUnitOfWork.Object);
            //_productController = new ProductController(_mockUnitOfWork.Object);
            _productSkuController = new ProductSkuController(_mockUnitOfWork.Object);
            _checkoutController = new CheckoutController(_mockUnitOfWork.Object, _mockUserManager.Object);
            _brandController = new BrandController(_mockUnitOfWork.Object);
            _accountController = new AccountController(
                _mockUserManager.Object,
                _mockTokenService.Object,
                _mockSignInManager.Object);
            _userController = new UserController(_mockUserManager.Object);
            _orderController = new OrderController(_mockUnitOfWork.Object, _mockUserManager.Object);
            _cartController = new CartController(_mockUnitOfWork.Object);
            _commentController = new CommentController(_mockUnitOfWork.Object, _mockUserManager.Object);
            _colorController = new ColorController(_mockUnitOfWork.Object);
        }
    }
}
