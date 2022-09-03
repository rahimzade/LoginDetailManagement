using LoginDetailManagement.Entities;
using System.Collections.Generic;
using System;
using LoginDetailManagement.Data.Repository;
using LoginDetailManagement.Services.interfaces;
using System.Linq;

namespace LoginDetailManagement.Services
{
    public class LoginDetailService : ILoginDetailService
    {
        private readonly ILoginDetailRepository _loginDetailRepository;
        private readonly IConfiguration _config;

        public LoginDetailService(ILoginDetailRepository loginDetailRepository, IConfiguration config)
        {
            _loginDetailRepository = loginDetailRepository;
            _config = config;
        }

        public async Task<LoginDetail> Add(LoginDetail loginDetail, CancellationToken cancellationToken)
        {
            try
            {
                var encryptionKey = _config["EncripyStrings:key"];
                loginDetail.Password = SecurityHelper.Encrypt(encryptionKey, loginDetail.Password);

                return await _loginDetailRepository.CreateAsync(loginDetail, cancellationToken);
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message);
                throw;
            }
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                await _loginDetailRepository.DeleteAsync(id, cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message);
                throw;
            }
        }

        public async Task<List<LoginDetail>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var encryptionKey = _config["EncripyStrings:key"];

                var list = await _loginDetailRepository.GetAllAsync(cancellationToken);
                return list.Select(x => new LoginDetail
                {
                    Id = x.Id,
                    Title = x.Title,
                    UserName = x.UserName,
                    Password = SecurityHelper.Decrypt(encryptionKey, x.Password),
                }).ToList(); ;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message);
                throw;
            }
        }

        public async Task<LoginDetail> GetById(int id, CancellationToken cancellationToken)
        {
            try
            {
                var encryptionKey = _config["EncripyStrings:key"];

                var loginDetail = await _loginDetailRepository.GetByIdAsync(id, cancellationToken);
                if (loginDetail != null)
                    loginDetail.Password = SecurityHelper.Decrypt(encryptionKey, loginDetail.Password);

                return loginDetail;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message);
                throw;
            }
        }

        public async Task<bool> Update(int id, LoginDetail loginDetail, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _loginDetailRepository.GetByIdAsync(id, cancellationToken);
                if (data != null)
                {
                    var encryptionKey = _config["EncripyStrings:key"];

                    data.UserName = loginDetail.UserName;
                    data.Password = SecurityHelper.Encrypt(encryptionKey, loginDetail.Password);

                    data.Title = loginDetail.Title;

                    await _loginDetailRepository.UpdateAsync(data, cancellationToken);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message);
                throw;
            }
        }
    }
}
