/*
* FILE : RelayCommand.cs
* PROJECT : PROG2121 - A05
* PROGRAMMER : Microsoft Community
* MODIFIED BY: Jaden Dixon-Schulz
* FIRST VERSION : 2023-11-19
*/
using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace TMS.Commands
{   /*
    * NAME : RelayCommand : ICommand
    * DESCRIPTION: This class simplifies the process of command binding. It is modified
    * from open source code inside the Microsoft Community MVVM .NET Toolkit, found
    * https://github.com/CommunityToolkit/dotnet/blob/main/src/CommunityToolkit.Mvvm/Input/RelayCommand.cs
    * https://github.com/CommunityToolkit/dotnet/blob/main/src/CommunityToolkit.Mvvm/Input/RelayCommand%7BT%7D.cs
    */
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> execute = null;
        private readonly Func<T, bool> canExecute = null;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<T> execute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
            this.execute = execute;
        }

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
            if (canExecute == null)
            {
                throw new ArgumentNullException(nameof(canExecute));
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(T? parameter)
        {
            return canExecute?.Invoke(parameter) != false;
        }

        public bool CanExecute(object? parameter)
        {
            // Special case a null value for a value type argument type.
            // This ensures that no exceptions are thrown during initialization.
            if (parameter is null && default(T) is not null)
            {
                return false;
            }

            if (!TryGetCommandArgument(parameter, out T? result))
            {
                ThrowArgumentExceptionForInvalidCommandArgument(parameter);
            }

            return CanExecute(result);
        }

        public void Execute(T? parameter)
        {
            execute(parameter);
        }

        /// <inheritdoc/>
        public void Execute(object? parameter)
        {
            if (!TryGetCommandArgument(parameter, out T? result))
            {
                ThrowArgumentExceptionForInvalidCommandArgument(parameter);
            }

            Execute(result);
        }

        public static bool TryGetCommandArgument(object? parameter, out T? result)
        {
            // If the argument is null and the default value of T is also null, then the
            // argument is valid. T might be a reference type or a nullable value type.
            if (parameter is null && default(T) is null)
            {
                result = default;

                return true;
            }

            // Check if the argument is a T value, so either an instance of a type or a derived
            // type of T is a reference type, an interface implementation if T is an interface,
            // or a boxed value type in case T was a value type.
            if (parameter is T argument)
            {
                result = argument;

                return true;
            }

            result = default;

            return false;
        }

        public static void ThrowArgumentExceptionForInvalidCommandArgument(object? parameter)
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            static Exception GetException(object? parameter)
            {
                if (parameter is null)
                {
                    return new ArgumentException($"Parameter \"{nameof(parameter)}\" (object) must not be null, as the command type requires an argument of type {typeof(T)}.", nameof(parameter));
                }

                return new ArgumentException($"Parameter \"{nameof(parameter)}\" (object) cannot be of type {parameter.GetType()}, as the command type requires an argument of type {typeof(T)}.", nameof(parameter));
            }

            throw GetException(parameter);
        }
    }

    public class RelayCommand : RelayCommand<object>
    {
        public RelayCommand(Action execute)
            : base(_ => execute()) { }

        public RelayCommand(Action execute, Func<bool> canExecute)
            : base(_ => execute(), _ => canExecute()) { }
    }
}