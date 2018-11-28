using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PullToRefreshTest.Properties;

namespace PullToRefreshTest.ViewModels
{
    public abstract class ABaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
