using DAL.EF;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace DAL.Test
{
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputObjectInstance_CallsAddMethodOfDbSetWithStreetInstance()
        {
        //Arrange
            DbContextOptions<STOContent> options = new DbContextOptionsBuilder<STOContent>().Options;
            var mockContext = new Mock<STOContent>(options);
            var mockDbSet = new Mock<DbSet<Object>>();
            mockContext.Setup(
                    context => 
                        context.Set<Object>(
                        ))
                .Returns(mockDbSet.Object);
            var repository = new TestObjectRepository(mockContext.Object);
            Object expected = new Mock<Object>().Object;
            
        //Act
        repository.Create(expected);
        
        //Assert
        mockDbSet.Verify(dbSet => dbSet.Add(expected), Times.Once);
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            //Arrange
            DbContextOptions<STOContent> options = new DbContextOptionsBuilder<STOContent>().Options;
            var mockContext = new Mock<STOContent>(options);
            var mockDbSet = new Mock<DbSet<Object>>();
            mockContext.Setup(
                context => 
                    context.Set<Object>(
                        ))
                .Returns(mockDbSet.Object);
            Object expected = new Object() { ObjectId = 1};
            mockDbSet.Setup(mock => mock.Find(expected.ObjectId))
                .Returns(expected);
            var repository = new TestObjectRepository(mockContext.Object);
            
            //Act
            var current = repository.Get(expected.ObjectId);
            
            //Assert
            mockDbSet.Verify(DbSet => DbSet.Find(expected.ObjectId),Times.Once);
            Assert.Equal(expected,current);
        }

        [Fact]
        public void  Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            //Arrange
            DbContextOptions<STOContent> options = new DbContextOptionsBuilder<STOContent>().Options;
            var mockContext = new Mock<STOContent>(options);
            var mockDbSet = new Mock<DbSet<Object>>();
            mockContext.Setup(
                    context => 
                        context.Set<Object>(
                        ))
                .Returns(mockDbSet.Object);
            var repository = new TestObjectRepository(mockContext.Object);
            Object expected = new Object() { ObjectId = 1 };
            mockDbSet.Setup(mock => mock.Find(expected.ObjectId))
                .Returns(expected);

            //Act
            repository.Delete(expected.ObjectId);
            
            //Assert
            mockDbSet.Verify(DbSet => DbSet.Find(expected.ObjectId),Times.Once);
            mockDbSet.Verify(DbSet => DbSet.Remove(expected),Times.Once);
        }
    }
}