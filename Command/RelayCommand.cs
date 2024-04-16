﻿using System;
using System.Windows.Input;

namespace WPF.Workshop
{
    public class RelayCommand : ICommand
    {
        private Action _action;
        public RelayCommand(Action action)
        {
            _action = action;
        }

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            _action();
        }
    }
}
