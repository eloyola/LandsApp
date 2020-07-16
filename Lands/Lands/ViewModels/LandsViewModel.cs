using Lands.Models;
using Lands.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Lands.ViewModels
{
    public class LandsViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<Land> lands;

        private ApiService apiService;
        #endregion

        #region Properties
        public ObservableCollection<Land> Lands
        {
            get => lands;
            set
            {
                SetValue(ref this.lands, value);
            }
        }
        #endregion

        public LandsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadLands();
        }

        #region Methods
        private async void LoadLands()
        {
            var response = await this.apiService.GetList<Land>("https://restcountries.eu", 
                "/rest", 
                "/v2/all");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", 
                    response.Message, 
                    "Accept");
                return;
            }

            var list = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<Land>(list);
        }
        #endregion
    }
}
