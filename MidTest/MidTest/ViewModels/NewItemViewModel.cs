using MidTest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MidTest.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string navn;
        private string energi;
        private string tempo;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(navn)
                && !String.IsNullOrWhiteSpace(energi);
        }

        public string Navn
        {
            get => navn;
            set => SetProperty(ref navn, value);
        }
        public string Tempo
        {
            get => tempo;
            set => SetProperty(ref tempo, value);
        }
        public string Energi
        {
            get => energi;
            set => SetProperty(ref energi, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Navn = Navn,
                Energi = Energi,
                Tempo = Tempo
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
