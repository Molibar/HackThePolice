using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackThePolice.Infrastructure.Core.Models
{
    public class Incident : DBEntity
    {
        public string Name { get; set; }
        public string PoliceStation { get; set; }
        public string TelephoneNumber { get; set; }
        public string IncidentReference { get; set; }
        public List<Statement> Statements { get; set; }
        public DateTime? OccurredAt { get; set; }
    }
    public class Statement : DBEntity
    {
        [ForeignKey(nameof(Incident))]
        public Guid? IncidentId { get; set; }

        public Incident Incident { get; set; }

        [ForeignKey(nameof(ContactDetails))]
        public Guid? ContactDetailsId { get; set; }
        public ContactDetails ContactDetails { get; set; }

        /// <summary>
        /// Section A: What Happened.
        /// </summary>
        public string WhatHappened { get; set; }

        /// <summary>
        /// Section B: Who committed the crime?
        /// </summary>
        public List<Suspect> Suspects { get; set; } = new List<Suspect>();

        /// <summary>
        /// Section C: The scene
        /// </summary>
        public string SceneDescription { get; set; }

        /// <summary>
        /// Section D: Were other people present who saw what happened?
        /// </summary>
        public List<People> PeoplePresent { get; set; }

        /// <summary>
        /// Section E: Were there any vehicles involved?
        /// </summary>
        public List<Vehicle> Vehicles { get; set; }

        [ForeignKey(nameof(Circumstance))]
        public Guid? CircumstanceId { get; set; }
        /// <summary>
        /// Section F: How well did you see the incident?
        /// </summary>
        public Circumstance Circumstance { get; set; }
        /// <summary>
        /// Section G: Is there any other information you would like to tell us about the
        /// event that we have not asked you about? If so, write it in the space below.
        /// </summary>
        public string OtherInformation { get; set; }
    }

    public class Circumstance : DBEntity
    {
        public int? HowLong { get; set; }
        public string Weather { get; set; }
        public TimeSpan TimeOfDay { get; set; }
        public string Obstructions { get; set; }
        public string ReasonToRemember { get; set; }
        public string KnownPeople { get; set; }
        public int? TimePassed { get; set; }
        public string DescriptionOfYourselfAndClothing { get; set; }
    }

    public class Vehicle : DBEntity
    {
        [ForeignKey(nameof(Statement))]
        public Guid? StatementId { get; set; }
        public Statement Statement { get; set; }

        public string Size { get; set; }
        public string MakeModel { get; set; }
        public string DrivingStyle { get; set; }
        public string Shape { get; set; }
        public int? NumberOfDoors { get; set; }
        public string Speed { get; set; }
        public string Colour { get; set; }
        public string RegistrationNumber { get; set; }
        public string OtherInformation { get; set; }
    }

    public class People : DBEntity
    {
        [ForeignKey(nameof(Statement))]
        public Guid? StatementId { get; set; }
        public Statement Statement { get; set; }

        public string Description { get; set; }
    }

    public class ContactDetails : DBEntity
    {
        public WIV Wiv { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public bool WillingToTestify { get; set; }
    }

    public class Suspect : DBEntity
    {
        [ForeignKey(nameof(Statement))]
        public Guid? StatementId { get; set; }
        public Statement Statement { get; set; }

        public Gender Gender { get; set; }
        public Ethnicity Ethnicity { get; set; }
        public HairColour HairColour { get; set; }
        public string ClothingAndShoes { get; set; }
        public string Jewellery { get; set; }
        public int? AgeMin { get; set; }
        public int? AgeMax { get; set; }
        public int? WeightMin { get; set; }
        public int? WeightMax { get; set; }
        public int? HeightMin { get; set; }
        public int? HeightMax { get; set; }
        public string FacialHair { get; set; }
        public string Accent { get; set; }
        public string Accessories { get; set; }
        public string FacialAndEars { get; set; }
        public string Complexion { get; set; }
        public string Glasses { get; set; }
        public string ScarsMarksTattoos { get; set; }
        public string OtherInformation { get; set; }
    }

    public enum HairColour
    {
        Unknown = 0,
        LightBlonde = 1,
        Blonde = 2,
        DarkBlonde = 3,
        Ginger = 4,
        LightBrown = 5,
        Brown = 6,
        DarkBrown = 7,
        Black = 8,
        Pink = 9,
        Red = 10,
        Green = 11,
        Blue = 12,
        Other = 13
    }

    public enum Ethnicity
    {
        Unknown = 0,
        NorthernEuropean = 1,
        SouthernEuropean = 2,
        African = 3,
        Asian = 4,
        Oriental = 5,
        NorthAfricanArabic = 6,
    }

    public enum Gender
    {
        Unknown = 0,
        Male = 1,
        Female = 2,
        TransMale = 3,
        TransFemale = 4
    }



    [Flags]
    public enum WIV
    {
        Unknown = 0,
        Witness = 1,
        Informant = 2,
        Victim = 3
    }
}