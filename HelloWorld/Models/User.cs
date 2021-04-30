using System.ComponentModel;

namespace HelloWorld.Models
{
    class User : INotifyPropertyChanged
    {
        private string name = string.Empty;
        private string password = string.Empty;
        private bool submitEnabled = false;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public bool SubmitEnabled
        {
            get
            {
                return submitEnabled;
            }

            set
            {
                if (string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(Password))
                {
                    submitEnabled = false;
                }
                else
                {
                    submitEnabled = true;
                }                
            }
        }

        //public bool SubmitEnabled
        //{
        //    get
        //    {
        //        //submitEnabled = false;
        //        //if (string.IsNullOrEmpty(Name)) //&& string.IsNullOrEmpty(Password))
        //        if (Name.Length >3)

        //        {
        //            submitEnabled = true;
        //        }
        //        else submitEnabled = false;

        //        return submitEnabled;
        //    }

        //    set
        //    {
        //        if (submitEnabled != value)
        //        {
        //            submitEnabled = value;

        //        }
        //    }
        //}

        //// IDataErrorInfo interface
        //public string Error
        //{
        //    get
        //    {
        //        return NameError;
        //    }
        //}

        //// IDataErrorInfo interface
        //// Called when ValidatesOnDataErrors=True
        //public string this[string columnName]
        //{
        //    get
        //    {
        //        NameError = "";
        //        switch (columnName)
        //        {
        //            case "Name":
        //                {
        //                    if (string.IsNullOrEmpty(Name))
        //                    {
        //                        NameError = "Name cannot be empty.";
        //                    }
        //                    if (Name.Length > 12)
        //                    {
        //                        NameError = "Name cannot be longer than 12 characters.";
        //                    }
        //                    break;
        //                }
        //        }
        //        return NameError;
        //    }
        //}

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
