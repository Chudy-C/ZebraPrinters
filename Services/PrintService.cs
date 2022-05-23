using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ZebraPrinters.Entities;
using ZebraPrinters.Services.Interfaces;

namespace ZebraPrinters.Services
{
    public class PrintService : IPrintService
    {

        private readonly HttpClient httpClient;

        public PrintService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Printer> GetPrinter(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Printer/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(Printer);
                    }
                    return await response.Content.ReadFromJsonAsync<Printer>();
                }
                else
                {
                    var message = response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} | message : {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<Printer> GetPrinterByDepartment(string department)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Printer/{department}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(Printer);
                    }
                    return await response.Content.ReadFromJsonAsync<Printer>();
                }
                else
                {
                    var message = response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} | message : {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Printer>> GetPrinters()
        {
            try
            {
                var response = await this.httpClient.GetAsync($"api/Printer");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<Printer>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<Printer>>();
                }
                else
                {
                    var message = response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} | message : {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
