using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Avtotest.WPF.Pages
{
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();

            var btn = new Button();
            btn.Template = FindResource("MainMenuButtonTemplate") as ControlTemplate;
            panel.Children.Add(btn);
        }

        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var button = (Button)sender;

            var duration = new Duration(TimeSpan.FromSeconds(.5));
            DoubleAnimation anim = new DoubleAnimation(200, 300, duration);
            Storyboard.SetTargetProperty(anim, new PropertyPath(Button.WidthProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(anim);

            storyboard.Begin(button);
        }

        private void Button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var button = (Button)sender;

            var duration = new Duration(TimeSpan.FromSeconds(.3));
            DoubleAnimation anim = new DoubleAnimation(button.Width, 200, duration);
            Storyboard.SetTargetProperty(anim, new PropertyPath(Button.WidthProperty));

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(anim);

            storyboard.Begin(button);
        }
    }
}
