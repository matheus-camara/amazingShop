using System.Collections.Generic;
using System.Linq;

namespace amazingShop.Domain.Core.Validators
{
    public sealed class Validator<T> where T : class
    {
        private ICollection<IRule<T>> _rules;

        private T _target;

        public Validator(T target)
        {
            _target = target;
            _rules = new List<IRule<T>>();
        }

        public Validator<T> Add(IRule<T> rule)
        {
            _rules.Add(rule);
            return this;
        }

        public bool Run() => _rules.All(r => r.ApplyTo(_target));
    }
}