using Xunit;
using DG.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DG.Tests.Model;

namespace DG.Json.Tests
{
    public class ConvertTests
    {
        [Fact()]
        public void ObjToJsonStringTest()
        {
            Users u = new Users() { ID= 292727059327094784, Age=18, Name="张珊珊SanSan", Birthday=new DateTime(1999,10,10) };
            var str=u.ObjToJsonString();
            Assert.True(!string.IsNullOrEmpty(str), str);
        }

        [Fact()]
        public void JsonStringToObjTest()
        {
            var pp = "{\"ID\": 292727059327094784,\"Age\": 18,\"Name\": \"张珊珊SanSan\",\"Birthday\": \"1999-10-10 16:00:00\"}";
            var uu=pp.JsonStringToObj<Users>();
            Assert.True(false, "This test needs an implementation");
        }
        
    }
}