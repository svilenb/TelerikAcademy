namespace Computers.Components.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;

    [TestClass]
    public class CpuRandomTest
    {
        [TestMethod]
        public void CpuStandardRandomTest()
        {
            var randomNumberProvider = Mock.Create<IRandomNumbersProvider>();
            Mock.Arrange(() => randomNumberProvider.GetRandomNumber(Arg.IsAny<int>(), Arg.IsAny<int>())).Returns(50);
            var motherboard = new Motherboard(new RAM(64), new ColorfulVideoCard());
            var cpu = new Cpu128Bit(2, motherboard, randomNumberProvider);
            cpu.GenerateRandomNumber(20, 100);
            Assert.AreEqual(50, motherboard.LoadRamValue());
        }
    }
}
