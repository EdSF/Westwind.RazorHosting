﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Westwind.RazorHosting;

namespace RazorHostingTests
{
    /// <summary>
    /// Summary description for FolderHostTests
    /// </summary>
    [TestClass]
    public class StringHostTests
    {
        public StringHostTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void BasicStringHostTest()
        {
            var host = new RazorStringHostContainer();
            
            // add model assembly - ie. this assembly
            host.AddAssemblyFromType(this);

            host.UseAppDomain = true;

            host.Start();
              
            Person person = new Person()
            {
                Name = "Rick",
                Company = "West Wind",
                Entered = DateTime.Now,
                Address = new Address()
                {
                    Street = "32 Kaiea",
                    City = "Paia"
                }
            };
            
            string result = host.RenderTemplate(Templates.BasicTemplateStringWithPersonModel,person);
            

            Console.WriteLine(result);
            Console.WriteLine("---");
            Console.WriteLine(host.Engine.LastGeneratedCode);

            if (result == null)
            {
                Assert.Fail(host.ErrorMessage);
            }

            
            host.Stop();
        }
    }
}
