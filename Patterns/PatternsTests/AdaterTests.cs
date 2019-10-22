using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns.Adapter;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatternsTests
{
    [TestClass]
    public class AdaterTests
    {
        [TestMethod]
        public void Adapter_DonutToSnackInfoAdapter_CanGetCorrectCalorieConversion()
        {
            //Create a concrete of IDonut, and then adapt it to a concrete of ISnackInfo
            //Check that ISnackInfo.GetCalorieCount is correct

            //Arrange
            var expectedCal = 150;
            var donut = new Donut(10, 15);
            
            //Act
            var snackInfo = new DonutToSnackInfoAdapter(donut);
            var result = snackInfo.GetCalorieCount();

            //Assert
            Assert.IsTrue(result == expectedCal);
        }
    }
}
