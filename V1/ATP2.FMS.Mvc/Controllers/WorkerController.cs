using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FMS_Entities;
using FMS_Framework;
using FMS_Model;
using FMS_Web_Framework.Base;
using Newtonsoft.Json;

namespace ATP2.FMS.Mvc.Controllers
{
    public class WorkerController : BaseController
    {
        // GET: Worker
        public ActionResult WorkerProfile()
        {

            var workerInfo = userDao.GetById(JsonConvert.DeserializeObject<UserInfo>(User.Identity.Name).UserId);
            //   var ownerCMP = workerDao.GetByID(JsonConvert.DeserializeObject<UserInfo>(User.Identity.Name).UserId);
            var workerVM = new Worker();
            var workerRate = ratingWorkerDao.GetAll1(JsonConvert.DeserializeObject<UserInfo>(User.Identity.Name).UserId);
            int ti = 0;
            int bu = 0;
            int beh = 0;
            int com = 0;
            int cmp = 0;
            foreach (var p in workerRate)
            {
                ti = p.OnTime + ti;
                bu = p.OnBudget + ti;
                beh = p.Behaviour + ti;
                com = p.CommunicationSkill + ti;
                cmp = p.Completeness + ti;
            }

            ti = ti / workerRate.Count;
            bu = bu / workerRate.Count;
            beh = beh / workerRate.Count;
            com = com / workerRate.Count;
            cmp = cmp / workerRate.Count;
            workerVM.Balance = workerInfo.Data.Balance;
            workerVM.City = workerInfo.Data.City;
            //  workerVM.RatePerHour = ownerCMP.Data.RatePerHour;
            //workerVM.CompanyName = ownerCMP.Data.CompanyName;
            workerVM.Country = workerInfo.Data.Country;
            workerVM.DateofBrith = workerInfo.Data.DateofBrith;
            workerVM.Email = workerInfo.Data.Email;
            workerVM.FristName = workerInfo.Data.FristName;
            workerVM.LastName = workerInfo.Data.LastName;
            workerVM.JoinDate = workerInfo.Data.JoinDate;
            workerVM.ProPic = workerInfo.Data.ProPic;
            workerVM.State = workerInfo.Data.State;
            workerVM.UserId = workerInfo.Data.UserId;
            workerVM.UserType = workerInfo.Data.UserType;
            workerVM.TotalRatings = workerInfo.Data.Totalratings;
            workerVM.Onbudget = bu;
            workerVM.Ontime = ti;
            workerVM.Behaviour = beh;
            workerVM.Communicationskill = com;
            workerVM.Completeness = cmp;
            var result = selectedWorkerDao.GetAllUser(CurrentUser.User.UserId);
            foreach (var selectedWorker in result)
            {
                var result2 = postProjectDao.GetByID(selectedWorker.PostId);
             
                if(result2.Data.Flag==0)
                    workerVM.PostAProjects.Add(result2.Data);
               
            }


           // var result3 = selectedWorkerDao.GetByID(CurrentUser.User.UserId);
         
            return View(workerVM);
        }

        public ActionResult EditProfileWorker()
        {
            //
            var result = userDao.GetById(CurrentUser.User.UserId);
            var workerVM = new Worker();
            workerVM.UserInfo = result.Data;
            var result2 = workerDao.GetByID(CurrentUser.User.UserId);
            workerVM.RatePerHour = result2.Data.RatePerHour;
            workerVM.EarnedMoney = result2.Data.EarnedMoney;


            return View(workerVM);
        }

        [HttpPost]
        public ActionResult EditProfileWorker(Worker workerVM)
        {
            UserInfo u = new UserInfo();
            u.UserId = CurrentUser.User.UserId;
            if (workerVM.ConfirmPassword == null)
            {
                u.Password = CurrentUser.User.Password;

            }
            else
            {
                u.Password = workerVM.ConfirmPassword;
            }
            u.FristName = workerVM.FristName;
            u.LastName = workerVM.LastName;
            // u.DateofBrith = ownerVM.DateofBrith;
            u.Country = workerVM.Country;
            u.City = workerVM.City;
            u.State = workerVM.State;
            var result = userDao.Save(u);

            WorkerInfo o = new WorkerInfo();
            o.RatePerHour = workerVM.RatePerHour;
            o.EarnedMoney = workerVM.EarnedMoney;
            o.UserId = CurrentUser.User.UserId;
            var result2 = workerDao.Save(o);


            return RedirectToAction("WorkerProfile");
        }

        public ActionResult Deleteacount()
        {
            var result = userDao.Delete(CurrentUser.User.UserId);
            return RedirectToAction("RegisterForm", "User");
        }

        public ActionResult WorkProgressWoker()
        {
            WorkProgressModel work = new WorkProgressModel();

            //  work.RequestedMemberModel= getall();
            //postid
            var result = projectSectionDao.GetAll(1);
            //foreach (var section in result)
            //{
            //    work.USectionName.Add(section.SectionName+"1");
            //}
            work.ProjectSection = result;
            //postid
            var result2 = selectedWorkerDao.GetAll(1);
            work.SelectedWorkers = result2;
            foreach (var p in result2)
            {
                var result3 = userDao.GetById(p.UserId);
                work.Name.Add(result3.Data.FristName + " " + result3.Data.LastName);

            }
            work.Postid = 1;

            return View(work);
        }
      

        //[HttpPost]
        //public ActionResult WorkProgress(ProjectSection projectSection)
        //{

        //    try
        //    {

        //        var result = projectSectionDao.Save(projectSection);
        //        if (result.HasError)
        //        {
        //            ViewBag.Message = result.Message;
        //            return View("WorkProgress");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return RedirectToAction("WorkProgress");
        //}

        public ActionResult ProjectList()
        {
          
      
            var result = postProjectDao.GetAll();
            var a = result.Where(d => d.Flag == 0);

            var result2 = skillsDao.GetAll();
            ProjectListModel projectListModel=new ProjectListModel();
            projectListModel.PostAProjects = a.ToList();
            projectListModel.Skills = result2;

            return View(projectListModel);
      
        }

        [HttpPost]
        public ActionResult ProjectList(ProjectSkills skill)
        {
            ProjectListModel projectListModel = new ProjectListModel();

            var result = projectSkillDao.GetAllskill(skill.SkillID);
            foreach (var projectSkillse in result)
            {
                var result2 = postProjectDao.GetByID(projectSkillse.PostID);
                projectListModel.PostAProjects.Add(result2.Data);

            }
            var result3 = skillsDao.GetAll();
            projectListModel.Skills = result3;
            return View(projectListModel);
        }

        public ActionResult ProjectList1()
        {

            return RedirectToAction("ProjectList");
        }
    }
}