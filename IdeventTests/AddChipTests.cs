using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdeventAdminBlazorServer.Pages.Admin.Chips;
using Bunit;

namespace IdeventTests
{
    [TestClass]
    public class AddChipTests : TestBase
    {
        [TestInitialize]
        public void Setup()
        {

        }
        [TestCleanup]
        public void Teardown()
        {

        }
        [TestMethod]
        public void SelectCompanyAndOpenEventSelection()
        {
            // Arrange
            IRenderedComponent<AddChip> page = _testContext.RenderComponent<AddChip>(

            // Act
            var toggleBtn = page.Find("#toggleAddStandBtn");
            toggleBtn.Click();
            var addStandContainer = page.Find("#addStandContainer");
            string addStandContainerMarkup = addStandContainer.ToMarkup();

            // Assert
            page.Markup.Contains(addStandContainerMarkup);

            // Act
            toggleBtn.Click();

            // Assert
            Assert.IsFalse(page.Markup.Contains(addStandContainerMarkup));
        }
        [TestMethod]
        public void SelectEventAndOpenGroupAndProductSelection()
        {
            Assert.Fail();
        }
    }
}
