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
    public class MealTest
    {

        [Fact]
        public async Task IsGetMealListTest()
        {
            var mockRepo = new Mock<IMeal>();
            mockRepo.Setup(repo => repo.GetMealList())
                .ReturnsAsync(GetMealList());
            var controller = new MealController(mockRepo.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var viewResult = Assert.IsType<List<meal>>(result);

            Assert.Equal(2, result.Count);

        }

        [Fact]
        public async Task IsGetMealByIdTest()
        {
            var flowerId = 1;
            var mockRepo = new Mock<IMeal>();
            mockRepo.Setup(repo => repo.GetMealById(It.IsAny<int>()))
                .ReturnsAsync(GetMealById());
            var controller = new MealController(mockRepo.Object);

            // Act
            var result = await controller.Get(It.IsAny<int>());

            // Assert
            var viewResult = Assert.IsType<meal>(result);

            Assert.Equal(flowerId, viewResult.MealId);

        }


        [Fact]
        public async Task IsCreateMealTest()
        {
            meal _meal = new meal();
            var mockRepo = new Mock<IMeal>();
            mockRepo.Setup(repo => repo.CreateAsync(_meal))
                .ReturnsAsync(true);
            var controller = new MealController(mockRepo.Object);

            // Act
            var result = await controller.Post(_meal);

            // Assert
            var viewResult = Assert.IsType<bool>(result);

            Assert.Equal<bool>(result, viewResult);

        }

        [Fact]
        public async Task IsUpdateMealTest()
        {
            meal _meal = new meal()
            {

                MealId = It.IsAny<int>(),
                Name = "Test One"
            };
            var mockRepo = new Mock<IMeal>();
            mockRepo.Setup(repo => repo.UpdateAsync(_meal))
                .ReturnsAsync(true);
            var controller = new MealController(mockRepo.Object);

            // Act
            var result = await controller.Put(_meal);

            // Assert
            var viewResult = Assert.IsType<bool>(result);

            Assert.Equal<bool>(result, viewResult);

        }

        [Fact]
        public async Task IsDeleteMealTest()
        {
            meal _meal = new meal();
            var mockRepo = new Mock<IMeal>();
            mockRepo.Setup(repo => repo.DeleteAsysn(_meal))
                .ReturnsAsync(true);
            var controller = new MealController(mockRepo.Object);

            // Act
            var result = await controller.Delete(It.IsAny<int>());

            // Assert
            var viewResult = Assert.IsType<bool>(result);

            Assert.Equal<bool>(result, viewResult);

        }

        private List<meal> GetMealList()
        {
            var sessions = new List<meal>();
            sessions.Add(new meal()
            {

                MealId = 1,
                Name = "Test One"
            });
            sessions.Add(new meal()
            {

                MealId = 2,
                Name = "Test Two"
            });
            return sessions;
        }

        private meal GetMealById()
        {
            var sessions = new meal()
            {

                MealId = 1,
                Name = "Test One"
            };

            return sessions;
        }



    }
}