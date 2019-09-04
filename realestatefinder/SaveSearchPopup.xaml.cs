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
using System.Net.Mail;

namespace realestatefinder
{
    /// <summary>
    /// Interaction logic for SaveSearchPopup.xaml
    /// </summary>
    public partial class SaveSearchPopup
    {
        bool email_field_visible = false;
        EmailTextField email_field = new EmailTextField();
        ItemsControl SideBar;
        bool name_valid = false;
        bool email_valid = false;

        public SaveSearchPopup(ItemsControl sidebar)
        {
            InitializeComponent();
            SideBar = sidebar;
            email_field.email_text_field.TextChanged += EmailChanged;
            SearchName.TextChanged += NameChanged;
            SaveButton.IsEnabled = false;
        }

        public void EmailChanged(object sender, EventArgs e)
        {
            try
            {
                MailAddress m = new MailAddress(email_field.email_text_field.Text);
                email_valid = true;
                SaveEnabled();
            }
            catch
            {
                email_valid = false;
                SaveEnabled();
            }
        }

        public void NameChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SearchName.Text))
            {
                name_valid = false;
                SaveEnabled();
            }
            else
            {
                name_valid = true;
                SaveEnabled();
            }
        }

        private void SaveEnabled()
        {
            if (email_field_visible)
            {
                SaveButton.IsEnabled = email_valid && name_valid;
            }
            else
            {
                SaveButton.IsEnabled = name_valid;
            }
            
        }

        private void SubscribeButton_Click(object sender, RoutedEventArgs e)
        {
            if (email_field_visible)
            {
                this.Items.Remove(email_field);
                email_field_visible = false;
                SaveEnabled();
            }
            else
            {
                this.Items.Insert(1, email_field);
                email_field_visible = true;
                SaveEnabled();
            }
        }

        public void Cancel_Click(object sender, EventArgs e)
        {
            SideBar.Items.Remove(this);
            MainPage.SaveSearchOpen = false;
        }

        public void Save_Click(object sender, EventArgs e)
        {
            SavableFilters saved_filters = new SavableFilters();
            saved_filters.FilterDict.Add("Sub", SearchSubButton.FilterActive);
            saved_filters.FilterDict.Add("Email", email_field.email_text_field.Text);
            MainPage.saved_searches.Add(SearchName.Text, saved_filters);
            saved_filters.SaveFilters(SearchName.Text + ".xml");
            Cancel_Click(sender, e);
        }
    }
}
