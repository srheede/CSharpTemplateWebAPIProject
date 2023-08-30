using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace TemplateWebAPI.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private readonly Mock<ITemplateService> _templateService;

        public TemplateServiceTests()
        {
            this.templateService = new TemplateServiceTests()
        }

        [TestMethod]
        public void CreateTemplateMessage_ValidCalulations_ReturnsCorrectValue()
        {
            TemplateModelDTO result = await _templateService.CreateTemplateMessage(7);

        }
    }
}
