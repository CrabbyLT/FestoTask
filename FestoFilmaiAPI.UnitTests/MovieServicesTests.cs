using FestoFilmaiAPI.Models;
using FestoFilmaiAPI.Repository;
using FestoFilmaiAPI.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FestoFilmaiAPI.Tests
{
    public class MovieServicesTests
    {
        private IMoviesService _moviesService;
        private Mock<IMovieDetailRepository> _movieDetailRepo;
        private Mock<IApiReaderService> _apiReaderService;
        private MovieModel _movieModel;

        [SetUp]
        public void Setup()
        {
            _movieDetailRepo = new Mock<IMovieDetailRepository>();
            _apiReaderService = new Mock<IApiReaderService>();
            _moviesService = new MoviesService(_apiReaderService.Object, null, _movieDetailRepo.Object);

            _movieModel = new MovieModel()
            {
                Title = "The Simp",
                Year = "1920",
                Genre = "Short, Comedy",
                Actors = "Lloyd Hamilton, Marvel Rea, Otto Fries",
                Plot = "When Hamilton is kicked out of his home by his father, he lives in a park until a girl brings him to a rescue mission. But there, though innocent, it appears he's robbed the collection basket.",
                ImdbRating = "6.5",
                ImdbId = "tt0248438",
                Poster = "https://m.media-amazon.com/images/M/MV5BMzlhMzE2ZjAtNDcwNC00YjBjLTk0NDEtMWM4M2VmZTFjZjUzXkEyXkFqcGdeQXVyMTcyODY2NDQ@._V1_SX300.jpg"
            };

        }

        [Test]
        public async Task Given_RequestOfMovieDetail_When_CorrectImdbIdAndAlreadyInDatabase_Then_ReturnsMovieDetailsAsync()
        {
            _movieDetailRepo.Setup(repository => repository.GetMovieFromRepository(_movieModel.ImdbId)).ReturnsAsync(_movieModel);

            var result = await _moviesService.GetDetailsFromId(_movieModel.ImdbId);

            _movieDetailRepo.Verify(mock => mock.GetMovieFromRepository(It.IsAny<string>()), Times.Once());
            AssertResultEqualsExpected(result);
        }

        private void AssertResultEqualsExpected(MovieModel result)
        {
            Assert.That(result.ImdbId.Equals(_movieModel.ImdbId));
            Assert.That(result.Title.Equals(_movieModel.Title));
            Assert.That(result.Genre.Equals(_movieModel.Genre));
            Assert.That(result.Actors.Equals(_movieModel.Actors));
            Assert.That(result.Year.Equals(_movieModel.Year));
        }

        [Test]
        public async Task Given_RequestOfMovieDetail_When_CorrectImdbIdAndNotInDatabase_Then_CallsApiAndInsertsNewData()
        {
            _movieDetailRepo.Setup(repository => repository.GetMovieFromRepository(_movieModel.ImdbId));
            _apiReaderService.Setup(service => service.GetMovieDetails(_movieModel.ImdbId)).ReturnsAsync(_movieModel);

            var result = await _moviesService.GetDetailsFromId(_movieModel.ImdbId);

            _movieDetailRepo.Verify(mock => mock.GetMovieFromRepository(It.IsAny<string>()), Times.Once());
            _movieDetailRepo.Verify(mock => mock.InsertDataToRepository(It.IsAny<MovieModel>()), Times.Once());
            _apiReaderService.Verify(mock => mock.GetMovieDetails(It.IsAny<string>()), Times.Once());
            AssertResultEqualsExpected(result);
        }
    }
}