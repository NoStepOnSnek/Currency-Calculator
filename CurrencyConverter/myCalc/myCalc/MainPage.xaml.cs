using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace myCalc
{
    public sealed partial class MainPage : Page
    {
        public struct Calculate
        {
            public string sourceCountry, targetCountry;
            public decimal amount, convertToRate, convertFromRate, convertedAmount;
            public int selectedIndexOrigin, selectedIndexTarget, hiddenIndexTo, hiddenIndexFrom;
        }

        public static Calculate currency = new Calculate();



        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            
                
        }

        public async void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            //Stores the index numbers of the Source and Target combo boxes
            currency.selectedIndexOrigin = convertFromComboBox.SelectedIndex;
            currency.hiddenIndexTo = currency.selectedIndexOrigin;
            hiddenCB.SelectedIndex = currency.hiddenIndexTo;

            currency.convertToRate = Convert.ToDecimal(hiddenCB.SelectedItem);
            
            //Convert To CB data
            currency.selectedIndexTarget = convertToComboBox.SelectedIndex;
            currency.hiddenIndexFrom = currency.selectedIndexTarget;
            hiddenCB2.SelectedIndex = currency.hiddenIndexFrom;

            currency.convertFromRate = Convert.ToDecimal(hiddenCB2.SelectedItem);

            //Stores the selected country of the Source and Target combo boxes
            currency.sourceCountry = Convert.ToString(convertFromComboBox.SelectedItem);
            currency.targetCountry = Convert.ToString(convertToComboBox.SelectedItem);


            try
            {
                currency.amount = Convert.ToDecimal(currencyAmountTextBox.Text);
            }
            catch (Exception ex)
            {
                ContentDialog noNumberDialog = new ContentDialog
                {
                    Title = "Incorrect Value in Field",
                    Content = "Enter a numeric value in the textbox.",
                    CloseButtonText = "Ok"
                };

                ContentDialogResult result = await noNumberDialog.ShowAsync();

                return;
            }

            SourceUS();
            TargetUS();
            NeitherUS();


            //Reads out the value, and Country it is from / for
            MediaElement mediaElement = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync(convertedAmountTextBlock.Text + currency.targetCountry);
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();

        }
        
        public decimal SourceUS()
        {

            if (currency.sourceCountry == "United States")
            {
                currency.convertedAmount = currency.amount * currency.convertFromRate;
                var roundedAmount = Math.Round(currency.convertedAmount, 2);

                convertedAmountTextBlock.Text = Convert.ToString(roundedAmount);
                return currency.convertedAmount;
            }
            else
            {
                return 0;
            }
        }

        public decimal TargetUS()
        {
            currency.amount = Convert.ToDecimal(currencyAmountTextBox.Text);

            if (currency.targetCountry == "United States")
            {
                currency.convertedAmount = currency.amount / currency.convertToRate;
                var roundedAmount = Math.Round(currency.convertedAmount, 2);

                convertedAmountTextBlock.Text = Convert.ToString(roundedAmount);
                return currency.convertedAmount;
            }
            else
            {
                return 0;
            }
        }

        public decimal NeitherUS()
        {
            currency.amount = Convert.ToDecimal(currencyAmountTextBox.Text);
            
            if (currency.targetCountry != "United States" && currency.sourceCountry != "United States")
            {
                currency.convertedAmount = (currency.amount / currency.convertToRate) * currency.convertFromRate;

                var roundedAmount = Math.Round(currency.convertedAmount, 2);

                convertedAmountTextBlock.Text = Convert.ToString(roundedAmount);
                return currency.convertedAmount;
            }
            else
            {
                return 0;
            }
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void convertFromComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }

        private void currencyAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //convertedAmountTextBlock.Text = "$" + Convert.ToString(formData.convertedTo);

        }

        private void convertToComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            convertFromComboBox.Items.Add("United States");
            convertFromComboBox.Items.Add("Canada");
            convertFromComboBox.Items.Add("Australia");
            convertFromComboBox.Items.Add("European Union");
            convertFromComboBox.Items.Add("Japan");

            convertToComboBox.Items.Add("United States");
            convertToComboBox.Items.Add("Canada");
            convertToComboBox.Items.Add("Australia");
            convertToComboBox.Items.Add("European Union");
            convertToComboBox.Items.Add("Japan");

            //These numbers are the values compared to USD value
            hiddenCB.Items.Add("1.00");
            hiddenCB.Items.Add("1.25");
            hiddenCB.Items.Add("1.27");
            hiddenCB.Items.Add("0.85");
            hiddenCB.Items.Add("109.56");

            hiddenCB2.Items.Add("1.00");
            hiddenCB2.Items.Add("1.25");
            hiddenCB2.Items.Add("1.27");
            hiddenCB2.Items.Add("0.85");
            hiddenCB2.Items.Add("109.10");


        }
    }


}

