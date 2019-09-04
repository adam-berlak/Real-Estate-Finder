using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace realestatefinder
{
    /// <summary>
    /// Interaction logic for ViewSavedSearchesPopup.xaml
    /// </summary>
    public partial class ViewSavedSearchesPopup
    {
        ItemsControl SideBar;

        public ViewSavedSearchesPopup(ItemsControl sidebar)
        {
            InitializeComponent();
            SideBar = sidebar;
            foreach (string search in MainPage.saved_searches.Keys)
            {
                SavedSearches.Items.Add(new SavedSearchEntry(this, search, MainPage.saved_searches[search]));
            }
        }

        public void Cancel_Click(object sender, EventArgs e)
        {
            SideBar.Items.Remove(this);
            MainPage.ViewSavedSearchesOpen = false;
        }
    }
}
