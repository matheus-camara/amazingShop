using amazingShop.Domain.Core.Notifications;

namespace amazingShop.Domain.Core.Validators
{
	public abstract class Rule<T> : IRule<T> where T : class
	{
		private Notification[] _notifications;

		protected Notification[] Notifications
		{
			get
			{
				if (_notifications is null)
					_notifications = new Notification[0];

				return _notifications;
			}

		}

		public Rule(params Notification[] notifications)
		{
			_notifications = notifications;
		}

		public abstract bool ApplyTo(T target);
	}
}