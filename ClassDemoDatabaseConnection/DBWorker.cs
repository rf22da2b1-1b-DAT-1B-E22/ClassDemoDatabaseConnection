using ClassDemoDatabaseConnection.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoDatabaseConnection
{
    public class DBWorker:IDBWorker
    {
        private const String ConnectionString = @"Data Source=mssql3.unoeuro.com;Initial Catalog=pele_zealand_dk_db_classdemo;User ID=pele_zealand_dk;Password=RexEByFhcwGbk943mAr6;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public DBWorker() 
        { 
        
        }

        public List<Person> GetAll()
        {
            String sql = "select * from Person";

            // forbindelse
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Person> personer = new List<Person>();
            while (reader.Read()) {
                personer.Add(ReadPerson(reader));
            }

            return personer;
        }

        private Person ReadPerson(SqlDataReader reader)
        {
            Person p = new Person();

            p.Id = reader.GetInt32(0);
            p.Name = reader.GetString(1);
            p.Address = reader.GetString(2);
            p.Phone = reader.GetString(3);


            return p;
        }

        public Person GetById(int id)
        {
            String sql = "select * from Person where Id = @ID";

            // forbindelse
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ID", id);

            SqlDataReader reader = cmd.ExecuteReader();

            
            if (reader.Read())
            {
                return ReadPerson(reader);
            }

            return null; // mulighed 1
            //throw new KeyNotFoundException(); // mulighed 2
        }
        public Person Create(Person person)
        {
            String sql = "insert into Person values(@ID,@Name, @Address, @Phone)";

            // forbindelse
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ID", person.Id);
            cmd.Parameters.AddWithValue("@Name", person.Name);
            cmd.Parameters.AddWithValue("@Address", person.Address);
            cmd.Parameters.AddWithValue("@Phone", person.Phone);

            int row = cmd.ExecuteNonQuery();

            if (row == 1)
            {
                return person;
            }
            else
            {
                return null; // eller exception
            }
            

            
        }

        public Person Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Person Update(int id, Person person)
        {
            throw new NotImplementedException();
        }
    }
}
