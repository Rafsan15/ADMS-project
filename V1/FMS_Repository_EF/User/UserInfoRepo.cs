﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FMS_Entities;
using FMS_Framework.Helper;
using FMS_Framework.Object;
using UserInfo = FMS_Entities.UserInfo;

namespace FMS_Repository_EF
{
    class UserInfoRepo:BaseRepo
    {
       
        
    public Result<UserInfo> Save(UserInfo userinfo)
        {
            var result = new Result<UserInfo>();
            try
            {
                var objtosave = DbContext.UserInfos.FirstOrDefault(u => u.UserId == userinfo.UserId);
                if (objtosave == null)
                {
                    objtosave = new UserInfo();
                    DbContext.UserInfos.Add(objtosave);
                }
            
                objtosave.FristName = userinfo.FristName;
                objtosave.LastName = userinfo.LastName;
                objtosave.Email = userinfo.Email;
                objtosave.Password = userinfo.Password;
                objtosave.DateofBrith = userinfo.DateofBrith;
                objtosave.JoinDate = userinfo.JoinDate;
                objtosave.ProPic = userinfo.ProPic;
                objtosave.City = userinfo.City;
                objtosave.State = userinfo.State;
                objtosave.Country = userinfo.Country;
                objtosave.UserType = userinfo.UserType;
                objtosave.Balance = userinfo.Balance;
            
            

                if (!IsValid(objtosave, result))
                {
                    return result;
                }
                DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        private bool IsValid(UserInfo obj, Result<UserInfo> result)
        {
            if (!ValidationHelper.IsStringValid(obj.FristName))
            {
                result.HasError = true;
                result.Message = "Invalid FristName";
                return false;
            }
            if (!ValidationHelper.IsStringValid(obj.LastName))
            {
                result.HasError = true;
                result.Message = "Invalid LastName";
                return false;
            }

            if (!ValidationHelper.IsStringValid(obj.Email))
            {
                result.HasError = true;
                result.Message = "Invalid Email";
                return false;
            }
            if (!ValidationHelper.IsStringValid(obj.Password))
            {
                result.HasError = true;
                result.Message = "Invalid Password";
                return false;
            }
             if (!ValidationHelper.IsStringValid(obj.DateofBrith.ToString()))
            {
                result.HasError = true;
                result.Message = "Invalid DateofBrith";
                return false;
            } if (!ValidationHelper.IsStringValid(obj.JoinDate.ToString()))
            {
                result.HasError = true;
                result.Message = "Invalid JoinDate";
                return false;
            } if (!ValidationHelper.IsStringValid(obj.ProPic))
            {
                result.HasError = true;
                result.Message = "Invalid ProPic";
                return false;
            } if (!ValidationHelper.IsStringValid(obj.City))
            {
                result.HasError = true;
                result.Message = "Invalid City";
                return false;
            } if (!ValidationHelper.IsStringValid(obj.State))
            {
                result.HasError = true;
                result.Message = "Invalid State";
                return false;
            } if (!ValidationHelper.IsStringValid(obj.Country))
            {
                result.HasError = true;
                result.Message = "Invalid Country";
                return false;
            } if (!ValidationHelper.IsStringValid(obj.UserType))
            {
                result.HasError = true;
                result.Message = "Invalid UserType";
                return false;
            } if (!ValidationHelper.IsStringValid(obj.Balance.ToString()))
            {
                result.HasError = true;
                result.Message = "Invalid Balance";
                return false;
            }
         
          
            return true;
        }

        public Result<List<UserInfo>> GetAll(string key="")
        {
            var result = new Result<List<UserInfo>>(){Data = new List<UserInfo>()};

            try
            {
                IQueryable<UserInfo> query = DbContext.UserInfos;

                if (ValidationHelper.IsIntValid(key))
                {
                    query = query.Where(q => q.UserId == Int32.Parse(key));
                }

                if (ValidationHelper.IsStringValid(key))
                {
                    query = query.Where(q => q.FristName.Contains(key));

                }

                if (ValidationHelper.IsStringValid(key))
                {
                    query = query.Where(q => q.LastName.Contains(key));

                }

                if (ValidationHelper.IsStringValid(key))
                {
                    query = query.Where(q => q.Email.Contains(key));

                }


                if (ValidationHelper.IsStringValid(key))
                {
                    query = query.Where(q => q.Password.Contains(key));

                }
                 if (ValidationHelper.IsStringValid(key))
                 {
                     query = query.Where(q => q.DateofBrith.ToString().Contains(key));

                }
                 if (ValidationHelper.IsStringValid(key))
                {
                    query = query.Where(q => q.JoinDate.ToString().Contains(key));

                }
                 if (ValidationHelper.IsStringValid(key))
                {
                    query = query.Where(q => q.ProPic.Contains(key));

                }
                 if (ValidationHelper.IsStringValid(key))
                {
                    query = query.Where(q => q.City.Contains(key));

                }
                 if (ValidationHelper.IsStringValid(key))
                {
                    query = query.Where(q => q.State.Contains(key));

                }
                 if (ValidationHelper.IsStringValid(key))
                {
                    query = query.Where(q => q.Country.Contains(key));

                }
                 if (ValidationHelper.IsStringValid(key))
                {
                    query = query.Where(q => q.UserType.Contains(key));

                }
                 if (ValidationHelper.IsStringValid(key))
                {
                    query = query.Where(q => q.Balance.Equals(Int32.Parse(key)));

                }
                result.Data = query.ToList();
            }
            catch (Exception e)
            {
                result.HasError = true;
                result.Message = e.Message;
               
               
            }
            return result ;
        }

        public Result<UserInfo> GetByID(int id )
        {
            var result = new Result<UserInfo>();

            try
            {
                var obj = DbContext.UserInfos.FirstOrDefault(c => c.UserId == id);
                if (obj == null)
                {
                    result.HasError = true;
                    result.Message = "Invalid UserID";
                    return result;


                }
                result.Data = obj;
            }
            catch (Exception e)
            {
                result.HasError = true;
                result.Message = e.Message;


            }
            return result;
        }

        public Result<bool> Delete(int id)
        {
            var result = new Result<bool>();

            try
            {
                var objtodelete = DbContext.UserInfos.FirstOrDefault(c => c.UserId == id);
                if (objtodelete == null)
                {
                    result.HasError = true;
                    result.Message = "Invalid UserID";
                    return result;


                }

                DbContext.UserInfos.Remove(objtodelete);
                DbContext.SaveChanges();

            }
            catch (Exception e)
            {
                result.HasError = true;
                result.Message = e.Message;


            }
            return result;
        }

        private bool IsValidToSave(UserInfo obj, Result<UserInfo> result)
        {
            if(!ValidationHelper.IsIntValid(obj.UserId.ToString()))
            {
                result.HasError = true;
                result.Message = "Invalid UserID";
                return false;

            }
            if (DbContext.UserInfos.Any(u =>u.Email == obj.Email))
            {

                result.HasError= true;
                result.Message = "Email Exists";
                return false;



            }
            return true;

        }

       

    }


    }

