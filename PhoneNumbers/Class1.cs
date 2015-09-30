using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Given_I_Have_A_PhoneNumbers_Checker
{
    [TestFixture]
    public class When_I_Pass_A_PhoneNumber_List
    {
        public List<Contacts> ValidContactList;
        public List<Contacts> InValidContactList;
        
        [SetUp]
        public void SetUpTest()
        {
            ValidContactList = new List<Contacts>
            {
                new Contacts {Name = "Jai", PhoneNumber = "07738756597"},
                new Contacts {Name = "Sara", PhoneNumber = "0774654654"},
                new Contacts {Name = "Joe", PhoneNumber = "0772"},
                new Contacts {Name = "John", PhoneNumber = "07765464"}
            };

            InValidContactList = new List<Contacts>
            {
                new Contacts {Name = "Jai", PhoneNumber = "07738756597"},
                new Contacts {Name = "Sara", PhoneNumber = "0774654654"},
                new Contacts {Name = "Joe", PhoneNumber = "07738"},
                new Contacts {Name = "John", PhoneNumber = "07765464"}
            };
        }

        [Test]
        public void Then_It_Passes_The_ValidContact_List()
        {
            const bool expected = true;
            var phoneNumbers = new PhoneNumberChecker();
            
            var actual = phoneNumbers.Check(ValidContactList);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Then_It_Fails_The_InvalidContact_List()
        {
            const bool expected = false;
            var phoneNumbers = new PhoneNumberChecker();

            var actual = phoneNumbers.Check(InValidContactList);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    public class Contacts
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class PhoneNumberChecker
    {
        public bool Check(List<Contacts> contactList)
        {
            for (var i = 0; i < contactList.Count - 1; i++)
            {
                for (var j = i + 1; j < contactList.Count; j++)
                {
                    if (contactList[i].PhoneNumber.Contains(contactList[j].PhoneNumber) ||
                        contactList[j].PhoneNumber.Contains(contactList[i].PhoneNumber))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}