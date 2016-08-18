using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfernoProjectThing;
using NUnit.Framework;

namespace CarLockingTest
{
    public class CarLockTests
    {
        [Test]
        public void NewCarNoSpeedShouldBeUnlocked()
        {
            var car = new Automobile();
            Assert.That(car.AreDoorsLocked(), Is.False);
        }

        [Test]
        public void SettingACarSpeedToTwentyShouldLockDoors()
        {
            var car = new Automobile();
            Assert.That(car.AreDoorsLocked(), Is.False);
            car.SetSpeed(20);
            Assert.That(car.AreDoorsLocked(), Is.True);
        }
    }
}
