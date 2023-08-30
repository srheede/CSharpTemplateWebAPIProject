using Moq;
using TemplateWebAPI.Models;
using TemplateWebAPI.Repositories;
using TemplateWebAPI.Services;

namespace TemplateWebApi.Tests
{
    [TestClass]
    public class TemplateUnitTest
    {
        private readonly ITemplateService _templateService;
        private readonly Mock<ITemplateRepository> _mockTemplateRepository;

        public TemplateUnitTest()
        {
            _templateService = new TemplateService();
            _mockTemplateRepository = new Mock<ITemplateRepository>();

            _mockTemplateRepository.Setup(repository => repository.GetById(It.IsAny<int>())).Returns(CreateMockTemplateModelDTO());
        }

        private TemplateModelDTO CreateMockTemplateModelDTO()
        {
            TemplateModelDTO templateModelDTO = new TemplateModelDTO();
            templateModelDTO.Id = 0;
            templateModelDTO.Name = "name";

            return templateModelDTO;
        }

        [TestMethod]
        public async Task CreateTemplateMessage_ValidCalulations_ReturnsCorrectValue()
        {
            string result = await _templateService.CreateTemplateMessage(7);

            Assert.AreEqual("value: 20", result);
        }
    }
}