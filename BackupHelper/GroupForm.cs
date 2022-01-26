using BackupHelper;
using BackupHelper.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BinanceAutoTrader
{
    public partial class GroupForm : Form
    {
        private readonly object OriginForm;
        private readonly Dictionary<ListViewItem, object> SelectedItems = new Dictionary<ListViewItem, object>();
        private List<ListViewGroup> ListViewGroups;

        public GroupForm(object originForm)
        {
            InitializeComponent();
            OriginForm = originForm;

            if (originForm.GetType() == typeof(FormProfileMenu))
                ConfigureProfileCamps();

            comboBoxSelectGroup.SelectedIndex = 0;
        }

        private void ConfigureProfileCamps()
        {
            FormProfileMenu profilesForm = OriginForm as FormProfileMenu;

            foreach (ListViewItem item in profilesForm.listViewProfile.SelectedItems)
                SelectedItems.Add(item, profilesForm.Profiles.Find(p => p.Id == (int)item.Tag));

            if (SelectedItems.Count == 1)
                labelSelected.Text = "Profile: " + ((Profile)SelectedItems.Values.First()).Id;
            else
                labelSelected.Text = "Selected: " + SelectedItems.Count + " profiles";

            ListViewGroups = profilesForm.listViewProfile.Groups.Cast<ListViewGroup>().ToList();

            if (profilesForm.listViewProfile.Groups.Count == 1)
                radioButtonNewGroup.Checked = true;

            comboBoxSelectGroup.Items.AddRange(ListViewGroups.Select(g => g.Header).ToArray());
        }

        private void RadioButtonSelectGroup_CheckedChanged(object sender, EventArgs e)
        {
            textBoxNewGroup.Enabled = !textBoxNewGroup.Enabled;
            comboBoxSelectGroup.Enabled = !comboBoxSelectGroup.Enabled;
        }

        private void ButtonDone_Click(object sender, EventArgs args)
        {
            try
            {
                ListViewGroup listViewGroup;

                if (radioButtonSelectGroup.Checked)
                {
                    listViewGroup = /*comboBoxSelectGroup.Name == "Ungrouped" ? null : */ListViewGroups[comboBoxSelectGroup.SelectedIndex];
                }
                else
                {
                    if (ListViewGroups.Find(g => g.Header == textBoxNewGroup.Text) != null)
                    {
                        MessageBox.Show("Group name already exists.");
                        return;
                    }

                    listViewGroup = new ListViewGroup(textBoxNewGroup.Text);

                    if (OriginForm.GetType() == typeof(FormProfileMenu))
                        ((FormProfileMenu)OriginForm).listViewProfile.Groups.Add(listViewGroup);
                }

                foreach (var pair in SelectedItems)
                {
                    pair.Key.Group = listViewGroup;
                    if (OriginForm.GetType() == typeof(FormProfileMenu))
                    {
                        Profile profile = pair.Value as Profile;
                        profile.GroupName = listViewGroup.Header;
                        DBAccess.UpdateProfile(profile);
                    }
                }

                Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
