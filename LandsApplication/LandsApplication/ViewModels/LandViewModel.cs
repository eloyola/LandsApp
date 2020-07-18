namespace LandsApplication.ViewModels
{
    using LandsApplication.Models;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class LandViewModel : BaseViewModel
    {
        private ObservableCollection<Border> borders;

        #region Propperties
        public Land Land
        {
            get;
            set;
        }
        public ObservableCollection<Border> Borders
        {
            get => borders;
            set
            {
                SetValue(ref this.borders, value);
            }
        }
        #endregion

        #region Constructors
        public LandViewModel(Land land)
        {
            this.Land = land;
            LoadBorders();
        }
        #endregion

        private void LoadBorders()
        {
            this.borders = new ObservableCollection<Border>();
            foreach (var item in this.Land.Borders)
            {
                var land = MainViewModel.GetInstance().LandsList
                    .Where(p => p.Alpha3Code == item)
                    .FirstOrDefault();
                if (land != null)
                {
                    this.Borders.Add(new Border
                    {
                        Code = land.Alpha3Code,
                        Name = land.Name
                    });
                }
            }
        }
    }
}