﻿using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace TTB.Controls.Settings
{
    public partial class CheckboxSetting
    {
        public CheckboxSetting()
        {
            InitializeComponent();
        }

        public bool IsOn
        {
            get => (bool)GetValue(IsOnProperty);
            set => SetValue(IsOnProperty, value);
        }
        public static readonly DependencyProperty IsOnProperty =
            DependencyProperty.Register("IsOn", typeof(bool), typeof(CheckboxSetting), new PropertyMetadata(false));

        public Brush CheckBoxColor
        {
            get => (Brush)GetValue(CheckBoxColorProperty);
            set => SetValue(CheckBoxColorProperty, value);
        }
        public static readonly DependencyProperty CheckBoxColorProperty =
            DependencyProperty.Register("CheckBoxColor", typeof(Brush), typeof(CheckboxSetting), new PropertyMetadata(Brushes.LightSlateGray));

        public string SettingName
        {
            get => (string)GetValue(SettingNameProperty);
            set => SetValue(SettingNameProperty, value);
        }
        public static readonly DependencyProperty SettingNameProperty =
            DependencyProperty.Register("SettingName", typeof(string), typeof(CheckboxSetting), new PropertyMetadata(""));

        public Geometry SvgIcon
        {
            get => (Geometry)GetValue(SvgIconProperty);
            set => SetValue(SvgIconProperty, value);
        }
        public static readonly DependencyProperty SvgIconProperty =
            DependencyProperty.Register("SvgIcon", typeof(Geometry), typeof(CheckboxSetting));

        private void OnMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            CheckBox.IsChecked = !CheckBox.IsChecked;
        }
    }
}
