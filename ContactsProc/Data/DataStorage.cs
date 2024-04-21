using ContactsProc.Models;

namespace ContactsProc.Data
{
    public static class DataStorage
    {
        private static List<Contact> contacts = new List<Contact>();
        public static List<Contact> AllContacts => contacts;

        public static void AddContact(Contact contact)
        {
            var existingContact = AllContacts.Where(x => x.Id == contact.Id).FirstOrDefault();

            if (contact != null && existingContact == null)
            {
                contacts.Add(contact);
            }
        }

        public static void UpdateContact(Contact contact)
        {
            var foundExistingContact = contacts.FirstOrDefault(x => x.Id.Equals(contact.Id));
            if (foundExistingContact != null)
            {
                foundExistingContact.Name = contact.Name;
                foundExistingContact.Surname = contact.Surname;
                foundExistingContact.Email = contact.Email;
                foundExistingContact.PhoneNumber = contact.PhoneNumber;
            }
        }

        public static void DeleteContact(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.Id == id);
            if (contact != null)
                contacts.Remove(contact);
        }

        public static Contact GetContact(int id)
        {
            return contacts.FirstOrDefault(c => c.Id == id);
        }
    }
}
