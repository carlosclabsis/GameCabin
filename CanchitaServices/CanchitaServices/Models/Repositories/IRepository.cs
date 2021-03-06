﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanchitaServices.Models.Repositories
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> Items { get; }
        Task Save(TEntity item);
        Task Delete(Guid itemId);
    }
}
