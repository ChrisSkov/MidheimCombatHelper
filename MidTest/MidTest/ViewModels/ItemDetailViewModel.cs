using MidTest.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MidTest.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string navn;
        private string energi;
        private string tempo;
        public string Id { get; set; }

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

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Navn = item.Navn;
                Energi = item.Energi;
                Tempo = item.Tempo;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
