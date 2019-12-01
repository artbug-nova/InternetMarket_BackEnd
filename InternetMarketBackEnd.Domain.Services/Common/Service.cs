using InternetMarketBackEnd.Core.Domain;
using InternetMarketBackEnd.Core.Domain.Entity;

using InternetMarketBackEnd.Core.Domain.Service;
using InternetMarketBackEnd.Core.Domain.Specification;
using InternetMarketBackEnd.Infra.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InternetMarketBackEnd.Domain.Services.Common
{
    public class Service<TEntity> : IService<TEntity> where TEntity : IAggregateRoot, new()
    {

        private readonly IRepository<TEntity> _repository;
        private readonly ValidationResult _validationResult;

        public Service(IRepository<TEntity> repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            _repository = repository;
            _validationResult = new ValidationResult();
        }

        protected IRepository<TEntity> Repository
        {
            get { return _repository; }
        }

        protected ValidationResult ValidationResult
        {
            get { return _validationResult; }
        }


        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_repository.Dispose();
                GC.SuppressFinalize(this);
            }
        }

        ~Service()
        {
            Dispose(false);
        }

        public IQueryable<TEntity> FilterBy(ISpecification<TEntity> spec, bool @readonly = false)
        {
            throw new NotImplementedException();
            //return _repository.FilterBy(spec, @readonly);
        }

        public TEntity FindBy(ISpecification<TEntity> spec, bool @readonly = false)
        {
            throw new NotImplementedException();
            //return _repository.FindBy(spec, @readonly);
        }

        public IQueryable<TEntity> GetAll(bool @readonly = false)
        {
            throw new NotImplementedException();
            //return _repository.GetAll(@readonly);
        }

        public TEntity GetById(object id, bool @readonly = false)
        {
            throw new NotImplementedException();
            //return TEntity;//_repository.GetById(id, @readonly);
        }

        #region CRUD
        public virtual ValidationResult Add(TEntity entity)
        {
            /*if (ValidationResult.IsValid)
                return ValidationResult;*/

            //_repository.Add(entity);
            _repository.Add(entity);
            //_repository.AddAsync(entity);
            return _validationResult;
        }

        public virtual ValidationResult Add(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public virtual ValidationResult Update(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            //_repository.Update(entity);

            return _validationResult;
        }

        public virtual ValidationResult Update(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
        public virtual ValidationResult Remove(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;
            //_repository.Remove(entity);

            return ValidationResult;
        }

        public virtual ValidationResult Remove(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
