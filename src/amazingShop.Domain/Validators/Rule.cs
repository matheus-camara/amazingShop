using System;
using amazingShop.Domain.Entities;

namespace amazingShop.Domain.Validators
{
    public class Rule<T> : IRule<T> where T : EntityBase
    {
        private Func<T, bool> _function;

        protected Rule() { }

        public Rule(Func<T, bool> function) => _function = function;

        public virtual bool ApplyTo(T target) => _function.Invoke(target);
  }
}