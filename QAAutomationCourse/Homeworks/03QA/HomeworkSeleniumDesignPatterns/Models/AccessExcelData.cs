using Dapper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDesignPatternsDemo.Models
{
    public class AccessExcelData
    {
        public static string TestDataFileConnection()
        {
            string pathToProject = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
            string path = pathToProject + ConfigurationManager.AppSettings["RelativeTestDataSheetPath"];
            var filename = "RegUserCases.xlsx";
            var fullPath = path + "\\" + filename;
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;
		                              Data Source = {0}; 
		                              Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;';",
                                      fullPath);
            return con;
        }

        public static RegistrationUser GetTestData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [Negative$] where key = '{0}'", keyName);
                var value = connection.Query<RegistrationUser>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}
