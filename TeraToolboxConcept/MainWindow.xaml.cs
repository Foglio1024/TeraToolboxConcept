using Nostrum;
using Nostrum.Extensions;
using Nostrum.Factories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;

namespace TTB
{

    public class ModInfo : TSPropertyChanged
    {
        private bool _enabled = true;
        private bool _autoUpdateEnabled = true;

        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public ModType Type { get; set; }
        public bool Enabled
        {
            get => _enabled;
            set
            {
                if (_enabled == value) return;
                _enabled = value;
                N();
            }
        }
        public bool AutoUpdateEnabled
        {
            get => _autoUpdateEnabled;
            set
            {
                if (_autoUpdateEnabled == value) return;
                _autoUpdateEnabled = value;
                N();
            }
        }
        private bool _isPopupOpen;

        public bool IsPopupOpen
        {
            get => _isPopupOpen;
            set
            {
                if (_isPopupOpen == value) return;
                _isPopupOpen = value;
                N();
            }
        }

        public ICommand OpenPopupCommand { get; }
        public ICommand ToggleAutoUpdateCommand { get; }
        public ICommand ToggleEnabledCommand { get; }

        public ModInfo()
        {
            OpenPopupCommand = new RelayCommand(_ => IsPopupOpen = true);
            ToggleAutoUpdateCommand = new RelayCommand(_ => AutoUpdateEnabled = !AutoUpdateEnabled);
            ToggleEnabledCommand = new RelayCommand(_ => Enabled = !Enabled);
        }

        public enum ModType
        {
            Network,
            Client
        }
    }

    public class LogVM : TSPropertyChanged
    {

    }

    public class InstalledModsVM : TSPropertyChanged
    {
        public TSObservableCollection<ModInfo> Mods { get; }

        public InstalledModsVM()
        {
            Mods = new TSObservableCollection<ModInfo>(Dispatcher)
            {
                new ModInfo
                {
                    Author = "Foglio",
                    Description = "UI replacement with some extra features.",
                    Name = "TCC",
                    Version = "1.4.65",
                    Type = ModInfo.ModType.Network
                },
                new ModInfo
                {
                    Author = "Risenio",
                    Description = "A free script filled with features dedicated to improve your fps.",
                    Name = "Fps Utils",
                    Version = "17",
                    Type = ModInfo.ModType.Network
                },
                new ModInfo
                {
                    Author = "Foglio",
                    Description = "Moves charging/gathering bar right below system messages location.",
                    Name = "Progress bar: top screen",
                    Version = "1.0",
                    Type = ModInfo.ModType.Client,
                    Enabled = false
                },
                new ModInfo
                {
                    Author = "Pinkie Pie / many others",
                    Description =
                        "Simulates skills client-side, eliminating ping-based delays and animation lock.",
                    Name = "Skill Prediction",
                    Version = "69",
                    Type = ModInfo.ModType.Network
                }
            };

        }
    }
    public class DownloadModsVM : TSPropertyChanged
    {
        public TSObservableCollection<ModInfo> Mods { get; }

        public DownloadModsVM()
        {
            Mods = new TSObservableCollection<ModInfo>(Dispatcher)
            {
                new ModInfo
                {
                    Author = "Caali",
                    Description = "Flashes your client (like when receiving a negotiation request) to notify you of certain events (for example instance matching completed).",
                    Name = "Flasher",
                    Version = "1.0",
                    Type = ModInfo.ModType.Network
                },
                new ModInfo
                {
                    Author = "Foglio",
                    Description = "WARNING: this mod marks some of your quests as not completed. This might cause unwanted side effects, so use it at your own risk.",
                    Name = "Heartwood",
                    Version = "1.0",
                    Type = ModInfo.ModType.Network
                },
                new ModInfo
                {
                    Author = "Foglio",
                    Description = "Modern UI",
                    Name = "Modern UI: Profile",
                    Version = "1.0",
                    Type = ModInfo.ModType.Client
                },
                new ModInfo
                {
                    Author = "Foglio",
                    Description = "This mod automatically hides skill bar when skill window is closed.",
                    Name = "Modern UI: Skill window (hides skill bar)",
                    Version = "1.0",
                    Type = ModInfo.ModType.Client
                },
                new ModInfo
                {
                    Author = "SaltyMonkey",
                    Description = "Placing server name near guild name in dungeons/everywhere based on settings.",
                    Name = "ServerExposer",
                    Version = "1.0",
                    Type = ModInfo.ModType.Network
                },
                new ModInfo
                {
                    Author = "FRÜT & PÅNT",
                    Description = "Costume and appareance changer with in-game UI. Video: https://youtu.be/wzrTrbYx2mA Discord: https://discord.gg/7PfQfD8",
                    Name = "Unicast",
                    Version = "1.0",
                    Type = ModInfo.ModType.Network
                },
                new ModInfo
                {
                    Author = "Snug",
                    Description = "Automaticly resets ghillie once entering Velik's Sanctuary",
                    Name = "GG-Reset",
                    Version = "1.0",
                    Type = ModInfo.ModType.Network
                },
            };

        }

    }

