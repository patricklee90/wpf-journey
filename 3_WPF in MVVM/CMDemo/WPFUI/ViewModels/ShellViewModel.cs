using Caliburn.Micro;
using System;
using WPFUI.Models;
using WPFUI.ViewModels;

namespace WPFUI {
    public class ShellViewModel : Conductor<object> 
    {
        private string _firstName = "Tim";
        private string _lastName;
        private PersonModel _selectedPerson;
        private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();

        public ShellViewModel()
        {
            People.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
            People.Add(new PersonModel { FirstName = "Bill", LastName = "Jones" });
            People.Add(new PersonModel { FirstName = "Sue", LastName = "Storm" });
        }

        public string FirstName
        {
            get 
            {
                return _firstName; 
            }
            set 
            { 
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string LastName
        {
            get 
            { 
                return _lastName; 
            }
            set 
            { 
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public BindableCollection<PersonModel> People
        {
            get 
            { 
                return _people; 
            }
            set 
            { 
                _people = value; 
            }
        }

        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set 
            { 
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
            }
        }

        public bool CanClearText(string firstName, string lastName) // => !String.IsNullOrEmpty(firstName) && !String.IsNullOrEmpty(lastName);
        {
            if(String.IsNullOrEmpty(firstName) && String.IsNullOrEmpty(lastName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ClearText(string firstName, string lastName)
        {

            FirstName = "";
            LastName = "";
        }

        public void LoadPageOne()
        {
            ActivateItem(new FirstChildViewModel());
        }

        public void LoadPageTwo()
        {
            ActivateItem(new SecondChildViewModel());
        }
    }
}