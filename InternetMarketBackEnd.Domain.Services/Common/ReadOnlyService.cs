using InternetMarketBackEnd.Core.Domain.Repository;
using InternetMarketBackEnd.Core.Domain.Service;
using InternetMarketBackEnd.Core.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InternetMarketBackEnd.Domain.Services.Common
{
    public class ReadOnlyService<TEntity> : IReadOnlyService<TEntity> where TEntity : class, new()
    {

        private readonly IReadOnlyRepository<TEntity> _readOnlyRepository;

        public ReadOnlyService(IReadOnlyRepository<TEntity> readOnlyRepository)
        {
            if (readOnlyRepository == null)
                throw new ArgumentNullException("readOnlyRepository");
            _readOnlyRepository = readOnlyRepository;
        }


        protected IReadOnlyRepository<TEntity> ReadOnlyRepository
        {
            get { return _readOnlyRepository; }
        }

        

        public void Dispose()
        {
            Dispose(true);
        }

        ~ReadOnlyService()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _readOnlyRepository.Dispose();
                GC.SuppressFinalize(this);
            }
        }


        public IQueryable<TEntity> FilterBy(ISpecification<TEntity> spec)
        {
            return _readOnlyRepository.FilterBy(spec);
        }

        public TEntity FindBy(ISpecification<TEntity> spec)
        {
            return _readOnlyRepository.FindBy(spec);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _readOnlyRepository.GetAll();
        }

        public TEntity GetById(object id)
        {
            return _readOnlyRepository.GetById(id);
        }
    }
}
