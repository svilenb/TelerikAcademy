namespace Computers.Components.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LaptopBatteryChargeTest
    {
        [TestMethod]
        public void Charging50PercentBatteryWith10ShouldChargeTHeBatteryTo60Percent()
        {
            var battery = new LaptopBattery();
            battery.Charge(10);
            Assert.AreEqual(60, battery.Percentage);
        }

        [TestMethod]
        public void Charging50PercentBatteryWithMinus10ShouldChargeTHeBatteryTo40Percent()
        {
            var battery = new LaptopBattery();
            battery.Charge(-10);
            Assert.AreEqual(40, battery.Percentage);
        }

        [TestMethod]
        public void Charging50PercentBatteryWith60ShouldChargeTHeBatteryTo100Percent()
        {
            var battery = new LaptopBattery();
            battery.Charge(60);
            Assert.AreEqual(100, battery.Percentage);
        }

        [TestMethod]
        public void Charging50PercentBatteryWithMinus60ShouldChargeTHeBatteryTo0Percent()
        {
            var battery = new LaptopBattery();
            battery.Charge(-60);
            Assert.AreEqual(0, battery.Percentage);
        }
    }
}
