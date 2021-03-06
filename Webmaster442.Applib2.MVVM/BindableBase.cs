﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Webmaster442.Applib.Internals;

namespace Webmaster442.Applib
{
    /// <summary>
    /// A base class that implements the INotifyPropertyChanged interface, therefore making it simple to create
    /// View models and model classes
    /// </summary>
    public abstract class BindableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// <see cref="INotifyPropertyChanged.PropertyChanged"/>
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Fires the PropertyChanged event
        /// </summary>
        /// <param name="propertyName">property name</param>
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Fires the PropertyChanged event
        /// </summary>
        /// <param name="expression">Lambda expresion to get property</param>
        protected virtual void OnPropertyChanged(Expression<Func<object>> expression)
        {
            string propertyName = PropertyName.For(expression);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Simplifies property setting code
        /// </summary>
        /// <typeparam name="T">type of proprerty</typeparam>
        /// <param name="storage">private variable to store property value</param>
        /// <param name="value">new porperty value</param>
        /// <param name="propertyName">property name. Don't need to pass, uses caller member name</param>
        /// <returns>true, if property was set to new value</returns>
        protected virtual bool SetValue<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
