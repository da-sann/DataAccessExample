﻿using System;
using System.Linq.Expressions;

namespace DataAccessExample.Helpers
{
    public static class ExpressionHelper
    {
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
                                                      Expression<Func<T, bool>> expr2)
        {
            return Expression.Lambda<Func<T, bool>>(
                Expression.OrElse(
                    new SwapVisitor(expr1.Parameters[0], expr2.Parameters[0]).Visit(expr1.Body),
                    expr2.Body
                ), expr2.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
                                                             Expression<Func<T, bool>> expr2)
        {
            return Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(
                    new SwapVisitor(expr1.Parameters[0], expr2.Parameters[0]).Visit(expr1.Body),
                    expr2.Body
                ), expr2.Parameters);
        }

        public static Expression GetProperty(this Expression obj, string property)
        {
            if (property.Contains("."))
            {
                var index = property.IndexOf(".");
                var propertName = property.Substring(0, index);
                property = property.Substring(index + 1);
                return GetProperty(Expression.PropertyOrField(obj, propertName), property);
            }
            return Expression.PropertyOrField(obj, property);
        }

        public static Expression<Func<TResult, bool>> Convert<TSource, TResult>(this Expression<Func<TSource, bool>> expr1,
          Expression<Func<TResult, TSource>> selector)
        {

            return Expression.Lambda<Func<TResult, bool>>(
                new ParameterTypeVisitor<TSource, TResult>(selector).Visit(expr1.Body),
                selector.Parameters
            );
        }
    }
}
