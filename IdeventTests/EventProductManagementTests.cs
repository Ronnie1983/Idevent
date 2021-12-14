using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bunit;
using IdeventLibrary.Repositories;
using IdeventAdminBlazorServer.Pages;
using Microsoft.AspNetCore.Components;
using IdeventAdminBlazorServer.Pages.Admin.Events;
using Microsoft.Extensions.DependencyInjection;

namespace IdeventTests
{
    /// <summary>
    /// Tests if you can load all pages by checking the h1 tag of each page after navigating to it.
    /// </summary>
    [TestClass]
    public class EventProductManagementTests : TestBase
    {
        private NavigationManager _navManager;

        [TestInitialize]
        public void Inititialise()
        {
            _testContext.Services.AddSingleton<StandFunctionalityRepository>(new StandFunctionalityRepository());
            _navManager = _testContext.Services.GetService<NavigationManager>();
            
        }
        [TestCleanup]
        public void Cleanup()
        {
            _testContext.Dispose();
        }

        [TestMethod]
        public void EventProductManagement_ToggleAddStandOpensAndCloses()
        {
            // Arrange
            IRenderedComponent<EventProductManagement> page = _testContext.RenderComponent<EventProductManagement>(
                parameters =>
                {
                    parameters.Add(p => p.EventId, 1.ToString());
                });

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
    }
}
