using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Core.Data
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
