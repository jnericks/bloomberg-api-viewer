using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace bbapi.UI.ViewModels
{
    public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        IDictionary<string, Action> _onPropertyChangedActions = new Dictionary<string, Action>();
        ICollection<Action<string>> _onAnyPropertyChangedActions = new List<Action<string>>();

        protected void RegisterActionOnPropertyChanged<T>(Expression<Func<T>> propertyExpression, Action action)
        {
            var propertyName = PropertyInfo(propertyExpression).Name;

            if (!_onPropertyChangedActions.ContainsKey(propertyName))
                _onPropertyChangedActions.Add(propertyName, action);
            else
                _onPropertyChangedActions[propertyName] += action;
        }

        protected void RegisterActionOnAnyPropertyChanged(Action<string> action)
        {
            _onAnyPropertyChangedActions.Add(action);
        }

        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var propertyInfo = PropertyInfo(propertyExpression);

            RaisePropertyChanged(propertyInfo);

            var propertyName = propertyInfo.Name;
            if (_onPropertyChangedActions.ContainsKey(propertyName))
                _onPropertyChangedActions[propertyName].Invoke();

            foreach (var action in _onAnyPropertyChangedActions)
                action(propertyName);
        }

        protected PropertyInfo PropertyInfo<T>(Expression<Func<T>> propertyExpression)
        {
            var lambda = (LambdaExpression)propertyExpression;

            var memberExpression = lambda.Body is UnaryExpression
                                       ? ((UnaryExpression)lambda.Body).Operand as MemberExpression
                                       : lambda.Body as MemberExpression;

            if (memberExpression == null)
                throw new ArgumentException(@"Property does not represent a UnaryExpression or MemberExpression.");

            var propertyInfo = memberExpression.Member as PropertyInfo;
            if (propertyInfo == null)
                throw new ArgumentException(@"UnaryExpression or MemberExpression does not represent a PropertyInfo.");

            return propertyInfo;
        }

        protected virtual void RaisePropertyChanged(PropertyInfo propertyInfo)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyInfo.Name));
        }
    }
}