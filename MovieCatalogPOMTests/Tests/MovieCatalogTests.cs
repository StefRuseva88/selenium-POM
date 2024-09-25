namespace MovieCatalogPOMTests.Tests
{
    public class MovieCatalogTests : BaseTest
    {
        private static string lastCreatedMovieTitle;
        private static string lastCreatedMovieDescription;

        [Test, Order(1)]
        public void AddMovieWithoutTitleTest()
        {
            addMoviePage.OpenPage();

            addMoviePage.TitleField.Clear();

            actions.ScrollToElement(addMoviePage.AddMovieBtn).Perform();

            addMoviePage.AddMovieBtn.Click();

            addMoviePage.AssertEmptyTitleMsg();
        }

        [Test, Order(2)]
        public void AddMovieWithoutDescriptionTest()
        {
            lastCreatedMovieTitle = GenerateRandomTitle();

            addMoviePage.OpenPage();

            addMoviePage.TitleField.SendKeys(lastCreatedMovieTitle);

            actions.ScrollToElement(addMoviePage.AddMovieBtn).Perform();

            addMoviePage.AddMovieBtn.Click();

            addMoviePage.AssertEmptyDescriptionMsg();
        }

        [Test, Order(3)]
        public void AddMovieWithValidDataTest()
        {
            lastCreatedMovieTitle = GenerateRandomTitle();
            lastCreatedMovieDescription = GenerateRandomDescription();
            addMoviePage.OpenPage();

            addMoviePage.TitleField.Clear();
            addMoviePage.TitleField.SendKeys(lastCreatedMovieTitle);
            addMoviePage.DescriptionField.Clear();
            addMoviePage.DescriptionField.SendKeys(lastCreatedMovieDescription);
            actions.ScrollToElement(addMoviePage.AddMovieBtn).Perform();
            addMoviePage.AddMovieBtn.Click();

            allMoviesPage.NavigateToLastPage();

            Assert.That(allMoviesPage.LastMovieTitle.Text.Trim, Is.EqualTo(lastCreatedMovieTitle), "The title is not as expected");
        }

        [Test, Order(4)]
        public void EditLastMovie()
        {
            lastCreatedMovieTitle = GenerateRandomTitle() + "EDITED";
            lastCreatedMovieDescription = GenerateRandomDescription();

            allMoviesPage.OpenPage();
            allMoviesPage.NavigateToLastPage();
            allMoviesPage.LastMovieEditButton.Click();

            editMoviePage.TitleInput.Clear();
            editMoviePage.TitleInput.SendKeys(lastCreatedMovieTitle);
            actions.ScrollToElement(editMoviePage.EditButton).Perform();
            editMoviePage.EditButton.Click();

            editMoviePage.AssertRecordEdited();
        }
        [Test, Order(5)]
        public void MarkLastMovieAsWatched()
        {
            allMoviesPage.OpenPage();
            allMoviesPage.NavigateToLastPage();
            allMoviesPage.LastMovieMarkAsWatchedButton.Click();

            watchedMoviesPage.OpenPage();
            watchedMoviesPage.NavigateToLastPage();

            Assert.That(watchedMoviesPage.LastMovieTitle.Text.Trim, Is.EqualTo(lastCreatedMovieTitle), "The movie was not added to watched");
        }
        [Test, Order(6)]
        public void DeleteMovie()
        {
            allMoviesPage.OpenPage();
            allMoviesPage.NavigateToLastPage();
            allMoviesPage.LastMovieDeleteButton.Click();

            deleteMoviePage.YesButton.Click();

            Assert.That(deleteMoviePage.ToastMessage.Text.Trim(), Is.EqualTo("The Movie is deleted successfully!"), "The movie was not deleted");
        }
    }
}