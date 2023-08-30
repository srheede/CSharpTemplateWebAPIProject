namespace TemplateWebAPI.Services
{
    public class TemplateService : ITemplateService
    {
        public async Task<string> CreateTemplateMessage(int id)
        {
            return await CSharpFundamentals(id.ToString());
        }

        private async Task<string> CSharpFundamentals(string id)
        {
            try
            {
                bool didParse = int.TryParse(id, out int result);

                if (didParse)
                {
                    int[] numbersArray = new int[result];
                    string[] stringArray = new string[] { "value1", "value2" };

                    for (int i = 0; i < result; i++)
                    {
                        numbersArray[i] = i + 1;
                    }

                    List<int> evenNumbers = new List<int>();

                    evenNumbers = numbersArray.Where(n => n % 2 == 0).ToList();

                    evenNumbers.Add((evenNumbers.Count * 2) + 2);

                    Action<int> PrintNextInt = (n) => Console.Write(n + " ");

                    Console.WriteLine("Generated even numbers: ");
                    foreach (int number in evenNumbers)
                    {
                        PrintNextInt(number);
                    }

                    Func<List<int>, int> GetSum = (evenNumbers) => evenNumbers.Sum();

                    return await DelayResponse($"value: {GetSum(evenNumbers)}");
                }
                else
                {
                    return $"Could not parse: {id}";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        static async Task<string> DelayResponse(string response)
        {
            await Task.Delay(1000);
            return response;
        }
    }
}
