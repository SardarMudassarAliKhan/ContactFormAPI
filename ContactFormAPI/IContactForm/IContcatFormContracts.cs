using ContactFormAPI.Model;

namespace ContactFormAPI.IContactForm
{
    public interface IContcatFormContracts
    {
        Task<ContactForm> AddContactForm(ContactForm contactForm);
        Task<IEnumerable<ContactForm>> GetContactForms();
        Task<ContactForm> GetContactForm(int id);
        Task<ContactForm> UpdateContactForm(int id, ContactForm contactForm);
        Task<ContactForm> DeleteContactForm(int id);
    }
}
