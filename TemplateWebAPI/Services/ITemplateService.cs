namespace TemplateWebAPI.Services
{
    public interface ITemplateService
    {
        Task<string> CreateTemplateMessage(int id);
    }
}
