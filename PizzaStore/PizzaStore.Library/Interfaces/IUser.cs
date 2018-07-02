using PizzaStore.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library.Interfaces
{
    public interface IUser
    {
        string firstName { get; set; }
        string lastName { get; set; }
        string favLocation { get; set; }

        string LogIn();
        void ChangeName();
        void ChangeLocation();
    }
}
