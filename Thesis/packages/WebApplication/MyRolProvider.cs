using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using WebApplication.Models;

namespace WebApplication
{
    public class MyRolProvider: RoleProvider 
    {
        private int _cacheTimeOutInMinute = 20;
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string usercorreo)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return null;
            }
            var cacheKey = String.Format("{0}_role", usercorreo);
            //if (HttpRuntime.Cache[cacheKey] != null)
            //{
            //    return (String[])HttpRuntime.Cache[cacheKey];
            //}
            string[] roles = new string[] { };
            using (bd_ControlVisitasEntities dc = new bd_ControlVisitasEntities())
            {

                var rolesTemp = (from a in dc.roles
                         join b in dc.com_usuarios on a.idRoles equals b.Roles_idRoles
                         where b.Com_Correo.Equals(usercorreo)
                         select a.idRoles).FirstOrDefault();
                
                roles = new String[] { rolesTemp.ToString() };

                if (roles.Count() > 0)
                {
                    HttpRuntime.Cache.Insert(cacheKey, roles, null, DateTime.Now.AddMinutes(_cacheTimeOutInMinute), Cache.NoSlidingExpiration);
                    
                }
            }
            return roles;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string usercorreo, string roleName)
        {
            var userRoles = GetRolesForUser(usercorreo);
            return userRoles.Contains(roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}