using SuperForms.Controls.Pages;
using System;

namespace SuperForms.Samples
{
    public partial class CustomToolbarPage : PageWithCustomToolbar
    {
        private bool _isVisible;

        public bool IsItemVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                OnPropertyChanged();
            }
        }

        public CustomToolbarPage()
        {
            Controls.CustomToolbarItem item = new Controls.CustomToolbarItem();

            InitializeComponent();
        }

        public void OnButtonClicked(object sender, EventArgs args)
        {
            IsItemVisible = !IsItemVisible;
        }
    }
}
