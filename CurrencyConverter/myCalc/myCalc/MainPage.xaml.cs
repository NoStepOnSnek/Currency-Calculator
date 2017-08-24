using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
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

        
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            
                
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            //Left off here
            //var combo = sender as convertFromComboBox;
            var selectedItem = convertFromComboBox.SelectedIndex;
            var hiddenIndex = selectedItem;

            hiddenCB.SelectedIndex = hiddenIndex;

            string sourceCountry = Convert.ToString(convertFromComboBox.SelectedItem);
            decimal conversionRate = Convert.ToDecimal(hiddenCB.SelectedItem);

            convertedAmountTextBlock.Text = Convert.ToString(sourceCountry);


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
            hiddenCB.Items.Add("1.28");
            hiddenCB.Items.Add("1.27");
            hiddenCB.Items.Add("0.85");
            hiddenCB.Items.Add("109.00");


        }
    }


}

