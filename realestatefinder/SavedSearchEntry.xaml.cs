using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace realestatefinder
{
    /// <summary>
    /// Interaction logic for SavedSearchEntry.xaml
    /// </summary>
    public partial class SavedSearchEntry : UserControl
    {
        ViewSavedSearchesPopup p;
        String searchname;
        bool isEmailOpen = false;
        EmailTextFiledPlusSave email_field = new EmailTextFiledPlusSave();
        bool isSubscribed;
        string subEmail;
        SavableFilters s;

        public SavedSearchEntry(ViewSavedSearchesPopup parent, string name, SavableFilters search)
        {
            InitializeComponent();
            SearchName.Content = name;
            p = parent;
            searchname = name;            
            isSubscribed = Convert.ToBoolean(search.FilterDict["Sub"]);
            subEmail = search.FilterDict["Email"].ToString();
            s = search;

            SearchSubButton.FilterActive = isSubscribed;
            email_field.EmailTextField.email_text_field.Text = subEmail;
            EmailUpdated(null, null);
            email_field.EmailTextField.email_text_field.TextChanged += EmailUpdated;
            email_field.SaveEmail.Click += SaveClicked;
        }

        private void LoadSaveClick(object sender, EventArgs e)
        {
            SavableFilters saved_filters = new SavableFilters();
            saved_filters.ReadFilters(searchname);
            Filters.InitializeFilters(saved_filters);
            p.Cancel_Click(sender, e);
        }

        public void SubscribeButton_Click(object sender, RoutedEventArgs e)
        {
            isSubscribed = !isSubscribed;
            if (isSubscribed)
            {
                int position = p.SavedSearches.Items.IndexOf(this);
                p.SavedSearches.Items.Insert(position, email_field);
                isEmailOpen = true;
            }
            else
            {
                p.SavedSearches.Items.Remove(email_field);
                email_field.EmailTextField.email_text_field.Text = subEmail;
                isEmailOpen = false;
            }
        }

        private void Trash_Button_Click(object sender, EventArgs e)
        {
            TrashConfirmation.IsOpen = true;
        } 

        private void Trash_Confirmed(object sender, EventArgs e)
        {
            TrashConfirmation.IsOpen = false;
            if (isEmailOpen)
            {
                p.SavedSearches.Items.Remove(email_field);
            }
            p.SavedSearches.Items.Remove(this);
            MainPage.saved_searches.Remove(searchname);
            System.IO.File.Delete("SavedFilters/" + searchname + ".xml");
        }

        private void Trash_Cancelled(object sender, EventArgs e)
        {
            TrashConfirmation.IsOpen = false;
        }
        
        private void EmailUpdated(object sender, EventArgs e)
        {
            try
            {
                MailAddress m = new MailAddress(email_field.EmailTextField.email_text_field.Text);
                email_field.SaveEmail.IsEnabled = true;
            }
            catch
            {
                email_field.SaveEmail.IsEnabled = false;
            }
        }

        private void SaveClicked(object sender, EventArgs e)
        {
            subEmail = email_field.EmailTextField.email_text_field.Text;
            s.FilterDict["Email"] = subEmail;
            s.SaveFilters(searchname + ".xml");
            p.SavedSearches.Items.Remove(email_field);
            email_field.EmailTextField.email_text_field.Text = subEmail;
            isEmailOpen = false;
        }
    }
}
