using System;
using System.Collections.Generic;
using HackThePolice.Infrastructure.Core.Models;

namespace HackThePolice.Api.Models
{
    public class IncidentModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string PoliceStation { get; set; }
        public string TelephoneNumber { get; set; }
        public string IncidentReference { get; set; }
        public List<StatementModel> Statements { get; set; } = new List<StatementModel>();
        public DateTime? OccurredAt { get; set; }
    }

    public class StatementModel
    {
        public Guid? Id { get; set; }
        public Guid? IncidentId { get; set; }

        public ContactDetailsModel ContactDetails { get; set; } = new ContactDetailsModel();

        /// <summary>
        /// Section A: What Happened.
        /// </summary>
        public string WhatHappened { get; set; }

        /// <summary>
        /// Section B: Who committed the crime?
        /// </summary>
        public List<SuspectModel> Suspects { get; set; } = new List<SuspectModel>();

        /// <summary>
        /// Section C: The scene
        /// </summary>
        public string SceneDescription { get; set; }

        /// <summary>
        /// Section D: Were other people present who saw what happened?
        /// </summary>
        public List<PeopleModel> PeoplePresent { get; set; } = new List<PeopleModel>();

        /// <summary>
        /// Section E: Were there any vehicles involved?
        /// </summary>
        public List<VehicleModel> Vehicles { get; set; } = new List<VehicleModel>();

        /// <summary>
        /// Section F: How well did you see the incident?
        /// </summary>
        public CircumstanceModel Circumstance { get; set; } = new CircumstanceModel();
        /// <summary>
        /// Section G: Is there any other information you would like to tell us about the
        /// event that we have not asked you about? If so, write it in the space below.
        /// </summary>
        public string OtherInformation { get; set; }
    }

    public class CircumstanceModel
    {
        public Guid? Id { get; set; }
        public int HowLong { get; set; }
        public string Weather { get; set; }
        public TimeSpan TimeOfDay { get; set; }
        public string Obstructions { get; set; }
        public string ReasonToRemember { get; set; }
        public string KnownPeople { get; set; }
        public int TimePassed { get; set; }
        public string DescriptionOfYourselfAndClothing { get; set; }
    }

    public class VehicleModel
    {
        public Guid? Id { get; set; }

        public string Size { get; set; }
        public string MakeModel { get; set; }
        public string DrivingStyle { get; set; }
        public string Shape { get; set; }
        public int NumberOfDoors { get; set; }
        public string Speed { get; set; }
        public string Colour { get; set; }
        public string RegistrationNumber { get; set; }
        public string OtherInformation { get; set; }
    }

    public class PeopleModel
    {
        public Guid? Id { get; set; }

        public string Description { get; set; }
    }

    public class ContactDetailsModel
    {
        public Guid? Id { get; set; }
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

    public class SuspectModel
    {
        public Guid? Id { get; set; }

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
}