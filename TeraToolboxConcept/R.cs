////////////////////////////////////////////////////
//// File automatically generated from App.xaml ////
////////////////////////////////////////////////////
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using TTB;

namespace TTB.R
{
	public static class Converters
	{
		public static RoundedClipConverter RoundedClipConverter => ((RoundedClipConverter)App.Current.FindResource("RoundedClipConverter"));
	}
	public static class Colors
	{
		public static Color ToolboxColor => ((Color)App.Current.FindResource("ToolboxColor"));
		public static Color RevampBackgroundColor => ((Color)App.Current.FindResource("RevampBackgroundColor"));
		public static Color RevampBorderColor => ((Color)App.Current.FindResource("RevampBorderColor"));
		public static Color TooltipColor => ((Color)App.Current.FindResource("TooltipColor"));
	}
	public static class Brushes
	{
		public static SolidColorBrush ToolboxBrush => ((SolidColorBrush)App.Current.FindResource("ToolboxBrush"));
		public static SolidColorBrush SelectionBackgroundBrush => ((SolidColorBrush)App.Current.FindResource("SelectionBackgroundBrush"));
		public static SolidColorBrush SelectionBackgroundLightBrush => ((SolidColorBrush)App.Current.FindResource("SelectionBackgroundLightBrush"));
		public static SolidColorBrush RevampBackgroundBrush => ((SolidColorBrush)App.Current.FindResource("RevampBackgroundBrush"));
		public static SolidColorBrush RevampBorderBrush => ((SolidColorBrush)App.Current.FindResource("RevampBorderBrush"));
		public static SolidColorBrush TooltipBrush => ((SolidColorBrush)App.Current.FindResource("TooltipBrush"));
		public static SolidColorBrush SelectionBorderBrush => ((SolidColorBrush)App.Current.FindResource("SelectionBorderBrush"));
		public static SolidColorBrush CheckBoxOffBrush => ((SolidColorBrush)App.Current.FindResource("CheckBoxOffBrush"));
	}
	public static class Styles
	{
		public static DropShadowEffect DropShadow => ((DropShadowEffect)App.Current.FindResource("DropShadow"));
		public static Style RevampBorderStyle => ((Style)App.Current.FindResource("RevampBorderStyle"));
		public static Geometry SyncOnSVG => ((Geometry)App.Current.FindResource("SyncOnSVG"));
		public static Geometry SyncOffSVG => ((Geometry)App.Current.FindResource("SyncOffSVG"));
		public static Geometry EnableSVG => ((Geometry)App.Current.FindResource("EnableSVG"));
		public static Geometry DisableSVG => ((Geometry)App.Current.FindResource("DisableSVG"));
		public static Style ScrollThumbs => ((Style)App.Current.FindResource("ScrollThumbs"));
		public static Style GlowHoverGrid => ((Style)App.Current.FindResource("GlowHoverGrid"));
		public static Style ButtonMainStyle => ((Style)App.Current.FindResource("ButtonMainStyle"));
		public static Style FocusVisual => ((Style)App.Current.FindResource("FocusVisual"));
		public static Style ComboBoxToggleButton => ((Style)App.Current.FindResource("ComboBoxToggleButton"));
		public static ControlTemplate ComboBoxTemplate => ((ControlTemplate)App.Current.FindResource("ComboBoxTemplate"));
		public static Style DefaultListItemStyle => ((Style)App.Current.FindResource("DefaultListItemStyle"));
	}
	public static class DataTemplates
	{
		public static DataTemplate EnumDescrDataTemplate => ((DataTemplate)App.Current.FindResource("EnumDescrDataTemplate"));
	}
}
