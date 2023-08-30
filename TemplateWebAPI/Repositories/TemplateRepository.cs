using AutoMapper;
using System.Reflection.Metadata;
using TemplateWebAPI.Models;

namespace TemplateWebAPI.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly IMapper _mapper;
        public TemplateRepository(IMapper mapper) {
            _mapper = mapper;
        }

        private readonly List<TemplateModel> _templateModels = new List<TemplateModel>();

        public IEnumerable<TemplateModel> GetAll() { return _templateModels; }

        public TemplateModelDTO? GetById(int id) { return _mapper.Map<TemplateModelDTO>(_templateModels.FirstOrDefault(x => x.Id == id)); }

        public void Add(TemplateModel templateModel) { _templateModels.Add(templateModel); }

        public void Update(TemplateModel templateModel)
        {
            TemplateModel? existingTemplateModel = _templateModels.FirstOrDefault(x => x.Id == templateModel.Id);

            if (existingTemplateModel != null)
            {
                foreach (var property in typeof(TemplateModel).GetProperties())
                {
                    var newValue = property.GetValue(templateModel);
                    if (newValue != null)
                    {
                        property.SetValue(existingTemplateModel, newValue);
                    }
                }
            }
        }

        public void Delete(int id)
        {
            TemplateModel? existingTemplateModel = _templateModels.FirstOrDefault(x => x.Id == id);

            if (existingTemplateModel != null)
            {
                _templateModels.Remove(existingTemplateModel);
            }
        }
    }
}
