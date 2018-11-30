using System;
namespace PullToRefreshTest.ViewModels
{
    public class InspectionViewModel: ABaseViewModel
    {

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
