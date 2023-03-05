using System;
namespace PaymentTerminal
{
    public class Person
    {
        private Guid _documentId;
        private String _name;
        private String _surname;
        private DateTime _birthDate;

        public Person(Guid documentId, String name, String surname, DateTime birthDate)
        {
            _documentId = documentId;
            _name = name;
            _surname = surname;
            _birthDate = birthDate;
        }
    }
}