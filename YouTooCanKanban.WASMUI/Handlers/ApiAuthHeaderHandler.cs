using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using YouTooCanKanban.WASMUI.Services;

namespace YouTooCanKanban.WASMUI.Handlers
{
    public class ApiAuthHeaderHandler : DelegatingHandler
    {
        private readonly IAccessTokenProvider TokenProvider;
        private readonly ITokenStorageService TokenStorage;

        public ApiAuthHeaderHandler(IAccessTokenProvider tokenProvider, ITokenStorageService tokenStorage)
        {
            TokenProvider = tokenProvider;
            TokenStorage = tokenStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            AccessToken? token = await TokenStorage.GetToken();
            if (token is null || token.Expires <= DateTime.UtcNow)
            {
                AccessTokenResult accessTokenResult = await TokenProvider.RequestAccessToken();
                if (accessTokenResult.TryGetToken(out token))
                {
                    this.TokenStorage.SetToken(token);
                }
            }

            if (token is not null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
