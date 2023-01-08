namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arxiko : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CandidateNumber = c.Int(nullable: false),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        NativeLanguage = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Email = c.String(),
                        LandlineNumber = c.String(),
                        MobileNumber = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        CountryOfResidence = c.String(),
                        StateOfResidence = c.String(),
                        TerritoryOfResidence = c.String(),
                        ProvinceOfResidence = c.String(),
                        TownOfResidence = c.String(),
                        CityOfResidence = c.String(),
                        PostalCode = c.String(),
                        PhotoIdType = c.Int(nullable: false),
                        PhotoNumber = c.String(),
                        PhotoIdIssueDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Certificate_Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Certificate_Id = c.Int(),
                        Topic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Certificates", t => t.Certificate_Id)
                .ForeignKey("dbo.Topics", t => t.Topic_Id)
                .Index(t => t.Certificate_Id)
                .Index(t => t.Topic_Id);
            
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProductEnabled = c.Boolean(nullable: false),
                        MaxScore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PossibleMarks = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Examinations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssessmentCode = c.String(),
                        ExaminationDate = c.DateTime(nullable: false),
                        ScoreReportDate = c.DateTime(nullable: false),
                        CandidateScore = c.Int(nullable: false),
                        Passed = c.Boolean(nullable: false),
                        PercentageScore = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Candidate_Id_Id = c.Int(nullable: false),
                        Certificate_Id_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidates", t => t.Candidate_Id_Id, cascadeDelete: true)
                .ForeignKey("dbo.Certificates", t => t.Certificate_Id_Id)
                .Index(t => t.Candidate_Id_Id)
                .Index(t => t.Certificate_Id_Id);
            
            CreateTable(
                "dbo.ExaminationTopic_Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AwardedMarks = c.Int(nullable: false),
                        Examination_Id = c.Int(nullable: false),
                        Topic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Examinations", t => t.Examination_Id, cascadeDelete: true)
                .ForeignKey("dbo.Topics", t => t.Topic_Id)
                .Index(t => t.Examination_Id)
                .Index(t => t.Topic_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExaminationTopic_Results", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.ExaminationTopic_Results", "Examination_Id", "dbo.Examinations");
            DropForeignKey("dbo.Examinations", "Certificate_Id_Id", "dbo.Certificates");
            DropForeignKey("dbo.Examinations", "Candidate_Id_Id", "dbo.Candidates");
            DropForeignKey("dbo.Certificate_Topics", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.Certificate_Topics", "Certificate_Id", "dbo.Certificates");
            DropIndex("dbo.ExaminationTopic_Results", new[] { "Topic_Id" });
            DropIndex("dbo.ExaminationTopic_Results", new[] { "Examination_Id" });
            DropIndex("dbo.Examinations", new[] { "Certificate_Id_Id" });
            DropIndex("dbo.Examinations", new[] { "Candidate_Id_Id" });
            DropIndex("dbo.Certificate_Topics", new[] { "Topic_Id" });
            DropIndex("dbo.Certificate_Topics", new[] { "Certificate_Id" });
            DropTable("dbo.ExaminationTopic_Results");
            DropTable("dbo.Examinations");
            DropTable("dbo.Topics");
            DropTable("dbo.Certificates");
            DropTable("dbo.Certificate_Topics");
            DropTable("dbo.Candidates");
        }
    }
}
