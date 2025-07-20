using Avalonia.Controls;
using Avalonia.Threading;
using System;

namespace hey_my_rest.Views
{
    public partial class ReminderWindow : Window
    {
        private int _secondsLeft;
        private DispatcherTimer? _timer;

        public ReminderWindow(string remindText, int durationSeconds)
        {
            InitializeComponent();
            _secondsLeft = durationSeconds;
            var remindTextBlock = this.FindControl<TextBlock>("RemindTextBlock");
            var autoCloseTip = this.FindControl<TextBlock>("AutoCloseTip");
            if (remindTextBlock != null)
                remindTextBlock.Text = remindText;
            if (autoCloseTip != null)
                autoCloseTip.Text = $"本窗口将在 {_secondsLeft} 秒后自动关闭...";
            // 启动动态倒计时
            StartCountdown(autoCloseTip);
        }

        private void StartCountdown(TextBlock? autoCloseTip)
        {
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += (s, e) =>
            {
                _secondsLeft--;
                if (autoCloseTip != null)
                    autoCloseTip.Text = $"本窗口将在 {_secondsLeft} 秒后自动关闭...";
                if (_secondsLeft <= 0)
                {
                    _timer?.Stop();
                    Close();
                }
            };
            _timer.Start();
        }
    }
}
