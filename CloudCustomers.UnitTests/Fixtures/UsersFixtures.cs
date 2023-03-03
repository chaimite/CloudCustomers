using System;
using CloudCustomers.API.Models;

namespace CloudCustomers.UnitTests.Fixtures
{
    public static class UsersFixtures
    {
        public static List<User> GetTestUsers() =>
        new()
        {
            new User
            {
                Name = "Test user",
                Id = 1,
                Email = "testuser1@gmail.com",
                Address = new Address
                {
                    City= "Some city",
                    Street = "Some street",
                    ZipCode = "12345"
                }
            },
            new User
            {
                Name = "Test user2",
                Id = 2,
                Email = "testuser2@gmail.com",
                Address = new Address
                {
                    City= "Some city",
                    Street = "Some street",
                    ZipCode = "12345"
                }
            }
        };	
	}
}

