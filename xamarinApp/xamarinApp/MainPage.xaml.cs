using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace xamarinApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]


    public class BindableBase:INotifyPropertyChanged
    {
        protected BindableBase()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnProretyChaned([CallerMemberName]string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if(object.Equals(field, value)) { return false; }

            field = value;

            this.OnProretyChaned(propertyName);
            return true;
        }
    }

    public class MyPageViewModel:BindableBase
    {
        private double sliderValue;

        public double SliderValue
        {
            get { return this.sliderValue; }

            set { this.SetProperty(ref this.sliderValue, value); this.OnProretyChaned(nameof(LabelValue)); }
        }

        public string LabelValue => string.Format("This is slider value '{0}'", this.SliderValue);
    }

    

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            
        }

        
    }
}
