using System;
using System.Collections.ObjectModel;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Linq;

namespace hey_my_rest.ViewModels;

public partial class WeekDayItem : ObservableObject
{
    public string Name { get; }
    [ObservableProperty]
    private bool isChecked;
    public WeekDayItem(string name, bool isChecked = false)
    {
        Name = name;
        this.isChecked = isChecked;
    }
}

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

    // 星期多选集合
    public ObservableCollection<WeekDayItem> WeekDays { get; } = new()
    {
        new WeekDayItem("日", false),
        new WeekDayItem("一", true),
        new WeekDayItem("二", true),
        new WeekDayItem("三", true),
        new WeekDayItem("四", true),
        new WeekDayItem("五", true),
        new WeekDayItem("六", false),
    };

    // 开始提醒时间（当天）
    [ObservableProperty]
    private TimeSpan startTime = new TimeSpan(9, 0, 0); // 默认09:00

    // 结束提醒时间（当天）
    [ObservableProperty]
    private TimeSpan endTime = new TimeSpan(18, 0, 0); // 默认18:00

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
            _timer = null;
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
        var now = DateTime.Now;
        // 判断当前时间是否在区间内
        var nowTime = now.TimeOfDay;
        bool inTimeRange = nowTime >= StartTime && nowTime <= EndTime;
        // 判断今天是否为选中星期
        int dayIndex = (int)now.DayOfWeek; // 周日为0，周一为1...
        bool isSelectedDay = WeekDays[dayIndex].IsChecked;
        if (inTimeRange && isSelectedDay)
        {
            RemindRequested?.Invoke(this, EventArgs.Empty);
        }
    }

    // 提醒事件，供 View 订阅
    public event EventHandler? RemindRequested;
}
