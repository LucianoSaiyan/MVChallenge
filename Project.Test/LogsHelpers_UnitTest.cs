using Project.Entities.Model;
using Project.Shared;
using Project.Shared.Helpers;
using Project.Shared.Validations;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Project.Test
{
    [TestClass]
    public class LogsHelpers_UnitTest
    {

        public void Initialize()
        {

        }


        [TestMethod]
        public void Validations_Ok_Usuarios_Update_Method_Test()
        {
            string logs = LogsHelpers.BuildLogsHelpers<LogsHelpers_UnitTest>("this class is test");
            Assert.AreNotEqual(null, logs);
        }


    }
}