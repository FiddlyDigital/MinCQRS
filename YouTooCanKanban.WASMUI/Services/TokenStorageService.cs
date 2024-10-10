using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace YouTooCanKanban.WASMUI.Services
{
    public interface ITokenStorageService
    {
        Task<AccessToken?> GetToken();
        void SetToken(AccessToken token);
    }

    public class TokenStorageService : ITokenStorageService
    {
        private readonly ILocalStorageService localStorage;
        private const string storageKey = "TOKEN";

        public TokenStorageService(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
        }

        public async Task<AccessToken?> GetToken()
        {
            return await this.localStorage.GetItemAsync<AccessToken>(storageKey);
        }

        public async void SetToken(AccessToken token)
        {
            await this.localStorage.SetItemAsync<AccessToken>(storageKey, token);
        }
    }
}
