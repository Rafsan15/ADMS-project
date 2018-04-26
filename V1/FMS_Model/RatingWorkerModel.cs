using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMS_Entities;

namespace FMS_Model
{
   public class RatingWorkerModel
    {
       
        public int CommunicationSkill { get; set; }

       
        public int OnTime { get; set; }

      
        public int OnBudget { get; set; }

      
        public int Behaviour { get; set; }

        public int Id { get; set; }

        public int PostId { get; set; }

        public List<int> UserId =new List<int>();

     
        public int Completeness { get; set; }

       public List<string>Name=new List<string>(); 

       public List<SelectedWorker>SelectedWorkers=new List<SelectedWorker>(); 

    }

}
