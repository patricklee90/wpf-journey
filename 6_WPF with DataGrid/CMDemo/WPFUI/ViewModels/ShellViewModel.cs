using Caliburn.Micro;
using DemoLibrary;
using DemoLibrary.Models;
using System;
using System.Linq;

namespace WPFUI {
    public class ShellViewModel : Screen
    {
        public BindableCollection<PersonModel> People { get; set; }

       
        public ShellViewModel()
        {
            DataAccess da = new DataAccess();
            People = new BindableCollection<PersonModel>(da.GetPeople());
        }

    }
}