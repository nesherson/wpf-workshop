using System;
using System.Windows;
using System.Windows.Controls;

namespace WPF.Tesetto.Word
{
    public class PasswordBoxAttachedProperties
    {
        public static readonly DependencyProperty MonitorPasswordProperty = DependencyProperty
            .RegisterAttached(
            "MonitorPassword",
            typeof(bool),
            typeof(PasswordBoxAttachedProperties),
            new PropertyMetadata(false, OnMonitorPasswordChanged));

        private static void OnMonitorPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static void SetMonitorPassword(PasswordBox element, bool value)
        {
            element.SetValue(MonitorPasswordProperty, value);
        }

        public static bool GetMonitorPassword(PasswordBox element)
        {
            return (bool)element.GetValue(MonitorPasswordProperty);
        }

        public static readonly DependencyProperty HasTextProperty = DependencyProperty
            .RegisterAttached(
            "HasText",
            typeof(bool),
            typeof(PasswordBoxAttachedProperties),
            new PropertyMetadata(false));

        private static void SetHasText(PasswordBox element)
        {
            element.SetValue(HasTextProperty, element.SecurePassword.Length > 0);
        }

        public static bool GetHasText(PasswordBox element)
        {
            return (bool)element.GetValue(HasTextProperty);
        }
    }
}
