using TemplateWebAPI.Models;

namespace TemplateWebAPI.Repositories
{
    public interface ITemplateRepository
    {
        IEnumerable<TemplateModel> GetAll();
        TemplateModelDTO? GetById(int id);
        void Add(TemplateModel templateModel);
        void Update(TemplateModel templateModel);
        void Delete(int id);
    }
}
