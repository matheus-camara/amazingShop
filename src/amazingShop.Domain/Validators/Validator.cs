using amazingShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace amazingShop.Domain.Validators
{
    public sealed class Validator<T> where T : EntityBase
    {
        private ICollection<IRule<T>> _rules;

        private T _target;

        private Validator(T target, ICollection<IRule<T>> rules)
        {
            _rules = rules;
            _target = target;
        }

        public static Validator<T> For(T target) => new Validator<T>(target, new List<IRule<T>>());

        public Validator<T> Add(Rule<T> rule)
        {
            if (!_rules.Contains(rule))
                _rules.Add(rule);

            return this;
        }

        public Validator<T> Add(Func<T, bool> action) => Add(new Rule<T>(action));

        public bool Run() => _rules.All(r => r.ApplyTo(_target));

    }
}
