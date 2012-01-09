using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Net;
using Newtonsoft.Json;
using WindowsPhoneApplication1.Models;

namespace WindowsPhoneApplication1
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        { 
            get
            {
                return _sampleProperty;
            }
            set
            {
                _sampleProperty = value;
                NotifyPropertyChanged("SampleProperty");
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            WebClient client = new WebClient();
            client.DownloadStringAsync(new Uri("http://localhost:22524/Source/GetTech"));
            client.DownloadStringCompleted += (sender, e) => {
                //MessageBox.Show(e.Result);
                var query =  JsonConvert.DeserializeObject<List<Tech>>(e.Result);

                foreach (var item in query)
                {
                    string imagUri = string.Format("{0}{1}","http://localhost:22524/Source/GetImage?name=",item.ImagePath);
                    Items.Add(new ItemViewModel() { ImageSrc = imagUri,LineOne = item.Title, LineTwo = "Maecenas praesent accumsan" });
                }
            };
            this.IsDataLoaded = true;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}