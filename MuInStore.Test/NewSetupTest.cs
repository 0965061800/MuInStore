using AutoFixture;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using MuIn.Application.BrandService;
using MuIn.Application.CategoryService;
using MuIn.Application.ColorService;
using MuIn.Application.ProductService.Concrete;
using MuIn.Domain.Aggregates.UserAggregate;
using MuIn.Domain.SeedWork.InterfaceRepo;
namespace MuInStore.Test
{
	public class NewSetupTest
	{
		protected readonly ListProductService _listProductService;
		protected readonly ProductImageServices _productImageServices;
		protected readonly BrandListService _brandListServices;
		protected readonly CategoryListService _categoryListServices;
		protected readonly ColorListService _colorListServices;


		protected readonly Mock<ICategoryRepository> _mockCategoryRepo;
		protected readonly Mock<IProductRepository> _mockProductRepo;
		protected readonly Mock<IBrandRepository> _mockBrandRepo;
		protected readonly Mock<IOrderRepository> _mockOrderRepo;
		protected readonly Mock<IColorRepository> _mockColorRepo;

		protected readonly Mock<UserManager<AppUser>> _mockUserManager;
		protected readonly Mock<SignInManager<AppUser>> _mockSignInManager;

		protected readonly Mock<IMapper> _mockMapper;

		protected readonly Fixture _fixture;
		public NewSetupTest()
		{
			_fixture = new Fixture();
			_fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
			_fixture.Behaviors.Add(new OmitOnRecursionBehavior());
			_fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(x => _fixture.Behaviors.Remove(x));


			_mockCategoryRepo = new Mock<ICategoryRepository>();
			_mockProductRepo = new Mock<IProductRepository>();
			_mockBrandRepo = new Mock<IBrandRepository>();
			_mockColorRepo = new Mock<IColorRepository>();

			_mockUserManager = new Mock<UserManager<AppUser>>(
			   Mock.Of<IUserStore<AppUser>>(), null, null, null, null, null, null, null, null);

			_mockSignInManager = new Mock<SignInManager<AppUser>>(
				_mockUserManager.Object,
				Mock.Of<IHttpContextAccessor>(),
				Mock.Of<IUserClaimsPrincipalFactory<AppUser>>(),
				null, null, null, null);

			_mockMapper = new Mock<IMapper>();


			_listProductService = new ListProductService(_mockCategoryRepo.Object, _mockBrandRepo.Object, _mockProductRepo.Object, _mockMapper.Object);






			//_accountController = new AccountController(
			//	_mockUserManager.Object,
			//	_mockTokenService.Object,
			//	_mockSignInManager.Object);
		}
	}
}
