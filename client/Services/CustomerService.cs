using System;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using BaseLibrary.Entities;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace client.Services
{
    public class CustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Customer>> GetListCustomerDataAsync()
        {
            try
            {
                var url = "";
                var postData = new
                {
                    SP = "exec spw_view_submission ",
                    ParamSP = new { }
                };

                var request = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(postData), Encoding.UTF8, "application/json")
                };

                // Menambahkan header

                var response = await _httpClient.SendAsync(request);
                var responseString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    return new List<Customer>();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var dataList = JsonSerializer.Deserialize<List<ApiResponse>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (dataList == null) return new List<Customer>();

                var customerDict = new Dictionary<string, Customer>();

                foreach (var item in dataList.Where(d => d.GroupName == "Customer"))
                {
                    if (!customerDict.ContainsKey(item.GroupNo))
                    {
                        customerDict[item.GroupNo] = new Customer();
                    }

                    var customer = customerDict[item.GroupNo];

                    switch (item.Caption)
                    {
                        case "No Anggota":
                            customer.MemberID = item.Value;
                            break;
                        case "Nama":
                            customer.Name = item.Value;
                            break;
                        case "Email":
                            customer.Email = item.Value;
                            break;
                        case "HP":
                            customer.MobilePhone = item.Value;
                            break;
                        case "Status":
                            customer.Status = item.Value;
                            break;
                    }
                }

                return customerDict.Values.ToList();
            }
            catch
            {
                return new List<Customer>();
            }
        }

        public async Task<Customer?> GetCustomerDataAsync(string citizenId, string memberId)
        {
                          
            try
            {
                var url = "";
                var postData = new
                {
                    SP = $"exec spw_view_submission '{citizenId}','{memberId}'",
                    ParamSP = new { }
                };

                var request = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(postData), Encoding.UTF8, "application/json")
                };

                // Menambahkan header

                var response = await _httpClient.SendAsync(request);
 
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var dataList = JsonSerializer.Deserialize<List<ApiResponse>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (dataList == null) return null;

                var customerData = new Customer();
                var transactions = new List<TransactionHistory>();


                foreach (var item in dataList)
                {
                    switch (item.GroupName)
                    {
                        case "Customer":
                            switch (item.Caption)
                            {
                                case "No Anggota":
                                    customerData.MemberID = item.Value;
                                    break;
                                case "Nomor KTP":
                                    customerData.CitizenID = item.Value;
                                    break;
                                case "Nama":
                                    customerData.Name = item.Value;
                                    break;
                                case "HP":
                                    customerData.MobilePhone = item.Value;
                                    break;
                                case "Email":
                                    customerData.Email = item.Value;
                                    break;
                                case "Status":
                                    customerData.Status = item.Value;
                                    break;
                            }
                            break;
                    }
                }

                var transactionDict = new Dictionary<string, TransactionHistory>();

                foreach (var data in dataList.Where(d => d.GroupName == "Transaction"))
                {
                    if (!transactionDict.ContainsKey(data.LineNo))
                        transactionDict[data.LineNo] = new TransactionHistory();

                    switch (data.Caption)
                    {
                        case "Waktu":
                            transactionDict[data.LineNo].Waktu = data.Value;
                            break;
                        case "Keterangan":
                            transactionDict[data.LineNo].Description = data.Value;
                            break;
                        case "Status":
                            transactionDict[data.LineNo].Status = data.Value;
                            break;
                    }
                }

                customerData.TransactionHistories = transactionDict.Values.ToList();
                return customerData;
            
            }
            catch
            {
                return null;
            }
        }

        public async Task<string> GetCustomerDataAsJsonAsync(string citizenId, string memberId)
        {
            var customer = await GetCustomerDataAsync(citizenId, memberId);

            if (customer == null)
                return "{}"; // Kembalikan JSON kosong jika tidak ada data

            var json = JsonSerializer.Serialize(customer, new JsonSerializerOptions
            {
                WriteIndented = true // Biar JSON lebih rapi
            });

            return json;
        }
    }
}

