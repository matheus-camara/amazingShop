using System;
using amazingShop.Domain.Core.Notifications;

namespace amazingShop.Domain.Core.Validators
{
    public class Rule<T> : IRule<T> where T : INotifiable
    {
        private Func<T, bool> _function;

        protected Rule() { }

        public Rule(Func<T, bool> function) => _function = function;

        public virtual bool ApplyTo(T target) => _function.Invoke(target);
  }
}