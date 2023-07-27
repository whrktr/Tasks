using Newtonsoft.Json.Linq;
using PhoneApp.Domain.Attributes;
using PhoneApp.Domain.DTO;
using PhoneApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Xml.Linq;

namespace EmployeesImportPlugin
{
    [Author(Name = "Dmitry Gorbunov")]
    public class Plugin : IPluggable
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public IEnumerable<DataTransferObject> Run(IEnumerable<DataTransferObject> args)
        {
            logger.Info("Collecting new employees");

            var newUsers = new List<EmployeesDTO>();
            
            using (var client = new HttpClient())
            {
                var randomUsers = client.GetStringAsync("https://dummyjson.com/users").Result;

                var userJObject = JObject.Parse(randomUsers);

                foreach(var userObj in userJObject["users"])
                {
                    var user = new EmployeesDTO
                    {
                        Name = $"{userObj["firstName"]} {userObj["lastName"]}"                       
                    };

                    user.AddPhone(userObj["phone"].ToString());
                    newUsers.Add(user);
                }
            }

            logger.Info($"Imported {newUsers.Count} employees");
            return args.Concat(newUsers.Cast<DataTransferObject>());
        }
    }
}
