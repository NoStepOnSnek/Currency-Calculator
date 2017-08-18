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

        public struct conversions
        {
            public decimal convertAmount, convertedTo;
            //Conversion Factors
            public decimal USDtoCAD, USDtoMXN, USDtoEUR, USDtoJPY, conversionFactor;
            public decimal CADtoUSD, CADtoMXN, CADtoEUR, CADtoJPY;
            public decimal MXNtoUSD, MXNtoCAD, MXNtoEUR, MXNtoJPY;
            public decimal EURtoUSD, EURtoCAD, EURtoMXN, EURtoJPY;
            public decimal JPYtoUSD, JPYtoCAD, JPYtoEUR, JPYtoMXN;

            public string currencyConverted;

        }

        public static conversions formData = new conversions();

        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            
                convertFromComboBox.Items.Add("USD");
                convertFromComboBox.Items.Add("CAD");
                convertFromComboBox.Items.Add("MXN");
                convertFromComboBox.Items.Add("EUR");
                convertFromComboBox.Items.Add("JPY");

                convertToComboBox.Items.Add("USD");
                convertToComboBox.Items.Add("CAD");
                convertToComboBox.Items.Add("MXN");
                convertToComboBox.Items.Add("EUR");
                convertToComboBox.Items.Add("JPY");
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
          //Conversions
            formData.USDtoCAD = 1 / 1.26m;//USD to CAD
            formData.USDtoMXN = 1 / 17.72m;//USD to MXN
            formData.USDtoEUR = 1m / (.85m);//USD to EUR
            formData.USDtoJPY = 1m / (109.70m);//USD to JPY
            
            formData.CADtoUSD = 1m / (.787m);//CAD to USD
            formData.CADtoMXN = 1 / (14.10m);//CAD to MXN
            formData.CADtoEUR = 1 / (.67m);//CAD to EUR
            formData.CADtoJPY = 1 / (86.25m);//CAD toJPY

            formData.MXNtoUSD = 1 / (.056m);//MXN to USD
            formData.MXNtoCAD = 1 / (.071m);//MXN to CAD
            formData.MXNtoEUR = 1 / (.048m);//MXN to EUR
            formData.MXNtoJPY = 1 / (6.12m);//MXN to JPY

            formData.EURtoUSD = 1 / (1.17m);//EUR to USD
            formData.EURtoCAD = 1 / (1.49m);//EUR to CAD
            formData.EURtoMXN = 1 / (20.97m);//EUR to MXN
            formData.EURtoJPY = 1 / (128.32m);//EUR to JPY

            formData.JPYtoUSD = 1 / (.0091m);//JPY to USD
            formData.JPYtoCAD = 1 / (.012m);//JPY to CAD
            formData.JPYtoMXN = 1 / (.16m);//JPY to MXN
            formData.JPYtoEUR = 1 / (.0078m);//JPY to EUR
            
            formData.convertAmount = Convert.ToDecimal(currencyAmountTextBox.Text);



            if(convertFromComboBox.SelectedItem.ToString() == "USD" && convertToComboBox.SelectedItem.ToString() == "CAD")
            {
                formData.conversionFactor = formData.USDtoCAD;

                formData.convertedTo = Convert.ToDecimal(currencyAmountTextBox.Text) * formData.conversionFactor;

                convertedAmountTextBlock.Text = "$" + Convert.ToString(formData.convertedTo);
            }

            else if (convertFromComboBox.SelectedItem.ToString() == "USD" && convertToComboBox.SelectedItem.ToString() == "MXN")
            {
                formData.conversionFactor = formData.USDtoMXN;

                formData.convertedTo = Convert.ToDecimal(currencyAmountTextBox.Text) * formData.conversionFactor;

                convertedAmountTextBlock.Text = "$" + Convert.ToString(formData.convertedTo);
            }

            else if (convertFromComboBox.SelectedItem.ToString() == "USD" && convertToComboBox.SelectedItem.ToString() == "EUR")
            {
                formData.conversionFactor = formData.USDtoEUR;

                formData.convertedTo = Convert.ToDecimal(currencyAmountTextBox.Text) * formData.conversionFactor;

                convertedAmountTextBlock.Text = "€" + Convert.ToString(formData.convertedTo);
            }

            else if (convertFromComboBox.SelectedItem.ToString() == "USD" && convertToComboBox.SelectedItem.ToString() == "JPY")
            {
                formData.conversionFactor = formData.USDtoJPY;

                formData.convertedTo = Convert.ToDecimal(currencyAmountTextBox.Text) * formData.conversionFactor;

                convertedAmountTextBlock.Text = "¥" + Convert.ToString(formData.convertedTo);
            }

            else if (convertFromComboBox.SelectedItem.ToString() == "CAD" && convertToComboBox.SelectedItem.ToString() == "USD")
            {
                formData.conversionFactor = formData.CADtoUSD;

                formData.convertedTo = Convert.ToDecimal(currencyAmountTextBox.Text) * formData.conversionFactor;

                convertedAmountTextBlock.Text = "$" + Convert.ToString(formData.convertedTo);
            }
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void convertFromComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            convertFromComboBox.Items.Add("USD");
            convertFromComboBox.Items.Add("CAD");
            convertFromComboBox.Items.Add("MXN");
            convertFromComboBox.Items.Add("EUR");
            convertFromComboBox.Items.Add("JPY");



        }

        private void currencyAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //convertedAmountTextBlock.Text = "$" + Convert.ToString(formData.convertedTo);

        }

        private void convertToComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            convertToComboBox.Items.Add("USD");
            convertToComboBox.Items.Add("CAD");
            convertToComboBox.Items.Add("MXN");
            convertToComboBox.Items.Add("EUR");
            convertToComboBox.Items.Add("JPY");
        }
    }
}

