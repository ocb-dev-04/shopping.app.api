using System;
using System.ComponentModel.DataAnnotations;

namespace DomainCore.Core.ModelsDTO
{
    public class SamePropsDTO
    {
        #region Properties

        [Required]
        public int Id { get; set; }

        // no need take the time with a construct (DTO give it)
        public DateTime CreateServerTime { get; set; }

        #endregion

        #region Construct

        public SamePropsDTO()
            => CreateServerTime = DateTime.Now;

        #endregion
    }
}
