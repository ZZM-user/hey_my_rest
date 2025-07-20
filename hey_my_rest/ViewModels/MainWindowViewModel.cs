using System;
using System.Collections.ObjectModel;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace hey_my_rest.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    // 提醒间隔（分钟）
    [ObservableProperty]
    private int remindInterval = 40;

    // 提醒持续时间（秒）
    [ObservableProperty]
    private int remindDuration = 10;

    // 当前话术
    [ObservableProperty]
    private string remindText = "请休息一下，保护眼睛！";

    // 预设话术列表
    public ObservableCollection<string> PresetTexts { get; } = new()
    {
        "请休息一下，保护眼睛！",
        "远眺20秒，缓解眼疲劳~",
        "喝口水，活动一下身体吧！"
    };

    // 是否正在提醒
    [ObservableProperty]
    private bool isReminding;

    private DispatcherTimer? _timer;

    public MainWindowViewModel()
    {
    }

    // 开始/停止提醒命令
    [RelayCommand]
    private void ToggleRemind()
    {
        if (IsReminding)
        {
            StopRemind();
        }
        else
        {
            StartRemind();
        }
    }

    // 开始定时提醒
    private void StartRemind()
    {
        if (_timer != null)
        {
            _timer.Stop();
        }
        _timer = new DispatcherTimer { Interval = TimeSpan.FromMinutes(RemindInterval) };
        _timer.Tick += (s, e) => OnRemind();
        _timer.Start();
        IsReminding = true;
        // OnRemind(); // 删除立即提醒
    }

    // 停止提醒
    private void StopRemind()
    {
        if (_timer != null)
        {
            _timer.Stop();
            _timer = null;
        }
        IsReminding = false;
    }

    // 触发提醒事件（UI线程）
    private void OnRemind()
    {
        // Avalonia 没有 WPF 的 Dispatcher，需在 View 里处理 UI 弹窗
        RemindRequested?.Invoke(this, EventArgs.Empty);
    }

    // 提醒事件，供 View 订阅
    public event EventHandler? RemindRequested;
}
