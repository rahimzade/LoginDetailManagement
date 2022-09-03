using LoginDetailManagement.Entities;

namespace LoginDetailManagement.Data.Repository
{
    public interface ILoginDetailRepository
    {
        IQueryable<LoginDetail> Table { get; }
        IQueryable<LoginDetail> TableNoTracking { get; }

        public Task<LoginDetail> CreateAsync(LoginDetail user, CancellationToken cancellationToken);
        public Task UpdateAsync(LoginDetail user, CancellationToken cancellationToken);
        public Task<List<LoginDetail>> GetAllAsync(CancellationToken cancellationToken);
        public Task<LoginDetail> GetByIdAsync(int Id, CancellationToken cancellationToken);
        public Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
