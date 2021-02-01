using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.MockData
{
    public class MockData
    {
        private static MockData _instance;
        private DataTable dtable;
        private static object synLock = new object();
        protected MockData()
        {
             dtable = new DataTable("userinfo");
            DataColumn firstName = new DataColumn("FirstName", typeof(string));
            firstName.MaxLength = 30;
            DataColumn lastName = new DataColumn("LastName", typeof(string));
            lastName.MaxLength = 30;
            DataColumn email = new DataColumn("Email", typeof(string));
            email.MaxLength = 100;
            DataColumn phone = new DataColumn("PhoneNumber", typeof(string));
            phone.MaxLength = 12;
            DataColumn securityQ = new DataColumn("SecurityQuestion", typeof(int));            
            DataColumn securityA = new DataColumn("SecurityAnswer", typeof(string));
            securityA.MaxLength = 100;
            DataColumn password = new DataColumn("Password", typeof(string));
            password.MaxLength = 12;
            DataColumn promotion = new DataColumn("RecievePromotion", typeof(bool));
            DataColumn enroll = new DataColumn("Enroll", typeof(bool));

            dtable.Columns.Add(firstName);
            dtable.Columns.Add(lastName);
            dtable.Columns.Add(email);
            dtable.Columns.Add(phone);            
            dtable.Columns.Add(securityQ);
            dtable.Columns.Add(securityA);
            dtable.Columns.Add(password);
            dtable.Columns.Add(promotion);
            dtable.Columns.Add(enroll);

            dtable.Rows.Add("Patrick","Huang", "patrick@email.com","4161111111",1,"test answer","QAZxsw123",true,true);

        }
        public static MockData GetMockData()
        {
            if (_instance == null)
            {
                lock (synLock)
                {
                    if (_instance == null)
                    {
                        _instance = new MockData();
                    }
                }
            }
            return _instance;
        }
      

        public bool AddData(UserInfo userinfo)
        {
            string email = null;
            foreach(DataRow dr in dtable.Rows)
            {
                if (dr.Field<string>(2) == userinfo.Email)
                {
                    return false;
                }
            }

            if (email == null)
            {
                dtable.Rows.Add(userinfo.FirstName, userinfo.LastName, userinfo.Email, userinfo.PhoneNumber, int.Parse(userinfo.SecurityQuestion), userinfo.SecurityAnswer, userinfo.PassWord, userinfo.RecievePromotion, userinfo.Enroll);
            }
            return true;
              
        }

        public string GetPassword(string email)
        {
            foreach (DataRow dr in dtable.Rows)
            {
                if (dr.Field<string>(2) == email)
                {
                    return dr.Field<string>(6);   
                }
            }
            return null;
        }



    }
}