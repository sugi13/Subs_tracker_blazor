using Subscription_tracker.models;
using Microsoft.JSInterop;
using System.Text.Json;

namespace Subscription_tracker.Services
{
    public class SubscriptionService
    {
        private const string Subs_Key = "subscriptions";

        private readonly IJSRuntime js;

        private List<Subscription> subscriptions = new List<Subscription>();

        public SubscriptionService(IJSRuntime js)
        {
            this.js = js;
        }
        // GET
        public async Task<List<Subscription>> GetAll()
        {
            if (subscriptions.Count == 0)
                await LoadFromLocalStorage();

            return subscriptions;
        }
        
        // POST
        public async Task AddSubscription(Subscription subscription)
        {
            subscription.ItemId = subscriptions.Count == 0 ? 1 : subscriptions.Max(s => s.ItemId) + 1;
            subscriptions.Add(subscription);
            await SaveToLocalStorage();
        }
        // UPDATE
        public async Task UpdateSubscription(Subscription subscription)
        {
            var existing = subscriptions.First(p => p.ItemId == subscription.ItemId);
            existing.Subs_name = subscription.Subs_name;
            existing.Subs_plan = subscription.Subs_plan;
            existing.Subs_amount = subscription.Subs_amount;
            existing.Subs_total = subscription.Subs_total;
            await SaveToLocalStorage();
        }
        // DELETE
        public async Task DeleteSubscription(int itemId)
        {
            var subscription = subscriptions.First(p => p.ItemId == itemId);
            subscriptions.Remove(subscription);
            await SaveToLocalStorage();
        }
        // LOCAL STORAGE HANDLING
        private async Task LoadFromLocalStorage()
        {
            var json = await js.InvokeAsync<string>("localStorage.getItem", Subs_Key);
            if (!string.IsNullOrEmpty(json))
            {
                subscriptions = JsonSerializer.Deserialize<List<Subscription>>(json)!;
            }
        }
        private async Task SaveToLocalStorage()
        {
            var json = JsonSerializer.Serialize(subscriptions);
            await js.InvokeVoidAsync("localStorage.setItem", Subs_Key, json);
        }
        // calculate total expense
    }
}