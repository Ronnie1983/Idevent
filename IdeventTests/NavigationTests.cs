using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bunit;
using IdeventAdminBlazorServer.Pages;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;

namespace IdeventTests
{

    [TestClass]
    public class NavigationTests
    {
        private Bunit.TestContext _testContext;
        private NavigationManager _navManager;

        [TestInitialize]
        public void Inititialise()
        {
            _testContext = new Bunit.TestContext();
            _navManager = _testContext.Services.GetService<NavigationManager>();
        }
        [TestMethod]
        public void DashboardIndex_Loads()
        {
            // Arrange
            var dashboardPage = _testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Dashboard.Index>();
            
            string url = $"{_navManager.BaseUri}Home";
            string expectedH1Tag = "<h1>Dashboard</h1>";

            // Act
            _navManager.NavigateTo(url);
            bool containsExpected = dashboardPage.Markup.Contains(expectedH1Tag);

            // Assert
            Assert.AreEqual("http://localhost/Home", url);
            Assert.IsTrue(containsExpected);
        }
        [TestMethod]
        public void ProfileIndex_Loads()
        {
            // Arrange
            var profilePage = _testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Profile.Index>();

            string url = $"{_navManager.BaseUri}Home";
            string expectedH1Tag = "<h1>Profile</h1>";

            // Act
            _navManager.NavigateTo(url);
            bool containsExpected = profilePage.Markup.Contains(expectedH1Tag);

            // Assert
            Assert.AreEqual("http://localhost/Home", url);
            Assert.IsTrue(containsExpected);
        }
        [TestCleanup]
        public void Cleanup()
        {
            _testContext.Dispose();
        }
    }
}
