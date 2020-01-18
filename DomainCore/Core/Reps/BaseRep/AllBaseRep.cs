using DomainCore.Data.DbAppContext;

using AutoMapper;

namespace DomainCore.Core.Reps.BaseRep
{
    public class AllBaseRep
    {
        #region Properties

        protected readonly AppDbContext _appDbContext;
        protected readonly IMapper _mapper;

        #endregion

        #region Constructors

        protected AllBaseRep(
            AppDbContext dbContext,
            IMapper mapper)
        {
            _appDbContext = dbContext;
            _mapper = mapper;
        }

        #endregion
    }
}
