using System;
using TechTalk.SpecFlow;
using BluePrism.Web.AutomatedUITests.POM;
using System.Collections.Generic;
using System.Linq;
using DemoProjectUsingEF.Configuration;
using DemoProjectUsingEF.POM;

namespace DemoProjectUsingEF.Steps.Hub
{
    [Binding]
    class HubLogInSteps
    {
        private HubDashboardPage _hubDashboardPage;
        private ImsLoginPage _imsLoginPage;
        private readonly string validUsername = ConfigurationLoader.Settings.HubUsers[0].Username;
        private readonly string validPassword = ConfigurationLoader.Settings.HubUsers[0].Password;
        public HubLogInSteps(HubDashboardPage hubDashboardPage, ImsLoginPage imsLoginPage)
        {
            _hubDashboardPage = hubDashboardPage;
            _imsLoginPage = imsLoginPage;
        }

        [Given(@"I am logged into HUB as admin")]
        [When(@"I am logged into HUB as admin")]
        public void GivenIAmLoggedInToHUBInAsAdmin()
        {
            _imsLoginPage
                .NavigateToIMS()
                .SendTextToUsernameInput(validUsername)
                .SendTextToPasswordInput(validPassword)
                .ClickLogIn()
                .GoToHub();
            //_hubDashboardPage
            //    .GetHubPageTitle();
        }

        [Then(@"I am logged into HUB as '(.*)' login and '(.*)' password")]
        [When(@"I am logged into HUB as '(.*)' login and '(.*)' password")]
        public void WhenIAmLoggedInToHUBAsLoginAndPassword(string username, string password)
        {
            _imsLoginPage
                .NavigateToIMS()
                .SendTextToUsernameInput(username)
                .SendTextToPasswordInput(password)
                .ClickLogIn()
                .GoToHub();
            //_hubDashboardPage
            //    .GetHubPageTitle();
        }

        [When(@"I log out")]
        public void WhenILogOut()
        {
            _imsLoginPage.LogOut();
        }

        [When(@"I logout from HUB")]
        public void WhenILogoutFromHUB()
        {
            _hubDashboardPage.ClickLogOutButton();
            _imsLoginPage.VerifyThatLogInPageIsOpened();
        }

        [When(@"I click on the Hub button")]
        public void WhenIClickOnTheHubButton()
        {
            _imsLoginPage.GoToHub();
        }

        [When(@"I click on the Interact button")]
        public void WhenIClickOnTheInteractButton()
        {
            _imsLoginPage.GoToInteract();
        }
    }
}
