using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableStorage.helper;

namespace TableStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectString = ConfigurationManager.AppSettings["AzureStorage"];
            var storageHelper = new TableStorageHelper(connectString);

            //insert
            //var member = new Member("Hong", "Long2")
            //{
            //    Address = "HongKung",
            //    Phone = "123456"
            //};
            //var result = storageHelper.Insert("KyleTest", member);


            //query
            //var result = storageHelper.Query<Member>("KyleTest", x => x.PartitionKey == "Lin");
            //var data = result.data;

            //query first
            //var obj = storageHelper.Query<Member>("KyleTest", "Lin", "Hue");
            //obj.entity.Phone = "99999";
            //var result = storageHelper.Update("KyleTest", obj.entity);

            //delete
            storageHelper.Delte<Member>("KyleTest", "Lin", "Hue");


        }
    }

    public class Member : TableEntity
    {
        public Member(string lastName, string firstName)
        {
            this.PartitionKey = lastName;
            this.RowKey = firstName;
        }

        public Member()
        {

        }

        public string Address { get; set; }

        public string Phone { get; set; }

        public bool? Sex { get; set; }
    }
}

