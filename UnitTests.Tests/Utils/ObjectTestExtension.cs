using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Tests.Utils
{
    public static class ObjectTestExtension
    {
        public static bool IsEqualTo(this object toTest, object fromTest)
        {
            bool result = true;

            PropertyInfo[] propertiesToItem = toTest.GetType().GetProperties();
            PropertyInfo[] propertiesFromItem = fromTest.GetType().GetProperties();
            propertiesToItem = propertiesToItem.OrderBy(x => x.Name).ToArray();
            propertiesFromItem = propertiesFromItem.OrderBy(x => x.Name).ToArray();

            for (int i = 0; i < propertiesToItem.Length; i++)
            {
                if (propertiesToItem[i].Name.Equals(propertiesFromItem[i].Name))
                {
                    if (propertiesToItem[i].GetValue(toTest) != null && propertiesFromItem[i].GetValue(fromTest) != null)
                    {
                        if (!propertiesToItem[i].GetValue(toTest).Equals(propertiesFromItem[i].GetValue(fromTest)))
                        {
                            result = false;
                            break;
                        }
                    }    
                }
                else
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public static void CopyIn(this object toItem, object fromItem)
        {
            PropertyInfo[] propertiesToItem = toItem.GetType().GetProperties();
            PropertyInfo[] propertiesFromItem = fromItem.GetType().GetProperties();
            propertiesToItem = propertiesToItem.OrderBy(x => x.Name).ToArray();
            propertiesFromItem = propertiesFromItem.OrderBy(x => x.Name).ToArray();

            for (int i = 0; i < propertiesToItem.Length; i++)
            {
                if (propertiesToItem[i].Name.Equals(propertiesFromItem[i].Name))
                {
                    propertiesToItem[i].SetValue(toItem, propertiesFromItem[i].GetValue(fromItem));
                }
            }
        }
    }
}
