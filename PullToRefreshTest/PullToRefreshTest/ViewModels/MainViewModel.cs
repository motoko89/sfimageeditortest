using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PullToRefreshTest.Properties;
using Xamarin.Forms;

namespace PullToRefreshTest.ViewModels
{
    public class MainViewModel : ABaseViewModel
    {
        public MainViewModel()
        {
            inspections = new ObservableCollection<InspectionViewModel>();
            for (int i = 0; i < 10;i++)
            {
                inspections.Add(new InspectionViewModel()
                {
                    Description = Guid.NewGuid().ToString()
                });
            }
        }
        private InspectionViewModel selectedInspection;
        public InspectionViewModel SelectedInspection
        {
            get { return selectedInspection; }
            set
            {
                selectedInspection = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<InspectionViewModel> inspections;

        public ObservableCollection<InspectionViewModel> Inspections
        {
            get { return inspections; }
            set
            {
                Debug.WriteLine("GetInspections");
                inspections = value;
                OnPropertyChanged();
            }
        }
        private bool isRefreshing;

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                if (isRefreshing != value)
                {
                    isRefreshing = value;
                    OnPropertyChanged();
                }
            }
        }


       private ICommand loadMoreInspectionsCommand;

        public ICommand LoadMoreInspectionsCommand
        {
            get
            {
                loadMoreInspectionsCommand = loadMoreInspectionsCommand ?? new Command<object>(LoadMoreInspections, LoadMoreInspectionsCanExecute);
                return loadMoreInspectionsCommand;
            }
        }

        public bool LoadMoreInspectionsCanExecute(object obj)
        {
            var canExecution = 11 > Inspections.Count;
            Debug.WriteLine("LoadMoreInspectionsCanExecute " + canExecution);
            return canExecution;
        }

        public void LoadMoreInspections(object obj)
        {

        }

    }
}
