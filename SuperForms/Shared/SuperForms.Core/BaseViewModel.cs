using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SuperForms.Core
{
    public class BaseViewModel : BindableObject
    {
        private int _busyCount;

        public bool IsBusy => _busyCount > 0;

        public int BusyCount
        {
            get { return _busyCount; }
            set
            {
                if (_busyCount != value)
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Busy count can't be less than zero");
                    }

                    var previousBusyValue = IsBusy;
                    _busyCount = value;

                    if (previousBusyValue != IsBusy)
                    {
                        OnPropertyChanged(nameof(IsBusy));
                    }
                }
            }
        }
    }
}
