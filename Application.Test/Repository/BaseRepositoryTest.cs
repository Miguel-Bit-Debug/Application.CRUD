using Domain.Interfaces;
using Infra.Data.Data;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Test.Repository
{
    public abstract class BaseRepositoryTest
    {
        protected readonly IProductRepository _productRepository;
    }
}
