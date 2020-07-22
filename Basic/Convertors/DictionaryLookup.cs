using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Xml;

namespace Basic.Convertors
{
    public class DictionaryLookup : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string resourceKey = string.Empty;
            string translation = string.Empty;

            try
            {
                switch (value.GetType().Name)
                {
                    case "XmlAttribute":
                        resourceKey = ((XmlAttribute)value).Value;
                        break;

                    default:
                        resourceKey = value.ToString();
                        break;
                }

                translation = (string)Application.Current.Resources[resourceKey];

                if (string.IsNullOrEmpty(translation)){
                    throw new KeyNotFoundException();
                }

            }
            catch(Exception)
            {
                translation = $"[MT]{resourceKey}";
            }

            return translation;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}