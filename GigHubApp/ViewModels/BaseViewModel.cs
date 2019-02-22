using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using GigHubApp.Models;
using GigHubApp.Services;
using System.Threading.Tasks;

namespace GigHubApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>() ?? new MockDataStore();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public async Task PushAsync<TViewModel>(params object[] args) where TViewModel : BaseViewModel
        {
            var viewModelType = typeof(TViewModel);

            var viewModelTypeName = viewModelType.Name;
            var viewModelWordLength = "ViewModel".Length;
            var viewTypeName = $"GigHubApp.Views.{viewModelTypeName.Substring(0, viewModelTypeName.Length - viewModelWordLength)}Page";
            var viewType = Type.GetType(viewTypeName);

            
            var page = Activator.CreateInstance(viewType) as Page;

            var viewModel = Activator.CreateInstance(viewModelType, args);
            if (page != null)
            {
                page.BindingContext = viewModel;
            }

            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(page);
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
