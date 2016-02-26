using System;
using System.Collections.Generic;

namespace AngularJS.Models
{
    public interface IPeopleRepository : IDisposable
    {
        List<Person> Get();
        Person Get(int id);
        Person Add(Person newPerson);
        Person Update(Person newPerson);
        void Delete(int id);
    }
}