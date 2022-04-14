using System;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.Linq;
using DemoProjectUsingEF.POM.GidOnline;

namespace DemoProjectUsingEF.Steps.GidOnline
{
    [Binding]
    class GidonlineSteps
    {
        private GidOnlineHomePage _gidOnlineHomePage;
        private SearchResultsPage _searchResultsPage;
        private LogInPage _logInPage;
        private MovieSectionPage _movieSectionPage;

        public GidonlineSteps(GidOnlineHomePage gidOnlineHomePage, SearchResultsPage searchResultsPage,
            LogInPage logInPage, MovieSectionPage movieSectionPage)
        {
            _gidOnlineHomePage = gidOnlineHomePage;
            _searchResultsPage = searchResultsPage;
            _logInPage = logInPage;
            _movieSectionPage = movieSectionPage;
        }

        [Given(@"User open web-site")]
        public void GivenUserOpenWeb_Site()
        {
            _gidOnlineHomePage.NavigateToHomePage()
                .VerifyThatLogoDisplays();
        }

        [When(@"User performs a search with '(.*)' value")]
        public void WhenUserPerformsASearchWithValue(string searchValue)
        {
            _gidOnlineHomePage.FillOutValueToTheSerchField(searchValue)
                .ClickOnSearchButton();
        }

        [Then(@"User should see results for '(.*)'")]
        public void ThenUserShouldSeeResultsFor(string searchValue)
        {
            _searchResultsPage.VerifyThatResultsDisplay(searchValue);
        }

        [Then(@"User should see a message that there are no search results")]
        public void ThenUserShouldSeeAMessageThatThereAreNoSearchResults()
        {
            _searchResultsPage.VerifyThatResultsDontDisplay();

        }

        [When(@"User click on '(.*)' buton on the side bar")]
        public void WhenUserClickOnButonOnTheSideBar(string buttonName)
        {
            _gidOnlineHomePage.ClickOnSideButton(buttonName);
        }

        [When(@"User enters the following data")]
        [Then(@"User enters the following data")]
        public void ThenUserEntersTheFollowingData(Table userDetailsTable)
        {
            var detailsInfo = userDetailsTable.Rows;
            _logInPage.EnterLogin(detailsInfo[0]["Username"])
                .EnterPasword(detailsInfo[0]["Password"])
                .ClickOnLoginButton();
        }

        [Then(@"User sees an error message about invalid login")]
        public void ThenUserSeesAnErrorMessageAboutInvalidLogin()
        {
            _logInPage.VerifyThatErrorDisplay();
        }

        [When(@"User selects '(.*)' on the home page")]
        public void WhenUserSelectsOnTheHomePage(string sectionName)
        {
            _gidOnlineHomePage.ClickOnSection(sectionName);
        }

        [Then(@"User should see corresponding '(.*)' results")]
        public void ThenUserShouldSeeCorrespondingResults(string sectionName)
        {
            _movieSectionPage.VerifyThatResultsDisplay(sectionName);
        }



    }
}
