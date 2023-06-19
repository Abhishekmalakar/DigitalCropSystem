using KrishiJagarnDigitalSystem.Controllers;
using KrishiJagarnDigitalSystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using System.Web.Mvc;

namespace KrishiJagarnUnitTest
{
    [TestClass]
    public class UnitTest1
    {


        public DbSet<FormerDetail> FormerDetails { get; set; }
        public DbSet<CropDetail> CropDetails { get; set; }
        [TestMethod]
        public void Unit_test_Case_Check_Valid_Data()
        {

            FormerDetailsController formerDetail = new FormerDetailsController();
            //Actual
            int expectedDetail = 24;
            //Action
            var result = formerDetail.Index() as ViewResult;

            //Assert

            Assert.AreEqual(expectedDetail, result);

        }

        [TestMethod]
        public void Test_To_Check_CropeFDetails()
        {
            var expextedDetail = "Rubby";
            CropDetailsController cropDetailsController = new CropDetailsController();
            var Result = cropDetailsController.Index();
            Assert.AreEqual(Result, expextedDetail);


        }
    }
}
