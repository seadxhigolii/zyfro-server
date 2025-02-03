using Moq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Zyfro.Pro.Server.Application.Services;
using Zyfro.Pro.Server.Application.Interfaces;
using Zyfro.Pro.Server.Domain.Entities;

namespace Zyfro.Pro.Server.Tests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IProDbContext> _dbContextMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _dbContextMock = new Mock<IProDbContext>();
            _mapperMock = new Mock<IMapper>();

            _userService = new UserService(_dbContextMock.Object, _mapperMock.Object);
        }

        private static IQueryable<ApplicationUser> GetFakeUsers()
        {
            return new List<ApplicationUser>
            {
                new ApplicationUser { Id = Guid.NewGuid(), Email = "test1@example.com", Deleted = false },
                new ApplicationUser { Id = Guid.NewGuid(), Email = "test2@example.com", Deleted = false }
            }.AsQueryable();
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            var users = GetFakeUsers();
            var targetUser = users.First();

            var dbSetMock = new Mock<DbSet<ApplicationUser>>();
            dbSetMock.As<IQueryable<ApplicationUser>>().Setup(m => m.Provider).Returns(users.Provider);
            dbSetMock.As<IQueryable<ApplicationUser>>().Setup(m => m.Expression).Returns(users.Expression);
            dbSetMock.As<IQueryable<ApplicationUser>>().Setup(m => m.ElementType).Returns(users.ElementType);
            dbSetMock.As<IQueryable<ApplicationUser>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            _dbContextMock.Setup(db => db.ApplicationUsers).Returns(dbSetMock.Object);

            // Act
            var result = await _userService.GetByIdAsync(targetUser.Id);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.Equal(targetUser.Email, result.Data.Email);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnError_WhenUserDoesNotExist()
        {
            // Arrange
            var users = GetFakeUsers();
            var nonExistentUserId = Guid.NewGuid(); // ID not present in fake data

            var dbSetMock = new Mock<DbSet<ApplicationUser>>();
            dbSetMock.As<IQueryable<ApplicationUser>>().Setup(m => m.Provider).Returns(users.Provider);
            dbSetMock.As<IQueryable<ApplicationUser>>().Setup(m => m.Expression).Returns(users.Expression);
            dbSetMock.As<IQueryable<ApplicationUser>>().Setup(m => m.ElementType).Returns(users.ElementType);
            dbSetMock.As<IQueryable<ApplicationUser>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            _dbContextMock.Setup(db => db.ApplicationUsers).Returns(dbSetMock.Object);

            // Act
            var result = await _userService.GetByIdAsync(nonExistentUserId);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.Success);
            Assert.Equal("User does not exist", result.Message);
            Assert.Equal(404, result.StatusCode);
        }
    }
}
