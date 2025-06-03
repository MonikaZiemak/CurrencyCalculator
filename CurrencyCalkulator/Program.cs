using System;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CurrencyCalculator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Podaj kwotę w EUR: ");
            string input = Console.ReadLine();

            if (!decimal.TryParse(input, out decimal euroAmount))
            {
                Console.WriteLine("Nieprawidłowa kwota.");
                return;
            }

            Console.Write("Podaj swój klucz API: ");
            string apiKey = Console.ReadLine();

            try
            {
                var rate = await GetExchangeRateAsync(apiKey);

                if (rate > 0)
                {
                    decimal btcAmount = euroAmount * rate;
                    Console.WriteLine($"{euroAmount} EUR = {btcAmount:F8} BTC");
                }
                else
                {
                    Console.WriteLine("Nie udało się pobrać kursu.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd: " + ex.Message);
            }

            Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć...");
            Console.ReadKey();
        }

        static async Task<decimal> GetExchangeRateAsync(string apiKey)
        {
            string url = $"https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency=BTC&to_currency=EUR&apikey={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Odpowiedź API:\n" + json);

                var result = JsonConvert.DeserializeObject<ExchangeRateResponse>(json);

                if (result?.ExchangeRate != null &&
                    decimal.TryParse(result.ExchangeRate.ExchangeRateValue, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal btcToEur))
                {
                    decimal eurToBtc = 1 / btcToEur;
                    return eurToBtc;
                }
                else
                {
                    return 0;
                }
            }
        }
    }

    // MODELE JSONA:

    public class ExchangeRateResponse
    {
        [JsonProperty("Realtime Currency Exchange Rate")]
        public ExchangeRateData ExchangeRate { get; set; }
    }

    public class ExchangeRateData
    {
        [JsonProperty("1. From_Currency Code")]
        public string FromCurrencyCode { get; set; }

        [JsonProperty("2. From_Currency Name")]
        public string FromCurrencyName { get; set; }

        [JsonProperty("3. To_Currency Code")]
        public string ToCurrencyCode { get; set; }

        [JsonProperty("4. To_Currency Name")]
        public string ToCurrencyName { get; set; }

        [JsonProperty("5. Exchange Rate")]
        public string ExchangeRateValue { get; set; }

        [JsonProperty("6. Last Refreshed")]
        public string LastRefreshed { get; set; }

        [JsonProperty("7. Time Zone")]
        public string TimeZone { get; set; }
    }
}
