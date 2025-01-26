using Newtonsoft.Json;
using System.Collections;

public class Program
{
    const string apiUrl = "https://jsonmock.hackerrank.com/api/football_matches?";
    public static async Task Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = await getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static async Task<int> getTotalScoredGoals(string team, int year)
    {
        int scoredGoals = 0;
        string urlRequest = apiUrl + $"year={year}&team1={team}";
        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(urlRequest);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                dynamic myObject = JsonConvert.DeserializeObject<dynamic>(responseBody);
                var data = (IList)myObject.data;                
                foreach (var item in data)
                {
                    scoredGoals += (int)((dynamic)item).team1goals;
                }                
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Erro ao enviar solicitação: {e.Message}");
                scoredGoals = 0;
            }            
        }
        return scoredGoals;
    }
}
