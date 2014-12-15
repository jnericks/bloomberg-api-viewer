using System;
using System.Windows;
using bbapi.Infrastructure;
using bbapi.UI.ViewModels;

namespace bbapi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ICanSubmitBloombergRequest _bloomberg;

        public BloombergViewModel Model
        {
            get { return (BloombergViewModel)DataContext; }
            private set { DataContext = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            Model = new DefaultBloombergViewModel();
            _bloomberg = new Bloomberg();
            App.Log += x => Model.Log += x; // set up global exception logger
        }

        void ClearLog()
        {
            Model.Log = string.Empty;
        }

        void SubmitReferenceDataRequest(object sender, RoutedEventArgs e)
        {
            if (ShouldClearCheckBox.IsChecked == true) ClearLog();

            var request = new ReferenceDataRequest(Model.GetReferenceSecurities(), Model.GetReferenceFields());
            
            if (Model.StartDateReference.HasValue && Model.EndDateReference.HasValue)
            {
                request.AddOverride("CUST_TRR_START_DT", Model.StartDateReference.Value);
                request.AddOverride("CUST_TRR_END_DT", Model.EndDateReference.Value);
            }

            if (!string.IsNullOrWhiteSpace(Model.CurrencyCodeReference))
            {
                request.AddOverride("CUST_TRR_CRNCY", Model.CurrencyCodeReference);
            }

            var response = _bloomberg.SubmitRequest(request);
            Model.Log += response + Environment.NewLine + Environment.NewLine;
        }

        void SubmitHistoricalDataRequest(object sender, RoutedEventArgs e)
        {
            if (ShouldClearCheckBox.IsChecked == true) ClearLog();

            var request = new HistoricalDataRequest(Model.GetHistoricalSecurities(), Model.GetHistoricalFields(), Model.StartDateHistorical, Model.EndDateHistorical, Model.Periodicity.ToString().ToUpper(), Model.CurrencyCodeHistorical);
            var response = _bloomberg.SubmitRequest(request);
            Model.Log += response + Environment.NewLine + Environment.NewLine;
        }

        void ClearStartDateReference(object sender, RoutedEventArgs e)
        {
            Model.StartDateReference = null;
        }

        void ClearEndDateReference(object sender, RoutedEventArgs e)
        {
            Model.EndDateReference = null;
        }
    }
}
