using IdeventAPI.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeventTests.IntegrationTests
{
    public class ManagerFactory
    {
        /// <summary>
        /// Creates a manager of the type you specify (Managers from the API). E.g. UserManager.cs or ChipGroupManager.cs
        /// with a ConnectionString to the test database.
        /// </summary>
        /// <typeparam name="T">A Manager class from the IdeventAPI.</typeparam>
        /// <returns></returns>
        public static T CreateManagerForTests<T>() where T : new()
        {
            Type t = typeof(T);
            T manager = (T)Activator.CreateInstance(t, TestSettings.ConnectionString);
            return manager;
        }
    }
}
