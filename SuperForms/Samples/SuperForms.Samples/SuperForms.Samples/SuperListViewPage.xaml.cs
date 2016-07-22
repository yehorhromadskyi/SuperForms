using SuperForms.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace SuperForms.Samples
{
    public partial class SuperListViewPage : ContentPage
    {
        private ObservableCollection<string> _items;

        public ObservableCollection<string> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public SuperListViewPage()
        {
            var list = new SuperListView();

            InitializeComponent();

            var items = new List<string>(10);
            for (int i = 1; i <= 10; i++)
            {
                items.Add($"Item {i}");
            }

            Items = new ObservableCollection<string>(items);
        }
    }
}
