using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
namespace LottoAdmin.ClassUtil
{
    public class LineNoti
    {
        public async void LineNotifyAsync(string lineToken, string message, string picturePath)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "https://notify-api.line.me/api/notify");
                request.Headers.Add("Authorization", "Bearer " + lineToken);
                var content = new MultipartFormDataContent();
                if (message != "")
                {
                    content.Add(new StringContent(message), "message");
                }
                if (picturePath != "")
                {
                    content.Add(new StreamContent(File.OpenRead(picturePath)), "imageFile", picturePath);
                }

                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {

            }



        }
    }
}
