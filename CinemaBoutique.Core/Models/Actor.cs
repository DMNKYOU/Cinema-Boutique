using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaBoutique.Core
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        //многие ко многим свзязь добавить
    }
}
