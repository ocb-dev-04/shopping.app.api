using AutoMapper;
using AutoMapper.QueryableExtensions;
using DomainCore.Core.EntitiesDTO.App.Cart;
using DomainCore.Core.Interfaces.App;
using DomainCore.Data.DataBaseContext;
using DomainCore.Data.Entities.App;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCore.Core.Reps.App
{
    public class CartRep : BaseRep, ICartRep
    {
        #region Construct

        public CartRep(
            AppDbContext dbContext,
            IMapper mapper) : base(dbContext, mapper)
        { }

        #endregion

        #region Methods

        #region Get's methods

        public async Task<List<CartDTO>> GetByUserIdAsync(string userId)
            => await _appDbContext
                            .Cart
                            .ProjectTo<CartDTO>(_mapper.ConfigurationProvider)
                            .Where(p => p.UserId == userId)
                            .ToListAsync();

        #endregion

        #region CRUD

        public async Task<CartDTO> CreateAsync(CreateCartDTO create)
        {
            //confirm if userId exist
            var confirm = await _appDbContext
                                    .Cart
                                    .FirstOrDefaultAsync(p =>
                                        p.ProductId == create.ProductId &&
                                        p.UserId == create.UserId);

            if (confirm != null)
                throw new ArgumentNullException(nameof(confirm));

            var map = _mapper.Map<Cart>(create);
            var add = await _appDbContext
                                .Cart
                                .AddAsync(map);
            if (add == null)
                throw new ArgumentNullException(nameof(add));

            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<CartDTO>(add.Entity);
        }

        public async Task<bool> UpdateAsync(UpdateCartDTO update)
        {
            var confirm = await _appDbContext
                                    .Cart
                                    .FirstOrDefaultAsync(p =>
                                            p.Id == update.Id &&
                                            p.UserId == update.UserId &&
                                            p.ProductId == update.ProductId);
            if (confirm == null)
                return false;

            // mapeo los nuevos datos
            var map = _mapper.Map<Cart>(update);
            confirm.Quantity = map.Quantity;
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int productId, string userId)
        {
            var confirm = await _appDbContext
                                    .Cart
                                    .FirstOrDefaultAsync(p =>
                                            p.ProductId == productId &&
                                            p.UserId == userId);

            if (confirm == null)
                return false;

            var delete = _appDbContext.Cart.Remove(confirm);
            if (delete == null)
                return false;

            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAllAsync(int cartId, string userId)
        {
            var confirm = await _appDbContext
                                    .Cart
                                    .Where(p =>
                                            p.Id == cartId &&
                                            p.UserId == userId)
                                    .ToListAsync();

            if (confirm == null)
                return false;

            _appDbContext.Cart.RemoveRange(confirm);// eraser all product on cart
            await _appDbContext.SaveChangesAsync();// save changes
            return true;
        }

        #endregion

        #endregion
    }
}
