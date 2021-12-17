using Bunit;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeventTests
{
    public class Helpers
    {
        /// <summary>
        /// Makes a list of type T and adds it as a parameter to the childComponent. 
        /// The list contains an entry of type T with an Id of 1 and Name of 'TestName'.
        /// </summary>
        /// <typeparam name="T">The type T must have a constructor that sets the Id and Name parameter only.</typeparam>
        /// <param name="childComponent">The component you need to render inside another component (typically a page)</param>
        /// <param name="parameterName"></param>
        public static void SetListParameterForChildComponent<T>(IRenderedComponent<IComponent> childComponent, string parameterName)
        {
            Type t = typeof(T);
            System.Reflection.PropertyInfo[] properties = t.GetProperties();

            List<string> reflectionCheckList = new();
            #region CheckForIdAndNameProperties
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].Name == "Id" || properties[i].Name == "Name")
                {
                    reflectionCheckList.Add(properties[i].Name);
                }
            }
            if (!reflectionCheckList.Contains("Id") || !reflectionCheckList.Contains("Name"))
            {
                return;
            }
            #endregion
            // Id, Name
            object[] arguments = { 1, "TestName" };
            T model = (T)Activator.CreateInstance(t, arguments);
            List<T> list = new List<T>() { model };

            ComponentParameter componentParam = ComponentParameterFactory.Parameter(parameterName, list);
            childComponent.SetParametersAndRender(componentParam);
        }
    }
}
