using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestNinja.Mocking;

namespace TestNinjaUnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IFileReader> _fileReader;
        private VideoService _service;
        private Mock<IVideoRepository> _videoRepository;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _videoRepository = new Mock<IVideoRepository>();
            _service = new VideoService(_fileReader.Object, _videoRepository.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _service.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_WhenCalled_ReturnsVideIdsList()
        {
            _videoRepository.Setup(vr => vr.GetUnProcessedVideos())
                .Returns(new List<Video> {
                    new Video() { Id = 0},
                    new Video() { Id = 1},
                    new Video() { Id = 2}
                });

            var result = _service.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("0,1,2"));
        }

        [TestCase(1)]
        [TestCase(5)]
        public void GetUnprocessedVideosAsCsv_WhenCalled_ReturnsVideIdsNumber(int id)
        {
            var list = new List<Video>();
            for (int i = 0; i < id; i++)
            {
                list.Add(new Video() { Id = i });
            }
            _videoRepository.Setup(vr => vr.GetUnProcessedVideos())
                .Returns(list);

            var result = _service.GetUnprocessedVideosAsCsv();

            Assert.That(result.Split(',').Length, Is.EqualTo(id));
        }
    }
}
