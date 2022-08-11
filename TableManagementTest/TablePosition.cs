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
    public class TablePositionTest
    {



        [Fact]
        public async Task IsGetTablePositionListTest()
        {
            var mockRepo = new Mock<ITablePosition>();
            mockRepo.Setup(repo => repo.GetTablePositionList())
                .ReturnsAsync(GetTablePositionList());
            var controller = new TablePositionController(mockRepo.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var viewResult = Assert.IsType<List<tablePosition>>(result);

            Assert.Equal(2, result.Count);

        }

        [Fact]
        public async Task IsGetTablePositionByIdTest()
        {
            var tablePositionId = 1;
            var mockRepo = new Mock<ITablePosition>();
            mockRepo.Setup(repo => repo.GetTablePositionById(It.IsAny<int>()))
                .ReturnsAsync(GetTablePositionById());
            var controller = new TablePositionController(mockRepo.Object);

            // Act
            var result = await controller.Get(It.IsAny<int>());

            // Assert
            var viewResult = Assert.IsType<tablePosition>(result);

            Assert.Equal(tablePositionId, viewResult.TablePositionId);

        }


        [Fact]
        public async Task IsCreateTablePositionTest()
        {
            tablePosition _position = new tablePosition();
            var mockRepo = new Mock<ITablePosition>();
            mockRepo.Setup(repo => repo.CreateAsync(_position))
                .ReturnsAsync(true);
            var controller = new TablePositionController(mockRepo.Object);

            // Act
            var result = await controller.Post(_position);

            // Assert
            var viewResult = Assert.IsType<bool>(result);

            Assert.Equal<bool>(result, viewResult);

        }

        [Fact]
        public async Task IsUpdateTablePositionTest()
        {
            tablePosition _position = new tablePosition()
            {

                TablePositionId = It.IsAny<int>(),
                Position = "table1"
            };
            var mockRepo = new Mock<ITablePosition>();
            mockRepo.Setup(repo => repo.UpdateAsync(_position))
                .ReturnsAsync(true);
            var controller = new TablePositionController(mockRepo.Object);

            // Act
            var result = await controller.Put(_position);

            // Assert
            var viewResult = Assert.IsType<bool>(result);

            Assert.Equal<bool>(result, viewResult);

        }

        [Fact]
        public async Task IsDeleteTablePositionTest()
        {
            tablePosition _foodType = new tablePosition();
            var mockRepo = new Mock<ITablePosition>();
            mockRepo.Setup(repo => repo.DeleteAsysn(_foodType))
                .ReturnsAsync(true);
            var controller = new TablePositionController(mockRepo.Object);

            // Act
            var result = await controller.Delete(It.IsAny<int>());

            // Assert
            var viewResult = Assert.IsType<bool>(result);

            Assert.Equal<bool>(result, viewResult);

        }

        private List<tablePosition> GetTablePositionList()
        {
            var sessions = new List<tablePosition>();
            sessions.Add(new tablePosition()
            {

                TablePositionId = 1,
                Position = "Table 1"
            });
            sessions.Add(new tablePosition()
            {

                TablePositionId = 2,
                Position = "Table 1"
            });
            return sessions;
        }

        private tablePosition GetTablePositionById()
        {
            var sessions = new tablePosition()
            {

                TablePositionId = 1,
                Position = "Table 1"
            };

            return sessions;
        }



    }
}