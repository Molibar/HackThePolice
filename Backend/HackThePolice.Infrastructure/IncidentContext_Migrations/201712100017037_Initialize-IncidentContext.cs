namespace HackThePolice.Infrastructure.IncidentContext_Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeIncidentContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Incidents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        PoliceStation = c.String(),
                        TelephoneNumber = c.String(),
                        IncidentReference = c.String(),
                        OccurredAt = c.DateTime(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Statements",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IncidentId = c.Guid(),
                        ContactDetailsId = c.Guid(),
                        WhatHappened = c.String(),
                        SceneDescription = c.String(),
                        CircumstanceId = c.Guid(),
                        OtherInformation = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Circumstances", t => t.CircumstanceId)
                .ForeignKey("dbo.ContactDetails", t => t.ContactDetailsId)
                .ForeignKey("dbo.Incidents", t => t.IncidentId)
                .Index(t => t.IncidentId)
                .Index(t => t.ContactDetailsId)
                .Index(t => t.CircumstanceId);
            
            CreateTable(
                "dbo.Circumstances",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        HowLong = c.Int(),
                        Weather = c.String(),
                        TimeOfDay = c.Time(nullable: false, precision: 7),
                        Obstructions = c.String(),
                        ReasonToRemember = c.String(),
                        KnownPeople = c.String(),
                        TimePassed = c.Int(),
                        DescriptionOfYourselfAndClothing = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Wiv = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(),
                        Address = c.String(),
                        PostCode = c.String(),
                        TelephoneNumber = c.String(),
                        MobileNumber = c.String(),
                        Email = c.String(),
                        WillingToTestify = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StatementId = c.Guid(),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Statements", t => t.StatementId)
                .Index(t => t.StatementId);
            
            CreateTable(
                "dbo.Suspects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StatementId = c.Guid(),
                        Gender = c.Int(nullable: false),
                        Ethnicity = c.Int(nullable: false),
                        HairColour = c.Int(nullable: false),
                        ClothingAndShoes = c.String(),
                        Jewellery = c.String(),
                        AgeMin = c.Int(),
                        AgeMax = c.Int(),
                        WeightMin = c.Int(),
                        WeightMax = c.Int(),
                        HeightMin = c.Int(),
                        HeightMax = c.Int(),
                        FacialHair = c.String(),
                        Accent = c.String(),
                        Accessories = c.String(),
                        FacialAndEars = c.String(),
                        Complexion = c.String(),
                        Glasses = c.String(),
                        ScarsMarksTattoos = c.String(),
                        OtherInformation = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Statements", t => t.StatementId)
                .Index(t => t.StatementId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StatementId = c.Guid(),
                        Size = c.String(),
                        MakeModel = c.String(),
                        DrivingStyle = c.String(),
                        Shape = c.String(),
                        NumberOfDoors = c.Int(),
                        Speed = c.String(),
                        Colour = c.String(),
                        RegistrationNumber = c.String(),
                        OtherInformation = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Statements", t => t.StatementId)
                .Index(t => t.StatementId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "StatementId", "dbo.Statements");
            DropForeignKey("dbo.Suspects", "StatementId", "dbo.Statements");
            DropForeignKey("dbo.People", "StatementId", "dbo.Statements");
            DropForeignKey("dbo.Statements", "IncidentId", "dbo.Incidents");
            DropForeignKey("dbo.Statements", "ContactDetailsId", "dbo.ContactDetails");
            DropForeignKey("dbo.Statements", "CircumstanceId", "dbo.Circumstances");
            DropIndex("dbo.Vehicles", new[] { "StatementId" });
            DropIndex("dbo.Suspects", new[] { "StatementId" });
            DropIndex("dbo.People", new[] { "StatementId" });
            DropIndex("dbo.Statements", new[] { "CircumstanceId" });
            DropIndex("dbo.Statements", new[] { "ContactDetailsId" });
            DropIndex("dbo.Statements", new[] { "IncidentId" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.Suspects");
            DropTable("dbo.People");
            DropTable("dbo.ContactDetails");
            DropTable("dbo.Circumstances");
            DropTable("dbo.Statements");
            DropTable("dbo.Incidents");
        }
    }
}
