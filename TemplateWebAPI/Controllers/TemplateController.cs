using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TemplateWebAPI.Models;
using TemplateWebAPI.Repositories;
using TemplateWebAPI.Services;

namespace TemplateWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly ILogger<TemplateController> _logger;
        private readonly ITemplateService _templateService;
        private readonly ITemplateRepository _templateRepository;
        private readonly IMapper _mapper;

        public TemplateController(ILogger<TemplateController> logger, ITemplateService templateService, ITemplateRepository templateRepository, IMapper mapper)
        {
            _logger = logger;
            _templateService = templateService;
            _templateRepository = templateRepository;
            _mapper = mapper;
        }

        // GET: api/Template
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_templateRepository.GetAll());
        }

        // GET api/Template/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            return Ok(_mapper.Map<TemplateModel>(_templateRepository.GetById(id)));
        }

        // GET api/Template/5/TemplateMessage
        [HttpGet("{id}/TemplateMessage")]
        public async Task<string> GetTemplateMessage(int id)
        {
            return await _templateService.CreateTemplateMessage(id);
        }

        // POST api/Template
        [HttpPost]
        public string Post([FromBody] TemplateModel templateModel)
        {
            _templateRepository.Add(templateModel);
            return "Template Model added successfully.";
        }

        // PUT api/Template/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TemplateModel templateModel)
        {
           _templateRepository.Update(templateModel);
        }

        // DELETE api/Template/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _templateRepository.Delete(id);
        }
    }
}
