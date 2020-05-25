using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainLibrary;
using System;
using DomainLibrary.Domain;
using DataLayer;
using System.Security.Cryptography.X509Certificates;
using FluentAssertions;

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
        #region GenerateMonthlyReportTest
        [TestMethod]
        public void GenerateMonthlyCyclingReportTest()
        {
            //Arrange = initialisatie objecten en kent waarden van gegevens toe aan methoden 

            //Act = roept testen method op met ingestgelde parameters

            //Assert = verifieert actie van geteste methoden
           
        }
        [TestMethod]
        public void GenerateMonthlyRunningReportTest()
        {
            //Arrange = initialisatie objecten en kent waarden van gegevens toe aan methoden 

            //Act = roept testen method op met ingestgelde parameters

            //Assert = verifieert actie van geteste methoden

        }
        [TestMethod]
        public void GenerateMonthlyTrainingReportTest()
        {
            //Arrange = initialisatie objecten en kent waarden van gegevens toe aan methoden 

            //Act = roept testen method op met ingestgelde parameters

            //Assert = verifieert actie van geteste methoden

        }
        #endregion
        #region RemoveTrainings
        #endregion
        #region ConstructorTests Running/CyclingSession
        #endregion
    }
}
