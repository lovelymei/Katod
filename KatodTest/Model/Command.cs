using System;
using System.Windows.Input;

namespace Katod
{
    /// <summary>
    /// Реалзация интерфейса ICommand
    /// </summary>
	public class Command : ICommand
    {
        /// <inheritdoc/>
        private Action<object> execute;
        
        /// <inheritdoc/>
        private Func<object, bool> canExecute;

        /// <inheritdoc/>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Конструктор класса Command
        /// </summary>
        /// <param name="execute"> выполнение команды </param>
        /// <param name="canExecute">может ли выполняться команда</param>
        public Command(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <inheritdoc/>
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }
        /// <inheritdoc/>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
