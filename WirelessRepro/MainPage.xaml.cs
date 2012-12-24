using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Scheduler;

namespace WirelessRepro
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            ScheduledAction Existing = ScheduledActionService.Find("WirelessReproBackground");
            if (Existing != null)
            {
                ScheduledActionService.Remove("WirelessReproBackground");
            }
            PeriodicTask periodicTask = new PeriodicTask("WirelessReproBackground");
            periodicTask.Description = "Wireless Repro Background Task";
            periodicTask.ExpirationTime = DateTime.Now.AddDays(14);

            ScheduledActionService.Add(periodicTask);
            ScheduledActionService.LaunchForTest("WirelessReproBackground", TimeSpan.FromSeconds(300));
        }
    }
}