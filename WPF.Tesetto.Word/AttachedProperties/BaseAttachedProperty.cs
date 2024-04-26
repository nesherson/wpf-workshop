using System;
using System.Windows;

namespace WPF.Tesetto.Word
{
    public abstract class BaseAttachedProperty<TParent, TProperty>
        where TParent : BaseAttachedProperty<TParent, TProperty>, new()
    {
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        public static TParent Instance { get; private set; } = new TParent();

        public static DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value",
            typeof(TProperty),
            typeof(BaseAttachedProperty<TParent, TProperty>),
            new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));

        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Instance.OnValueChanged(d, e);
            Instance.ValueChanged(d, e);
        }

        public static TProperty GetValue(DependencyObject d) =>
            (TProperty)d.GetValue(ValueProperty);

        public static void SetValue(DependencyObject d, TProperty value)
            => d.SetValue(ValueProperty, value);

        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        { }
    }
}