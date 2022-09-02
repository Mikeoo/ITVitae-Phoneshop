namespace PhoneShop.BlazorApp.Data
{
    public interface IApiClient
    {
        IPhoneClient PhoneClient { get; }
        ILoginClient LoginClient { get; }
        IRegisterClient RegisterClient { get; }
    }
}
