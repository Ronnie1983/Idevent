using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bunit;
using IdeventAdminBlazorServer.Pages;
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
        [TestCleanup]
        public void Cleanup()
        {
            _testContext.Dispose();
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
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Profile.Index>(), "Profile");
        }

        private void LoadPageTest(IRenderedComponent<IComponent> pageComponent, string pageTitle, string navigationTitle = "")
        {
            // Arrange
            var page = pageComponent;
            string url;
            if (string.IsNullOrEmpty(navigationTitle))
            {
                url = $"{_navManager.BaseUri}{pageTitle}";
            }
            else
            {
                url = $"{_navManager.BaseUri}{navigationTitle}";
            }
            string expectedH1Tag = $"<h1>{pageTitle}</h1>";

            // Act
            _navManager.NavigateTo(url);

            bool containsExpected = page.Markup.Contains(expectedH1Tag);

            // Assert
            Assert.IsTrue(containsExpected);
        }

    }
}
