using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using DomainCore.Data.Identity;
using DomainCore.Core.Reps.BaseRep;
using DomainCore.Data.DbAppContext;
using DomainCore.Core.ModelsDTO.Identity;
using DomainCore.Core.Interfaces.Identity;

namespace DomainCore.Core.Reps.Identity
{
    public class ProfileInfoRep : AllBaseRep, IProfileInfoRep
    {
        #region Construct

        public ProfileInfoRep(
            AppDbContext dbContext,
            IMapper mapper) : base(dbContext, mapper)
        { }

        #endregion

        #region Get's Methods

        public async Task<ProfileInfoDTO> GetProfileInfoById(int id)
            => await _appDbContext
                            .ProfileInfo
                            .ProjectTo<ProfileInfoDTO>(_mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<ProfileInfoDTO> GetProfileInfoByName(string name)
            => await _appDbContext
                            .ProfileInfo
                            .ProjectTo<ProfileInfoDTO>(_mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync(p => p.Name == name);

        #endregion

        #region CRUD Methods

        public async Task<ProfileInfoDTO> CreateProfileInfoAsync(CreateProfileInfoDTO create)
        {
            //confirm if userId exist
            var confirm = await _appDbContext
                                    .ProfileInfo
                                    .FirstOrDefaultAsync(p => p.UserId == create.UserId);
            if (confirm == null)
                throw new ArgumentNullException(nameof(confirm));

            var map = _mapper.Map<ProfileInfo>(create);
            var add = await _appDbContext
                                .ProfileInfo
                                .AddAsync(map);
            if (add == null)
                throw new ArgumentNullException(nameof(add));

            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<ProfileInfoDTO>(add.Entity);
        }

        public async Task<ProfileInfoDTO> UpdateProfileInfoAsync(int id, ProfileInfoDTO update)
        {
            //confirm if userId exist
            var confirm = await _appDbContext
                                    .ProfileInfo
                                    .FirstOrDefaultAsync(p => 
                                            p.UserId == update.UserId &&
                                            p.Id == id);
            if (confirm == null)
                throw new ArgumentNullException(nameof(confirm));

            // maping new info to old info
            var map = _mapper.Map(confirm, update);
            // and save all
            await _appDbContext.SaveChangesAsync();
            return map;
        }

        public async Task<bool> DeleteteProfileInfoAsync(int id)
        {
            // confirm if exist
            var confirm = await _appDbContext
                                    .ProfileInfo
                                    .FindAsync(id);

            if (confirm == null)
                return false;

            // delete membership
            var del = _appDbContext
                            .ProfileInfo
                            .Remove(confirm);
            if (del == null)
                return false;

            await _appDbContext.SaveChangesAsync();
            return true;
        }

        #endregion
    }
}
