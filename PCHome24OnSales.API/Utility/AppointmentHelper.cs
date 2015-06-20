using PCHome24OnSales.API.Service.GetOnSaleItems;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments;
using Windows.UI.Xaml;

namespace PCHome24OnSales.API.Utility
{
    public class AppointmentHelper
    {
        public static async Task<Boolean> AddReminder(String title, String detail, Uri uri, DateTimeOffset startTime, TimeSpan duration)
        {
            Boolean result = false;

            var appointment = new Appointment
            {
                Subject = title,
                Details = detail,
                Uri = uri,
                StartTime = startTime,
                Duration = duration,
                Reminder = TimeSpan.FromMinutes(10)
            };

            String appointmentId = await AppointmentManager.ShowAddAppointmentAsync(appointment, Window.Current.Bounds, Windows.UI.Popups.Placement.Default);
            if (String.IsNullOrEmpty(appointmentId) == false)
            {
                result = true;
            }

            return result;
        }

        public static async Task<Boolean> AddReminder(Node sourceData, DateTime date, Boolean isWeekend)
        {
            Boolean result = false;

            if (sourceData != null)
            {
                String title = null;
                String details = null;
                Uri uri = null;

                if (sourceData.Link != null)
                {
                    title = sourceData.Link.Text1;
                    details = sourceData.Link.Text1 + Environment.NewLine +
                              sourceData.Link.Price + Environment.NewLine +
                              sourceData.Link.Url;
                    uri = new Uri(sourceData.Link.Url, UriKind.RelativeOrAbsolute);
                }

                var onSaleStartTime = date;

                if (sourceData.ExtraData != null && sourceData.ExtraData.HourArray != null && sourceData.ExtraData.HourArray.Length > 0)
                {
                    Double hour = 0;
                    if (Double.TryParse(sourceData.ExtraData.HourArray[0], out hour))
                    {
                        onSaleStartTime = onSaleStartTime.AddHours(hour);
                    }
                }

                result = await AddReminder(title, details, uri, onSaleStartTime, TimeSpan.Zero);
            }

            return result;
        }
    }
}
