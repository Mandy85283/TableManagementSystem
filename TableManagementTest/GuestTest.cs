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
    public class GuestTest
    {

        [Fact]
        public async Task IsGetGuestListTest()
        {
            var mockRepo = new Mock<IGuest>();
            mockRepo.Setup(repo => repo.GetGuestList())
                .ReturnsAsync(GetGuestList());
            var controller = new GuestController(mockRepo.Object);

            // Act
            var result = await controller.Get();

            // Assert
             var viewResult = Assert.IsType<List<guest>>(result);

            Assert.Equal(2, result.Count);

        }

        [Fact]
        public async Task IsGetMealByIdTest()
        {
            var id = 1;
            var mockRepo = new Mock<IGuest>();
            mockRepo.Setup(repo => repo.GetGuestById(It.IsAny<int>()))
                .ReturnsAsync(GetGuestById());
            var controller = new GuestController(mockRepo.Object);

            // Act
            var result = await controller.Get(It.IsAny<int>());

            // Assert
            var viewResult = Assert.IsType<guest>(result);

            Assert.Equal(id, viewResult.GuestId);

        }


        [Fact]
        public async Task IsCreateGuestTest()
        {
            guest _guest = new guest();
            var mockRepo = new Mock<IGuest>();
            mockRepo.Setup(repo => repo.CreateAsync(_guest))
                .ReturnsAsync(true);
            var controller = new GuestController(mockRepo.Object);

            // Act
            var result = await controller.Post(_guest);

            // Assert
            var viewResult = Assert.IsType<bool>(result);

            Assert.Equal<bool>(result, viewResult);

        }

        [Fact]
        public async Task IsUpdateGuestTest()
        {
            guest guest = new guest()
            {

                GuestId = 1,
                FirstName = "Test One",
                LastName = "test",
                PhoneNumber = "232323",
                Email = "parwinder@gmail.com"
            };
            var mockRepo = new Mock<IGuest>();
            mockRepo.Setup(repo => repo.UpdateAsync(guest))
                .ReturnsAsync(true);
            var controller = new GuestController(mockRepo.Object);

            // Act
            var result = await controller.Put(guest);

            // Assert
            var viewResult = Assert.IsType<bool>(result);

            Assert.Equal<bool>(result, viewResult);

        }

        [Fact]
        public async Task IsDeleteGuestTest()
        {
            guest _meal = new guest();
            var mockRepo = new Mock<IGuest>();
            mockRepo.Setup(repo => repo.DeleteAsysn(_meal))
                .ReturnsAsync(true);
            var controller = new GuestController(mockRepo.Object);

            // Act
            var result = await controller.Delete(It.IsAny<int>());

            // Assert
            var viewResult = Assert.IsType<bool>(result);

            Assert.Equal<bool>(result, viewResult);

        }

        private List<guest> GetGuestList()
        {
            var sessions = new List<guest>();
            sessions.Add(new guest()
            {
                
                GuestId = 1,
                FirstName = "Test One",
                LastName="test",
                PhoneNumber="232323",
                Email="parwinder@gmail.com"
            });
            sessions.Add(new guest()
            {

                GuestId = 2,
                FirstName = "Test One",
                LastName = "test",
                PhoneNumber = "232323",
                Email = "parwinder@gmail.com"
            });
            return sessions;
        }

        private guest GetGuestById()
        {
            var sessions = new guest()
            {

                GuestId = 1,
                FirstName = "Test One",
                LastName = "test",
                PhoneNumber = "232323",
                Email = "parwinder@gmail.com"
            };
            
            return sessions;
        }



    }
}