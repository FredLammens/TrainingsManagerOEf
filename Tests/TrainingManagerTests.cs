using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainLibrary;
using System;
using DomainLibrary.Domain;
using DataLayer;

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
            TimeSpan time = TimeSpan.FromMinutes(20);
            float averageSpeed = 40;
            int averageWatt = 400;
            //Act = roept testen method op met ingestgelde parameters
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            //Assert = verifieert actie van geteste methoden
            Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(future, distance, time, averageSpeed, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike));
        }
        [TestMethod]
        public void AddCyclingTrainingWithInvalidDistance() 
        {
            //Arrange
            DateTime now = DateTime.Now;
            float distanceToBig = 510;
            float distanceNul = 0;
            float distanceToSmall = -10;
            TimeSpan time = TimeSpan.FromMinutes(20);
            float averageSpeed = 40;
            int averageWatt = 400;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            //Assert
            Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distanceToBig, time, averageSpeed, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike));
            Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distanceNul, time, averageSpeed, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike));
            Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distanceToSmall, time, averageSpeed, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike));
        }
        [TestMethod]
        public void AddCyclingTrainingWithInvalidTime() 
        {
            //Arrange
            DateTime now = DateTime.Now;
            float distance = 400;
            TimeSpan timeMin = now - DateTime.MinValue;
            TimeSpan timeMax = now - DateTime.MaxValue;
            float averageSpeed = 40;
            int averageWatt = 400;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            //Assert
            Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distance, timeMin, averageSpeed, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike));
            Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distance, timeMax, averageSpeed, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike));

        }
        [TestMethod]
        public void AddCyclingTrainingWithInvalidAverageSpeed()
        {
            //Arrange
            DateTime now = DateTime.Now;
            float distance = 400;
            TimeSpan time = TimeSpan.FromMinutes(20);
            float averageSpeedMin = -20;
            float averageSpeedNul = 0;
            float averageSpeedMax = 69;
            int averageWatt = 400;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            //Assert
            Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distance, time, averageSpeedMin, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike));
            Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distance, time, averageSpeedNul, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike));
            Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distance, time, averageSpeedMax, averageWatt, TrainingType.Interval, "comment", BikeType.MountainBike));
        }
        [TestMethod]
        public void AddCyclingTrainingWithInvalidWatt()
        {
            //Arrange
            DateTime now = DateTime.Now;
            float distance = 400;
            TimeSpan time = TimeSpan.FromMinutes(20);
            float averageSpeed = 40;
            int averageWattMin = -5;
            int averageWattNul = 0;
            int averageWattMax = 840;
            //Act
            TrainingManager t = new TrainingManager(new UnitOfWork(new TrainingContextTest(false)));
            //Assert
            Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distance, time, averageSpeed, averageWattMin, TrainingType.Interval, "comment", BikeType.MountainBike));
            Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distance, time, averageSpeed, averageWattNul, TrainingType.Interval, "comment", BikeType.MountainBike));
            Assert.ThrowsException<DomainException>(() => t.AddCyclingTraining(now, distance, time, averageSpeed, averageWattMax, TrainingType.Interval, "comment", BikeType.MountainBike));
        }
        #endregion
        #region RunningTrainingTests
        #endregion
        #region ConstructorTests Running/CyclingSession
        #endregion
    }
}
