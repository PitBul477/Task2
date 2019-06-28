using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Model
{
    public class Interlayer
    {
        private string _nameColumn = string.Empty;
        private string _valueColumn = string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;
        public string NameColumn
        {
            get { return _nameColumn; }
            set
            {
                _nameColumn = value;
                OnPropertChanged(string.Empty);
            }
        }
        public string ValueColumn
        {
            get { return _valueColumn; }
            set
            {
                _valueColumn = value;
                OnPropertChanged(string.Empty);
            }
        }

        void OnPropertChanged(string propertyName)
        {
            if (PropertyChanged != null)
            { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }
    }
}
