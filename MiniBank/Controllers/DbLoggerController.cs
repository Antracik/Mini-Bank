using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mini_Bank.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json.Linq;
using Services.Services;
using Shared;

namespace Mini_Bank.Controllers
{
    public class DbLoggerController : Controller
    {
        private readonly MongoLoggerService _mongoLoggerService;

        public DbLoggerController(MongoLoggerService mongoLoggerService)
        {
            _mongoLoggerService = mongoLoggerService;
        }

        public IActionResult Index()
        {
            //Code below will be majorly refactored soon(TM)
            var testing = _mongoLoggerService.GetAll();
            var objList = new List<IBaseModel>();

            foreach (var test in testing)
            {
                string modelName = test.Properties.Elements.ToList()[0].Value.ToString();
                string jsonData = test.Data;

                var jObject = JObject.Parse(jsonData);

                object obj = _mongoLoggerService.GetInstance(modelName);
                
                if (obj != null)
                {
                    var jNew = jObject.Value<JObject>(Constants.mongoNewItemValues);
                    var jOld= jObject.Value<JObject>(Constants.mongoOldItemValues);

                    if (jOld == null || jNew == null)
                        continue;

                    obj = jNew.ToObject(obj.GetType());
                    objList.Add(obj as IBaseModel);

                    obj = jOld.ToObject(obj.GetType());
                    objList.Add(obj as IBaseModel);
                }
            }

            bool skip = false;
            var valueList = new List<List<Tuple<string, string, string,string>>>();
            
            //Only god and me knows what this does
            for (int i = 0; i < objList.Count; i++)
            {
                if (skip)
                {
                    skip = false;
                    continue;
                }
                var innerList = new List<Tuple<string, string, string, string>>();

                int tempIndex = i;

                Type itemNewValueType = objList[tempIndex].GetType(); // we get the newValue Item type
                List<PropertyInfo> newValueProps = new List<PropertyInfo>(itemNewValueType.GetProperties());

                Type itemOldValueType = objList[++tempIndex].GetType(); // we get the oldValue Item type
                List<PropertyInfo> oldValueProps = new List<PropertyInfo>(itemOldValueType.GetProperties());

                int propCount = (newValueProps.Count + oldValueProps.Count) / 2; //both prop lists should always have the same count of props

                for (int j = 0; j < propCount; j++)
                {
                    int innerTempIndex = i;

                    object newValuePropValue = newValueProps[j].GetValue(objList[innerTempIndex]);
                    object oldValuePropValue = oldValueProps[j].GetValue(objList[++innerTempIndex]);

                    if (newValuePropValue == null || oldValuePropValue == null)
                        continue;

                    if(newValuePropValue.Equals(oldValuePropValue))
                    {
                        innerList.Add(new Tuple<string, string, string, string>(itemNewValueType.FullName, newValueProps[j].Name + ": " + newValuePropValue.ToString(), newValueProps[j].Name + ": " + oldValuePropValue.ToString(), Constants.mongoEqualsTrue));
                    }
                    else
                    {
                        innerList.Add(new Tuple<string, string, string, string>(itemNewValueType.FullName, newValueProps[j].Name + ": " + newValuePropValue.ToString(), newValueProps[j].Name + ": " + oldValuePropValue.ToString(), Constants.mongoEqualsFalse));
                    }
                }
                valueList.Add(innerList);
                skip = true;
            }

            return View("UpdatedEntities", valueList);
        }
    }
}