using System;
using System.Linq;
using bbapi.UI.Enums;

namespace bbapi.UI.ViewModels
{
    public class BloombergViewModel : NotifyPropertyChangedBase
    {
        // Reference Data Request

        string _referenceSecurities;
        public string ReferenceSecurities
        {
            get { return _referenceSecurities; }
            set
            {
                if (value == _referenceSecurities) return;
                _referenceSecurities = value.ToUpper();
                RaisePropertyChanged(() => ReferenceSecurities);
            }
        }

        SecurityDatabase _referenceSecurityDatabase;
        public SecurityDatabase ReferenceSecurityDatabase
        {
            get { return _referenceSecurityDatabase; }
            set
            {
                if (value == _referenceSecurityDatabase) return;
                _referenceSecurityDatabase = value;
                RaisePropertyChanged(() => ReferenceSecurityDatabase);
            }
        }

        string _referenceFields;
        public string ReferenceFields
        {
            get { return _referenceFields; }
            set
            {
                if (value == _referenceFields) return;
                _referenceFields = value;
                RaisePropertyChanged(() => ReferenceFields);
            }
        }

        DateTime? _startDateReference;
        public DateTime? StartDateReference
        {
            get { return _startDateReference; }
            set
            {
                if (value == _startDateReference) return;
                _startDateReference = value;
                RaisePropertyChanged(() => StartDateReference);
            }
        }

        DateTime? _endDateReference;
        public DateTime? EndDateReference
        {
            get { return _endDateReference; }
            set
            {
                if (value == _endDateReference) return;
                _endDateReference = value;
                RaisePropertyChanged(() => EndDateReference);
            }
        }

        string _currencyCodeReference;
        public string CurrencyCodeReference
        {
            get { return _currencyCodeReference; }
            protected set
            {
                if (value == _currencyCodeReference) return;
                _currencyCodeReference = value;
                RaisePropertyChanged(() => CurrencyCodeReference);
            }
        }

        // Historical Data Request

        string _historicalSecurities;
        public string HistoricalSecurities
        {
            get { return _historicalSecurities; }
            set
            {
                if (value == _historicalSecurities) return;
                _historicalSecurities = value.ToUpper();
                RaisePropertyChanged(() => HistoricalSecurities);
            }
        }

        SecurityDatabase _historicalSecurityDatabase;
        public SecurityDatabase HistoricalSecurityDatabase
        {
            get { return _historicalSecurityDatabase; }
            set
            {
                if (value == _historicalSecurityDatabase) return;
                _historicalSecurityDatabase = value;
                RaisePropertyChanged(() => HistoricalSecurityDatabase);
            }
        }

        string _historicalFields;
        public string HistoricalFields
        {
            get { return _historicalFields; }
            set
            {
                if (value == _historicalFields) return;
                _historicalFields = value;
                RaisePropertyChanged(() => HistoricalFields);
            }
        }

        DateTime _startDateHistorical;
        public DateTime StartDateHistorical
        {
            get { return _startDateHistorical; }
            set
            {
                if (value == _startDateHistorical) return;
                _startDateHistorical = value;
                RaisePropertyChanged(() => StartDateHistorical);
            }
        }

        DateTime _endDateHistorical;
        public DateTime EndDateHistorical
        {
            get { return _endDateHistorical; }
            set
            {
                if (value == _endDateHistorical) return;
                _endDateHistorical = value;
                RaisePropertyChanged(() => EndDateHistorical);
            }
        }

        Periodicity _periodicity;
        public Periodicity Periodicity
        {
            get { return _periodicity; }
            set
            {
                if (value == _periodicity) return;
                _periodicity = value;
                RaisePropertyChanged(() => Periodicity);
            }
        }

        string _currencyCodeHistorical;
        public string CurrencyCodeHistorical
        {
            get { return _currencyCodeHistorical; }
            set
            {
                if (value == _currencyCodeHistorical) return;
                _currencyCodeHistorical = value;
                RaisePropertyChanged(() => CurrencyCodeHistorical);
            }
        }

        string _log;
        public string Log
        {
            get { return _log; }
            set
            {
                if (value == _log) return;
                _log = value;
                RaisePropertyChanged(() => Log);
            }
        }

        public string[] GetReferenceSecurities()
        {
            return ReferenceSecurities.Split(',').Select(x => x.Trim() + " " + ReferenceSecurityDatabase.ToString().ToUpper()).ToArray();
        }

        public string[] GetReferenceFields()
        {
            return ReferenceFields.Split(',').Select(x => x.Trim()).ToArray();
        }

        public string[] GetHistoricalSecurities()
        {
            return HistoricalSecurities.Split(',').Select(x => x.Trim() + " " + HistoricalSecurityDatabase.ToString().ToUpper()).ToArray();
        }

        public string[] GetHistoricalFields()
        {
            return HistoricalFields.Split(',').Select(x => x.Trim()).ToArray();
        }
    }
}