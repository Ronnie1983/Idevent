using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bunit;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using IdeventLibrary.Repositories;
using IdeventLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace IdeventTests
{
    /// <summary>
    /// Tests if you can load all pages by checking the h1 tag of each page after navigating to it.
    /// </summary>
    [TestClass]
    public class NavigationTests : TestBase
    {
        private NavigationManager _navManager;

        [TestInitialize]
        public void Inititialise()
        {
            
            _testContext.JSInterop.SetupVoid("BlazorFocusElement", _ => true);
            _testContext.Services.AddSingleton<CompanyRepository>(new CompanyRepository());
            _testContext.Services.AddSingleton<ChipRepository>(new ChipRepository());
            _testContext.Services.AddSingleton<EventRepository>(new EventRepository());
            _testContext.Services.AddSingleton<ChipGroupRepository>(new ChipGroupRepository());
            _testContext.Services.AddSingleton<StandProductRepository>(new StandProductRepository());
            _testContext.Services.AddSingleton<ChipContentRepository>(new ChipContentRepository());
            _testContext.Services.AddSingleton<UserRepository>(new UserRepository());
            _testContext.Services.AddSingleton<StandFunctionalityRepository>(new StandFunctionalityRepository());
            _testContext.Services.AddSingleton<EventStandRepository>(new EventStandRepository());
            _testContext.Services.AddSingleton<IHttpContextAccessor>(new HttpContextAccessor());

            _navManager = _testContext.Services.GetService<NavigationManager>();
      
        }
        [TestMethod]
        public void DashboardIndexLoads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Dashboard.Index>(), "Dashboard", "Home");
        }
        [TestMethod]
        public void ProfileIndexLoads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Profile.Index>(), "Profile");
        }
        [TestMethod]
        public void ChipsIndexLoads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Chips.Index>(), "Chips Oversigt", "Chips");
        }
        [TestMethod]
        public void CompaniesIndexLoads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Companies.Index>(), "Companies");
        }
        [TestMethod]
        public void EventsIndexLoads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Events.Index>(), "Events");
        }
        [TestMethod]
        public void OperatorSiteIndexLoads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.OperatorSite.Index>(), "Operator's Site", "OperatorSite");
        }
        [TestMethod]
        public void ChipActivityLogIndexLoads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.ChipActivityLog.Index>(), "Chip Activity Log", "ChipActivityLog");
        }
        [TestMethod]
        public void UsersIndexLoads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Users.Index>(), "Users");
        }
        [TestMethod]
        public void EventsAddEventLoads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Events.AddEvent>(), "Add Event", "AddEvent");
        }
        [TestMethod]
        public void EventsEditEventLoads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Events.EditEvent>(), "Edit Event", "EditEvent/1");
        }
        [TestMethod]
        public void EventsEventProductManagementLoads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Events.EventProductManagement>(), "Event Product Management", "EventProductManagement/1");
        }
        [TestMethod]
        public void ChipsChipDetailsLoads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Chips.DetailsChip>(), "Chip Details", "ChipDetails/1");
        }
        [TestMethod]
        public void ChipsEditChipLoads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Chips.EditChip>(), "Edit Chip", "EditChip/1");
        }

        [TestMethod]
        public void ChipsEditChipCancelBtn()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Chips.Index>(), "Chips Oversigt", "Chips");
        }
        [TestMethod]
        public void ChipsAddChipLoads()
        {
            
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Chips.AddChip>(), "Add Chip", "AddChip");
        }

        [TestMethod]
        public void CompanyDetailsLoads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Companies.DetailsCompany>(), "Company Details:", "CompanyDetails/1");
        }
        [TestMethod]
        public void CompanyEditPage()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Companies.EditCompany>(), "Edit Company", "CompanyEdit/1");
        }

        [TestMethod]
        public void TerminalFirstScanPage()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Terminal.Index>(), "Ready", "Terminal");
        }

        [TestMethod]
        public void TerminalErrorPage()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Terminal.Error>(), "Error", "Error/Template");
        }

        [TestMethod]
        public void TerminalUserScanPage()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Terminal.ReadyState>(), "Ready", "Ready/1");
        }

        [TestMethod]
        public void TerminalWaitingForOperatorPage()
        {
            var ctx = _testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Terminal.WaitingOperator>();
            ctx.Instance.EventStandId = 1;
            LoadPageTest(ctx, "Success", "chipContent/1");
        }

        /// <summary>
        /// Tests if a specified page loads with an expected title.
        /// </summary>
        /// <param name="pageComponent">The page component to test.</param>
        /// <param name="pageTitle">The expected content of the page's h1 tag.</param>
        /// <param name="navigationTitle">(optional) If the url is different from "baseuri/pageTitle" you can replace pageTitle with navigationTitle.</param>
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
            string expectedH1Content = $"<h1>{pageTitle}";

            // Act
            _navManager.NavigateTo(url);

            bool containsExpected = page.Markup.Contains(expectedH1Content);

            // Assert
            Assert.IsTrue(containsExpected);
        }

    }
}
