using System;
using NUnit.Framework;
using MyPayProject;
using System.Collections.Generic;
using System.IO;

namespace MyPayNUnitTestProject
{
    public class Tests
    {
        private List<PayRecord> _records;
        [SetUp]
        public void Setup()
        {
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            _records = CsvImporter.ImportPayRecords(path + "/Import/employee-payroll-data.csv");
        }

        [Test]
        public void TestImport()
        {
            //Assert
            Assert.IsNotNull(_records);
            Assert.IsNotEmpty(_records);
            Assert.AreEqual(5, _records.Count);
            
        }

        [Test]
        public void TestGross()
        {
            double[] expectedGross = new double[5] { 652, 418, 2202, 1104, 1797.45 };
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(expectedGross[i], _records[i].Gross);
            }
        }

        [Test]
        public void TestTax() 
        {
            double[] expectedTax = new double[5] { 182.45, 133.76, 754.91, 165.6, 597.14 };
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(expectedTax[i], _records[i].Tax);
            }
        }

        [Test]
        public void TestNet()
        {
            double[] expectedNet = new double[5] { 469.55, 284.24, 1447.09, 938.4, 1200.31 };
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(expectedNet[i], _records[i].Net);
            }
        }

        [Test]
        public void TestExport()
        {
            
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase ;
            PayRecordWriter.Write(path+"../../Export/myExportData.csv"  , _records);
            bool exists = File.Exists(path+ "../../Export/myExportData.csv");
            Assert.IsTrue(exists);
        }
    }
}
