using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Glissade.Client {
    class ImageSender {
        public void Sender(byte[] Bytes) {
            byte[] ScreenBytes = Bytes;
            string url = "https://api.glissade/api/us/uploadimage";

            ContentDTO contentDTO = new ContentDTO();
            ScreenDTO screenDTO = new ScreenDTO();

            contentDTO.Content = ScreenBytes;
            string json = JsonConvert.SerializeObject(contentDTO);
            var scontent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.PostAsync(url, scontent).Result;

            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync();

            screenDTO = JsonConvert.DeserializeObject<ScreenDTO>(responseBody.Result);
            string link = screenDTO.Link;

            System.Diagnostics.Process.Start(link);
        }
    }
}
