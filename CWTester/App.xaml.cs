using CWTester.DataBase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CWTester
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static TesterContext db = new TesterContext();
        private static List<CultureInfo> languages = new List<CultureInfo>();

        public static List<CultureInfo> Languages => languages;

        public App()
        {
            languages.Clear();
            languages.Add(new CultureInfo("ru-RU"));
            languages.Add(new CultureInfo("en-US"));
        }

        public static event EventHandler LanguageChanged;

        public static CultureInfo Language
        {
            get => CultureInfo.CurrentUICulture;
            set
            {
                if (value == null)
                    return;
                if (value.Equals(CultureInfo.CurrentUICulture))
                    return;
                CultureInfo.CurrentUICulture = value;
                ResourceDictionary dict = new ResourceDictionary();
                switch (value.Name)
                {
                    case "en-US":
                        dict.Source = new Uri(String.Format("Resources/EnLocalization.xaml", value.Name), UriKind.Relative);
                        break;
                    case "ru-RU":
                        dict.Source = new Uri("Resources/RuLocalization.xaml", UriKind.Relative);
                        break;
                }
                ResourceDictionary oldDict = (from d in Application.Current.Resources.MergedDictionaries
                                              where d.Source != null && d.Source.OriginalString.Contains("Localization.")
                                              select d).First();
                if (oldDict != null)
                {
                    int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                    Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                    Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
                }
                else
                {
                    Application.Current.Resources.MergedDictionaries.Add(dict);
                }
                LanguageChanged?.Invoke(null, new EventArgs());
            }
        }
    }
}