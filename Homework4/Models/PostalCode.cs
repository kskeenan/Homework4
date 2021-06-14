using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Homework4.Models
{
    class PostalCode : IDataErrorInfo, INotifyPropertyChanged
    {
        private string _postCode = string.Empty;
        public string PostCode
        {
            get
            {
                return _postCode;
            }
            set
            {
                if (_postCode != value)
                {
                    _postCode = value;
                    OnPropertyChanged("PostCode");
                }
            }
        }

        string _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
        string _caZipRegEx = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";    //Letters must be capitalized

        private bool IsUSOrCanadianZipCode(string zipCode)
        {
            var validZipCode = true;
            if ((!Regex.Match(zipCode, _usZipRegEx).Success) && (!Regex.Match(zipCode, _caZipRegEx).Success))
            {
                validZipCode = false;
            }
            return validZipCode;
        }

        #region IDataErrorInfo Members
        private string _error;
        public string Error
        {
            get => _error;
            set
            {
                if (_error != value)
                {
                    _error = value;
                    OnPropertyChanged("Error");
                }
            }
        }


        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "PostCode")
                {
                    if (string.IsNullOrEmpty(PostCode) || !IsUSOrCanadianZipCode(PostCode))
                        result = "Please enter a US or Canadian postal code";
                }
                if (result == null)
                {
                    Error = null;
                }
                else
                {
                    Error = "Error";
                }
                return result;
            }
        }
        #endregion
        // INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
