using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace CleanMovie.UI.Provider
{
    public class CutomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _runtime;

        public AuthenticationState authenticationState { get; set; }
        public CutomAuthStateProvider(ILocalStorageService localStorageService, HttpClient httpClient, IJSRuntime jSRuntime)
        {
            _localStorageService = localStorageService;
            _httpClient = httpClient;
            _runtime = jSRuntime;
        }

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    if (firstRender)
        //    {
        //        var token = await TokenProvider.GetTokenAsync();
        //        Branches = await Http.GetJsonAsync<List<BranchDto>>(
        //            "vip/api/lookup/getbranches",
        //            new AuthenticationHeaderValue("Bearer", token));

        //        StateHasChanged();
        //    }
        //}

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    if (firstRender)
        //    {
        //        // call the JS function.
        //        await _runtime.InvokeVoidAsync(
        //              "initializeAnimation");
        //    }
        //}


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                //await _runtime.InvokeAsync("initializeAnimation");
                string token = await _localStorageService.GetItemAsStringAsync("token");
                //string token = "";

                var identity = new ClaimsIdentity();
                _httpClient.DefaultRequestHeaders.Authorization = null;
                if (!string.IsNullOrEmpty(token))
                {
                    identity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
                }

                var user = new ClaimsPrincipal(identity);
                var state = new AuthenticationState(user);

                NotifyAuthenticationStateChanged(Task.FromResult(state));

                return state;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }

        }
        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
