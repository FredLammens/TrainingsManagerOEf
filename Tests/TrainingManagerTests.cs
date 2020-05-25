using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainLibrary;
using System;
using DomainLibrary.Domain;
using DataLayer;
using System.Security.Cryptography.X509Certificates;
using FluentAssertions;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class TrainingManagerTests
    {
        #region CyclingTrainingTests
        [TestMethod]
        public void AddCyclingTrainingWithInvalidDate()
        {
            //Arrange = initialisatie objecten en kent waarden van gegevens toe aan methoden 
            DateTime future = new DateTime(2050, 2, 12);
            float distance = 400;
            TimeSpan time = new TimeSpan(0, 10, 20);
            float averageSpeed = 40;
            int averageWatt = 400;
            //Act = roept testen method op met ingestgelde parameters
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddCyclingTraining(future, distance, time, averageSpeed, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike);
            //Assert = verifieert actie van geteste methoden
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------
            //Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(future, distance, time, averageSpeed, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike));
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>()
                        .WithMessage("Training is in the future");
            
        }
        [TestMethod]
        public void AddCyclingTrainingWithInvalidDistanceToBig() 
        {
            //Arrange
            DateTime now = DateTime.Now;
            float distanceToBig = 510;
            TimeSpan time = new TimeSpan(0, 10, 20);
            float averageSpeed = 40;
            int averageWatt = 400;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddCyclingTraining(now, distanceToBig, time, averageSpeed, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike);
            //Assert
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------
            //Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distanceToBig, time, averageSpeed, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike));
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>()
                           .WithMessage("Distance invalid value");
        }
        [TestMethod]
        public void AddCyclingTrainingWithInvalidDistanceToSmall()
        {
            //Arrange
            DateTime now = DateTime.Now;
            float distanceToSmall = -10;
            TimeSpan time = new TimeSpan(0, 10, 20);
            float averageSpeed = 40;
            int averageWatt = 400;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddCyclingTraining(now, distanceToSmall, time, averageSpeed, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike);
            //Assert
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------
            //Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distanceToSmall, time, averageSpeed, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike));
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>()
                           .WithMessage("Distance invalid value");
        }
        [TestMethod]
        public void AddCyclingTrainingWithInvalidDistanceNul()
        {
            //Arrange
            DateTime now = DateTime.Now;
            float distanceNul = 0;
            TimeSpan time = new TimeSpan(0, 10, 20);
            float averageSpeed = 40;
            int averageWatt = 400;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddCyclingTraining(now, distanceNul, time, averageSpeed, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike);
            //Assert
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------
            //Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distanceNul, time, averageSpeed, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike));
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>()
                           .WithMessage("Distance invalid value");
        }
        [TestMethod]
        public void AddCyclingTrainingWithInvalidTimeToSmall() 
        {
            //Arrange
            DateTime now = DateTime.Now;
            float distance = 400;
            TimeSpan timeMin = new TimeSpan(-1);
            float averageSpeed = 40;
            int averageWatt = 400;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddCyclingTraining(now, distance, timeMin, averageSpeed, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike);
            //Assert
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------
            //Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distance, timeMax, averageSpeed, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike));
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>()
                        .WithMessage("Time invalid value");
        }
        [TestMethod]
        public void AddCyclingTrainingWithInvalidTimeNul()
        {
            //Arrange
            DateTime now = DateTime.Now;
            float distance = 400;
            TimeSpan timeNul = new TimeSpan(0);
            float averageSpeed = 40;
            int averageWatt = 400;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddCyclingTraining(now, distance, timeNul, averageSpeed, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike);
            //Assert
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------
            //Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distance, timeMax, averageSpeed, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike));
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>()
                        .WithMessage("Time invalid value");
        }
        [TestMethod]
        public void AddCyclingTrainingWithInvalidTimeToBig()
        {
            //Arrange
            DateTime now = DateTime.Now;
            float distance = 400;
            TimeSpan timeMax = new TimeSpan(20, 50, 20);
            float averageSpeed = 40;
            int averageWatt = 400;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddCyclingTraining(now, distance, timeMax, averageSpeed, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike);
            //Assert
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------
            //Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distance, timeMax, averageSpeed, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike));
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>()
                        .WithMessage("Time invalid value");
        }
        [TestMethod]
        public void AddCyclingTrainingWithInvalidAverageSpeedToSmall()
        {
            //Arrange
            DateTime now = DateTime.Now;
            float distance = 400;
            TimeSpan time = new TimeSpan(0, 10, 20);
            float averageSpeedMin = -20;
            int averageWatt = 400;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddCyclingTraining(now, distance, time, averageSpeedMin, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike);
            //Assert
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------
            //Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distance, time, averageSpeedMin, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike));
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>()
                        .WithMessage("Average speed invalid value");
        }
        [TestMethod]
        public void AddCyclingTrainingWithInvalidAverageSpeedNul()
        {
            //Arrange
            DateTime now = DateTime.Now;
            float distance = 400;
            TimeSpan time = new TimeSpan(0, 10, 20);
            float averageSpeedNul = 0;
            int averageWatt = 400;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddCyclingTraining(now, distance, time, averageSpeedNul, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike);
            //Assert
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------
            //Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distance, time, averageSpeedNul, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike));
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>()
                        .WithMessage("Average speed invalid value");
        }
        [TestMethod]
        public void AddCyclingTrainingWithInvalidAverageSpeedToBig()
        {
            //Arrange
            DateTime now = DateTime.Now;
            float distance = 400;
            TimeSpan time = new TimeSpan(0, 10, 20);
            float averageSpeedMax = 69;
            int averageWatt = 400;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddCyclingTraining(now, distance, time, averageSpeedMax, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike);
            //Assert
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------
            //Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distance, time, averageSpeedMax, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike));
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>()
                        .WithMessage("Average speed invalid value");
        }
        [TestMethod]
        public void AddCyclingTrainingWithInvalidWattToSmall()
        {
            //Arrange
            DateTime now = DateTime.Now;
            float distance = 400;
            TimeSpan time = new TimeSpan(0, 10, 20);
            float averageSpeed = 40;
            int averageWattMin = -5;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddCyclingTraining(now, distance, time, averageSpeed, averageWattMin, TrainingType.Interval, "comment", BikeType.MountainBike);
            //Assert
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------
            //Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distance, time, averageSpeed, averageWattMin, TrainingType.Interval, "comment", BikeType.MountainBike));
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>()
                .WithMessage("Average watt invalid value");
        }
        [TestMethod]
        public void AddCyclingTrainingWithInvalidWattNul()
        {
            //Arrange
            DateTime now = DateTime.Now;
            float distance = 400;
            TimeSpan time = new TimeSpan(0, 10, 20);
            float averageSpeed = 40;
            int averageWattNul = 0;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddCyclingTraining(now, distance, time, averageSpeed, averageWattNul, TrainingType.Interval, "comment", BikeType.MountainBike);
            //Assert
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------
            //Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distance, time, averageSpeed, averageWattNul, TrainingType.Interval, "comment", BikeType.MountainBike));
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>()
                .WithMessage("Average watt invalid value");
        }
        [TestMethod]
        public void AddCyclingTrainingWithInvalidWattToBig()
        {
            //Arrange
            DateTime now = DateTime.Now;
            float distance = 400;
            TimeSpan time = new TimeSpan(0, 10, 20);
            float averageSpeed = 40;
            int averageWattMax = 840;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddCyclingTraining(now, distance, time, averageSpeed, averageWattMax, TrainingType.Interval, "comment", BikeType.MountainBike);
            //Assert
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------
            //Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distance, time, averageSpeed, averageWattMax, TrainingType.Interval, "comment", BikeType.MountainBike));
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>()
                .WithMessage("Average watt invalid value");
        }
        #endregion
        #region RunningTrainingTests
        [TestMethod]
        public void AddRunningTrainingWithInvalidDate()
        {
            //Arrange = initialisatie objecten en kent waarden van gegevens toe aan methoden 
            DateTime future = new DateTime(2050, 2, 12);
            int distance = 400;
            TimeSpan time = new TimeSpan(0, 10, 20);
            float averageSpeed = 40;
            //Act = roept testen method op met ingestgelde parameters
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddRunningTraining(future, distance, time, averageSpeed, TrainingType.Endurance, "comment");
            //Assert = verifieert actie van geteste methoden
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------
            //Assert.ThrowsException<DomainException>(() => t.AddRunningTraining(future,distance,time,averageSpeed,TrainingType.Endurance,"comment"));
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>()
                        .WithMessage("Training is in the future");
        }
        [TestMethod]
        public void AddRunningTrainingWithInvalidDistanceToBig()
        {
            //Arrange
            DateTime now = DateTime.Now;
            int distanceToBig = 50001;
            TimeSpan time = new TimeSpan(0, 10, 20);
            float averageSpeed = 40;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddRunningTraining(now, distanceToBig, time, averageSpeed, TrainingType.Endurance, "comment");
            //Assert
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------            
            //Assert.ThrowsException<DomainException>(() => t.AddRunningTraining(now, distanceToBig, time, averageSpeed, TrainingType.Endurance, "comment"));
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>()
                        .WithMessage("Distance invalid value");
        }
        [TestMethod]
        public void AddRunningTrainingWithInvalidDistanceNul()
        {
            //Arrange
            DateTime now = DateTime.Now;
            int distanceNul = 0;
            TimeSpan time = new TimeSpan(0, 10, 20);
            float averageSpeed = 40;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddRunningTraining(now, distanceNul, time, averageSpeed, TrainingType.Endurance, "comment");
            //Assert
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------            
            //Assert.ThrowsException<DomainException>(() => t.AddRunningTraining(now, distanceNul, time, averageSpeed, TrainingType.Endurance, "comment"));
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>()
                        .WithMessage("Distance invalid value");
        }
        [TestMethod]
        public void AddRunningTrainingWithInvalidDistanceToSmall()
        {
            //Arrange
            DateTime now = DateTime.Now;
            int distanceToSmall = -10;
            TimeSpan time = new TimeSpan(0, 10, 20);
            float averageSpeed = 40;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddRunningTraining(now, distanceToSmall, time, averageSpeed, TrainingType.Endurance, "comment");
            //Assert
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------            
            //Assert.ThrowsException<DomainException>(() => t.AddRunningTraining(now, distanceToSmall, time, averageSpeed, TrainingType.Endurance, "comment"));
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>()
                        .WithMessage("Distance invalid value");
        }
        [TestMethod]
        public void AddRunningTrainingWithInvalidTimeToSmall()
        {
            //Arrange
            DateTime now = DateTime.Now;
            int distance = 400;
            TimeSpan timeMin = new TimeSpan(-1);
            float averageSpeed = 40;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddRunningTraining(now, distance, timeMin, averageSpeed, TrainingType.Endurance, "comment");
            //Assert
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------            
            //Assert.ThrowsException<DomainException>(() => t.AddRunningTraining(now, distance, timeMin, averageSpeed, TrainingType.Endurance, "comment"));          
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>().WithMessage("Time invalid value");

        }
        [TestMethod]
        public void AddRunningTrainingWithInvalidTimeNul()
        {
            //Arrange
            DateTime now = DateTime.Now;
            int distance = 400;
            TimeSpan timeNul = new TimeSpan(0);
            float averageSpeed = 40;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddRunningTraining(now, distance, timeNul, averageSpeed, TrainingType.Endurance, "comment");
            //Assert
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------            
            //Assert.ThrowsException<DomainException>(() => t.AddRunningTraining(now, distance, timeMin, averageSpeed, TrainingType.Endurance, "comment"));          
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>().WithMessage("Time invalid value");

        }
        [TestMethod]
        public void AddRunningTrainingWithInvalidTimeToBig()
        {
            //Arrange
            DateTime now = DateTime.Now;
            int distance = 400;
            TimeSpan timeMax = new TimeSpan(20, 50, 20);
            float averageSpeed = 40;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddRunningTraining(now, distance, timeMax, averageSpeed, TrainingType.Endurance, "comment");
            //Assert
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------            
            //Assert.ThrowsException<DomainException>(() => t.AddRunningTraining(now, distance, timeMax, averageSpeed, TrainingType.Endurance, "comment"));            
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>().WithMessage("Time invalid value");
        }
        [TestMethod]
        public void AddRunningTrainingWithInvalidAverageSpeedToSmall()
        {
            //Arrange
            DateTime now = DateTime.Now;
            int distance = 400;
            TimeSpan time = new TimeSpan(0, 10, 20);
            float averageSpeedMin = -20;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddRunningTraining(now, distance, time, averageSpeedMin, TrainingType.Endurance, "comment");
            //Assert
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------            
            //Assert.ThrowsException<DomainException>(() => t.AddRunningTraining(now, distance, time, averageSpeedMin, TrainingType.Endurance, "comment"));                   
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>()
                        .WithMessage("Average speed invalid value");
        }
        [TestMethod]
        public void AddRunningTrainingWithInvalidAverageSpeedNul()
        {
            //Arrange
            DateTime now = DateTime.Now;
            int distance = 400;
            TimeSpan time = new TimeSpan(0, 10, 20);
            float averageSpeedNul = 0;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddRunningTraining(now, distance, time, averageSpeedNul, TrainingType.Endurance, "comment");
            //Assert
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------            
            //Assert.ThrowsException<DomainException>(() => t.AddRunningTraining(now, distance, time, averageSpeedNul, TrainingType.Endurance, "comment"));
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>()
                        .WithMessage("Average speed invalid value");
        }
        [TestMethod]
        public void AddRunningTrainingWithInvalidAverageSpeedToBig()
        {
            //Arrange
            DateTime now = DateTime.Now;
            int distance = 400;
            TimeSpan time = new TimeSpan(0, 10, 20);
            float averageSpeedMax = 69;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            Action act = () => t.AddRunningTraining(now, distance, time, averageSpeedMax, TrainingType.Endurance, "comment");
            //Assert
            //--------------------------------------------------------------MS-------------------------------------------------------------------------------------------------------------------------            
            //Assert.ThrowsException<DomainException>(() => t.AddRunningTraining(now, distance, time, averageSpeedMax, TrainingType.Endurance, "comment"));                      
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            act.Should().Throw<DomainException>()
                        .WithMessage("Average speed invalid value");
        }
        #endregion
        #region GenerateMonthlyReportTests
        [TestMethod]
        public void GenerateMonthlyCyclingReportTest()
        {
            //Arrange = initialisatie objecten en kent waarden van gegevens toe aan methoden 
            int year = 1996;
            int month = 1;
            //DB testCyclingSessions
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            //Cyclingreport
            #region AddCyclingTraining maxDistanceSession
            DateTime now = new DateTime(1996, 1, 23); float distance = 257.20f; TimeSpan time = new TimeSpan(12, 05, 10);
            float averageSpeed = 30.00f; int averageWatt = 200; TrainingType tt = TrainingType.Endurance; string comment = "Good job"; BikeType bt = BikeType.RacingBike;
            t.AddCyclingTraining(now, distance, time, averageSpeed, averageWatt, tt, comment, bt);
            #endregion
            #region AddCyclingTraining2 maxSpeedSession
            DateTime tommorow = new DateTime(1996, 1, 24); float distance2 = 120.40f; TimeSpan time2 = new TimeSpan(6, 03, 08);
            float averageSpeed2 = 50.00f; int averageWatt2 = 200; TrainingType tt2 = TrainingType.Endurance; BikeType bt2 = BikeType.MountainBike;
            t.AddCyclingTraining(tommorow, distance2, time2, averageSpeed2, averageWatt2, tt2, comment, bt2);
            #endregion
            #region AddCyclingTraining3 maxWattSession
            DateTime afterTommorow = new DateTime(1996, 1, 25); float distance3 = 110.40f; TimeSpan time3 = new TimeSpan(6, 03, 08);
            float averageSpeed3 = 30.00f; int averageWatt3 = 400; TrainingType tt3 = TrainingType.Endurance; BikeType bt3 = BikeType.MountainBike;
            t.AddCyclingTraining(afterTommorow, distance3, time3, averageSpeed3, averageWatt3, tt3, comment, bt3);
            #endregion
            //Act = roept testen method op met ingestgelde parameters
            Report rapport = t.GenerateMonthlyCyclingReport(year, month);
            //Assert = verifieert actie van geteste methoden
            //Test findMAxSessions
            rapport.MaxDistanceSessionCycling.Distance.Should().Be(257.20f);
            rapport.MaxSpeedSessionCycling.AverageSpeed.Should().Be(50.00f);
            rapport.MaxWattSessionCycling.AverageWatt.Should().Be(400);
            //Test TotalSessions
            rapport.CyclingSessions.Should().Be(3);
            rapport.TotalCyclingDistance.Should().Be(488.00f);
            rapport.TotalCyclingTrainingTime.Should().Be(new TimeSpan(24,11,26));
            //Test Timeline
            rapport.TimeLine.Should().NotBeEmpty();

        }
        [TestMethod]
        public void GenerateMonthlyRunningReportTest()
        {
            //Arrange = initialisatie objecten en kent waarden van gegevens toe aan methoden 
            int year = 1996;
            int month = 1;
            //DB testCyclingSessions
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            #region runningTraining maxDistanceSessionRunning
            DateTime now = new DateTime(1996, 1, 23); int distance = 500;
            TimeSpan time = new TimeSpan(0, 15, 20); float averageSpeed = 15.00f;
            t.AddRunningTraining(now, distance, time, averageSpeed, TrainingType.Interval, "good job!");
            #endregion
            #region runningTraining maxSpeedSessionRunning
            int distance2 = 200;
            TimeSpan time2 = new TimeSpan(0, 20, 20); float averageSpeed2 = 25.00f;
            t.AddRunningTraining(now, distance2, time2, averageSpeed2, TrainingType.Recuperation, "awesome new SpeedRecord");
            #endregion
            //Act = roept testen method op met ingestgelde parameters
            Report rapport = t.GenerateMonthlyRunningReport(year, month);
            //Assert = verifieert actie van geteste methoden
            rapport.MaxDistanceSessionCycling.Distance.Should().Be(500);
            rapport.MaxSpeedSessionRunning.Should().Be(25.00f);
            rapport.TotalSessions.Should().Be(2);
            rapport.TotalRunningDistance.Should().Be(700);
            rapport.TotalTrainingTime.Should().Be(new TimeSpan(0, 35, 40));
            rapport.TimeLine.Should().NotBeEmpty();
        }
        [TestMethod]
        public void GenerateMonthlyTrainingReportTest()
        {
            //Arrange = initialisatie objecten en kent waarden van gegevens toe aan methoden 
            int year = 1996;
            int month = 1;
            //DB testCyclingSessions
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            //Cyclingreport
            #region AddCyclingTraining maxDistanceSession
            DateTime now = new DateTime(1996, 1, 23); float distance = 257.20f; TimeSpan time = new TimeSpan(12, 05, 10);
            float averageSpeed = 30.00f; int averageWatt = 200; TrainingType tt = TrainingType.Endurance; string comment = "Good job"; BikeType bt = BikeType.RacingBike;
            t.AddCyclingTraining(now, distance, time, averageSpeed, averageWatt, tt, comment, bt);
            #endregion
            #region AddCyclingTraining2 maxSpeedSession
            DateTime tommorow = new DateTime(1996, 1, 24); float distance2 = 120.40f; TimeSpan time2 = new TimeSpan(6, 03, 08);
            float averageSpeed2 = 50.00f; int averageWatt2 = 200; TrainingType tt2 = TrainingType.Endurance; BikeType bt2 = BikeType.MountainBike;
            t.AddCyclingTraining(tommorow, distance2, time2, averageSpeed2, averageWatt2, tt2, comment, bt2);
            #endregion
            #region AddCyclingTraining3 maxWattSession
            DateTime afterTommorow = new DateTime(1996, 1, 25); float distance3 = 110.40f; TimeSpan time3 = new TimeSpan(6, 03, 08);
            float averageSpeed3 = 30.00f; int averageWatt3 = 400; TrainingType tt3 = TrainingType.Endurance; BikeType bt3 = BikeType.MountainBike;
            t.AddCyclingTraining(afterTommorow, distance3, time3, averageSpeed3, averageWatt3, tt3, comment, bt3);
            #endregion
            //RunningReport
            #region runningTraining maxDistanceSessionRunning
            DateTime now4 = new DateTime(1996, 1, 26);
            int distance4 = 500;
            TimeSpan time4 = new TimeSpan(0, 15, 20); float averageSpeed4 = 15.00f;
            t.AddRunningTraining(now4, distance4, time4, averageSpeed4, TrainingType.Interval, "good job!");
            #endregion
            #region runningTraining maxSpeedSessionRunning
            DateTime now5 = new DateTime(1996, 1, 26,12,20,30);
            int distance5 = 200;
            TimeSpan time5 = new TimeSpan(0, 20, 20); float averageSpeed5 = 25.00f;
            t.AddRunningTraining(now5, distance5, time5, averageSpeed5, TrainingType.Recuperation, "awesome new SpeedRecord");
            #endregion
            //Act = roept testen method op met ingestgelde parameters
            Report rapport = t.GenerateMonthlyTrainingsReport(year, month);
            //Assert = verifieert actie van geteste methoden
            rapport.TimeLine.Count.Should().Be(5);
            rapport.Rides.Count.Should().Be(3);
            rapport.Runs.Count.Should().Be(2);
        }
        #endregion
        #region ConstructorTests Running/CyclingSession
        [TestMethod]
        public void TestRunningSessionConstructor()
        {
            //Arrange = initialisatie objecten en kent waarden van gegevens toe aan methoden 
            DateTime now = DateTime.Now;
            int distance = 4000;
            TimeSpan time = new TimeSpan(0, 10, 20);
            float? averageSpeed = null;
            //Act = roept testen method op met ingestgelde parameters
            RunningSession rs = new RunningSession(now, distance, time, averageSpeed, TrainingType.Endurance, "comment");
            //Assert = verifieert actie van geteste methoden
            rs.AverageSpeed.Should().Be(23.225807F);
        }
        [TestMethod]
        public void TestCyclingSessionConstructor() 
        {
            //Arrange = initialisatie objecten en kent waarden van gegevens toe aan methoden 
            DateTime now = DateTime.Now;
            float distance = 400;
            TimeSpan time = new TimeSpan(0, 10, 20);
            float? averageSpeed = null;
            int averageWatt = 400;
            //Act = roept testen method op met ingestgelde parameters
            CyclingSession cs = new CyclingSession(now, distance, time, averageSpeed, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike);
            //Assert = verifieert actie van geteste methode
            cs.AverageSpeed.Should().Be(2322.5806f);
        }
        #endregion
    }
}
