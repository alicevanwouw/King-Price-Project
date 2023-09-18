using King_Price_Assessment.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace King_Price_Assessment.Data
{
    public class DatabaseInitializer
    {
        private UserManagementContext context;

        public DatabaseInitializer(UserManagementContext context)
        {
            this.context = context;
        }

        public void Initialize() {

            context.Database.EnsureCreated();

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

            //Add some groups
            var groups = new Group[]
            {
                //TO DO add users and permissions
                new Group{Name="Administrator",IsActive=true,CreatedAt=DateTime.Now,Permissions=new List<Permission>{
                        permissions[0],
                        permissions[1],
                        permissions[2]
                    }
                },
                new Group{Name="Developer",IsActive=true,CreatedAt=DateTime.Now,Permissions=new List<Permission>{
                        permissions[1],
                        permissions[2]
                    }
                },
                new Group{Name="Tester",IsActive=true,CreatedAt=DateTime.Now,Permissions=new List<Permission>{
                        permissions[1],
                        permissions[2]
                    }
                },
                new Group{Name="Visitor",IsActive=true,CreatedAt=DateTime.Now,Permissions=new List<Permission>{
                        permissions[2]
                    }
                },
            };

            foreach (Group e in groups)
            {
                context.Groups.Add(e);
            }

            context.SaveChanges();

            //Add some Users
            var users = new User[]
            {
                //To Do add groups
                new User{FirstName="Carl",Surname="Carlson",Email="carl@carlson.com",PhoneNumber="0891234567",CreatedAt=DateTime.Now, 
                    Groups=new List<Group>{
                        groups[0]
                    }
                },
                new User{FirstName="James",Surname="Jameson",Email="james@jameson.com",PhoneNumber="0891267564",CreatedAt=DateTime.Now, 
                    Groups=new List<Group>{
                        groups[1],
                        groups[2],
                    }
                },
                new User{FirstName="Fred",Surname="Fredson",Email="fred@fredson.com",PhoneNumber="0891234262",CreatedAt=DateTime.Now, 
                    Groups=new List<Group>{
                        groups[1],
                        groups[2],
                    }
                },
                new User{FirstName="Betty",Surname="Bettyson",Email="betty@bettyson.com",PhoneNumber="0891231189",CreatedAt=DateTime.Now,
                    Groups=new List<Group>{
                        groups[1],
                    } }
                ,
                new User{FirstName="Bob",Surname="Bobson",Email="bob@bobson.com",PhoneNumber="0892233565",CreatedAt=DateTime.Now, 
                    Groups=new List<Group>{
                        groups[1],
                        groups[2],
                    }
                },
                new User{FirstName="Henry",Surname="Henrison",Email="henry@henrison.com",PhoneNumber="0891230560",CreatedAt=DateTime.Now, 
                    Groups=new List<Group>{
                        groups[0],
                        groups[1],
                    }
                },
                new User{FirstName="Nelly",Surname="Nellson",Email="nelly@nellson.com",PhoneNumber="0891334563",CreatedAt=DateTime.Now, 
                    Groups=new List<Group>{
                        groups[3],
                    }
                },
                new User{FirstName="Lisa",Surname="Lison",Email="lisa@lison.com",PhoneNumber="0891456565",CreatedAt=DateTime.Now,
                    Groups=new List<Group>{
                        groups[1],
                    }
                },
                new User{FirstName="Kim",Surname="Kimson",Email="kim@kimson.com",PhoneNumber="0891232227",CreatedAt=DateTime.Now, 
                    Groups=new List<Group>{
                        groups[0],
                        groups[2],
                    }
                },
                new User{FirstName="Meg",Surname="megson",Email="meg@megson.com",PhoneNumber="0896783577",CreatedAt=DateTime.Now,
                    Groups=new List<Group>{
                        groups[3],
                    }
                }
            };

            foreach (User u in users)
            {
                context.Users.Add(u);
            }

            context.SaveChanges();

        }
    }
}
