using InternetMarketBackEnd.Core.Domain;
using InternetMarketBackEnd.Core.Domain.Entity;
using InternetMarketBackEnd.Core.Domain.Repository;
using InternetMarketBackEnd.Core.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetMarketBackEnd.Domain.Services.Common
{
    public class WriteOnlyService<TEntity> : IWriteOnlyService<TEntity> where TEntity : IAggregateRoot, new()
    {
        private readonly IWriteOnlyRepository<TEntity> _writeOnlyRepository;
        private readonly ValidationResult _validationResult;

        public WriteOnlyService(IWriteOnlyRepository<TEntity> writeOnlyRepository)
        {
            if (writeOnlyRepository == null)
                throw new ArgumentNullException("writeOnlyService");

            _writeOnlyRepository = writeOnlyRepository;

            _validationResult = new ValidationResult();
        }

        protected IWriteOnlyRepository<TEntity> WriteOnlyRepository
        {
            get { return _writeOnlyRepository; }
        }

        protected ValidationResult ValidationResult
        {
            get { return _validationResult; }
        }


        public ValidationResult Add(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            _writeOnlyRepository.Add(entity);

            return ValidationResult;
        }

        public ValidationResult Add(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        ~WriteOnlyService()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _writeOnlyRepository.Dispose();
                GC.SuppressFinalize(this);
            }
        }

        public ValidationResult Remove(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            _writeOnlyRepository.Remove(entity);

            return ValidationResult;
        }

        public ValidationResult Remove(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Update(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            _writeOnlyRepository.Update(entity);

            return ValidationResult;
        }

        public ValidationResult Update(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
