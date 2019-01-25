using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();

        public CreateTeamForm()
        {
            InitializeComponent();

            //CreateSampleData();

            WireUpLists();
        }

        private void CreateSampleData()
        {
            availableTeamMembers.Add(new PersonModel { Id = 1, FirstName = "Donatas", LastName = "Dajoras", EmailAddress = "daj@gmail.com", CellphoneNumber = "111-222-333" });
            availableTeamMembers.Add(new PersonModel { Id = 2, FirstName = "Donatas", LastName = "Bajoras", EmailAddress = "daj@mil.com", CellphoneNumber = "999-888-333" });
            availableTeamMembers.Add(new PersonModel { Id = 3, FirstName = "Rimas", LastName = "Kariniauskas", EmailAddress = "rim@gmail.com", CellphoneNumber = "123-555-777" });

            selectedTeamMembers.Add(new PersonModel { Id = 4, FirstName = "Jolanta", LastName = "Braz", EmailAddress = "braz@gmail.com", CellphoneNumber = "123-555-777" });
            selectedTeamMembers.Add(new PersonModel { Id = 5, FirstName = "Rimute", LastName = "Mik", EmailAddress = "mik@gmail.com", CellphoneNumber = "123-555-777" });



        }
        private void WireUpLists()
        {
            //need thios line becouse no refreshing
            selectTeamMemberDropDown.DataSource = null;

            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = "FullName";

            teamMembersListBox.DataSource = null;

            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember = "FullName";
        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel personModel = new PersonModel();
                personModel.FirstName = firstNameValue.Text;
                personModel.LastName = lastNameValue.Text;
                personModel.EmailAddress = emailValue.Text;
                personModel.CellphoneNumber = cellphoneValue.Text;

                personModel = GlobalConfig.Connection.CreatePerson(personModel);

                selectedTeamMembers.Add(personModel);

                WireUpLists();

                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                cellphoneValue.Text = "";
            }
            else
            {
                MessageBox.Show("You need to fill in all of the fields.");
            }

        }
        private bool ValidateForm()
        {
            if (firstNameValue.Text.Length == 0)
            {
                return false;
            }
            if (lastNameValue.Text.Length == 0)
            {
                return false;
            }
            if (emailValue.Text.Length == 0)
            {
                return false;
            }
            if (cellphoneValue.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)selectTeamMemberDropDown.SelectedItem;

            if (p != null)
            {
                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);

                WireUpLists();
            }

        }

        private void removeSelectedMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)teamMembersListBox.SelectedItem;

            if (p != null)
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);

                WireUpLists();
            }
        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel t = new TeamModel();
            t.TeamName = teamNameValue.Text;
            t.TeamMembers = selectedTeamMembers;

            t = GlobalConfig.Connection.CreateTeam(t);

            //TODO - If we aren't closing this form after creation, reset the form.
        }
    }
}
