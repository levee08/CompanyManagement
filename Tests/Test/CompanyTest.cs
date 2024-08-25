using CompanyManagement.Models;
using Moq;
using NuGet.ContentModel;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using Xunit;

namespace CompanyManagement.Test
{
    
    public class CompanyTest
    {

        [Fact]
        public async Task CreateAsync_Call_CreateAsync_Once()
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
        public async Task ReadAsync_Return_Company_When_Exists()
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
        public async Task ReadAsync_Return_Null_When_Company_Doesnt_Exist()
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

        
        [Fact]
        public async Task CreateAsync_ShouldReturnFalse_WhenCompanyNameAlreadyExists()
        {
            // Arrange
            var existingCompany = new Company { Id = 1, Name = "Existing Company", Address = "123 Test St" };

            var mockRepo = new Mock<IRepository<Company>>();

            // Setup mock to return an existing company when checking for duplicates
            mockRepo.Setup(repo => repo.ReadAllAsync())
                .ReturnsAsync(new List<Company> { existingCompany }.AsQueryable());

            var logic = new CompanyLogic(mockRepo.Object);

            var newCompany = new Company { Name = "Existing Company", Address = "456 New St" };

            // Act
            var result = await logic.CreateAsync(newCompany);

            // Assert
            Assert.False(result); // Should return false since the name already exists
            mockRepo.Verify(repo => repo.CreateAsync(It.IsAny<Company>()), Times.Never); // Ensure CreateAsync was never called
        }
    }
}
