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
    public class FoodTypeTest
    {

    

        [Fact]
        public async Task IsGetFoodTypeListTest()
        {
            var mockRepo = new Mock<IFoodType>();
            mockRepo.Setup(repo => repo.GetFoodTypeList())
                .ReturnsAsync(GetFoodTypeList());
            var controller = new FoodTypeController(mockRepo.Object);

            // Act
            var result = await controller.Get();

            // Assert
             var viewResult = Assert.IsType<List<foodType>>(result);

            Assert.Equal(2, result.Count);

        }

        [Fact]
        public async Task IsGetFoodTypeByIdTest()
        {
            var foodTypeId = 1;
            var mockRepo = new Mock<IFoodType>();
            mockRepo.Setup(repo => repo.GetFoodTypeById(It.IsAny<int>()))
                .ReturnsAsync(GetFoodTypeById());
            var controller = new FoodTypeController(mockRepo.Object);

            // Act
            var result = await controller.Get(It.IsAny<int>());

            // Assert
            var viewResult = Assert.IsType<foodType>(result);

            Assert.Equal(foodTypeId, viewResult.FoodId);

        }


        [Fact]
        public async Task IsCreateFoodTypeTest()
        {
            foodType _table = new foodType();
            var mockRepo = new Mock<IFoodType>();
            mockRepo.Setup(repo => repo.CreateAsync(_table))
                .ReturnsAsync(true);
            var controller = new FoodTypeController(mockRepo.Object);

            // Act
            var result = await controller.Post(_table);

            // Assert
            var viewResult = Assert.IsType<bool>(result);

            Assert.Equal<bool>(result, viewResult);

        }

        [Fact]
        public async Task IsUpdateFoodTypeTest()
        {
            foodType _table = new foodType()
            {

                FoodId = It.IsAny<int>(),
                Name = "table1"
            };
            var mockRepo = new Mock<IFoodType>();
            mockRepo.Setup(repo => repo.UpdateAsync(_table))
                .ReturnsAsync(true);
            var controller = new FoodTypeController(mockRepo.Object);

            // Act
            var result = await controller.Put(_table);

            // Assert
            var viewResult = Assert.IsType<bool>(result);

            Assert.Equal<bool>(result, viewResult);

        }

        [Fact]
        public async Task IsDeleteFoodTypeTest()
        {
            foodType _foodType = new foodType();
            var mockRepo = new Mock<IFoodType>();
            mockRepo.Setup(repo => repo.DeleteAsysn(_foodType))
                .ReturnsAsync(true);
            var controller = new FoodTypeController(mockRepo.Object);

            // Act
            var result = await controller.Delete(It.IsAny<int>());

            // Assert
            var viewResult = Assert.IsType<bool>(result);

            Assert.Equal<bool>(result, viewResult);

        }

        private List<foodType> GetFoodTypeList()
        {
            var sessions = new List<foodType>();
            sessions.Add(new foodType()
            {
                
                FoodId = 1,
                Name = "Table 1"
            });
            sessions.Add(new foodType()
            {

                FoodId = 2,
                Name = "Table 1"
            });
            return sessions;
        }

        private foodType GetFoodTypeById()
        {
            var sessions = new foodType()
            {

                FoodId = 1,
                Name = "Table 1"
            };
            
            return sessions;
        }



    }
}