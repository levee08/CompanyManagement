using CompanyManagement.Models;
using Moq;
using NuGet.ContentModel;
using Xunit;

namespace CompanyManagement.Test
{
    
    public class CompanyTest
    {

        [Fact]
        public async Task CreateAsync_Should_Call_CreateAsync_Once()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Company>>();
            var logic = new CompanyLogic(mockRepo.Object);
            var newCompany = new Company { Name = "Test Company", Address = "123 Test St" };

            // Act
            await logic.CreateAsync(newCompany);

            // Assert
            mockRepo.Verify(repo => repo.CreateAsync(newCompany), Times.Once);
        }

        [Fact]
        public async Task ReadAsync_Should_Return_Company_When_Exists()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Company>>();
            var company = new Company { Id = 1, Name = "Test Company", Address = "123 Test St" };
            mockRepo.Setup(repo => repo.ReadAsync(1)).ReturnsAsync(company);

            var logic = new CompanyLogic(mockRepo.Object);

            // Act
            var result = await logic.ReadAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Company", result.Name);
        }
            
        [Fact]
        public async Task ReadAsync_Should_Return_Null_When_Company_Does_Not_Exist()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Company>>();
            mockRepo.Setup(repo => repo.ReadAsync(1)).ReturnsAsync((Company)null);

            var logic = new CompanyLogic(mockRepo.Object);

            // Act
            var result = await logic.ReadAsync(1);

            // Assert
            Assert.Null(result);
        }
    }
}
