using Microsoft.EntityFrameworkCore;
using LoginDetailManagement.Data;
using LoginDetailManagement.Entities;

namespace LoginDetailManagement.Data.Repository
{
    public class LoginDetailRepository : ILoginDetailRepository
    {
        ApplicationDbContext _dbContext;

        public LoginDetailRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public virtual IQueryable<LoginDetail> Table => _dbContext.Set<LoginDetail>();
        public virtual IQueryable<LoginDetail> TableNoTracking => _dbContext.Set<LoginDetail>().AsNoTracking();

        public async Task<LoginDetail> CreateAsync(LoginDetail user, CancellationToken cancellationToken)
        {
            try
            {
                var obj = await _dbContext.LoginDetail.AddAsync(user);
                _dbContext.SaveChanges();
                return obj.Entity;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message);
                throw;
            }
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                var data = _dbContext.LoginDetail.FirstOrDefault(x => x.Id == id);
                if (data != null)
                {
                    _dbContext.Remove(data);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message);
                throw;
            }
        }

        public async Task<List<LoginDetail>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await _dbContext.LoginDetail.ToListAsync();
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message);
                throw;
            }
        }

        public async Task<LoginDetail> GetByIdAsync(int Id, CancellationToken cancellationToken)
        {
            try
            {
                return await _dbContext.LoginDetail.FirstOrDefaultAsync(x => x.Id == Id);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message);
                throw;
            }
        }

        public async Task UpdateAsync(LoginDetail user, CancellationToken cancellationToken)
        {
            try
            {
                _dbContext.LoginDetail.Update(user);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message);
                throw;
            }
        }
    }
}
