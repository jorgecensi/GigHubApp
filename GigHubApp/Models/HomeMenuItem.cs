using System;
using System.Collections.Generic;
using System.Text;

namespace GigHubApp.Models
{
    public enum MenuItemType
    {
        Browse,
        Gigs,
        About,
        Logout
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
