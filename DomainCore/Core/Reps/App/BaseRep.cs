using AutoMapper;
using DomainCore.Data.DataBaseContext;

namespace DomainCore.Core.Reps.App
{
    public class BaseRep
    {
        #region Properties

        protected readonly AppDbContext _appDbContext;
        protected readonly IMapper _mapper;

        #endregion

        #region Constructors

        protected BaseRep(
            AppDbContext dbContext,
            IMapper mapper)
        {
            _appDbContext = dbContext;
            _mapper = mapper;
        }

        #endregion
    }
}
