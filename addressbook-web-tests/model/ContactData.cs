using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace addressbook_web_tests.model
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return (Firstname?.GetHashCode() ?? 0) ^ (Lastname?.GetHashCode() ?? 0);
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null)) return 1;
            int byLast = string.Compare(Lastname, other.Lastname, StringComparison.Ordinal);
            if (byLast != 0) return byLast;
            return string.Compare(Firstname, other.Firstname, StringComparison.Ordinal);
        }

        public string Firstname { get; set; }        
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string AllPhones {
            get {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else 
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            
            }
            
            set {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone,"[ -()] ", "") + "\r\n";
        }

        public string Id { get; set; }
    }
}
