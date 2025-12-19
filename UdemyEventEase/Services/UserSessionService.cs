using System.Text.Json;
using Microsoft.JSInterop;
using UdemyEventEase.Models;

public class UserSessionService(IJSRuntime js)
{
    public UserModel? CurrentUser { get; private set; }
    public event Action? OnChange;

    public async Task RegisterUser(UserModel user)
    {
        CurrentUser = user;
        var json = JsonSerializer.Serialize(user);
        await js.InvokeVoidAsync("localStorage.setItem", "userSession", json);
        NotifyStateChanged();
    }

    public async Task LoadSession()
    {
        try
        {
            var json = await js.InvokeAsync<string?>("localStorage.getItem", "userSession");
            if (!string.IsNullOrWhiteSpace(json))
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var user = JsonSerializer.Deserialize<UserModel>(json, options);
                if (user != null)
                {
                    CurrentUser = user;
                    NotifyStateChanged();
                }
            }
        }
        catch (Exception ex)
        {
            // Log the error or handle corrupted storage
            Console.WriteLine($"Error loading session: {ex.Message}");
        }
    }

    public async Task Logout()
    {
        await js.InvokeVoidAsync("localStorage.removeItem", "userSession");
        CurrentUser = null;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}