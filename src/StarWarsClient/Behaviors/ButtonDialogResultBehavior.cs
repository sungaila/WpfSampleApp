using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StarWarsClient.Behaviors
{
    /// <summary>
    /// Sets <see cref="Window.DialogResult"/> to <see cref="DialogResult"/> when the attached button is clicked.
    /// </summary>
    public class ButtonDialogResultBehavior : Behavior<Button>
    {
        public static readonly DependencyProperty DialogResultProperty = DependencyProperty.Register(
            nameof(DialogResult),
            typeof(bool?),
            typeof(ButtonDialogResultBehavior),
            new PropertyMetadata(true));

        public bool? DialogResult
        {
            get => (bool?)GetValue(DialogResultProperty);
            set => SetValue(DialogResultProperty, value);
        }

        protected override void OnAttached()
        {
            AssociatedObject.Click += AssociatedObject_Click;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AssociatedObject_Click;
        }
        private void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {
            if (TryFindParentWindow(sender as Button) is not Window window)
                return;

            window.DialogResult = DialogResult;
        }

        private static Window? TryFindParentWindow(FrameworkElement? element)
        {
            if (element == null)
                return null;

            for (FrameworkElement? parent = element; parent != null; parent = VisualTreeHelper.GetParent(parent) as FrameworkElement)
            {
                if (parent is Window window)
                    return window;
            }

            return null;
        }
    }
}