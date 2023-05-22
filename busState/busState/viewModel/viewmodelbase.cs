using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Web;

namespace busState.viewModel
{
    public abstract class viewmodelbase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;  
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
