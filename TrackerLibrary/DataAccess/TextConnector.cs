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
        private const string PrizesFile = "PrizeModels.csv";
        private const string PeopleFile = "PersonModels.csv";
        private const string TeamFile = "TeamModels.csv";



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
            List<TeamModel> teams = TeamFile.FullFilePath().LoadFile().ConvertToTeamModels();

            //Find Max ID
            int currentId = 1;
            if (prizes.Count > 0)
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

        public List<PersonModel> GetPerson_All()
        {
            return PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }
    }
}
