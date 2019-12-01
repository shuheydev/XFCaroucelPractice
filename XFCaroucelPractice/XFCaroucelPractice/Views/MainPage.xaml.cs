﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFCaroucelPractice.Models;

namespace XFCaroucelPractice.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Person> People { get; set; } = new ObservableCollection<Person>();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            for(int i=1;i<100;i++)
            {
                People.Add(new Person
                {
                    FirstName = $"FirstName{i}",
                    LastName = $"LastName{i}",
                });
            }
        }
    }
}
