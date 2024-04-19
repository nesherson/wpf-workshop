﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace WPF.Tesetto.Word.ValueConverters
{
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        private static T _converter = null;

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        public override object ProvideValue(IServiceProvider serviceProvider) => _converter ?? (_converter = new T());

    }
}
