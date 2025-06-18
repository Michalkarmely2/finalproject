using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AskingForHelpDAL
    {
        HelpForElderlyEntities db=new HelpForElderlyEntities();
        public List<AskingForHelp> GetAskingForHelp()
        {
            return db.AskingForHelp.ToList();
        }
    }
}
