using System;
using System.ComponentModel.DataAnnotations;

namespace DomainCore.Data
{
    public class SameProps
    {
        #region Properties

        [Key]
        public int Id { get; set; }

        // no need take the time with a construct (DTO give it)
        public DateTime CreateServerTime { get; set; }

        #endregion
    }
}
