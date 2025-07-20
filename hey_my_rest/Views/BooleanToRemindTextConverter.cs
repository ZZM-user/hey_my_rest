using System;
using Avalonia.Data.Converters;
using System.Globalization;

namespace hey_my_rest.Views
{
    /// <summary>
    /// 将布尔值转换为“开始提醒”或“停止提醒”按钮文本的转换器
    /// </summary>
    public class BooleanToRemindTextConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool b)
                return b ? "停止提醒" : "开始提醒";
            return "开始提醒";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
