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
    public class TablesTest
    {



        [Fact]
        public async Task IsGetTableListTest()
        {
            var mockRepo = new Mock<ITables>();
            mockRepo.Setup(repo => repo.GetTableList())
                .ReturnsAsync(GetTableList());
            var controller = new TableController(mockRepo.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var viewResult = Assert.IsType<List<tables>>(result);

            Assert.Equal(2, result.Count);

        }

        [Fact]
        public async Task IsGetTableByIdTest()
        {
            var flowerId = 1;
            var mockRepo = new Mock<ITables>();
            mockRepo.Setup(repo => repo.GetTableById(It.IsAny<int>()))
                .ReturnsAsync(GetTableById());
            var controller = new TableController(mockRepo.Object);

            // Act
            var result = await controller.Get(It.IsAny<int>());

            // Assert
            var viewResult = Assert.IsType<tables>(result);

            Assert.Equal(flowerId, viewResult.TableId);

        }


        [Fact]
        public async Task IsCreateTableTest()
        {
            tables _table = new tables();
            var mockRepo = new Mock<ITables>();
            mockRepo.Setup(repo => repo.CreateAsync(_table))
                .ReturnsAsync(true);
            var controller = new TableController(mockRepo.Object);

            // Act
            var result = await controller.Post(_table);

            // Assert
            var viewResult = Assert.IsType<bool>(result);

            Assert.Equal<bool>(result, viewResult);

        }

        [Fact]
        public async Task IsUpdateTableTest()
        {
            tables _table = new tables()
            {

                TableId = It.IsAny<int>(),
                TableName = "table1"
            };
            var mockRepo = new Mock<ITables>();
            mockRepo.Setup(repo => repo.UpdateAsync(_table))
                .ReturnsAsync(true);
            var controller = new TableController(mockRepo.Object);

            // Act
            var result = await controller.Put(_table);

            // Assert
            var viewResult = Assert.IsType<bool>(result);

            Assert.Equal<bool>(result, viewResult);

        }

        [Fact]
        public async Task IsDeleteTableTest()
        {
            tables _table = new tables();
            var mockRepo = new Mock<ITables>();
            mockRepo.Setup(repo => repo.DeleteAsysn(_table))
                .ReturnsAsync(true);
            var controller = new TableController(mockRepo.Object);

            // Act
            var result = await controller.Delete(It.IsAny<int>());

            // Assert
            var viewResult = Assert.IsType<bool>(result);

            Assert.Equal<bool>(result, viewResult);

        }

        private List<tables> GetTableList()
        {
            var sessions = new List<tables>();
            sessions.Add(new tables()
            {

                TableId = 1,
                TableName = "Table 1"
            });
            sessions.Add(new tables()
            {

                TableId = 2,
                TableName = "Table 2"
            });
            return sessions;
        }

        private tables GetTableById()
        {
            var sessions = new tables()
            {

                TableId = 1,
                TableName = "Table 1"
            };

            return sessions;
        }



    }
}