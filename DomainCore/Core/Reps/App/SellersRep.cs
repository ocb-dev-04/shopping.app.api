using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using DomainCore.Data.Entities.App;
using DomainCore.Core.Interfaces.App;
using DomainCore.Data.DataBaseContext;
using DomainCore.Core.EntitiesDTO.App.Sellers;

namespace DomainCore.Core.Reps.App
{
    public class SellersRep : BaseRep, ISellersRep
    {
        #region Construct

        public SellersRep(
            AppDbContext dbContext,
            IMapper mapper) : base(dbContext, mapper)
        { }

        #endregion

        #region Methods

        #region Get's methods

        public async Task<List<SellersDTO>> GetAllAsync()
            => await _appDbContext
                            .Sellers
                            .ProjectTo<SellersDTO>(_mapper.ConfigurationProvider)
                            .ToListAsync();

        public async Task<SellersDTO> GetByIdAsync(int profileId)
        => await _appDbContext
                            .Sellers
                            .ProjectTo<SellersDTO>(_mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync(p => p.Id == profileId);

        #endregion

        #region CRUD

        public async Task<SellersDTO> CreateAsync(CreateSellersDTO create)
        {
            //confirm if userId exist
            var confirm = await _appDbContext
                                    .Sellers
                                    .FirstOrDefaultAsync(p =>
                                        p.ProfileId == create.ProfileId);

            if (confirm != null)
                throw new ArgumentNullException(nameof(confirm));

            var map = _mapper.Map<Sellers>(create);
            var add = await _appDbContext
                                .Sellers
                                .AddAsync(map);
            if (add == null)
                throw new ArgumentNullException(nameof(add));

            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<SellersDTO>(add.Entity);
        }

        public async Task<bool> UpdateAsync(UpdateSellersDTO update)
        {
            var confirm = await _appDbContext
                                    .Sellers
                                    .FirstOrDefaultAsync(p =>
                                            p.ProfileId == update.ProfileId &&
                                            p.SellerShopName == update.SellerShopName);

            if (confirm == null)
                return false;

            // mapeo los nuevos datos
            var map = _mapper.Map<Sellers>(update);
            confirm = map;
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int profileId)
        {
            var confirm = await _appDbContext
                                    .Sellers
                                    .FirstOrDefaultAsync(p =>
                                            p.ProfileId == profileId);

            if (confirm == null)
                return false;

            var delete = _appDbContext.Sellers.Remove(confirm);
            if (delete == null)
                return false;

            await _appDbContext.SaveChangesAsync();
            return true;
        }

        #endregion

        #endregion
    }
}
