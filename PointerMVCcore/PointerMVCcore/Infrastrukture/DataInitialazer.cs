using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PointerMVCcore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointerMVCcore.Infrastrukture
{
    public class DataInitialazer
    {
        public static void Seed(IServiceScope scoped)
        {
            using (var context = scoped.ServiceProvider.GetRequiredService<PointerDbContext>())
            {
                var manager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                if (!manager.Users.Any())
                {
                    var config = scoped.ServiceProvider.GetRequiredService<IConfiguration>();
                    AppUser appUser = new AppUser
                    {
                        Email = config["User:email"],
                        UserName=config["User:username"]
                    };
                    manager.CreateAsync(appUser, config["User:password"])
                            .GetAwaiter()
                            .GetResult();

                    var rolemanager = scoped.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

                    List<IdentityRole<int>> roles = new List<IdentityRole<int>>();

                    if (!rolemanager.Roles.Any())
                    {
                        string[] rollar = config.GetSection("Role").Value.Split(",");
                        foreach (var item in rollar)
                        {
                            var r = new IdentityRole<int>()
                            {
                                Name = item
                            };
                            roles.Add(r);
                            rolemanager.CreateAsync(r).GetAwaiter()
                                                  .GetResult(); 
                        }

                    }
                    manager.AddToRoleAsync(appUser, roles[0].Name).GetAwaiter().GetResult();
                }
                if (!context.Menus.Any())
                {
                    context.Menus.AddRange(

                        new Menu { Name = "Home", Href = "#home-section" },
                        new Menu { Name = "About", Href = "#about-section" },
                        new Menu { Name = "Service", Href = "#service-section" },
                        new Menu { Name = "Team", Href = "#team-section" },
                        new Menu { Name = "Block", Href = "#block-section" },
                        new Menu { Name = "Testimonials", Href = "#testimonials-section" },
                        new Menu { Name = "Contact", Href = "#contact-section" }
                    );
                    context.SaveChanges();
                }

                if (!context.HomeAbouts.Any())
                {
                    context.HomeAbouts.AddRange(
                        new HomeAbout
                        {
                            Title = "We Are The Best Consulting Agency",
                            Describtion = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Laboriosam assumenda ea quo cupiditate facere deleniti fuga officia.",
                            Image = "hero_2.jpg"
                        },
                         new HomeAbout
                         {
                             Title = "Create Your Own Web Masterpiece",
                             Describtion = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Perferendis eveniet, voluptatem harum provident iusto modi explicabo! Aperiam velit reiciendis, eius impedit ea necessitatibus facilis nobis ipsum, architecto cum, doloribus nesciunt.",
                             Image = "img_big_1.jpg"
                         }

                        );
                    context.SaveChanges();
                }

                if (!context.Teams.Any())
                {
                    context.Teams.AddRange(

                        new Team { Name = "Murad", Surname = "Maqa", Image = "person_5.jpg", Position = "ProductManager" },
                         new Team { Name = "Murad", Surname = "Maqa", Image = "person_6.jpg", Position = "ProductManager" },
                          new Team { Name = "Murad", Surname = "Maqa", Image = "person_7.jpg", Position = "ProductManager" },
                           new Team { Name = "Murad", Surname = "Maqa", Image = "person_3.jpg", Position = "ProductManager" },
                          new Team { Name = "Murad", Surname = "Maqa", Image = "person_3.jpg", Position = "ProductManager" },
                          new Team { Name = "Murad", Surname = "Maqa", Image = "person_2.jpg", Position = "ProductManager" },
                          new Team { Name = "Murad", Surname = "Maqa", Image = "person_1.jpg", Position = "ProductManager" },
                          new Team { Name = "Murad", Surname = "Maqa", Image = "person_8.jpg", Position = "ProductManager" }

                        );
                    context.SaveChanges();
                    if (!context.Socials.Any())
                    {
                        context.Socials.AddRange(
                             new Social { Name = "facebook", CssName = "icon-facebook", Href = "#", TeamId = 1 },
                               new Social { Name = "instagram", CssName = "icon-instagram", Href = "#", TeamId = 1 },
                                 new Social { Name = "linkedin", CssName = "icon-linkedin", Href = "#", TeamId = 1 },
                                   new Social { Name = "twiterr", CssName = "icon-twitter", Href = "#", TeamId = 1 },

                                     new Social { Name = "facebook", CssName = "icon-facebook", Href = "#", TeamId = 2 },
                               new Social { Name = "instagram", CssName = "icon-instagram", Href = "#", TeamId = 2 },
                                 new Social { Name = "linkedin", CssName = "icon-linkedin", Href = "#", TeamId = 2 },
                                   new Social { Name = "twiterr", CssName = "icon-twitter", Href = "#", TeamId = 2 },
                                     new Social { Name = "facebook", CssName = "icon-facebook", Href = "#", TeamId = 2 },

                               new Social { Name = "instagram", CssName = "icon-instagram", Href = "#", TeamId = 3 },
                                 new Social { Name = "linkedin", CssName = "icon-linkedin", Href = "#", TeamId = 3 },
                                   new Social { Name = "twiterr", CssName = "icon-twitter", Href = "#", TeamId = 3 },
                                     new Social { Name = "facebook", CssName = "icon-facebook", Href = "#", TeamId = 3 },

                               new Social { Name = "instagram", CssName = "icon-instagram", Href = "#", TeamId = 4 },
                                 new Social { Name = "linkedin", CssName = "icon-linkedin", Href = "#", TeamId = 4 },
                                   new Social { Name = "twiterr", CssName = "icon-twitter", Href = "#", TeamId = 4 },
                                     new Social { Name = "facebook", CssName = "icon-facebook", Href = "#", TeamId = 4 },

                               new Social { Name = "instagram", CssName = "icon-instagram", Href = "#", TeamId = 5 },
                                 new Social { Name = "linkedin", CssName = "icon-linkedin", Href = "#", TeamId = 5 },
                                   new Social { Name = "facebook", CssName = "icon-facebook", Href = "#", TeamId = 5 },
                               new Social { Name = "instagram", CssName = "icon-instagram", Href = "#", TeamId = 5 },

                                 new Social { Name = "linkedin", CssName = "icon-linkedin", Href = "#", TeamId = 6 },
                                   new Social { Name = "twiterr", CssName = "icon-twitter", Href = "#", TeamId = 6 },
                                     new Social { Name = "facebook", CssName = "icon-facebook", Href = "#", TeamId = 6 },
                               new Social { Name = "instagram", CssName = "icon-instagram", Href = "#", TeamId = 6 },

                                 new Social { Name = "linkedin", CssName = "icon-linkedin", Href = "#", TeamId = 7 },
                                   new Social { Name = "twiterr", CssName = "icon-twitter", Href = "#", TeamId = 7 },
                                     new Social { Name = "facebook", CssName = "icon-facebook", Href = "#", TeamId = 7 },
                               new Social { Name = "instagram", CssName = "icon-instagram", Href = "#", TeamId = 7 },

                                 new Social { Name = "linkedin", CssName = "icon-linkedin", Href = "#", TeamId = 8 },
                                   new Social { Name = "twiterr", CssName = "icon-twitter", Href = "#", TeamId = 8 },
                                     new Social { Name = "facebook", CssName = "icon-facebook", Href = "#", TeamId = 8 },
                               new Social { Name = "instagram", CssName = "icon-instagram", Href = "#", TeamId = 8 }
                            );

                        context.SaveChanges();
                    }
                }

                if (!context.Approaches.Any())
                {
                    context.Approaches.AddRange(
                        new Approach
                        {
                            Title = "Creative",
                            Number = 01,
                            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Et praesentium eos nulla qui commodi consectetur beatae fugiat. Veniam iste rerum perferendis."
                        },
                         new Approach
                         {
                             Title = "Strategy",
                             Number = 02,
                             Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Et praesentium eos nulla qui commodi consectetur beatae fugiat. Veniam iste rerum perferendis."
                         },
                           new Approach
                           {
                               Title = "Production",
                               Number = 03,
                               Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Et praesentium eos nulla qui commodi consectetur beatae fugiat. Veniam iste rerum perferendis."
                           }
                               );
                    context.SaveChanges();
                }
                if (!context.Services.Any())
                {
                    context.Services.AddRange(
                        new Service
                        {
                            Title = "Great Design",
                            IconName = "icon-autorenew",
                            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Et praesentium eos nulla qui commodi consectetur beatae fugiat. Veniam iste rerum perferendis."
                        },
                         new Service
                         {
                             Title = "Quick Response",
                             IconName = "icon-backspace",
                             Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Et praesentium eos nulla qui commodi consectetur beatae fugiat. Veniam iste rerum perferendis."
                         },
                           new Service
                           {
                               Title = "Time Saving",
                               IconName = "icon-av_timer",
                               Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Et praesentium eos nulla qui commodi consectetur beatae fugiat. Veniam iste rerum perferendis."
                           },
                             new Service
                             {
                                 Title = "Best Support",
                                 IconName = "icon-backspace",
                                 Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Et praesentium eos nulla qui commodi consectetur beatae fugiat. Veniam iste rerum perferendis."
                             },
                              new Service
                              {
                                  Title = "Best Support",
                                  IconName = "icon-beenhere",
                                  Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Et praesentium eos nulla qui commodi consectetur beatae fugiat. Veniam iste rerum perferendis."
                              },
                               new Service
                               {
                                   Title = "Best Support",
                                   IconName = "icon-business_center",
                                   Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Et praesentium eos nulla qui commodi consectetur beatae fugiat. Veniam iste rerum perferendis."
                               }
                               );
                    context.SaveChanges();
                }

                if (!context.Testimonials.Any())
                {
                    context.Testimonials.AddRange(
                   new Testimonial { Name = "Robert", Surname = "Sunami", Image = "person_4.jpg", Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Consectetur unde reprehenderit aperiam quaerat fugiat " },
                    new Testimonial { Name = "Robert", Surname = "Hasanli", Image = "person_2.jpg", Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Consectetur unde reprehenderit aperiam quaerat fugiat " },
                   new Testimonial { Name = "Christine", Surname = "Aguilar", Image = "person_3.jpg", Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Consectetur unde reprehenderit aperiam quaerat fugiat " },
                  new Testimonial { Name = "Ronaldo", Surname = "Felaket", Image = "person_2.jpg", Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Consectetur unde reprehenderit aperiam quaerat fugiat " }

                   );
                    context.SaveChanges();
                }

                if (!context.Consultings.Any())
                {
                    context.Consultings.AddRange(

                        new Consulting { Title = "Web & Mobile Specialties", Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Perferendis quis consect.", IconName = "icon-adb" },
                          new Consulting { Title = "Web & Mobile Specialties", Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Perferendis quis consect.", IconName = " icon-assignment" }

                        );
                    context.SaveChanges();
                }
                if (!context.ConsultingImages.Any())
                {
                    context.ConsultingImages.AddRange(
                        new ConsultingImage { Image = "slide_1jpg" },
                        new ConsultingImage { Image = "slide_2.jpg" },
                        new ConsultingImage { Image = "slide_3.jpg" },
                        new ConsultingImage { Image = "slide_4.jpg" }
                        );
                    context.SaveChanges();
                }
            }
        }
    }
}
