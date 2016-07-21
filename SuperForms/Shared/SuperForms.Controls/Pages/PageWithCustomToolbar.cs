using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace SuperForms.Controls.Pages
{
    public class PageWithCustomToolbar : ContentPage
    {
        public IList<CustomToolbarItem> CustomToolbar { get; private set; }

        public PageWithCustomToolbar()
        {
            var items = new ObservableCollection<CustomToolbarItem>();
            items.CollectionChanged += ToolbarItemsChanged;

            CustomToolbar = items;
        }

        private void ToolbarItemsChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ToolbarItems.Clear();

            foreach (var item in CustomToolbar)
            {
                item.PropertyChanged += OnToolbarItemPropertyChanged;
                if (item.IsVisible)
                {
                    ToolbarItems.Add(item);
                }
            }
        }

        private void OnToolbarItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == CustomToolbarItem.IsVisibleProperty.PropertyName)
            {
                UpdateToolbar();
            }
        }

        private void UpdateToolbar()
        {
            foreach (var item in CustomToolbar)
            {
                if (item.IsVisible)
                {
                    ToolbarItems.Add(item);
                }
                else
                {
                    ToolbarItems.Remove(item);
                }
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ToolbarItems.Clear();
            CustomToolbar.Clear();
            foreach (var item in CustomToolbar)
            {
                item.PropertyChanged -= OnToolbarItemPropertyChanged;
            }
        }
    }
}
