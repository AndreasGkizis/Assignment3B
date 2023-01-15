using ModelProject.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace WebApplication1.Data
{
        public class MyDBInitializer : CreateDatabaseIfNotExists<AppContextDikoMou>
        {
        public void InitializeDatabase(AppContextDikoMou context)
        {
            if (!context.Database.Exists())
            {
                context.Database.Create();
                Seed(context);
                context.SaveChanges();
            }
        }
        protected override void Seed(AppContextDikoMou context)
            {
            // used only to make the results of each exam random
            var _random = new Random();
            #region //try adding 4 candidates only if table is empty
            try
            {
                if (context.Candidates.Count() == 0)
                {
                    Console.WriteLine("Appending initial Data");
                    context.Candidates.Add(new Candidate
                    {
                        CandidateNumber = 75629274,
                        FirstName = "Andreas",
                        MiddleName = "Rixardos",
                        LastName = "Gkizis",
                        Gender = "Male",
                        NativeLanguage = "Greek",
                        DateOfBirth = new DateTime(1991, 5, 24),
                        Email = "And@gmail.com",
                        LandlineNumber = "2109317736",
                        MobileNumber = "6985784626",
                        Address1 = "Dhmofontos 86A",
                        Address2 = "Thrakis 21",
                        CountryOfResidence = "Greece",
                        StateOfResidence = "somestate",
                        TerritoryOfResidence = "some ter",
                        ProvinceOfResidence = "some province",
                        TownOfResidence = "Athens",
                        CityOfResidence = " still athens",
                        PostalCode = "17121",
                        PhotoIdType = IdTypes.PASSPORT,
                        PhotoNumber = "AI653249",
                        PhotoIdIssueDate = new DateTime(2007, 5, 6)
                    });

                    context.Candidates.Add(new Candidate
                    {
                        CandidateNumber = 69854521,
                        FirstName = "Eleni",
                        MiddleName = "Margarita",
                        LastName = "Barda",
                        Gender = "Female",
                        NativeLanguage = "Greek",
                        DateOfBirth = new DateTime(1993, 6, 11),
                        Email = "ElenBar@gmail.com",
                        LandlineNumber = "21116556582",
                        MobileNumber = "69766521369",
                        Address1 = "Dhmofontos 86A",
                        Address2 = "thiseio 98",
                        CountryOfResidence = "Greece",
                        StateOfResidence = "somestate",
                        TerritoryOfResidence = "some ter",
                        ProvinceOfResidence = "some province",
                        TownOfResidence = "Athens",
                        CityOfResidence = " still athens",
                        PostalCode = "11851",
                        PhotoIdType = IdTypes.PASSPORT,
                        PhotoNumber = "UK11238AS",
                        PhotoIdIssueDate = new DateTime(2012, 10, 20)
                    });
                    context.Candidates.Add(new Candidate
                    {
                        CandidateNumber = 1123654,
                        FirstName = "Stavros",
                        MiddleName = "",
                        LastName = "Petsalakis",
                        Gender = "Male",
                        NativeLanguage = "Greek",
                        DateOfBirth = new DateTime(1991, 11, 11),
                        Email = "Stav@gmail.com",
                        LandlineNumber = "2105642846",
                        MobileNumber = "6902254632",
                        Address1 = "Dhmofontos 88",
                        Address2 = "",
                        CountryOfResidence = "Greece",
                        StateOfResidence = "somestate",
                        TerritoryOfResidence = "some ter",
                        ProvinceOfResidence = "some province",
                        TownOfResidence = "Athens",
                        CityOfResidence = " still athens",
                        PostalCode = "11851",
                        PhotoIdType = IdTypes.NATIONAL_ID,
                        PhotoNumber = "AK111238",
                        PhotoIdIssueDate = new DateTime(2001, 1, 28)
                    });
                    context.Candidates.Add(new Candidate
                    {
                        CandidateNumber = 6548135,
                        FirstName = "Kwstas",
                        MiddleName = "Vagelis",
                        LastName = "Politis",
                        Gender = "Male",
                        NativeLanguage = "Greek",
                        DateOfBirth = new DateTime(1991, 12, 1),
                        Email = "Kpol@gmail.com",
                        LandlineNumber = "21054864295",
                        MobileNumber = "698546231",
                        Address1 = "delakroua  88",
                        Address2 = "",
                        CountryOfResidence = "Greece",
                        StateOfResidence = "somestate",
                        TerritoryOfResidence = "some ter",
                        ProvinceOfResidence = "some province",
                        TownOfResidence = "Athens",
                        CityOfResidence = " still athens",
                        PostalCode = "17122",
                        PhotoIdType = IdTypes.NATIONAL_ID,
                        PhotoNumber = "AZ2131238",
                        PhotoIdIssueDate = new DateTime(1998, 1, 28)
                    });
                    context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            #endregion

            #region // try adding 3 Certificate Options
            try
            {
                if (context.Certificates.Count() == 0)
                {
                    //var cer1Topics = context.Topics.Where(p => p.Title == "Topic 1").SingleOrDefault();
                    context.Certificates.Add(new Certificate
                    {

                        Name = "Certificate number 1",
                        ProductEnabled = true,
                        //Topics

                        //MaxScore = context.Topics.Where( item =>  item.Id == 1)
                    });
                    context.Certificates.Add(new Certificate
                    {
                        Name = "Certificate number 2",
                        ProductEnabled = true,
                        //MaxScore = context.Topics.Where( item =>  item.Id == 1)
                    });
                    context.Certificates.Add(new Certificate
                    {
                        Name = "Certificate number 3",
                        ProductEnabled = false,
                        //MaxScore = context.Topics.Where( item =>  item.Id == 1)
                    });
                }
                context.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion

            #region// try adding topic options

            try
            {
                if (context.Topics.Count() == 0)
                {
                    context.Topics.Add(new Topic
                    {
                        Title = "Topic 1",
                        PossibleMarks = 100,
                        Description = " A very important topic 1"
                    });

                    context.Topics.Add(new Topic
                    {
                        Title = "Topic 2",
                        PossibleMarks = 120,
                        Description = " A very important topic 2"
                    });

                    context.Topics.Add(new Topic
                    {
                        Title = "Topic 3",
                        PossibleMarks = 50,
                        Description = " A very important topic 3"
                    });

                    context.Topics.Add(new Topic
                    {
                        Title = "Topic 4",
                        PossibleMarks = 80,
                        Description = " A very important topic 4"
                    });
                }
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion

            #region // try adding Topics to each certificate
            try
            {
                for (int i = 1; i < context.Certificates.Count() + 1; i++)
                {
                    if (context.Certificate_Topics.Where(p => p.Certificate.Id == i).Count() == 0)
                    {
                        for (int j = 1; j < i + 1; j++)
                        {
                            context.Certificate_Topics.Add(new Certificate_Topics
                            {
                                Certificate = context.Certificates.Find(i),
                                Topic = context.Topics.Find(j),
                            });
                        }
                    }
                }
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion

            #region // adding maximum score to each Certificate

            try
            {
                var certs = context.Certificates.ToList();
                var cert_topics = context.Certificate_Topics.Include(p => p.Topic).ToList();
                foreach (var cert in certs)
                {
                    if (cert.MaxScore == 0)
                    {
                        foreach (var cert_topic in cert_topics)
                        {
                            if (cert.Id == cert_topic.Certificate.Id)
                            {
                                cert.MaxScore += cert_topic.Topic.PossibleMarks;
                            }
                        }
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion

            #region // try adding Examinations for some candidates (some left empty for testing reasons)
            try
            {
                if (context.Certificates.Count() != 0 &&
                        context.Candidates.Count() != 0 &&
                        context.Examinations.Count() == 0)
                {
                    #region // adding 3 examinations to Candidate with Id = 1
                    context.Examinations.Add(new Examination
                    {
                        Candidate_Id = context.Candidates.Find(1),
                        Certificate_Id = context.Certificates.Find(1),
                        AssessmentCode = "AQ1862RF",
                        ExaminationDate = new DateTime(2019, 2, 15),
                        ScoreReportDate = new DateTime(2019, 2, 16),
                    });
                    context.Examinations.Add(new Examination
                    {
                        Candidate_Id = context.Candidates.Find(1),
                        Certificate_Id = context.Certificates.Find(1),
                        AssessmentCode = "AQ2312RF",
                        ExaminationDate = new DateTime(2021, 2, 15),
                        ScoreReportDate = new DateTime(2021, 2, 16),
                    });
                    context.Examinations.Add(new Examination
                    {
                        Candidate_Id = context.Candidates.Find(1),
                        Certificate_Id = context.Certificates.Find(3),
                        AssessmentCode = "AQ9q8eq",
                        ExaminationDate = new DateTime(2022, 2, 15),
                        ScoreReportDate = new DateTime(2022, 2, 16),
                    });
                    #endregion

                    #region// adding 2 examinations to Candidate with id = 2
                    context.Examinations.Add(new Examination
                    {
                        Candidate_Id = context.Candidates.Find(2),
                        Certificate_Id = context.Certificates.Find(2),
                        AssessmentCode = "AQ9872RF",
                        ExaminationDate = new DateTime(2020, 2, 15),
                        ScoreReportDate = new DateTime(2020, 2, 16),
                    });
                    context.Examinations.Add(new Examination
                    {
                        Candidate_Id = context.Candidates.Find(2),
                        Certificate_Id = context.Certificates.Find(3),
                        AssessmentCode = "PA64682",
                        ExaminationDate = new DateTime(2022, 2, 15),
                        ScoreReportDate = new DateTime(2022, 2, 16),
                    });
                    #endregion

                    #region// adding 1 Exam to Candidate with Id = 3
                    context.Examinations.Add(new Examination
                    {
                        Candidate_Id = context.Candidates.Find(3),
                        Certificate_Id = context.Certificates.Find(3),
                        AssessmentCode = "KLa42034",
                        ExaminationDate = new DateTime(2022, 2, 15),
                        ScoreReportDate = new DateTime(2022, 2, 16),
                    });
                    #endregion

                    // ------------------------------------
                    // CANDIDATE 4 HAS NO EXAMS FOR TESTING 
                    // ------------------------------------
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion

            #region // generating Random results for each exam based onthe available topics
            try
            {
                var exams = context.Examinations.ToList();
                var topics = context.Certificate_Topics.Include(p => p.Certificate).Include(p => p.Topic).ToList();
                if (exams.Count() != 0 && context.ExaminationTopic_Results.Count() == 0)
                {
                    foreach (var exam in exams)
                    {
                        foreach (var topic in topics)
                        {
                            if (topic.Certificate.Id == exam.Certificate_Id.Id)
                            {
                                context.ExaminationTopic_Results.Add(new ExaminationTopic_Results
                                {
                                    Examination = exam,
                                    Topic = topic.Topic,
                                    AwardedMarks = _random.Next(30, topic.Topic.PossibleMarks + 1)
                                });
                            }
                        }
                    }
                }

                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
                Console.WriteLine(e.InnerException.StackTrace);
                throw;
            }
            #endregion

            #region // update Examination scores and Pass/Fail based on the existing data from above 

            var exams2 = context.Examinations.Include(p => p.Certificate_Id).ToList();
            var results = context.ExaminationTopic_Results.ToList();
            foreach (var exam in exams2)
            {
                if (exam.CandidateScore == 0)
                {
                    int counter = 0;
                    foreach (var result in results)
                    {
                        if (result.Examination.Id == exam.Id)
                        {
                            exam.CandidateScore += result.AwardedMarks;
                            counter++;
                        }
                    }
                }
                context.SaveChanges();
                exam.PercentageScore = ((decimal)exam.CandidateScore / (decimal)exam.Certificate_Id.MaxScore) * 100;
                context.SaveChanges();

                if (exam.PercentageScore > 65.00m)
                {
                    exam.Passed = true;
                }
            }
            context.SaveChanges();
            #endregion

            Console.WriteLine("Appending Data Complete!");

            base.Seed(context);
            }
        }
    }