    public class SettingsVM : TSPropertyChanged
    {
        public IEnumerable<string> Languages { get; } = new List<string> { "English", "Deutsch", "Italiano", "Español", "Polski" };
        public string Language { get; } = "English";
    }
    public class CreditsVM : TSPropertyChanged
    {

    }
    public class MainVM : TSPropertyChanged
    {
        private object _currentVM;

        private bool _isLoading = true;

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (_isLoading == value) return;
                _isLoading = value;
                N();
            }
        }

        private string _loadingMessage = "Starting...";

        public string LoadingMessage
        {
            get => _loadingMessage;
            set
            {
                if (_loadingMessage == value) return;
                _loadingMessage = value;
                N();
            }
        }



        public LogVM Log { get; }
        public InstalledModsVM InstalledMods { get; }
        public DownloadModsVM DownloadMods { get; }
        public SettingsVM Settings { get; }
        public CreditsVM Credits { get; }

        public object CurrentVM
        {
            get => _currentVM;
            set
            {
                if (_currentVM == value) return;
                _currentVM = value;
                N();
            }
        }

        public ICommand SetVmCommand { get; }
        public ICommand HelpCommand { get; }
        public ICommand OpenModsFolderCommand { get; }

        public MainVM()
        {

            Log = new LogVM();
            InstalledMods = new InstalledModsVM();
            DownloadMods = new DownloadModsVM();
            Settings = new SettingsVM();
            Credits = new CreditsVM();

            CurrentVM = Log;

            SetVmCommand = new RelayCommand(arg =>
            {
                switch (arg.ToString())
                {
                    case nameof(Log):
                        CurrentVM = Log;
                        break;
                    case nameof(InstalledMods):
                        CurrentVM = InstalledMods;
                        break;
                    case nameof(DownloadMods):
                        CurrentVM = DownloadMods;
                        break;
                    case nameof(Settings):
                        CurrentVM = Settings;
                        break;
                    case nameof(Credits):
                        CurrentVM = Credits;
                        break;
                }
            });

            HelpCommand = new RelayCommand(_ => Process.Start("https://discordapp.com/invite/659YbNY"));
            OpenModsFolderCommand = new RelayCommand(_ => Process.Start(@"D:\TERA\TeraToolbox\mods\"));
        }
    }

    public partial class MainWindow
    {
        private Button _prevButton;

        public ICommand SetLogCommand { get; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainVM();
            SetLogCommand = new RelayCommand(e => { this.MainContent.Content = this.FindResource("Log"); });
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Task.Delay(1000).ContinueWith(t => Dispatcher.Invoke(() => ((MainVM)DataContext).LoadingMessage = "Checking for updates..."));
            Task.Delay(2500).ContinueWith(t => Dispatcher.Invoke(() => ((MainVM)DataContext).LoadingMessage = "Reducing ping..."));
            Task.Delay(4000).ContinueWith(t => Dispatcher.Invoke(() => ((MainVM)DataContext).LoadingMessage = "Starting..."));
            Task.Delay(5000).ContinueWith(t => Dispatcher.Invoke(() => ((MainVM)DataContext).IsLoading = false));
        }


        private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
        {
            ButtonsGrid.IsHitTestVisible = true;
            var an = new DoubleAnimation(ButtonsGrid.ActualWidth/40D, TimeSpan.FromMilliseconds(250))
            {EasingFunction = new QuadraticEase()};
            opRect.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, an);
            var ann = new DoubleAnimation(ButtonsGrid.ActualWidth, TimeSpan.FromMilliseconds(200))
            {EasingFunction = new QuadraticEase()};

            bgBorder.BeginAnimation(FrameworkElement.WidthProperty, ann);
            var an2 = new DoubleAnimation(.2, TimeSpan.FromMilliseconds(100));
            ((DropShadowEffect)bgBorder.Effect).BeginAnimation(DropShadowEffect.OpacityProperty, an2);
            bgBorder.Background.BeginAnimation(SolidColorBrush.ColorProperty, new ColorAnimation(Color.FromRgb(53, 61, 66), TimeSpan.FromMilliseconds(200)));

        }

        private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (ButtonsGrid.IsMouseOver) return;
            ButtonsGrid.IsHitTestVisible = false;
            var an = new DoubleAnimation(1, TimeSpan.FromMilliseconds(200)) {EasingFunction = new QuadraticEase()};
            opRect.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, an);
            var ann = new DoubleAnimation(40, TimeSpan.FromMilliseconds(250)) {EasingFunction = new QuadraticEase()};
            bgBorder.BeginAnimation(FrameworkElement.WidthProperty, ann);
            var an2 = new DoubleAnimation(0, TimeSpan.FromMilliseconds(50)){BeginTime = TimeSpan.FromMilliseconds(150)};
            ((DropShadowEffect)bgBorder.Effect).BeginAnimation(DropShadowEffect.OpacityProperty, an2);
            bgBorder.Background.BeginAnimation(SolidColorBrush.ColorProperty, new ColorAnimation(Color.FromRgb(45, 52, 56), TimeSpan.FromMilliseconds(200)));


        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var currMode = this.ResizeMode;
            ResizeMode = ResizeMode.NoResize;
            this.TryDragMove();
            ResizeMode = currMode;

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var target = (FrameworkElement) sender;

            var idx = ButtonsSP.Children.IndexOf(target);
            var totY = idx * 40;
            SelRect.RenderTransform.BeginAnimation(TranslateTransform.YProperty, AnimationFactory.CreateDoubleAnimation(150, totY, easing: true));

            return;
            var bg = new SolidColorBrush(Color.FromArgb(0, 114, 121, 255));
            ((Button)sender).Background = bg;
            var anim = AnimationFactory.CreateColorAnimation(100);
            anim.To = TTB.R.Colors.ToolboxColor;
            bg.BeginAnimation(SolidColorBrush.ColorProperty, anim);
            var transCol = TTB.R.Colors.ToolboxColor;
            transCol.A = 0;
            _prevButton?.Background.BeginAnimation(SolidColorBrush.ColorProperty, new ColorAnimation(transCol, TimeSpan.FromMilliseconds(100)));
            _prevButton = (Button)sender;
        }

        private void CloseBtnOnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeBtnOnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Popup_OnMouseLeave(object sender, MouseEventArgs e)
        {
            ((ModInfo)((FrameworkElement)sender).DataContext).IsPopupOpen = false;
        }

        private void ModMouseLeave(object sender, MouseEventArgs e)
        {
            var dc = ((ModInfo)((FrameworkElement)sender).DataContext);
            foreach (var mod in ((MainVM)DataContext).InstalledMods.Mods)
            {
                if (mod != dc)
                {
                    mod.IsPopupOpen = false;
                }
            }
        }
    }

    public class MainTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Log { get; set; }
        public DataTemplate InstalledMods { get; set; }
        public DataTemplate DownloadMods { get; set; }
        public DataTemplate Settings { get; set; }
        public DataTemplate Credits { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            switch (item)
            {
                case LogVM _: return Log;
                case InstalledModsVM _: return InstalledMods;
                case DownloadModsVM _: return DownloadMods;
                case SettingsVM _: return Settings;
                case CreditsVM _: return Credits;
                default: return null;
            }
        }
    }

    public class RoundedClipConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 3 && values[0] is double && values[1] is double && values[2] is CornerRadius)
            {
                var width = (double) values[0];
                var height = (double) values[1];

                if (width < double.Epsilon || height < double.Epsilon)
                {
                    return Geometry.Empty;
                }

                var radius = (CornerRadius) values[2];

                // Actually we need more complex geometry, when CornerRadius has different values.
                // But let me not to take this into account, and simplify example for a common value.
                var clip = new RectangleGeometry(new Rect(0, 0, width, height), radius.TopLeft, radius.TopLeft);
                clip.Freeze();
                return clip;
            }

            return DependencyProperty.UnsetValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
