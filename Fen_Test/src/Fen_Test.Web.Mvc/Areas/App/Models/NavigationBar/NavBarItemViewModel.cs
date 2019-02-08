using Fen_Test.Web.Areas.App.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fen_Test.Web.Areas.App.Models.NavigationBar
{
    public class NavBarItemViewModel
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public string URL { get; set; }
        public string Icon { get; set; }

        public List<FormsViewModel> FormsList { get; set; }
        //-------Lines to uncomment while using View component logic
        //public NavBarItemViewModel(string text, string url, string icon, long id)
        //{
        //    Text = text;
        //    URL = url;
        //    Icon = icon;
        //    Id = id;
        //    //FormsList = formdata;

        //}
    }
}
