using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace addressbook_web_tests.model
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string lastname;

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            return firstname == other.firstname && lastname == other.lastname;
        }

        public override int GetHashCode()
        {
            return (firstname?.GetHashCode() ?? 0) ^ (lastname?.GetHashCode() ?? 0);
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null)) return 1;
            int byLast = string.Compare(lastname, other.lastname, StringComparison.Ordinal);
            if (byLast != 0) return byLast;
            return string.Compare(firstname, other.firstname, StringComparison.Ordinal);
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
    }
}
