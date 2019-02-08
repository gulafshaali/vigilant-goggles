using Fen_Test.Web.Areas.App.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fen_Test.Web.Areas.App.Models.NavigationBar
{
    public class NavBarViewModel
    {
        public List<NavBarItemViewModel> NavBarItems { get; }
        //public List<FormsViewModel> FormsList { get; set; }
        public NavBarViewModel(List<NavBarItemViewModel> navBarItems)
        {
            NavBarItems = navBarItems;
        }
    }
}
