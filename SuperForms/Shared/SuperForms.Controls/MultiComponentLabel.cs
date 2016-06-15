using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Xamarin.Forms;

namespace SuperForms.Controls
{
    public class TextComponent : BindableObject
    {
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text),
                                    typeof(string),
                                    typeof(TextComponent),
                                    default(string));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }

    public class MultiComponentLabel : Label
    {
        public IList<TextComponent> Components { get; set; }

        public MultiComponentLabel()
        {
            var components = new ObservableCollection<TextComponent>();
            components.CollectionChanged += OnComponentsChanged;
            Components = components;
        }

        private void OnComponentsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            BuildText();
        }

        private void OnComponentPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            BuildText();
        }

        private void BuildText()
        {
            var formattedString = new FormattedString();
            foreach (var component in Components)
            {
                formattedString.Spans.Add(new Span { Text = component.Text });
                component.PropertyChanged -= OnComponentPropertyChanged;
                component.PropertyChanged += OnComponentPropertyChanged;
            }

            FormattedText = formattedString;
        }
    }
}
