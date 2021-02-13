using System;
using Xamarin.Forms;

namespace MidheimCombatHelper
{
    public partial class MainPage : ContentPage
    {
        public int attackCount = 0;
        public int energiCost = 0;

        public int mainHandEnergiCost;
        public int mainHandTempoCost;

        Weapons mainHandWep;
        Weapons offHandWep;

        Weapons activeWep;


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
            mainHandRadio.IsChecked = true;


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
            tempoSlider.Value = int.Parse(maxTempo.Text);
        }



        private void Angreb(object sender, EventArgs e)
        {
            if (activeWep == null)
            {
                activeWep = mainHandWep;
            }
            if (energiSlider.Value >= activeWep.GetEnergiCost() + attackCount && tempoSlider.Value >= activeWep.GetTempoCost())
            {
                energiSlider.Value -= activeWep.GetEnergiCost() + attackCount;
                tempoSlider.Value -= activeWep.GetTempoCost();
                AlternateAttack();
            }
            else
            {
                DisplayAlert("Ikke nok energi/tempo", "Du kan ikke angribe mere,bro", "OK, bro");
            }
        }

        private void StyrketAngreb(object sender, EventArgs e)
        {
            if (activeWep == null)
            {
                activeWep = mainHandWep;
            }
            if (energiSlider.Value >= activeWep.GetEnergiCost() + attackCount + 1 && tempoSlider.Value >= activeWep.GetTempoCost() && energiSlider.Value >= 8)
            {
                energiSlider.Value -= activeWep.GetEnergiCost() + attackCount + 1;
                tempoSlider.Value -= activeWep.GetTempoCost();
                AlternateAttack();
            }
            else
            {
                DisplayAlert("Ikke nok energi/tempo", "Du kan ikke angribe mere,bro", "OK, bro");
            }
        }

        private void DiscAngreb(object sender, EventArgs e)
        {
            if (activeWep == null)
            {
                activeWep = mainHandWep;
            }
            if (energiSlider.Value >= activeWep.GetEnergiCost() + attackCount && tempoSlider.Value >= activeWep.GetTempoCost() + 1 && fokusSlider.Value >= 1)
            {
                energiSlider.Value -= activeWep.GetEnergiCost() + attackCount;
                tempoSlider.Value -= activeWep.GetTempoCost() + 1; ;
                AlternateAttack();
            }
            else
            {
                DisplayAlert("Ikke nok energi/tempo", "Du kan ikke angribe mere,bro", "OK, bro");
            }
        }

        private void BrasendeAngreb(object sender, EventArgs e)
        {
            if (activeWep == null)
            {
                activeWep = mainHandWep;
            }
            if (energiSlider.Value >= activeWep.GetEnergiCost() + attackCount + 1 && tempoSlider.Value >= activeWep.GetTempoCost() + 1)
            {
                energiSlider.Value -= activeWep.GetEnergiCost() + attackCount + 1;
                tempoSlider.Value -= activeWep.GetTempoCost() + 1;
                AlternateAttack();
            }
            else
            {
                DisplayAlert("Ikke nok energi/tempo", "Du kan ikke angribe mere,bro", "OK, bro");
            }
        }

        private void DesperatAngreb(object sender, EventArgs e)
        {
            if (activeWep == null)
            {
                activeWep = mainHandWep;
            }
            if (energiSlider.Value >= activeWep.GetEnergiCost() + attackCount && tempoSlider.Value >= activeWep.GetTempoCost())
            {
                energiSlider.Value -= activeWep.GetEnergiCost() + attackCount;
                tempoSlider.Value -= activeWep.GetTempoCost();
                fokusSlider.Value -= 1;
                AlternateAttack();
            }
            else
            {
                DisplayAlert("Ikke nok energi/tempo", "Du kan ikke angribe mere,bro", "OK, bro");

            }
        }

        private void AlternateAttack()
        {
            if (offHandWep != null && alternateAttacks.IsToggled == true)
            {
                if (mainHandRadio.IsChecked)
                {
                    offHandRadio.IsChecked = true;
                    return;
                }
                if (offHandRadio.IsChecked)
                {
                    mainHandRadio.IsChecked = true;
                    return;
                }
            }
            else
            {
                attackCount++;
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


        private void KortVåben_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sender == kortVåben)
            {
                mainHandWep = new Weapons(1, 1);

            }
            else
            {
                offHandWep = new Weapons(1, 1);
            }

        }

        private void HåndVåben_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sender == håndVåben)
            {
                mainHandWep = new Weapons(2, 2);
            }
            else
            {
                offHandWep = new Weapons(2, 2);
            }
        }

        private void ToHånd_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            mainHandWep = new Weapons(3, 3);
            offHandToggle.IsToggled = false;
            //offHand.IsVisible = false;
            offHandRadio.IsVisible = false;
            offHandWep = null;

        }

        private void DecrementFokus(object sender, EventArgs e)
        {
            fokusSlider.Value -= 1;
        }

        private void IncrementFokus(object sender, EventArgs e)
        {
            fokusSlider.Value += 1;

        }

        private void MaxFokus_TextChanged(object sender, TextChangedEventArgs e)
        {
            fokusSlider.Maximum = int.Parse(maxFokus.Text);
            fokusSlider.Value = int.Parse(maxFokus.Text);
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (offHand.IsVisible == true)
            {
                offHand.IsVisible = false;
                offHandRadio.IsVisible = false;
                offHandWep = null;

            }
            else
            {
                offHand.IsVisible = true;
                offHandRadio.IsVisible = true;

            }

        }

        private void UseMain(object sender, CheckedChangedEventArgs e)
        {
            activeWep = mainHandWep;
        }

        private void UseOffHand(object sender, CheckedChangedEventArgs e)
        {
            activeWep = offHandWep;
        }

        private void mainHandToggle_Toggled(object sender, ToggledEventArgs e)
        {

        }
    }
}
