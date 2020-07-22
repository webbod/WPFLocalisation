using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Basic
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            LoadCorrectDictionary();
        }

        protected void LoadCorrectDictionary(string dictionaryName = "deDE")
        {
            try
            {
                var dictionary = new ResourceDictionary();

                // replace the default dictionary with the german one
                var path = Path.Combine("Resources", "Dictionaries", $"{dictionaryName}.xaml");
                dictionary.Source = new Uri(path, UriKind.Relative);


                // this feels a wee bit britle
                Resources.MergedDictionaries[0] = dictionary;
            }
            catch (Exception ex)
            {
                // happend when the dictionary is not found
            }
        }
    }
}
