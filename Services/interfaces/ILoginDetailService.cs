using LoginDetailManagement.Entities;

namespace LoginDetailManagement.Services.interfaces
{
    public interface ILoginDetailService
    {
        Task<LoginDetail> Add(LoginDetail user, CancellationToken cancellationToken);
        Task<bool> Update(int id, LoginDetail user, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
        Task<List<LoginDetail>> GetAll(CancellationToken cancellationToken);
        Task<LoginDetail> GetById(int id, CancellationToken cancellationToken);
    }
}
