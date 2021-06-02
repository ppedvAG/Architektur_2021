using ppedv.Cooky.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ppedv.Cooky.UI.WPF.ViewModels
{
    public class SaveCommand : ICommand
    {
        private readonly Core core;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public SaveCommand(Core core)
        {
            this.core = core;
        }

        public void Execute(object parameter)
        {
            core.UnitOfWork.SaveAll();
        }
    }
}
