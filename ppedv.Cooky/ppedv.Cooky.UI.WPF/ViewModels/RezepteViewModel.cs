using GalaSoft.MvvmLight.Command;
using ppedv.Cooky.Logic;
using ppedv.Cooky.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ppedv.Cooky.UI.WPF.ViewModels
{
    public class RezepteViewModel : INotifyPropertyChanged
    {
        Core core = new Core();
        private Rezept selectedRezept;

        public event PropertyChangedEventHandler PropertyChanged;

        public SaveCommand SaveCommand { get; set; }

        public ICommand SaveCommandInCool { get; set; }
        public ICommand AddCommand { get; set; }

        public ObservableCollection<Rezept> RezepteListe { get; set; } = new ObservableCollection<Rezept>();

        public Rezept SelectedRezept
        {
            get => selectedRezept;
            set
            {
                selectedRezept = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedRezept)));
            }
        }

        public RezepteViewModel()
        {
            RezepteListe = new ObservableCollection<Rezept>(core.UnitOfWork.RezeptRepository.GetAllRezepteWithZuaten());

            SaveCommand = new SaveCommand(core);

            SaveCommandInCool = new RelayCommand(() => core.UnitOfWork.SaveAll());
            AddCommand = new RelayCommand(UserWantsToAddNewRezept);
        }

        private void UserWantsToAddNewRezept()
        {
            var rez = new Rezept() { Name = "NEU WPF Rezept" };
            core.UnitOfWork.RezeptRepository.Add(rez);
            RezepteListe.Add(rez);
            SelectedRezept = rez;
        }
    }
}
