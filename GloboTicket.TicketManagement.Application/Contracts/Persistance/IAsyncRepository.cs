﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Contracts.Persistance
{
    public interface IAsyncRepository<T> where T : class
    {

        Task<T> GetByIdAsync(Guid Id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
