using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WSUniversalLib;

namespace WSUniversalLibTest
{
    [TestClass]
    public class WSUniversalLibUnitTest
    {
        [TestMethod]
        public void SalaryHours_170and4_680returned()
        {
            decimal Salary_hours = 170;
            int hours = 4;
            decimal expected = 680;
            decimal actual = WSUniverasl.SalaryTime(Salary_hours, hours);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SalaryHours_170and9_1683returned()
        {
            decimal Salary_hours = 170;
            int hours = 9;
            decimal expected = 1683;
            decimal actual = WSUniverasl.SalaryTime(Salary_hours, hours);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SalaryHours_170and14_2975returned()
        {
            decimal Salary_hours = 170;
            int hours = 14;
            decimal expected = 2975;
            decimal actual = WSUniverasl.SalaryTime(Salary_hours, hours);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SalaryHours_200and5_1000returned()
        {
            decimal Salary_hours = 200;
            int hours = 5;
            decimal expected = 1000;
            decimal actual = WSUniverasl.SalaryTime(Salary_hours, hours);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SalaryHours_200and10_2200returned()
        {
            decimal Salary_hours = 200;
            int hours = 10;
            decimal expected = 2200;
            decimal actual = WSUniverasl.SalaryTime(Salary_hours, hours);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SalaryHours_200and22_5500returned()
        {
            decimal Salary_hours = 200;
            int hours = 22;
            decimal expected = 5500;
            decimal actual = WSUniverasl.SalaryTime(Salary_hours, hours);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SalaryHours_190and6_1140returned()
        {
            decimal Salary_hours = 190;
            int hours = 6;
            decimal expected = 1140;
            decimal actual = WSUniverasl.SalaryTime(Salary_hours, hours);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SalaryHours_190and11_2299returned()
        {
            decimal Salary_hours = 190;
            int hours = 11;
            decimal expected = 2299;
            decimal actual = WSUniverasl.SalaryTime(Salary_hours, hours);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SalaryHours_190and20_4750returned()
        {
            decimal Salary_hours = 190;
            int hours = 20;
            decimal expected = 4750;
            decimal actual = WSUniverasl.SalaryTime(Salary_hours, hours);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SalaryHours_150and3_450returned()
        {
            decimal Salary_hours = 150;
            int hours = 3;
            decimal expected = 450;
            decimal actual = WSUniverasl.SalaryTime(Salary_hours, hours);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SalaryHours_150and12_1980returned()
        {
            decimal Salary_hours = 150;
            int hours = 12;
            decimal expected = 1980;
            decimal actual = WSUniverasl.SalaryTime(Salary_hours, hours);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SalaryHours_150and24_4500returned()
        {
            decimal Salary_hours = 150;
            int hours = 24;
            decimal expected = 4500;
            decimal actual = WSUniverasl.SalaryTime(Salary_hours, hours);
            Assert.AreEqual(expected, actual);
        }
    }
}
