using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using DomainCore.Data.Models;
using DomainCore.Core.Interfaces;
using DomainCore.Core.Reps.BaseRep;
using DomainCore.Data.DbAppContext;
using DomainCore.Core.ModelsDTO.Products;

namespace DomainCore.Core.Reps
{
    public class ProductsRep : AllBaseRep, IProductsRep
    {
        #region Construct

        public ProductsRep(
            AppDbContext dbContext,
            IMapper mapper) : base(dbContext, mapper)
        { }

        #endregion

        #region Get's Methods

        public async Task<ProductsDTO> GetProductsById(int id)
            => await _appDbContext
                            .Products
                            .ProjectTo<ProductsDTO>(_mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<ProductsDTO> GetProductsByName(string name)
            => await _appDbContext
                            .Products
                            .ProjectTo<ProductsDTO>(_mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync(p => p.Name == name);

        #endregion

        #region CRUD Methods

        public async Task<ProductsDTO> CreateProductsAsync(CreateProductsDTO create)
        {
            //confirm if userId exist
            var confirm = await _appDbContext
                                    .Products
                                    .FirstOrDefaultAsync(p => 
                                        p.Name == create.Name &&
                                        p.Price == create.Price &&
                                        p.SellerId == create.SellerId);

            if (confirm == null)
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

        public async Task<ProductsDTO> UpdateProductsAsync(int id, ProductsDTO update)
        {
            //confirm if userId exist
            var confirm = await _appDbContext
                                    .Products
                                    .FirstOrDefaultAsync(p =>
                                            p.SellerId == update.SellerId &&
                                            p.Id == id);
            if (confirm == null)
                throw new ArgumentNullException(nameof(confirm));

            // maping new info to old info
            var map = _mapper.Map(confirm, update);
            // and save all
            await _appDbContext.SaveChangesAsync();
            return map;
        }

        public async Task<bool> DeleteteProductsAsync(int id)
        {
            // confirm if exist
            var confirm = await _appDbContext
                                    .Products
                                    .FindAsync(id);
            if (confirm == null)
                return false;

            // delete membership
            var del = _appDbContext
                            .Products
                            .Remove(confirm);
            if (del == null)
                return false;

            await _appDbContext.SaveChangesAsync();
            return true;
        }

        #endregion
    }
}
