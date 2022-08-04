using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TableManagementLibrary.Interface;
using TableManagementLibrary.Models;
using TableManagementSystem.Controllers;
using Xunit;

namespace TableManagementTest
{
    public class FlowersTest
    {

        [Fact]
        public async Task IsGetFlowerListTest()
        {
            var mockRepo = new Mock<IFlowers>();
            mockRepo.Setup(repo => repo.GetFlowersList())
                .ReturnsAsync(GetFlowerList());
            var controller = new FlowersController(mockRepo.Object);

            // Act
            var result = await controller.Get();

            // Assert
             var viewResult = Assert.IsType<List<flowers>>(result);

            Assert.Equal(2, result.Count);

        }

        [Fact]
        public async Task IsGetFlowerByIdTest()
        {
            var flowerId = 1;
            var mockRepo = new Mock<IFlowers>();
            mockRepo.Setup(repo => repo.GetFlowerById(It.IsAny<int>()))
                .ReturnsAsync(GetFlowerById());
            var controller = new FlowersController(mockRepo.Object);

            // Act
            var result = await controller.Get(It.IsAny<int>());

            // Assert
            var viewResult = Assert.IsType<flowers>(result);

            Assert.Equal(flowerId, viewResult.FlowerId);

        }


        [Fact]
        public async Task IsCreateFlowerTest()
        {
            flowers _flower = new flowers();
            var mockRepo = new Mock<IFlowers>();
            mockRepo.Setup(repo => repo.CreateAsync(_flower))
                .ReturnsAsync(true);
            var controller = new FlowersController(mockRepo.Object);

            // Act
            var result = await controller.Post(_flower);

            // Assert
            var viewResult = Assert.IsType<bool>(result);

            Assert.Equal<bool>(result, viewResult);

        }

        [Fact]
        public async Task IsUpdateFlowerTest()
        {
            flowers _flower = new flowers()
            {

                FlowerId = It.IsAny<int>(),
                Name = "Test One"
            };
            var mockRepo = new Mock<IFlowers>();
            mockRepo.Setup(repo => repo.UpdateAsync(_flower))
                .ReturnsAsync(true);
            var controller = new FlowersController(mockRepo.Object);

            // Act
            var result = await controller.Put(_flower);

            // Assert
            var viewResult = Assert.IsType<bool>(result);

            Assert.Equal<bool>(result, viewResult);

        }

        [Fact]
        public async Task IsDeleteFlowerTest()
        {
            flowers _flower = new flowers();
            var mockRepo = new Mock<IFlowers>();
            mockRepo.Setup(repo => repo.DeleteAsysn(_flower))
                .ReturnsAsync(true);
            var controller = new FlowersController(mockRepo.Object);

            // Act
            var result = await controller.Delete(It.IsAny<int>());

            // Assert
            var viewResult = Assert.IsType<bool>(result);

            Assert.Equal<bool>(result, viewResult);

        }

        private List<flowers> GetFlowerList()
        {
            var sessions = new List<flowers>();
            sessions.Add(new flowers()
            {
                
                FlowerId = 1,
                Name = "Test One"
            });
            sessions.Add(new flowers()
            {
                
                FlowerId = 2,
                Name = "Test Two"
            });
            return sessions;
        }

        private flowers GetFlowerById()
        {
            var sessions = new flowers()
            {

                FlowerId = 1,
                Name = "Test One"
            };
            
            return sessions;
        }



    }
}