using newproj.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newproj.viewmodel
{
    public class SharedViewModel
    {
        private List<Login> _usersList;

        public SharedViewModel()
        {
            _usersList = new List<Login>();
        }

        public List<Login> UsersList
        {
            get { return _usersList; }
            set { _usersList = value; }
        }


       
    }
}
