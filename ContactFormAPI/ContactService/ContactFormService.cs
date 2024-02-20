using ContactFormAPI.AppDbContext;
using ContactFormAPI.IContactForm;
using ContactFormAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactFormAPI.ContactService
{
    public class ContactFormService : IContcatFormContracts
    {
        private readonly ApplicationDbContext _context;

        public ContactFormService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ContactForm> AddContactForm(ContactForm contactForm)
        {
            _context.ContactForms.Add(contactForm);
            await _context.SaveChangesAsync();
            return contactForm;
        }

        public async Task<ContactForm> DeleteContactForm(int id)
        {
            var contactForm = await _context.ContactForms.FindAsync(id);
            if (contactForm == null)
            {
                return null;
            }

            _context.ContactForms.Remove(contactForm);
            await _context.SaveChangesAsync();

            return contactForm;
        }

        public async Task<IEnumerable<ContactForm>> GetContactForms()
        {
            return await _context.ContactForms.ToListAsync();
        }

        public async Task<ContactForm> GetContactForm(int id)
        {
            return await _context.ContactForms.FindAsync(id);
        }

        public async Task<ContactForm> UpdateContactForm(int id, ContactForm contactForm)
        {
            if (id != contactForm.Id)
            {
                return null;
            }

            _context.Entry(contactForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactFormExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return contactForm;
        }

        private bool ContactFormExists(int id)
        {
            return _context.ContactForms.Any(e => e.Id == id);
        }
    }
}
