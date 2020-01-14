using amazingShop.Domain.Core.Notifications;
using System.Collections.Generic;

namespace amazingShop.Domain.Core.Validators
{
    public class Validator<T> where T : Notifiable
    {
        private ICollection<IRule<T>> _rules;

        private T _target;

        private Validator(T target, ICollection<IRule<T>> rules)
        {
            _rules = rules;
            _target = target;
        }

        public static Validator<T> For(T target) => new Validator<T>(target, new List<IRule<T>>());

        public void Add(IRule<T> rule)
        {
            if (!_rules.Contains(rule))
                _rules.Add(rule);
        }

        public bool Run()
        { 
            foreach(var rule in _rules)
            {
                rule.ApplyTo(_target);
            }

            return _target.HasNotification;
        }
    }
}
