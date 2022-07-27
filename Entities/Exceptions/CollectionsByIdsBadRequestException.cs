using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CollectionsByIdsBadRequestException : BadRequestException
    {
        public CollectionsByIdsBadRequestException() : base("Collection count mismatch comapring to ids")
        {

        }
    }
}
