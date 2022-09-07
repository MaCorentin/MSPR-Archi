using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MSPR_Archi.Data;
using MSPR_Archi.Model;

namespace MSPR_Archi.Services
{
    public class TokenService
    {
        public User user = new User();

        private readonly AppDBContext _appDBContext;
    
        public TokenService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
      
        public async Task<bool> InsertTokenAsync(TokenModel token)
        {
            TokenModel find = _appDBContext.tokens.FirstOrDefault(t => t.userId == token.userId);
            if ( find != null) {

                _appDBContext.tokens.Remove(find);
            }
            await _appDBContext.tokens.AddAsync(token);
            await _appDBContext.SaveChangesAsync();
            return true;
        }

        
        public async Task<TokenModel> VerifyTokenAsync(TokenModel retrieveToken)
        {
            TokenModel token = await _appDBContext.tokens.FirstOrDefaultAsync(c => c.userId.Equals(retrieveToken.userId) && c.token == retrieveToken.token);
            return token;
        }
        public async Task<TokenModel> GetTokenAsync(string userId)
        {
            TokenModel token = await _appDBContext.tokens.FirstOrDefaultAsync(c => c.userId.Equals(userId));
            return token;
        }

        public async Task<bool> UpdateTokenAsync(TokenModel token)
        {
            _appDBContext.tokens.Update(token);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
    
        public async Task<bool> DeleteTokenAsync(TokenModel token)
        {
            _appDBContext.Remove(token);
            await _appDBContext.SaveChangesAsync();
            return true;
        }

    }

}
