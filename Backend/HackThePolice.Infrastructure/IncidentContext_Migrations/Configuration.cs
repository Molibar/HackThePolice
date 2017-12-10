using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using HackThePolice.Infrastructure.Core.Models;

namespace HackThePolice.Infrastructure.IncidentContext_Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<HackThePolice.Infrastructure.IncidentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"IncidentContext_Migrations";
            ContextKey = "IncidentContext";
        }

        protected override void Seed(IncidentContext context)
        {
            var incident = new Incident
            {
                Id = Guid.Parse("d508ad6d-7f93-474d-946a-12a08ab200a1"),
                IncidentReference = "1234/02DEC17",
                Name = "Joe Smith",
                OccurredAt = DateTime.UtcNow.Date,
                PoliceStation = "Charing Cross",
                TelephoneNumber = "112",
                Statements = new List<Statement>
                {
                    new Statement
                    {
                        Id = Guid.Parse("07cd95c4-106d-46e0-bb16-75b9395ecf74"),
                        Circumstance = new Circumstance
                        {
                            Id = Guid.Parse("07d42f88-6aac-4196-ba11-995e4bcec683"),
                            DescriptionOfYourselfAndClothing =
                                @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean viverra purus at enim convallis euismod. Ut orci dui, ultrices eget feugiat eget, auctor in lorem. Nunc finibus, quam ac consectetur facilisis, elit justo viverra ex, sagittis fringilla quam lorem nec neque. Duis fermentum turpis faucibus dolor luctus dapibus.",
                            HowLong = 25,
                            KnownPeople =
                                @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean viverra purus at enim convallis euismod. Ut orci dui, ultrices eget feugiat eget, auctor in lorem. Nunc finibus, quam ac consectetur facilisis, elit justo viverra ex, sagittis fringilla quam lorem nec neque. Duis fermentum turpis faucibus dolor luctus dapibus.",
                            Obstructions =
                                @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean viverra purus at enim convallis euismod. Ut orci dui, ultrices eget feugiat eget, auctor in lorem. Nunc finibus, quam ac consectetur facilisis, elit justo viverra ex, sagittis fringilla quam lorem nec neque. Duis fermentum turpis faucibus dolor luctus dapibus.",
                            ReasonToRemember =
                                @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean viverra purus at enim convallis euismod. Ut orci dui, ultrices eget feugiat eget, auctor in lorem. Nunc finibus, quam ac consectetur facilisis, elit justo viverra ex, sagittis fringilla quam lorem nec neque. Duis fermentum turpis faucibus dolor luctus dapibus.",
                            TimePassed = 120,
                            TimeOfDay = new TimeSpan(12, 20, 0),
                            Weather = "Clear evening sky"
                        },
                        ContactDetails = new ContactDetails
                        {
                            Id = Guid.Parse("5766a1d3-61e1-4a8e-bf3a-4e155029c539"),
                            Address = "Flat 61, 59 Peckham Grove",
                            DateOfBirth = new DateTime(1975, 8, 6),
                            Email = "christer.brannstrom@gmail.com",
                            FirstName = "Hans",
                            LastName = "Braennstroem",
                            MobileNumber = "07455697681",
                            PostCode = "SE15 6PH",
                            TelephoneNumber = null,
                            WillingToTestify = true,
                            Wiv = WIV.Witness
                        },
                        OtherInformation =
                            @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean viverra purus at enim convallis euismod. Ut orci dui, ultrices eget feugiat eget, auctor in lorem. Nunc finibus, quam ac consectetur facilisis, elit justo viverra ex, sagittis fringilla quam lorem nec neque. Duis fermentum turpis faucibus dolor luctus dapibus.",
                        PeoplePresent = new List<People>
                        {
                            new People
                            {
                                Id = Guid.Parse("af5464a2-a975-4a6d-a6cd-22cb8425bafb"),
                                Description =
                                    @"First Person - Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean viverra purus at enim convallis euismod. Ut orci dui, ultrices eget feugiat eget, auctor in lorem. Nunc finibus, quam ac consectetur facilisis, elit justo viverra ex, sagittis fringilla quam lorem nec neque. Duis fermentum turpis faucibus dolor luctus dapibus.",
                            },
                            new People
                            {
                                Id = Guid.Parse("66d2dda7-aff4-4731-ab47-c67e7145f16c"),
                                Description =
                                    @"Second Person - Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean viverra purus at enim convallis euismod. Ut orci dui, ultrices eget feugiat eget, auctor in lorem. Nunc finibus, quam ac consectetur facilisis, elit justo viverra ex, sagittis fringilla quam lorem nec neque. Duis fermentum turpis faucibus dolor luctus dapibus.",
                            }
                        },
                        Suspects = new List<Suspect>
                        {
                            new Suspect
                            {
                                Id = Guid.Parse("74ca780c-1901-434c-8236-ee7b773db333"),
                                Accent = "Swedish",
                                Accessories = "Prada handbag",
                                AgeMin = 25,
                                AgeMax = 30,
                                WeightMin = 70,
                                WeightMax = 80,
                                HeightMin = 170,
                                HeightMax = 180,
                                ClothingAndShoes = "Jeans jacket and Nike shoes",
                                Complexion = "Pale",
                                Ethnicity = Ethnicity.NorthernEuropean,
                                FacialAndEars = "Big nose and elven ears.",
                                Gender = Gender.Male,
                                FacialHair = "Beard stubble.",
                                Glasses = "Nope",
                                HairColour = HairColour.DarkBrown,
                                Jewellery = "Phat gold chain!",
                                OtherInformation = "Limp",
                                ScarsMarksTattoos = "A nose tattooed on his nose!"
                            }
                        },
                        Vehicles = new List<Vehicle>
                        {
                            new Vehicle
                            {
                                Id = Guid.Parse("67757a26-7ad4-48f7-bf2c-de336d68f5a9"),
                                Colour = "Red",
                                DrivingStyle = "Erratic",
                                MakeModel = "Volvo 240",
                                NumberOfDoors = 5,
                                OtherInformation = "Cracked Windshield",
                                RegistrationNumber = "EX10 ZRY",
                                Shape = "Triangular",
                                Size = "Big",
                                Speed = "Fast",
                            }
                        },
                        SceneDescription =
                            @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean viverra purus at enim convallis euismod. Ut orci dui, ultrices eget feugiat eget, auctor in lorem. Nunc finibus, quam ac consectetur facilisis, elit justo viverra ex, sagittis fringilla quam lorem nec neque. Duis fermentum turpis faucibus dolor luctus dapibus.",
                        WhatHappened =
                            @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean viverra purus at enim convallis euismod. Ut orci dui, ultrices eget feugiat eget, auctor in lorem. Nunc finibus, quam ac consectetur facilisis, elit justo viverra ex, sagittis fringilla quam lorem nec neque. Duis fermentum turpis faucibus dolor luctus dapibus.",

                    },
                }
            };
            if (!context.Incidents.Any(x => x.Id == incident.Id))
            {
                context.Incidents.Add(incident);
            }
            SaveChanges(context);
        }

        private static void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();
                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb, ex
                );
            }
        }
    }
}