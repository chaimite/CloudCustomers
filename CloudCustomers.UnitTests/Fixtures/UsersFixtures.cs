using System;
using CloudCustomers.API.Models;

namespace CloudCustomers.UnitTests.Fixtures
{
    public static class UsersFixtures
    {
        public static List<User> GetTestUsers() => new()
        {
            new User{
            Name = "",
            Id=1,
            Email = "",
            Address = new Address
            {
                City= "",
                Street = "",
                ZipCode = ""
            } }
        };	
	}
}

