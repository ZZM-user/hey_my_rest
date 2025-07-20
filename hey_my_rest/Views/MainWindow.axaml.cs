using Avalonia.Controls;
using hey_my_rest.ViewModels;
using Avalonia.Threading;

namespace hey_my_rest.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // 订阅 ViewModel 的提醒事件
        if (DataContext is MainWindowViewModel vm)
        {
            vm.RemindRequested += OnRemindRequested;
        }
        else
        {
            // 兼容运行时 DataContext 绑定
            this.DataContextChanged += (s, e) =>
            {
                if (DataContext is MainWindowViewModel vm2)
                {
                    vm2.RemindRequested += OnRemindRequested;
                }
            };
        }
    }

    // 弹出提醒窗口
    private void OnRemindRequested(object? sender, System.EventArgs e)
    {
        if (DataContext is MainWindowViewModel vm)
        {
            // UI线程弹窗
            Dispatcher.UIThread.Post(() =>
            {
                var reminder = new ReminderWindow(vm.RemindText, vm.RemindDuration);
                reminder.Show();
            });
        }
    }
}
