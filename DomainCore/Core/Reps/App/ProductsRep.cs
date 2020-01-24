using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using DomainCore.Data.Entities.App;
using DomainCore.Core.Interfaces.App;
using DomainCore.Data.DataBaseContext;
using DomainCore.Core.EntitiesDTO.App.Products;

namespace DomainCore.Core.Reps.App
{
    public class ProductsRep : BaseRep, IProductsRep
    {
        #region Construct

        public ProductsRep(
            AppDbContext dbContext,
            IMapper mapper):base(dbContext,mapper)
        {}

        #endregion

        #region Methods

        #region Get's methods

        public async Task<List<ProductsDTO>> GetAllAsync()
            => await _appDbContext
                            .Products
                            .ProjectTo<ProductsDTO>(_mapper.ConfigurationProvider)
                            .ToListAsync();

        public async Task<ProductsDTO> GetByIdAsync(int productId)
        => await _appDbContext
                            .Products
                            .ProjectTo<ProductsDTO>(_mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync(p => p.Id == productId);

        #endregion

        #region CRUD

        public async Task<ProductsDTO> CreateAsync(CreateProductsDTO create)
        {
            //confirm if userId exist
            var confirm = await _appDbContext
                                    .Products
                                    .FirstOrDefaultAsync(p => 
                                        p.Name == create.Name &&
                                        p.SellerId == create.SellerId &&
                                        p.Price == create.Price);

            if (confirm != null)
                throw new ArgumentNullException(nameof(confirm));

            var map = _mapper.Map<Products>(create);
            var add = await _appDbContext
                                .Products
                                .AddAsync(map);
            if (add == null)
                throw new ArgumentNullException(nameof(add));

            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<ProductsDTO>(add.Entity);
        }

        public async Task<bool> UpdateAsync(UpdateProductsDTO update)
        {
            var confirm = await _appDbContext
                                    .Products
                                    .FirstOrDefaultAsync(p =>
                                            p.Id == update.Id &&
                                            p.SellerId == update.SellerId);
            if (confirm == null)
                return false;

            // mapeo los nuevos datos
            var map = _mapper.Map<Products>(update);
            confirm = map;
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int productId)
        {
            var confirm = await _appDbContext
                                    .Products
                                    .FirstOrDefaultAsync(p =>
                                            p.Id == productId);

            if (confirm == null)
                return false;

            var delete = _appDbContext.Products.Remove(confirm);
            if (delete == null)
                return false;

            await _appDbContext.SaveChangesAsync();
            return true;
        }

        #endregion

        #endregion
    }
}
