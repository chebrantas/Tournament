﻿using System;
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
    public partial class CreateTournamentForm : Form, IPrizeRequester, ITeamRequester
    {
        List<TeamModel> availableTeams = GlobalConfig.Connection.GetTeam_All();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        List<PrizeModel> selectedPrizes = new List<PrizeModel>(); 
        public CreateTournamentForm()
        {
            InitializeComponent();

            WireUpLists();
        }

        private void WireUpLists()
        {
            //need thios line becouse no refreshing
            selectTeamDropDown.DataSource = null;

            selectTeamDropDown.DataSource = availableTeams;
            selectTeamDropDown.DisplayMember = "TeamName";


            tournamentTeamsListBox.DataSource = null;

            tournamentTeamsListBox.DataSource = selectedTeams;
            tournamentTeamsListBox.DisplayMember = "TeamName";


            prizesListBox.DataSource = null;

            prizesListBox.DataSource = selectedPrizes; ;
            prizesListBox.DisplayMember = "PlaceName";


        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel p = (TeamModel)selectTeamDropDown.SelectedItem;

            if (p != null)
            {
                availableTeams.Remove(p);
                selectedTeams.Add(p);

                WireUpLists();
            }
        }


        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            //Call the CreatePrizeForm
            CreatePrizeForm frm = new CreatePrizeForm(this);
            frm.Show();
             
        }

        //cia jau gauname atgal PrizeModel po uzpildymo ir formos uzsidarymo
        public void PrizeComplete(PrizeModel model)
        {
            //Get back from the form a PrizeModel
            //Take a PrizeModel and put it into our list of selected prizes
            selectedPrizes.Add(model);
            WireUpLists();
        }

        private void createNewTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm frm = new CreateTeamForm(this);
            frm.Show();
        }

        public void TeamComplete(TeamModel model)
        {
            selectedTeams.Add(model);
            WireUpLists();
        }

        private void removeSelectedPlayersButton_Click(object sender, EventArgs e)
        {
            TeamModel p = (TeamModel)tournamentTeamsListBox.SelectedItem;

            if (p != null)
            {
                selectedTeams.Remove(p);
                availableTeams.Add(p);

                WireUpLists();
            }
        }

        private void removeSelectedPrizeButton_Click(object sender, EventArgs e)
        {
            PrizeModel p = (PrizeModel)prizesListBox.SelectedItem;
            if (p!=null)
            {
                selectedPrizes.Remove(p);
                WireUpLists();//darbe uzbaigta
            }
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            //validate data
            decimal fee = 0;
            bool feeAcceptable= decimal.TryParse(entryFeeValue.Text,out fee);

            if (!feeAcceptable)
            {
                MessageBox.Show("You need to enter a valid Entry Fee.",
                    "Invalid Fee",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            
            //Create our tournament model
            TournamentModel tm = new TournamentModel();
            tm.TournamentName = tournamentNameValue.Text;
            tm.EntryFee = fee;
            tm.EnteredTeams = selectedTeams;
            tm.Prizes = selectedPrizes;

            //TODO Wire our matchups
            TournamentLogic.CreateRounds(tm);



            //Order our list randomly of teams
            //Check if it is big enough - if not , add in byes Exs(14 teams not good, need 16 so +2 byes)
            //need teams number 2*2*2*2 - 2^4 
            //Create our first round of matchups
            //Create every round after that 8 matchups - 4 matchups - 2 matchups - 1 matchup

            
            //Create Tournament entry+
            //Create all of the prizes entries+
            //Create all of the team entries+
            GlobalConfig.Connection.CreateTournament(tm);

        }
    }
}
