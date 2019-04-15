using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        //TODO refactor this to be in 1 place
        private const string PrizesFile = "PrizeModels.csv";
        private const string PeopleFile = "PersonModels.csv";
        private const string TeamFile = "TeamModels.csv";
        private const string TournamentFile = "TournamentModels.csv";
        private const string MatchupFile = "MatchupModels.csv";
        private const string MatchupEntryFile = "MatchupEntryModels.csv";


        public PersonModel CreatePerson(PersonModel model)
        {
            //Load text file
            //Convert the text to List<PersonModel>
            List<PersonModel> people = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();

            //Find Max ID
            int currentId = 1;
            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(p => p.Id).First().Id + 1;
            }
            model.Id = currentId;

            //Add new record with the new ID MaxId+1
            people.Add(model);

            //Convert Prizes to List<string>
            //Save the List<string> to the text file
            people.SaveToPeopleFile(PeopleFile);

            return model;
        }

        //TODO - Make CreatePrize method actually save to the text file.
        public PrizeModel CreatePrize(PrizeModel model)
        {
            //Load text file
            //Convert the text to List<PrizeModel>
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            //Find Max ID
            int currentId = 1;
            if (prizes.Count>0)
            {
                currentId = prizes.OrderByDescending(p => p.Id).First().Id + 1;
            }
            model.Id = currentId;

            //Add new record with the new ID MaxId+1
            prizes.Add(model);

            //Convert Prizes to List<string>
            //Save the List<string> to the text file
            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }

        public TeamModel CreateTeam(TeamModel model)
        {
            //Load text file
            //Convert the text to List<PrizeModel>
            List<TeamModel> teams = TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(PeopleFile);

            //Find Max ID
            int currentId = 1;
            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(p => p.Id).First().Id + 1;
            }
            model.Id = currentId;

            //Add new record with the new ID MaxId+1
            teams.Add(model);

            //Convert Prizes to List<string>
            //Save the List<string> to the text file
            teams.SaveToTeamFile(TeamFile);

            return model;
        }

        public TournamentModel CreateTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = TournamentFile
                .FullFilePath()
                .LoadFile()
                .ConvertToTournamentModels(TeamFile,PeopleFile,PrizesFile);

            //Find Max ID
            int currentId = 1;
            if (tournaments.Count > 0)
            {
                currentId = tournaments.OrderByDescending(tm => tm.Id).First().Id + 1;
            }
            model.Id = currentId;

            //operate on  one specific model or list of models
            model.SaveRoundsToFile(MatchupFile, MatchupEntryFile);

            //Add new record with the new ID MaxId+1
            tournaments.Add(model);

            //Convert Prizes to List<string>
            //Save the List<string> to the text file
            tournaments.SaveToTournamentFile(TournamentFile);

            return model;
        }

        public List<PersonModel> GetPerson_All()
        {
            return PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        public List<TeamModel> GetTeam_All()
        {
            return TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(PeopleFile);
        }

        public List<TournamentModel> GetTournament_All()
        {
           return TournamentFile
                .FullFilePath()
                .LoadFile()
                .ConvertToTournamentModels(TeamFile, PeopleFile, PrizesFile);
        }
    }
}
