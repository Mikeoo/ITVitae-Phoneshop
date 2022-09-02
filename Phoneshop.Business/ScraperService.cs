using Phoneshop.Domain.Entities;
using Phoneshop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phoneshop.Business
{
    public class ScraperService : IScraperService
    {
        private readonly IPhoneService _phoneService;

        public ScraperService(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }
        private readonly List<string> _urlList = new()
        {
            "https://www.belsimpel.nl/API/vergelijk/v1.4/WebSearch?resultaattype=hardware_only&format=json_html_decoded",
            "https://www.vodafone.nl/telefoon/alle-telefoons?",
            "https://www.bol.com/nl/nl/l/smartphones/4010/?sort=release_date1&rating=all"
        };

        public async Task<List<Phone>> GetPhones(IEnumerable<IScraper> allScrapers)
        {
            List<Phone> phones = new();

            foreach (var url in _urlList)
            {
                var result = await allScrapers
                    .First(x => x.CanExecute(url))
                    .Execute(url);

                phones.AddRange(result);
            }
            return phones;
        }

        public async Task<List<Phone>> AddPhones(List<Phone> phones)
        {
            foreach (var phone in phones)
            {
                _phoneService.Create(phone);
            }

            return phones;
        }
    }
}
