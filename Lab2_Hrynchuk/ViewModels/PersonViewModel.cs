using Lab2_Hrynchuk.Models;
using Lab2_Hrynchuk.Tools;
using Lab2_Hrynchuk.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace Lab2_Hrynchuk.ViewModels
{
    internal class PersonViewModel
    {
        private Person _person = new Person("", "", "");
        private RelayCommand<object> _proceedCommand;

        public string FirstName
        {
            get => _person.FirstName;
            set { _person.FirstName = value; }
        }

        public string LastName
        {
            get => _person.LastName;
            set { _person.LastName = value; }
        }

        public string EmailAddress
        {
            get => _person.EmailAddress;
            set { _person.EmailAddress = value; }
        }

        public DateTime BirthDate
        {
            get => _person.BirthDate;
            set { _person.BirthDate = value; }
        }

        public string NameDisplay => $"You are {_person.FirstName} {_person.LastName}";
        public string EmailDisplay => $"Your Email  -  {_person.EmailAddress}";
        public string BirthDateDisplay => $"Your Birth Date  -  {_person.BirthDate.ToShortDateString()}";
        public string IsAdultDisplay => "Is Adult  -  " + (_person.IsAdult ? "Yes" : "No");
        public string SunSignDisplay => $"Sun Sign  -  {_person.SunSign}";
        public string ChineseSignDisplay => $"Chinese Sign  -  {_person.ChineseSign}";
        public string IsBirthdayDisplay => "Is Today Birthday  -  " + (_person.IsBirthday ? "Yes" : "No");

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ??= new RelayCommand<object>(_ => Proceed(), CanExecute);
            }
        }

        private bool PersonAgeValidation()
        {
            int userAge = _person.CalcPersonAge(_person.BirthDate);
            if (userAge < 0)
            {
                MessageBox.Show($"Selected Date: {_person.BirthDate.ToShortDateString()} is wrong! \n You are not born yet!", "Wrong Date of Birth", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (userAge > 135)
            {
                MessageBox.Show($"Selected Date: {_person.BirthDate.ToShortDateString()} is wrong \n or you over 135 years old which is not possible!", "Wrong Date of Birth", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        private async void Proceed()
        {
            if (PersonAgeValidation())
            {
                if (_person.IsBirthday)
                {
                    MessageBox.Show($"Happy Birthday!\n We wish you all the best!", "Happy Birthday!", MessageBoxButton.OK);
                }

                await ShowOutputWindow();
            }
        }

        private async Task ShowOutputWindow()
        {
            Views.OutputView outputWindow = new Views.OutputView();
            outputWindow.DataContext = this;
            outputWindow.Show();
        }

        private bool CanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_person.FirstName) && 
                   !String.IsNullOrWhiteSpace(_person.LastName) && 
                   !String.IsNullOrWhiteSpace(_person.EmailAddress) &&
                   _person.BirthDate != null;
        }

    }
}