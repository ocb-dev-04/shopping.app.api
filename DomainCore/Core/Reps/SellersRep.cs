using AutoMapper;
using AutoMapper.QueryableExtensions;
using DomainCore.Core.Interfaces;
using DomainCore.Core.ModelsDTO.Sellers;
using DomainCore.Core.Reps.BaseRep;
using DomainCore.Data.DbAppContext;
using DomainCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore.Core.Reps
{
    public class SellersRep : AllBaseRep, ISellersRep
    {
        #region Construct

        public SellersRep(
            AppDbContext dbContext,
            IMapper mapper) : base(dbContext, mapper)
        { }

        #endregion

        #region Get's Methods

        public async Task<SellersDTO> GetSellersById(int id)
            => await _appDbContext
                            .Sellers
                            .ProjectTo<SellersDTO>(_mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<SellersDTO> GetSellersByProfileId(int profile)
            => await _appDbContext
                            .Sellers
                            .ProjectTo<SellersDTO>(_mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync(p => p.ProfileId == profile);

        #endregion

        #region CRUD Methods

        public async Task<SellersDTO> CreateSellersAsync(CreateSellersDTO create)
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

        public async Task<SellersDTO> UpdateSellersAsync(int id, SellersDTO update)
        {
            //confirm if userId exist
            var confirm = await _appDbContext
                                    .Sellers
                                    .FirstOrDefaultAsync(p => p.Id == id);
            if (confirm == null)
                throw new ArgumentNullException(nameof(confirm));

            // maping new info to old info
            var map = _mapper.Map(confirm, update);
            // and save all
            await _appDbContext.SaveChangesAsync();
            return map;
        }

        public async Task<bool> DeleteteSellersAsync(int id)
        {
            // confirm if exist
            var confirm = await _appDbContext
                                    .Sellers
                                    .FindAsync(id);
            if (confirm == null)
                return false;

            // delete membership
            var del = _appDbContext
                            .Sellers
                            .Remove(confirm);
            if (del == null)
                return false;

            await _appDbContext.SaveChangesAsync();
            return true;
        }

        #endregion
    }
}
