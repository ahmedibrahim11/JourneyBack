namespace joureny.Data.Migrations
{
    using joureny.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<joureny.Data.JourenyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(joureny.Data.JourenyContext context)
        {

            //if (!System.Diagnostics.Debugger.IsAttached)
            //    System.Diagnostics.Debugger.Launch();

            #region [QuestionSeed]
            //List<Question> Questions = new List<Question>()
            //{
            //     new Question()
            //     {
            //          Name="Who are your target customers? And what networks do you want to connect to?",
            //           IsTop=false,
            //           IsMandatory=true
            //     },
            //     new Question()
            //     {
            //          Name="Is the startup a service or product startup",
            //           IsTop=false,
            //           IsMandatory=true
            //     },
            //     new Question()
            //     {
            //          Name="Which of the following categorizations apply to you (if any)",
            //           IsTop=false,
            //           IsMandatory=true
            //     },
            //     new Question()
            //     {
            //          Name="Organization's facebook ",
            //           IsTop=false,
            //           IsMandatory=true
            //     },
            //     new Question()
            //     {
            //          Name="Who are your target customers? And what networks do you want to connect to?",
            //           IsTop=false,
            //           IsMandatory=true
            //     },
            //     new Question()
            //     {
            //          Name="Organization's Linkedin",
            //           IsTop=false,
            //           IsMandatory=true
            //     },
            //};

            //context.Questions.AddRange(Questions);
            //context.SaveChanges();

            #endregion

            Trip trip = new Trip()
            {
                TripName = "Trip one",
            };

            Trip trip2 = new Trip()
            {
                TripName = "Trip Two",
            };

            //context.Trips.Add(trip);
            //context.Trips.Add(trip2);




            User user = new User()
            {
                UserName = "seka",
                Email = "aa",
                Role = Role.User,
                Gender = Gender.male,
                MobileNumber = 12233,
                Password = "popos"
            };

            User user2 = new User()
            {
                UserName = "ahmed",
                Email = "ahmed",
                Role = Role.User,
                Gender = Gender.male,
                MobileNumber = 12233,
                Password = "popos"

            };

            //context.Users.Add(user);
            //context.Users.Add(user2);

            //context.SaveChanges();


            List<UserTrips> UserTrips = new List<Entities.UserTrips>()
            {
                 new Entities.UserTrips()
                 {
                      Trip=trip,
                       User= user
                 },
                 new Entities.UserTrips()
                 {
                      Trip=trip2,
                       User=user2
                 }
            };


            UserTrips.ForEach(x => context.UserTrips.Add(x));
            context.SaveChanges();




            var tripQuestion = context.Trips.FirstOrDefault(s => s.TripName == "Trip one");






            #region Questions

            Question Question = new Question()
            {
                Name = "Startup name",
                Metadata = "Startup name",
                IsTop = true,
                IsMandatory = true,
                QuestionType = QuestionType.YesNo,
                QuestionTab = QuestionTab.ProductService
            };

            Question Question2 = new Question()
            {
                Name = "Please provide a summary of 1-2 lines about your organization.",
                Metadata = "Description / Summary",
                IsTop = true,
                IsMandatory = true,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.ProductService
            };

            Question Question3 = new Question()
            {
                Name = "Please list in short words all of your products / offerings.",
                Metadata = "Offerings",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.ProductService
            };

            Question Question4 = new Question()
            {
                Name = "Who are your target customers? And what networks do you want to connect to?",
                Metadata = "Target market",
                IsTop = false,
                IsMandatory = true,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.ProductService
            };


            Question Question5 = new Question()
            {
                Name = "Is the startup a service or product startup?",
                Metadata = "Is it a service or product startup",
                IsTop = false,
                IsMandatory = true,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.ProductService
            };


            Question Question6 = new Question()
            {
                Name = "Which of the following categorizations apply to you(if any)?",
                Metadata = "Platform Type",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.ProductService
            };

            Question Question7 = new Question()
            {
                Name = "Website :",
                Metadata = "Website",
                IsTop = true,
                IsMandatory = true,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.ProductService
            };
            Question Question8 = new Question()
            {
                Name = "Organization's Facebook :",
                Metadata = "Facebook Page",
                IsTop = false,
                IsMandatory = true,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.ProductService
            };

            Question Question9 = new Question()
            {
                Name = "Organization's LinkedIn :",
                Metadata = "LinkedIn Page",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.ProductService
            };

            Question Question10 = new Question()
            {
                Name = "Organization's Instagram :",
                Metadata = "Instgram Page",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.ProductService
            };

            Question Question11 = new Question()
            {
                Name = "Organization's Facebook group :",
                Metadata = "Facebook group",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.ProductService
            };


            Question Question12 = new Question()
            {
                Name = "Link to Video/Portfolio/Pictures of work :",
                Metadata = "Video / Portfolio",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.ProductService
            };

            Question Question13 = new Question()
            {
                Name = "Second startup name :",
                Metadata = "Second startup name",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.ProductService
            };

            Question Question14 = new Question()
            {
                Name = "Description / Summary :",
                Metadata = "Description / Summary",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.ProductService
            };

            Question Question15 = new Question()
            {
                Name = "Second startup Facebook page :",
                Metadata = "Second startup FB page",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.ProductService
            };

            Question Question16 = new Question()
            {
                Name = "Industry :",
                Metadata = "",
                IsTop = false,
                IsMandatory = true,
                QuestionType = QuestionType.MultipleAnswers,
                QuestionTab = QuestionTab.Organization
            };
            Question Question17 = new Question()
            {
                Name = "Which phase is your startup currently in?",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Organization
            };

            Question Question18 = new Question()
            {
                Name = "Year started :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Organization
            };

            Question Question19 = new Question()
            {
                Name = "Funding raised :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.YesNo,
                QuestionTab = QuestionTab.Organization
            };

            Question Question20 = new Question()
            {
                Name = "Funding Stage :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Organization
            };

            Question Question21 = new Question()
            {
                Name = "What is the business model?",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Organization
            };

            Question Question22 = new Question()
            {
                Name = "Is the startup social or business focus?",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Organization
            };

            Question Question23 = new Question()
            {
                Name = "Is the startup Consumption or production based?",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Organization
            };

            Question Question24 = new Question()
            {
                Name = "Number of employees :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Organization
            };

            Question Question25 = new Question()
            {
                Name = "Number of Founders :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Organization
            };

            Question Question26 = new Question()
            {
                Name = "Number of Customers/Users :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Organization
            };

            Question Question27 = new Question()
            {
                Name = "Number of branches (if any) :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Organization
            };

            Question Question28 = new Question()
            {
                Name = "Experience with registration in Delaware/abroad :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.YesNo,
                QuestionTab = QuestionTab.Organization
            };

            Question Question29 = new Question()
            {
                Name = "Open to franchising / global expansion?",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.YesNo,
                QuestionTab = QuestionTab.Organization
            };

            Question Question30 = new Question()
            {
                Name = "Open to franchising / global expansion?",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.YesNo,
                QuestionTab = QuestionTab.Organization
            };

            Question Question31 = new Question()
            {
                Name = "Countries you operate in outside of Egypt :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Organization
            };

            Question Question32 = new Question()
            {
                Name = "Job roles you are hiring for / experts you need :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Organization
            };

            Question Question33 = new Question()
            {
                Name = "What month do you usually do strategic planning for the new year?",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Organization
            };

            Question Question34 = new Question()
            {
                Name = "Upload Photo :",
                Metadata = "",
                IsTop = true,
                IsMandatory = true,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };

            Question Question35 = new Question()
            {
                Name = "Full Name :",
                Metadata = "",
                IsTop = true,
                IsMandatory = true,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };

            Question Question36 = new Question()
            {
                Name = "Mobile Number :",
                Metadata = "",
                IsTop = true,
                IsMandatory = true,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };

            Question Question37 = new Question()
            {
                Name = "Email Address :",
                Metadata = "",
                IsTop = true,
                IsMandatory = true,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };

            Question Question38 = new Question()
            {
                Name = "Governorate you currently live in :",
                Metadata = "",
                IsTop = false,
                IsMandatory = true,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Personal

            };

            Question Question39 = new Question()
            {
                Name = "Governorate you are from :",
                Metadata = "",
                IsTop = false,
                IsMandatory = true,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Personal

            };
            Question Question40 = new Question()
            {
                Name = "Nationality :",
                Metadata = "",
                IsTop = false,
                IsMandatory = true,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Personal

            };

            Question Question41 = new Question()
            {
                Name = "Age :",
                Metadata = "",
                IsTop = false,
                IsMandatory = true,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Personal

            };

            Question Question42 = new Question()
            {
                Name = "Gender :",
                Metadata = "",
                IsTop = false,
                IsMandatory = true,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Personal

            };

            Question Question43 = new Question()
            {
                Name = "Linkedin account link :",
                Metadata = "",
                IsTop = false,
                IsMandatory = true,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };

            Question Question44 = new Question()
            {
                Name = "Facebook account link :",
                Metadata = "",
                IsTop = false,
                IsMandatory = true,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };

            Question Question45 = new Question()
            {
                Name = "Instagram account link :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };

            Question Question46 = new Question()
            {
                Name = "Name of your Employer :",
                Metadata = "",
                IsTop = true,
                IsMandatory = true,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };

            Question Question47 = new Question()
            {
                Name = "Job Title :",
                Metadata = "",
                IsTop = true,
                IsMandatory = true,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };

            Question Question48 = new Question()
            {
                Name = "Position Type :",
                Metadata = "",
                IsTop = false,
                IsMandatory = true,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Personal

            };

            Question Question49 = new Question()
            {
                Name = "Is the startup a full time or part time role?",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Personal

            };

            Question Question50 = new Question()
            {
                Name = "Graduating Degree :",
                Metadata = "",
                IsTop = false,
                IsMandatory = true,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };

            Question Question51 = new Question()
            {
                Name = "University :",
                Metadata = "",
                IsTop = false,
                IsMandatory = true,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };

            Question Question52 = new Question()
            {
                Name = "Student clubs joined :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };

            Question Question53 = new Question()
            {
                Name = "Your Myers Briggs Personality :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Personal

            };

            Question Question54 = new Question()
            {
                Name = "What are your 'areas of expertise'? e.g. AI, Web development ( Separate each topic by commas)",
                Metadata = "",
                IsTop = true,
                IsMandatory = true,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };

            Question Question55 = new Question()
            {
                Name = "What is something you are good at and can teach to the group or give an introduction to in 20 minutes?",
                Metadata = "",
                IsTop = true,
                IsMandatory = true,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };

            Question Question56 = new Question()
            {
                Name = "What are you passionate about - issues / hobbies / topics ? (Separate each topic by commas)",
                Metadata = "",
                IsTop = true,
                IsMandatory = true,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };

            Question Question57 = new Question()
            {
                Name = "What knowledge, skills or networks do you need support with to grow your work that other attending mentors / experts can help with? (Please mention up-to 3 areas only separated by commas)",
                Metadata = "",
                IsTop = true,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };

            Question Question58 = new Question()
            {
                Name = "Fellowships / awards :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };

            Question Question59 = new Question()
            {
                Name = "Number of previous startups (Failed and Succeeded) :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };

            Question Question60 = new Question()
            {
                Name = "Age of starting startup :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };

            Question Question61 = new Question()
            {
                Name = "What is the one habit that works really well for your focus and wellbeing ?",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };
            //        Volunteer interests Issues you like to volunteer in that important to you ? TEXT BOX
            Question Question62 = new Question()
            {
                Name = "Issues you like to volunteer in that important to you ?",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };
            //        Title of trainings  Title of past trainings given if any        TEXT BOX
            Question Question63 = new Question()
            {
                Name = "Title of past trainings given (if any) :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };
            //        International conference experiences Please list any other camps, leadership training, international conferences or educational programs you have participated in 		TEXT BOX
            Question Question64 = new Question()
            {
                Name = "International conferences or educational programs you have participated in :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };
            //        User Persona    What of the following applies to you? Engaged Married Parent  Other
            Question Question65 = new Question()
            {
                Name = "What of the following applies to you?",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Personal

            };
            //  Out of egypt    Current location        In Egypt    Out of Egypt
            Question Question66 = new Question()
            {
                Name = "Current location :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Personal

            };
            //  Headquarters Area Headquarters Area e.g.Downtown TEXT BOX
            Question Question67 = new Question()
            {
                Name = "Headquarters Area e.g.Downtown :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };
            //Home Area Home Area e.g.Mohandessin TEXT BOX
            Question Question68 = new Question()
            {
                Name = "Home Area e.g.Mohandessin :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };
            //Recommended Ecosystem service providers(based on experience)   Ecosystem service providers you were part of and recommend TEXT BOX
            Question Question69 = new Question()
            {
                Name = "Ecosystem service providers you were part of and recommend :",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal

            };
            //Recommended Industry groups(facebook/ linkedin)	What are some of your favorite Facebook industry groups TEXT BOX

            Question Question70 = new Question()
            {
                Name = "What are some of your favorite Facebook industry groups ?",
                Metadata = "",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Personal
            };

            Question Question71 = new Question()
            {
                Name = "What are the INTERNATIONAL OR REGIONAL MARKETS you are connected to ? i.e.maybe because of your studies you studied in the states and are connected to AI experts in the US",
                Metadata = "Global Markets :",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Connections
            };

            Question Question72 = new Question()
            {
                Name = "What are the LOCAL MARKETS you are connected to ? (i.e.maybe you were born out of Cairo and have a big network in other local governorates)",
                Metadata = "Local Markets :",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Connections
            };

            Question Question73 = new Question()
            {
                Name = "What are the PROFESSIONS AND INDUSTRIES you are connected to ? (i.e. for example if you work with teens and teachers so have a good network of friends / acquaintances who are teachers in public schools for example)",
                Metadata = "Previous Networks that you have been a part of :",
                IsTop = false,
                IsMandatory = true,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Connections
            };


            Question Question74 = new Question()
            {
                Name = "Any discounts you want to give to members of the network if yes please specify ?",
                Metadata = "Community Discounts offered :",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Text,
                QuestionTab = QuestionTab.Community
            };

            Question Question75 = new Question()
            {
                Name = "Which of the following areas do you have experience with ?",
                Metadata = "Previous experience :",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Community
            };

            Question Question76 = new Question()
            {
                Name = "Availability of providing internships/ on - hand training / shadowing in your office ?",
                Metadata = "Internship / shadowing friendly office :",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.YesNo,
                QuestionTab = QuestionTab.Community
            };

            Question Question77 = new Question()
            {
                Name = "What is the best way to connect ?",
                Metadata = "Connect through :",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.Dropdown,
                QuestionTab = QuestionTab.Community
            };

            Question Question78 = new Question()
            {
                Name = "Availability of providing 1 hour office tours for earlier stage founders ?",
                Metadata = "Open to mentor :",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.YesNo,
                QuestionTab = QuestionTab.Community
            };

            Question Question79 = new Question()
            {
                Name = "Do you have access to interesting Market trends in in your field that are SHARABLE ?",
                Metadata = "Sharable Research :",
                IsTop = false,
                IsMandatory = false,
                QuestionType = QuestionType.YesNo,
                QuestionTab = QuestionTab.Community
            };

            #endregion









            List<TripQuestion> TripQuestions = new List<TripQuestion>()
              {
                  new TripQuestion()
                  {
                       Question=Question,
                       Trip=trip
                  },

                  new TripQuestion()
                  {
                       Question=Question2,
                       Trip=trip
                  },
                  new TripQuestion()
                  {
                       Question=Question3,
                       Trip=trip
                  },
                   new TripQuestion()
                  {
                       Question=Question4,
                       Trip=trip
                  }, new TripQuestion()
                  {
                       Question=Question5,
                       Trip=trip
                  }, new TripQuestion()
                  {
                       Question=Question6,
                       Trip=trip
                  }, new TripQuestion()
                  {
                       Question=Question7,
                       Trip=trip
                  },
                    new TripQuestion()
                  {
                       Question=Question8,
                       Trip=trip
                  }, new TripQuestion()
                  {
                       Question=Question9,
                       Trip=trip
                  }, new TripQuestion()
                  {
                       Question=Question10,
                       Trip=trip
                  }, new TripQuestion()
                  {
                       Question=Question11,
                       Trip=trip
                  }, new TripQuestion()
                  {
                       Question=Question12,
                       Trip=trip
                  }, new TripQuestion()
                  {
                       Question=Question13,
                       Trip=trip
                  }
                  //,new TripQuestion()
                  //{
                  //     Question=Question14,
                  //     Trip=trip
                  //},

                  //new TripQuestion()
                  //{
                  //     Question=Question15,
                  //     Trip=trip
                  //},
                  //new TripQuestion()
                  //{
                  //     Question=Question16,
                  //     Trip=trip
                  //},
                  // new TripQuestion()
                  //{
                  //     Question=Question17,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question18,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question19,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question20,
                  //     Trip=trip
                  //},
                  //  new TripQuestion()
                  //{
                  //     Question=Question21,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question22,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question23,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question24,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question25,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question26,
                  //     Trip=trip
                  //},
                  //  new TripQuestion()
                  //{
                  //     Question=Question27,
                  //     Trip=trip
                  //},

                  //new TripQuestion()
                  //{
                  //     Question=Question28,
                  //     Trip=trip
                  //},
                  //new TripQuestion()
                  //{
                  //     Question=Question29,
                  //     Trip=trip
                  //},
                  // new TripQuestion()
                  //{
                  //     Question=Question30,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question31,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question32,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question33,
                  //     Trip=trip
                  //},
                  //  new TripQuestion()
                  //{
                  //     Question=Question34,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question35,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question36,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question37,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question38,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question39,
                  //     Trip=trip
                  //},new TripQuestion()
                  //{
                  //     Question=Question40,
                  //     Trip=trip
                  //},

                  //new TripQuestion()
                  //{
                  //     Question=Question41,
                  //     Trip=trip
                  //},
                  //new TripQuestion()
                  //{
                  //     Question=Question42,
                  //     Trip=trip
                  //},
                  // new TripQuestion()
                  //{
                  //     Question=Question43,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question44,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question45,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question46,
                  //     Trip=trip
                  //},
                  //  new TripQuestion()
                  //{
                  //     Question=Question47,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question48,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question49,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question50,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question51,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question52,
                  //     Trip=trip
                  //},
                  //  new TripQuestion()
                  //{
                  //     Question=Question53,
                  //     Trip=trip
                  //},

                  //new TripQuestion()
                  //{
                  //     Question=Question54,
                  //     Trip=trip
                  //},

                  //new TripQuestion()
                  //{
                  //     Question=Question55,
                  //     Trip=trip
                  //},
                  //new TripQuestion()
                  //{
                  //     Question=Question56,
                  //     Trip=trip
                  //},
                  // new TripQuestion()
                  //{
                  //     Question=Question57,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question58,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question59,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question60,
                  //     Trip=trip
                  //},
                  //  new TripQuestion()
                  //{
                  //     Question=Question61,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question62,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question63,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question64,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question65,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question66,
                  //     Trip=trip
                  //},new TripQuestion()
                  //{
                  //     Question=Question67,
                  //     Trip=trip
                  //},

                  //new TripQuestion()
                  //{
                  //     Question=Question68,
                  //     Trip=trip
                  //},
                  //new TripQuestion()
                  //{
                  //     Question=Question69,
                  //     Trip=trip
                  //},
                  // new TripQuestion()
                  //{
                  //     Question=Question70,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question71,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question72,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question73,
                  //     Trip=trip
                  //},  new TripQuestion()
                  //{
                  //     Question=Question74,
                  //     Trip=trip
                  //},

                  //new TripQuestion()
                  //{
                  //     Question=Question75,
                  //     Trip=trip
                  //},
                  //new TripQuestion()
                  //{
                  //     Question=Question76,
                  //     Trip=trip
                  //},
                  // new TripQuestion()
                  //{
                  //     Question=Question77,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question78,
                  //     Trip=trip
                  //}, new TripQuestion()
                  //{
                  //     Question=Question79,
                  //     Trip=trip
                  //}
              };


            context.TripQuestions.AddRange(TripQuestions);
            context.SaveChanges();





        }
    }
}
