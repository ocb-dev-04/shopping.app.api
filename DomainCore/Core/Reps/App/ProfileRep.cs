using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using DomainCore.Data.Entities.App;
using DomainCore.Core.Interfaces.App;
using DomainCore.Data.DataBaseContext;
using DomainCore.Core.EntitiesDTO.App.ProfileInfo;
using DomainCore.Data.Entities.Identity;

namespace DomainCore.Core.Reps.App
{
    public class ProfileRep : BaseRep, IProfileInfosRep
    {
        #region Construct

        public ProfileRep(
            AppDbContext dbContext,
            IMapper mapper) : base(dbContext, mapper)
        { }

        #endregion

        #region Methods

        #region Get's methods

        public async Task<List<ProfileInfoDTO>> GetAllAsync()
            => await _appDbContext
                            .ProfileInfo
                            .ProjectTo<ProfileInfoDTO>(_mapper.ConfigurationProvider)
                            .ToListAsync();

        public async Task<ProfileInfoDTO> GetByIdAsync(string profileId)
        => await _appDbContext
                            .ProfileInfo
                            .ProjectTo<ProfileInfoDTO>(_mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync(p => p.UserId == profileId);

        #endregion

        #region CRUD

        public async Task<ProfileInfoDTO> CreateAsync(CreateProfileInfoDTO create)
        {
            //confirm if userId exist
            var confirm = await _appDbContext
                                    .ProfileInfo
                                    .FirstOrDefaultAsync(p => p.UserId == create.UserId);

            if (confirm != null)
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

        public async Task<bool> UpdateAsync(UpdateProfileInfoDTO update)
        {
            var confirm = await _appDbContext
                                    .ProfileInfo
                                    .FirstOrDefaultAsync(p =>
                                            p.UserId == update.UserId &&
                                            p.PersonalDocument == update.PersonalDocument && 
                                            p.Country == update.Country);

            if (confirm == null)
                return false;

            // mapeo los nuevos datos
            var map = _mapper.Map<ProfileInfo>(update);
            confirm = map;
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string userId)
        {
            var confirm = await _appDbContext
                                    .ProfileInfo
                                    .FirstOrDefaultAsync(p =>
                                            p.UserId == userId);

            if (confirm == null)
                return false;

            var delete = _appDbContext.ProfileInfo.Remove(confirm);
            if (delete == null)
                return false;

            await _appDbContext.SaveChangesAsync();
            return true;
        }

        #endregion

        #endregion
    }
}
