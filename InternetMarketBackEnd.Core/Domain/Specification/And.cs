﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace InternetMarketBackEnd.Core.Domain.Specification
{
    public class And<T> : SpecificationBase<T>
    {
        private ISpecification<T> left;
        private ISpecification<T> right;

        public And(ISpecification<T> left, ISpecification<T> right)
        {
            this.left = left;
            this.right = right;
        }


        public bool IsSatisfiedBy(ThreadStaticAttribute obj)
        {
            throw new NotImplementedException();
        }
        public override Expression<Func<T, bool>> SpecExpression
        {
            get
            {
                var objParam = Expression.Parameter(typeof(T), "obj");

                var newExpr = Expression.Lambda<Func<T, bool>>(
                    Expression.AndAlso(
                        Expression.Invoke(left.SpecExpression, objParam),
                        Expression.Invoke(right.SpecExpression, objParam)
                        ),
                    objParam);
                return newExpr;
                
            }
        }
    }
}
