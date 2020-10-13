using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgriDoktorum.WebApp.Models.Entity;
using AgriDoktorum.WebApp.Models.EntityDb;
using AgriDoktorum.WebApp.Models.ViewModel.Admin;

namespace AgriDoktorum.WebApp.BusinessLayer
{
    public class AdminManager
    {
        private Repository<AdUser> _repoUser = new Repository<AdUser>();

        public BusinessLayerResult<AdUser> RegisterUser(RegisterViewModel model)
        {
            AdUser user = _repoUser.Find(x => x.Username == model.Username || x.Email == model.Email);
            BusinessLayerResult<AdUser> layerResult = new BusinessLayerResult<AdUser>();

            if (user != null)
            {
                if (user.Username == model.Username)
                {
                    layerResult.ErrorList.Add("Kullanıcı adı kayıtlı");
                }

                if (user.Email == model.Email)
                {
                    layerResult.ErrorList.Add("Email Kayıtlı");
                }
            }
            else
            {
                var dbResult = _repoUser.Insert(new AdUser()
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password
                });
            }

            return layerResult;
        }

        public BusinessLayerResult<AdUser> LoginUser(LoginViewModel model)
        {
            BusinessLayerResult<AdUser> adminResult = new BusinessLayerResult<AdUser>();
            adminResult.Result = _repoUser.Find(x => x.Username == model.Username && x.Password == model.Password);

            if (adminResult.Result == null)
            {
                adminResult.ErrorList.Add("Kullancı Adı ya da Şifre Hatalı");
            }

            return adminResult;
        }

    }
}