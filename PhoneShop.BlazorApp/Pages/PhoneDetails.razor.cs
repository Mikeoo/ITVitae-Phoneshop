using Microsoft.AspNetCore.Components;
using Phoneshop.Domain.Entities;


namespace PhoneShop.BlazorApp.Pages
{
    public partial class PhoneDetails
    {
        [Parameter]
        public Phone Phone { get; set; }

        [Parameter]
        public int Id { get; set; }
        protected override void OnInitialized()
        {
            Phone = _phoneService.Get(Id);
        }
    }
}
