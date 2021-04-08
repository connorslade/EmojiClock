using System;
using System.Drawing;
using System.Windows.Forms;
using EmojiClock.Properties;

namespace EmojiClock
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new App());
        }
    }

    public class App : ApplicationContext
    {
        private static System.Timers.Timer _timer;
        public static readonly NotifyIcon Tray = new NotifyIcon();

        public static readonly Icon[] TrayIcons =
        {
            Resources.one_oclock_1f550_png,
            Resources.two_oclock_1f551_png,
            Resources.three_oclock_1f552_png,
            Resources.four_oclock_1f553_png,
            Resources.five_oclock_1f554_png,
            Resources.six_oclock_1f555_png,
            Resources.seven_oclock_1f556_png,
            Resources.eight_oclock_1f557_png,
            Resources.nine_oclock_1f558_png,
            Resources.ten_oclock_1f559_png,
            Resources.eleven_oclock_1f55a_png,
            Resources.twelve_oclock_1f55b_png
        };

        public App()
        {
            Tray.Icon = Resources.one_oclock_1f550_png;
            Tray.ContextMenu = new ContextMenu(new[]
            {
                new MenuItem("Github", GitHub),
                new MenuItem("Exit", Exit)
            });
            Tray.Visible = true;
            SetTimer();
            Time.SetTimeEmoji();
        }

        private static void Exit(object sender, EventArgs e)
        {
            Tray.Visible = false;
            Application.Exit();
        }

        private static void GitHub(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Basicprogrammer10/");
        }

        private static void SetTimer()
        {
            _timer = new System.Timers.Timer(5000);
            _timer.Elapsed += (sender, e) => { OnTimedEvent(); };
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private static void OnTimedEvent()
        {
            Time.SetTimeEmoji();
        }
    }

    public static class Time
    {
        public static void SetTimeEmoji()
        {
            var hour = DateTime.Now.ToString("HH");
            App.Tray.Icon = App.TrayIcons[int.Parse(hour) - 1];
        }
    }
}