namespace ChatApp.Application.Features.Interfaces
{
    public interface IUnitOfWork 
    {
        Task Save();
        Task BeginTransaction();
        Task Commit();
    }
}
