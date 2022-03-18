using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WypozyczalniaSamochodow.ViewModel
{
    /// <summary>
    /// INotifyPropertyChanged -> potrzebne do obslugi MVVm ( odswiezanie runtime'owe właściwości)
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /*
         https://docs.microsoft.com/pl-pl/dotnet/api/system.componentmodel.inotifypropertychanged.propertychanged?view=net-6.0
         */
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
