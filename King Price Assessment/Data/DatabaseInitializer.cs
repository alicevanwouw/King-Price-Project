﻿using King_Price_Assessment.Models;
using System.Diagnostics;

namespace King_Price_Assessment.Data
{
    public class DatabaseInitializer
    {
        private UserManagementContext _context;

        public static void Initialize(UserManagementContext context) {
            context.Database.EnsureCreated();

            // Look for any Users.
            if (context.Users.Any())
            {
                return;   
            }

            //Add some Users
            var users = new User[]
            {
                //To Do add groups
                new User{FirstName="Carl",Surname="Carlson",Email="carl@carlson.com",PhoneNumber="0891234567",CreatedAt=DateTime.Now},
                new User{FirstName="James",Surname="Jameson",Email="james@jameson.com",PhoneNumber="0891267564",CreatedAt=DateTime.Now},
                new User{FirstName="Fred",Surname="Fredson",Email="fred@fredson.com",PhoneNumber="0891234262",CreatedAt=DateTime.Now},
                new User{FirstName="Betty",Surname="Bettyson",Email="betty@bettyson.com",PhoneNumber="0891231189",CreatedAt=DateTime.Now},
                new User{FirstName="Bob",Surname="Bobson",Email="bob@bobson.com",PhoneNumber="0892233565",CreatedAt=DateTime.Now},
                new User{FirstName="Henry",Surname="Henrison",Email="henry@henrison.com",PhoneNumber="0891230560",CreatedAt=DateTime.Now},
                new User{FirstName="Nelly",Surname="Nellson",Email="nelly@nellson.com",PhoneNumber="0891334563",CreatedAt=DateTime.Now},
                new User{FirstName="Lisa",Surname="Lison",Email="lisa@lison.com",PhoneNumber="0891456565",CreatedAt=DateTime.Now},
                new User{FirstName="Kim",Surname="Kimson",Email="kim@kimson.com",PhoneNumber="0891232227",CreatedAt=DateTime.Now},
                new User{FirstName="Meg",Surname="megson",Email="meg@megson.com",PhoneNumber="0896783577",CreatedAt=DateTime.Now}
            };

            foreach (User u in users)
            {
                context.Users.Add(u);
            }

            context.SaveChanges();

            //Add some groups
            var groups = new Group[]
            {
                //TO DO add users and permissions
                new Group{Name="Administrator",IsActive=true,CreatedAt=DateTime.Now},
                new Group{Name="Developer",IsActive=true,CreatedAt=DateTime.Now},
                new Group{Name="Tester",IsActive=true,CreatedAt=DateTime.Now},
                new Group{Name="Visitor",IsActive=true,CreatedAt=DateTime.Now},
            };

            foreach (Group e in groups)
            {
                context.Groups.Add(e);
            }

           context.SaveChanges();

            //Add some permisisons
            var permissions = new Permission[]
            {
                //TO DO add users and permissions
                new Permission{Name="Full Clearance",IsActive=true,CreatedAt=DateTime.Now},
                new Permission{Name="Mid Clearance",IsActive=true,CreatedAt=DateTime.Now},
                new Permission{Name="Low Clearnce",IsActive=true,CreatedAt=DateTime.Now},
            };

            foreach (Permission e in permissions)
            {
                context.Permissions.Add(e);
            }

            context.SaveChanges();

        }
    }
}
