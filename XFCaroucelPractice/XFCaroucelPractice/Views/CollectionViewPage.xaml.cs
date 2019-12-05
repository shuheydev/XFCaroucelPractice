using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFCaroucelPractice.Models;

namespace XFCaroucelPractice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionViewPage : ContentPage
    {
        private ObservableCollection<Person> _people = new ObservableCollection<Person>();
        public ObservableCollection<Person> People
        {
            get => _people;
            set
            {
                _people = value;
                OnPropertyChanged(nameof(People));
            }
        }

        private int _remainingItemsThreshold;
        public int RemainingItemsThreshold
        {
            get => _remainingItemsThreshold;
            set
            {
                _remainingItemsThreshold = value;
                OnPropertyChanged(nameof(RemainingItemsThreshold));
            }
        }

        public CollectionViewPage()
        {
            InitializeComponent();

            for (int i = 1; i < 20; i++)
            {
                People.Add(new Person
                {
                    FirstName = $"FirstName{i}",
                    LastName = $"LastName{i}",
                });
            }

            RemainingItemsThreshold = 10;

            RemainingItemsThresholdReachedCommand = new Command(ExecuteRemainingItemsThresholdReachedCommand);

            BindingContext = this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteRemainingItemsThresholdReachedCommand(object obj)
        {
            int currentCount = People.Count;
            int increaseCount = 20;
            for (int i = currentCount + 1; i < currentCount + increaseCount; i++)
            {
                //指定した個数に達したらそれ以上は増やさない
                if (i > 100)
                {
                    //増分読み込みを無効にする.
                    RemainingItemsThreshold = 0;
                    return;
                }

                People.Add(new Person
                {
                    FirstName = $"FirstName{i}",
                    LastName = $"LastName{i}",
                });
            }
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var prev = e.PreviousSelection;
            var typePrev = prev.GetType();
            var current = e.CurrentSelection;
            var typeCurrent = current.GetType();
        }

        public Command RemainingItemsThresholdReachedCommand { get; set; }

        private void CollectionView_RemainingItemsThresholdReached(object sender, EventArgs e)
        {
            int currentCount = People.Count;
            int increaseCount = 20;
            for (int i = currentCount + 1; i < currentCount + increaseCount; i++)
            {
                //指定した個数に達したらそれ以上は増やさない
                if (i > 100)
                {
                    //増分読み込みを無効にする.
                    RemainingItemsThreshold = -1;
                    return;
                }

                People.Add(new Person
                {
                    FirstName = $"FirstName{i}",
                    LastName = $"LastName{i}",
                });
            }
        }
    }
}