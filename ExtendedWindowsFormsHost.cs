using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Input;

namespace MultiScreener_Media
{
    public class ExtendedWindowsFormsHost : WindowsFormsHost
    {
        public ExtendedWindowsFormsHost()
        {
            ChildChanged += OnChildChanged;
        }

        private void OnChildChanged(object sender, ChildChangedEventArgs childChangedEventArgs)
        {
            if (childChangedEventArgs.PreviousChild is Control previousChild)
            {
                previousChild.MouseDown -= OnMouseDown;
            }
            if (Child != null)
            {
                Child.MouseDown += OnMouseDown;
            }
        }

        private void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs mouseEventArgs)
        {
            MouseButton? wpfButton = ConvertToWpf(mouseEventArgs.Button);
            if (!wpfButton.HasValue)
                return;

            RaiseEvent(new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, wpfButton.Value)
            {
                RoutedEvent = Mouse.MouseDownEvent,
                Source = this,
            });
        }

        public static MouseButton? ConvertToWpf(MouseButtons winformButton)
        {
            return winformButton switch
            {
                MouseButtons.Left => MouseButton.Left,
                MouseButtons.None => null,
                MouseButtons.Right => MouseButton.Right,
                MouseButtons.Middle => MouseButton.Middle,
                MouseButtons.XButton1 => MouseButton.XButton1,
                MouseButtons.XButton2 => MouseButton.XButton2,
                _ => throw new ArgumentOutOfRangeException(nameof(winformButton)),
            };
        }
    }
}
