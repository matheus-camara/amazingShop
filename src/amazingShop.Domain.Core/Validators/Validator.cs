using System.Collections.Generic;
using System.Linq;

namespace amazingShop.Domain.Core.Validators
{
    public sealed class Validator<T> where T : class
    {
        private readonly ICollection<IRule<T>> _rules = new List<IRule<T>>();

        private T _target;

        public Validator(T target) => _target = target;

        public Validator<T> Add(IRule<T> rule)
        {
            _rules.Add(rule);
            return this;
        }

        public void Run()
        {
            foreach (var rule in _rules)
                rule.ApplyTo(_target);
        }
    }
}