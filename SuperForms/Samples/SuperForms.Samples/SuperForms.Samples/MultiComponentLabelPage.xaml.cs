using SuperForms.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SuperForms.Samples
{
    public partial class MultiComponentLabelPage : ContentPage
    {
        private string _currentTime;

        public string CurrentTime
        {
            get { return _currentTime; }
            set
            {
                _currentTime = value;
                OnPropertyChanged();
            }
        }

        public MultiComponentLabelPage()
        {
            // Workaround for fixing IOFileNotFound assenbly
            MultiComponentLabel l = new MultiComponentLabel();

            InitializeComponent();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                CurrentTime = DateTime.Now.ToString("hh : mm : ss");
                return true;
            });
        }
    }
}
