using System;
using System.Globalization;

namespace DateUtilities
{
    public class DateFormatter
    {
        public string FormatDate(string inputDate)
        {
            if (string.IsNullOrWhiteSpace(inputDate))
                throw new FormatException("Input date is invalid");

            DateTime date;

            bool isValid = DateTime.TryParseExact(
                inputDate,
                "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date
            );

            if (!isValid)
                throw new FormatException("Input date is invalid");

            return date.ToString("dd-MM-yyyy");
        }
    }
}
