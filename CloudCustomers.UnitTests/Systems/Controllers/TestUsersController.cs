using CloudCustomers.API.Models;
using CloudCustomers.API.Services;
using CloudCustomers.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CloudCustomers.UnitTests;

public class TestUsersController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        //Arrange
        var mockUsersService = new Mock<IUserService>();
        mockUsersService
           .Setup(service => service.GetAllUsers())
           .ReturnsAsync(new List<User>()
           { new (){
               Id=1,
               Address = new Address{
                   City= "",
                   Street = "",
                   ZipCode = ""
               },
               Email = "",
               Name = ""} });
        var sut = new UsersController(mockUsersService.Object);

        //Act
        var result = (OkObjectResult)await sut.Get();
        //Assert
        result.StatusCode.Should().Be(200);
        
    }
    [Fact]
    public async Task Get_OnSuccess_InvokesUserServiceExactlyOnce()
    {
        var mockUsersService = new Mock<IUserService>();

        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());
        var sut = new UsersController(mockUsersService.Object);
        //Act
        var result = await sut.Get();

        //Assert
        mockUsersService.Verify(
            service => service.GetAllUsers(),
            Times.Once);
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnsListOfUsers()
    {
        var mockUsersService = new Mock<IUserService>();

        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>()
            { new (){
               Id=1,
               Address = new Address{
                   City= "",
                   Street = "",
                   ZipCode = ""
               },
               Email = "",
               Name = ""} });
        var sut = new UsersController(mockUsersService.Object);
        //Act
        var result = await sut.Get();

        //Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<User>>();
    }
    [Fact]
    public async Task Get_OnNoUsersFound_ReturnStatusCode404()
    {
        var mockUsersService = new Mock<IUserService>();

        mockUsersService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());
        var sut = new UsersController(mockUsersService.Object);
        //Act
        var result = await sut.Get();

        //Assert

        result.Should().BeOfType<NotFoundResult>();
    }
}