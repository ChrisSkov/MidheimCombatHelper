using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MidheimCombatHelper
{
    public partial class MainPage : ContentPage
    {
        public int attackCount = 0;
        public int energiCost = 0;

        public int mainHandEnergiCost;
        public int mainHandTempoCost;
        public MainPage()
        {
            InitializeComponent();

        }


        private void NyRunde(object sender, EventArgs e)
        {
            if (energiRegen.Text == null)
            {
                DisplayAlert("Ingen regen", "Du har ikke tastet din energi per runde", "OK");
            }
            energiSlider.Value += int.Parse(energiRegen.Text);
            tempoSlider.Value = int.Parse(maxTempo.Text);
            attackCount = 0;
        }

        private void MaxEnergi_TextChanged(object sender, TextChangedEventArgs e)
        {

            energiSlider.Maximum = int.Parse(maxEnergi.Text);
            energiSlider.Value = int.Parse(maxEnergi.Text);

        }



        void MaxHelbred_TextChanged(object sender, TextChangedEventArgs e)
        {
            helbredSlider.Maximum = int.Parse(maxHelbred.Text);
            helbredSlider.Value = int.Parse(maxHelbred.Text);
        }

        private void MaxTempo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (maxTempo.Text == null)
            {
                tempoSlider.Maximum = 9;
                DisplayAlert("Ingen tempo", "Indtast lige dit tempo, bro", "OK");

            }

            tempoSlider.Maximum = int.Parse(maxTempo.Text);
            tempoSlider.Value = int.Parse(maxEnergi.Text);
        }



        private void Angreb(object sender, EventArgs e)
        {
            if (energiSlider.Value >= mainHandEnergiCost + attackCount && tempoSlider.Value >= mainHandTempoCost)
            {
                energiSlider.Value -= mainHandEnergiCost + attackCount;
                tempoSlider.Value -= mainHandTempoCost;
                attackCount++;
            }
            else
            {
                DisplayAlert("Ikke nok energi/tempo", "Du kan ikke angribe mere,bro", "OK, bro");
            }
        }

        private void StyrketAngreb(object sender, EventArgs e)
        {
            if (energiSlider.Value >= mainHandEnergiCost + attackCount + 1 && tempoSlider.Value >= mainHandTempoCost && energiSlider.Value >= 8)
            {
                energiSlider.Value -= mainHandEnergiCost + attackCount + 1;
                tempoSlider.Value -= mainHandTempoCost;
                attackCount++;
            }
            else
            {
                DisplayAlert("Ikke nok energi/tempo", "Du kan ikke angribe mere,bro", "OK, bro");
            }
        }

        private void DiscAngreb(object sender, EventArgs e)
        {
            if (energiSlider.Value >= mainHandEnergiCost + attackCount && tempoSlider.Value >= mainHandTempoCost + 1)
            {
                energiSlider.Value -= mainHandEnergiCost + attackCount;
                tempoSlider.Value -= mainHandTempoCost + 1; ;
                attackCount++;
            }
            else
            {
                DisplayAlert("Ikke nok energi/tempo", "Du kan ikke angribe mere,bro", "OK, bro");
            }
        }

        private void BrasendeAngreb(object sender, EventArgs e)
        {
            if (energiSlider.Value >= mainHandEnergiCost + attackCount + 1 && tempoSlider.Value >= mainHandTempoCost + 1)
            {
                energiSlider.Value -= mainHandEnergiCost + attackCount + 1;
                tempoSlider.Value -= mainHandTempoCost + 1;
                attackCount++;
            }
            else
            {
                DisplayAlert("Ikke nok energi/tempo", "Du kan ikke angribe mere,bro", "OK, bro");
            }
        }

        private void DesperatAngreb(object sender, EventArgs e)
        {
            if (energiSlider.Value >= mainHandEnergiCost + attackCount && tempoSlider.Value >= mainHandTempoCost)
            {
                energiSlider.Value -= mainHandEnergiCost + attackCount;
                tempoSlider.Value -= mainHandTempoCost;
                attackCount++;
            }
            else
            {
                DisplayAlert("Ikke nok energi/tempo", "Du kan ikke angribe mere,bro", "OK, bro");

            }
        }

        private void DecrementEnergi(object sender, EventArgs e)
        {
            energiSlider.Value -= 1;
        }

        private void IncrementEnergi(object sender, EventArgs e)
        {
            energiSlider.Value += 1;

        }

        private void IncrementHelbred(object sender, EventArgs e)
        {
            helbredSlider.Value += 1;
        }

        private void DecrementHelbred(object sender, EventArgs e)
        {
            helbredSlider.Value -= 1;
        }

        private void DecrementTempo(object sender, EventArgs e)
        {
            tempoSlider.Value -= 1;
        }

        private void IncrementTempo(object sender, EventArgs e)
        {
            tempoSlider.Value += 1;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
        }

        private void Næver_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            mainHandEnergiCost = 1;
            mainHandTempoCost = 1;
        }

        private void KortVåben_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            mainHandEnergiCost = 1;
            mainHandTempoCost = 1;
        }

        private void HåndVåben_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            mainHandEnergiCost = 2;
            mainHandTempoCost = 2;
        }

        private void ToHånd_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            mainHandEnergiCost = 3;
            mainHandTempoCost = 3;
        }
    }
}
