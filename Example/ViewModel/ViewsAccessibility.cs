using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Example.ViewModel
{
    public static class ViewsAccessibility
    {
        public static Window GetCorresponingWindow(CarViewModel viewModel)
        {
            var windowAccessibility = new WindowAccessibility(viewModel);
            return windowAccessibility.CorrespondanteWindow;
        }

        private class WindowAccessibility
        {
            public Window CorrespondanteWindow { get; private set; }

            public WindowAccessibility(CarViewModel viewModel)
            {
                var windows = Application.Current.Windows.OfType<Window>();
                CorrespondanteWindow = (from window in windows
                                        where window.DataContext.Equals(viewModel)
                                        select window).First();
            }
        }
    }
}
