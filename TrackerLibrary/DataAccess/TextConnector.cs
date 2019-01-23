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
    }
}
