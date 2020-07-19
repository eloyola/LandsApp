namespace LandsApplication.ViewModels
{
    using LandsApplication.Models;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class LandViewModel : BaseViewModel
    {
        private ObservableCollection<Border> borders;
        private ObservableCollection<Currency> currencies;
        private ObservableCollection<Language> languages;
        private Translations translations;
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

        public ObservableCollection<Currency> Currencies
        {
            get => currencies;
            set
            {
                SetValue(ref this.currencies, value);
            }
        }

        public ObservableCollection<Language> Languages
        {
            get => languages;
            set
            {
                SetValue(ref this.languages, value);
            }
        }

        public Translations Translations
        {
            get => translations;
            set
            {
                SetValue(ref this.translations, value);
            }
        }
        #endregion

        #region Constructors
        public LandViewModel(Land land)
        {
            this.Land = land;
            LoadBorders();
            this.currencies = new ObservableCollection<Currency>(this.Land.Currencies);
            this.languages = new ObservableCollection<Language>(this.Land.Languages);
            this.translations = this.Land.Translations;
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