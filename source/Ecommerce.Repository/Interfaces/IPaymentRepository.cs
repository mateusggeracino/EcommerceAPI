using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Interfaces
{
    public interface IPaymentRepository : IRepository<Payments>
    {
        void Updatestatus(Payments obj,int status);
    }
}
