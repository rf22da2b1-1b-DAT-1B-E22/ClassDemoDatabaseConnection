using ClassDemoDatabaseConnection.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoDatabaseConnection
{
    public interface IDBWorker
    {
        public List<Person> GetAll();
        public Person GetById(int id);
        public Person Create(Person person);
        public Person Update(int id, Person person);
        public Person Delete(int id);


    }
}
