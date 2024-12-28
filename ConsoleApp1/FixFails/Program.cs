using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks

class Program
{
    private const string ApiUrl = "https://api.tracker.yandex.net/v2/issues";
    private const string OAuthToken = "y0_AgAAAABUxt6ZAAz-cAAAAAEdC3lMAABam0KOY7hPEoMPak61DLqgZutZ0A";
    private const string OrgId = "bpf4tdujutj6u537jp38";

    static async Task Main(string[] args)
    {
        string summary = "Bulid Failed";
        string queue = "TEAMCITYBUILDFA";
        string assignee = "cutetempest";
        string description = "АААА СНОВА кукурузу не той стороной открыли АААА!";

        await CreateIssue(summary, queue, assignee, description);
    }

    static async Task CreateIssue(string summary, string queue, string assignee, string description)
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {OAuthToken}");
            client.DefaultRequestHeaders.Add("X-Cloud-Org-Id", OrgId);

            var issueData = new
            {
                summary = summary,
                queue = queue,
                assignee = assignee,
                description = description
            };

            string jsonData = System.Text.Json.JsonSerializer.Serialize(issueData);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(ApiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Задача успешно создана: {responseBody}");
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Ошибка создания задачи: {response.StatusCode}, {error}");
            }
        }
    }
}
