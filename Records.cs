using LinqToExcel;
using System;
using System.Configuration;
using System.Data.Common;

namespace DataStructureImplementation
{
    internal static class Records
    {
        private static readonly string file = @"C:\Users\sajain\Desktop\Contacts.xlsx";
        public static IEnumerable<Person> FetchData()
        {
            using (var excel = new ExcelQueryFactory(file))
            {
                var worksheet = excel.Worksheet<Person>("Sheet1");
                var data = worksheet.Select(row => row);
                return data;
            }
        }

    }
}
