﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SyncPlayWPF.Converters {
    class TextBoxValueToBoolean : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var text = value as string;

            return !string.IsNullOrWhiteSpace(text);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
