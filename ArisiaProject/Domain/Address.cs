using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArisiaProject.Domain
{
    public class Address
    {
        #region Properties

        public virtual string StreetAddress { get; set; }

        public virtual string State { get; set; }

        public virtual string PostCode { get; set; }

        #endregion
    }
}