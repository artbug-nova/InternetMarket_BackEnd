using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace InternetMarketBackEnd.Core.Domain.Entity
{
    [Serializable]
    public abstract class BaseEntity<TKey>: IEquatable<IEntity<TKey>>, IAggregateRoot
    {
        private TKey _Id;
        [Key]
        public virtual TKey Id
        {
            get
            {
                try
                {
                    return _Id;
                }
                catch(Exception err)
                {
                    throw new Exception("Error get Id", err);
                }
            }
            protected set
            {
                try
                {
                    _Id = value;
                }
                catch (Exception err)
                {
                    throw new Exception("Err set Id", err);
                }
            }
        }

        public virtual bool Equals(IEntity<TKey> other)
        {
            if(other == null)
                return false;
            return Id.Equals(other.Id);
        }
    }
}
