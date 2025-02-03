using Xunit;
using Moq;
using Zyfro.Pro.Server.Application.Services;
using Zyfro.Pro.Server.Application.Interfaces;
using Zyfro.Pro.Server.Domain.Entities;
using System.Threading.Tasks;
using System;

namespace Zyfro.Pro.Server.Tests.Services
{
	public class UserServiceTests
	{
		private readonly Mock<IUserRepository> _userRepositoryMock;
		private readonly UserService _userService;

		public UserServiceTests()
		{
			_userRepositoryMock = new Mock<IUserRepository>();
			_userService = new UserService(_userRepositoryMock.Object);
		}

		[Fact]
		public async Task GetByIdAsync_ShouldReturnUser_WhenUserExists()
		{
			// Arrange
			var userId = Guid.NewGuid();
			var expectedUser = new ApplicationUser { Id = userId, UserName = "Sead" };
			_userRepositoryMock.Setup(repo => repo.GetByIdAsync(userId))
								.ReturnsAsync(expectedUser);

			// Act
			var result = await _userService.GetByIdAsync(userId);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(expectedUser.UserName, result.UserName);
		}

		[Fact]
		public async Task GetByIdAsync_ShouldReturnNull_WhenUserDoesNotExist()
		{
			// Arrange
			var userId = Guid.NewGuid();
			_userRepositoryMock.Setup(repo => repo.GetByIdAsync(userId))
								.ReturnsAsync((ApplicationUser)null);

			// Act
			var result = await _userService.GetByIdAsync(userId);

			// Assert
			Assert.Null(result);
		}
	}
}
