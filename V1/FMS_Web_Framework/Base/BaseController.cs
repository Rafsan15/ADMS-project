﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FMS_Repository;
using FMS_Repository.Project;
using FMS_RepositoryOracle;

namespace FMS_Web_Framework.Base
{
    public class BaseController:Controller 
    {
        private static OwnerDAO _ownerDao;

        public static OwnerDAO ownerDao
        {
            get
            {
                if (_ownerDao == null)
                    _ownerDao = new OwnerDAO();
                return _ownerDao;
            }

        }

        private static WorkerDAO _workerDao;

        public static WorkerDAO workerDao
        {
            get
            {
                if (_workerDao == null)
                    _workerDao = new WorkerDAO();
                return _workerDao;
            }

        }

        private static UserDAO _userDao;
        public static UserDAO userDao
        {
            get
            {
                if (_userDao == null)
                    _userDao = new UserDAO();
                return _userDao;
            }
        }

        private static EducationalDAO _eduDao;

        public static EducationalDAO eduDao
        {
            get
            {
                if (_eduDao == null)
                    _eduDao = new EducationalDAO();
                return _eduDao;
            }

        }

        private static WorkHistoryDAO _workDao;

        public static WorkHistoryDAO workDao
        {
            get
            {
                if (_workDao == null)
                    _workDao = new WorkHistoryDAO();
                return _workDao;
            }

        }

        private static PostProjectDAO _postProjectDao;
        public static PostProjectDAO postProjectDao
        {
            get
            {
                if (_postProjectDao == null)
                    _postProjectDao = new PostProjectDAO();
                return _postProjectDao;
            }

        }

        private static ProjectSkillDAO _projectSkillDao;
        public static ProjectSkillDAO projectSkillDao
        {
            get
            {
                if (_projectSkillDao == null)
                    _projectSkillDao = new ProjectSkillDAO();
                return _projectSkillDao;
            }

        }

        private static ProjectSectionDAO _projectSectionDao;

        public static ProjectSectionDAO projectSectionDao
        {
            get
            {
                if (_projectSectionDao == null)
                    _projectSectionDao = new ProjectSectionDAO();
                return _projectSectionDao;
            }
        }

        private static SkillsDAO _skillsDao;
        public static SkillsDAO skillsDao
    {
        get
        {
            if (_skillsDao == null)
                _skillsDao = new SkillsDAO();
            return _skillsDao;
        }

    }

        private static ResponseToJobDAO _response;
        public static ResponseToJobDAO response
        {
            get
            {
                if (_response == null)
                    _response = new ResponseToJobDAO();
                return _response;
            }

        }
        private static SelectedWorkerDAO _selectedWorker;
        public static SelectedWorkerDAO selectedWorkerDao
        {
            get
            {
                if (_selectedWorker == null)
                    _selectedWorker = new SelectedWorkerDAO();
                return _selectedWorker;
            }

        }
        private static CommunicationDAO _communicationDao;

        public static CommunicationDAO CommunicationDao
        {
            get
            {
                if (_communicationDao == null)
                    _communicationDao = new CommunicationDAO();
                return _communicationDao;
            }



        }

        private static RatingOwnerDAO _ratingOwner;
        public static RatingOwnerDAO ratingOwnerDao
        {
            get
            {
                if (_ratingOwner == null)
                    _ratingOwner = new RatingOwnerDAO();
                return _ratingOwner;
            }

        }

        private static RatingWorkerDAO _ratingWorkerDao;
        public static RatingWorkerDAO ratingWorkerDao
        {
            get
            {
                if (_ratingWorkerDao == null)
                    _ratingWorkerDao = new RatingWorkerDAO();
                return _ratingWorkerDao;
            }

        }


    }
}
