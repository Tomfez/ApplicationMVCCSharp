using DataModel.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Interfaces;
using Services.Repositories;
using System;

namespace Services.Tests
{
    [TestClass]
    public class MovieServiceTester
    {
        private IMovieRepository _movieRepository;
        private IMovieService _movieService;

        public MovieServiceTester()
        {
            _movieRepository = new MovieRepository(null);
            _movieService = new MovieService(_movieRepository);
        }

        [TestMethod]
        public void GivenNoMovieWithSameTitle_WhenAddingNewMovie_ThenMovieFromRepository()
        {
            var mock = new Mock<IMovieRepository>();
            var movie = new Movie() { Title = "ok", Description = "description" };

            mock.Setup(p => p.GetByTitle(It.IsAny<string>()))
                .Returns<Movie>(null);
            mock.Setup(p => p.Add(It.IsAny<Movie>()))
                .Returns(movie);

            var service = new MovieService(mock.Object);
            var dbMovie = service.Add(movie);
            Assert.IsTrue(dbMovie != null);
        }

        [TestMethod]
        public void GivenMovieWithSameTitle_WhenAddingNewMovie_ThenMovieFromRepository()
        {
            var mock = new Mock<IMovieRepository>();
            var movie = new Movie() { Title = "test film", Description = "description" };

            mock.Setup(p => p.GetByTitle(It.IsAny<string>()))
            .Returns(movie);
            mock.Setup(p => p.Add(It.IsAny<Movie>()))
                .Returns(movie);

            var service = new MovieService(mock.Object);
            var dbMovie = service.Add(movie);
            Assert.IsNull(dbMovie);
        }

        //[TestMethod]
        //public void GivenMovieWithYearLessThan1980_WhenAddingNewMovie_ThenMovieFromRepository()
        //{
        //    var mock = new Mock<IMovieRepository>();
        //    var movie = new Movie() { Title = "test film", Description = "description", ReleasedDate = new DateTime(1979, 02, 02) };

        //    mock.Setup(p => p.CheckDate(It.IsAny<DateTime>()))
        //    .Returns(movie.ReleasedDate.Year);
        //    //mock.Setup(p => p.CheckDate(It.IsAny<Movie>()))
        //    //    .Returns(movie);

        //    var service = new MovieService(mock.Object);
        //    var dbMovie = service.Add(movie);
        //    Assert.IsFalse(dbMovie);
        //}
    }
}
