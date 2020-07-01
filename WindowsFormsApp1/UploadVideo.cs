using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using RestSharp;
using System.Net;


namespace BookReader
{
    /// <summary>
    /// YouTube Data API v3 sample: upload a video.
    /// Relies on the Google APIs Client Library for .NET, v1.7.0 or higher.
    /// See https://developers.google.com/api-client-library/dotnet/get_started
    /// </summary>
    internal class UploadVideo
    {
      
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("YouTube Data API: Upload Video");
        //    Console.WriteLine("==============================");

        //    try
        //    {
        //        new UploadVideo().Run().Wait();
        //    }
        //    catch (AggregateException ex)
        //    {
        //        foreach (var e in ex.InnerExceptions)
        //        {
        //            Console.WriteLine("Error: " + e.Message);
        //        }
        //    }

        //    Console.WriteLine("Press any key to continue...");
        //    Console.ReadKey();
        //}

        public async Task Run(Video video, string filePath)
        {
            UserCredential credential;
            using (var stream = new FileStream(@"O:\Programs\BookToYouTube\client_secret_694024227957-vk8ru29844lafeju95c1ut9hpd18vcr6.apps.googleusercontent.com.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    // This OAuth 2.0 access scope allows an application to upload files to the
                    // authenticated user's YouTube channel, but doesn't allow other types of access.
                    new[] { YouTubeService.Scope.YoutubeUpload },
                    "Main",
                    CancellationToken.None
                );
            }

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = Assembly.GetExecutingAssembly().GetName().Name
            });


            //video.Snippet = new VideoSnippet();

            //video.Snippet.Title = "Default Video Title";
            //video.Snippet.Description = "Default Video Description";
            //video.Snippet.Tags = new string[] { "tag1", "tag2" };
            //video.Snippet.CategoryId = "22"; // See https://developers.google.com/youtube/v3/docs/videoCategories/list
            //video.Status = new VideoStatus();
            //video.Status.PrivacyStatus = "unlisted"; // or "private" or "public"
            //var filePath = @"REPLACE_ME.mp4"; // Replace with path to actual movie file.
            //var targetFileName = Path.Combine(System.IO.Directory.GetCurrentDirectory(), Path.GetFileName(filePath));
            //System.IO.Directory.Move(filePath.Replace(":", "-"), targetFileName); System.IO.FileStream()
            using (var fileStream = new FileStream(filePath, FileMode.Open)) 
            {
                var videosInsertRequest = youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                videosInsertRequest.ProgressChanged += videosInsertRequest_ProgressChanged;
                videosInsertRequest.ResponseReceived += videosInsertRequest_ResponseReceived;

                await videosInsertRequest.UploadAsync();
            }
        }

        void videosInsertRequest_ProgressChanged(Google.Apis.Upload.IUploadProgress progress)
        {
            switch (progress.Status)
            {
                case UploadStatus.Uploading:
                    Console.WriteLine("{0} bytes sent.", progress.BytesSent);
                    break;

                case UploadStatus.Failed:
                    Console.WriteLine("An error prevented the upload from completing.\n{0}", progress.Exception);
                    break;
            }
        }

        void videosInsertRequest_ResponseReceived(Video video)
        {


            Console.WriteLine("Video id '{0}' was successfully uploaded.", video.Id);
        }

        private async Task AddToList(UserCredential credential)
        {
     
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = this.GetType().ToString()
            });

            // Create a new, private playlist in the authorized user's channel.
            var newPlaylist = new Playlist();
            newPlaylist.Snippet = new PlaylistSnippet();
            newPlaylist.Snippet.Title = "Test Playlist";
            newPlaylist.Snippet.Description = "A playlist created with the YouTube API v3";
            newPlaylist.Status = new PlaylistStatus();
            newPlaylist.Status.PrivacyStatus = "public";
            newPlaylist = await youtubeService.Playlists.Insert(newPlaylist, "snippet,status").ExecuteAsync();

            // Add a video to the newly created playlist.
            var newPlaylistItem = new PlaylistItem();
            newPlaylistItem.Snippet = new PlaylistItemSnippet();
            newPlaylistItem.Snippet.PlaylistId = newPlaylist.Id;
            newPlaylistItem.Snippet.ResourceId = new ResourceId();
            newPlaylistItem.Snippet.ResourceId.Kind = "youtube#video";
            newPlaylistItem.Snippet.ResourceId.VideoId = "GNRMeaz6QRI";
            newPlaylistItem = await youtubeService.PlaylistItems.Insert(newPlaylistItem, "snippet").ExecuteAsync();

            Console.WriteLine("Playlist item id {0} was added to playlist id {1}.", newPlaylistItem.Id, newPlaylist.Id);
        }

        public void authtori1(CookieContainer cookie)
        {

            var client = new RestClient("https://accounts.google.com/ServiceLogin?service=youtube&uilel=3&passive=true&continue=https%3A%2F%2Fwww.youtube.com%2Fsignin%3Faction_handle_signin%3Dtrue%26app%3Ddesktop%26hl%3Dru%26next%3Dhttps%253A%252F%252Fwww.youtube.com%252F%253Fgl%253DUA&hl=ru&ec=65620");
            client.Timeout = -1;
            client.FollowRedirects = true;
           
            client.CookieContainer = cookie;
            //string res = response1.Content.Replace(@")]}'", "");
            //var JSONObj = new JavaScriptSerializer().DeserializeObject(res);












            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Upgrade-Insecure-Requests", "1");
            //client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36";
            //request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            //request.AddHeader("X-Chrome-ID-Consistency-Request", "version=1,client_id=77185425430.apps.googleusercontent.com,device_id=2b917ecb-8e6d-46de-acf8-009a8277d873,signin_mode=all_accounts,signout_mode=show_confirmation");

            //IRestResponse response = client.Execute(request);

            //request = null;
            //request = new RestRequest("https://accounts.google.com/_/lookup/accountlookup?hl=ru&_reqid=85287&rt=j",Method.POST);
            //request.AddHeader("X-Same-Domain", "1");
            //request.AddHeader("Google-Accounts-XSRF", "1");
            //client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36";
            //request.AddHeader("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
            //request.AddHeader("Accept", "*/*");

            //request.AddParameter("azt", "AFoagUXiu41ttJAgNwGHeZIWzpREoQpyTQ:1593376870075");
            //request.AddParameter("bgRequest", "[\"identifier\",\"!DQ6lDi9CcTz3Tft026pYvQXXsu7NEWsCAAAASFIAAAAJmQOERcoiNOJAQWUvklZS2KRoolEP-k3zRXRszCBcAKyBu-PGkdneo8PPls6UPufqQc53MOw9EwAhrD2unBqpHaz41has7HgwUMy6JJt-v2UqqBblScVC91dSHi9g-uJrhwZvlBB9KiNVyEQXRjiEo6DZ_Ymo0X-urohzP-45_YilMcWkkPMuHAFgvXpqHIGGcYbuvQI5QgxFJvLBMc01xLI9kpCbyx63Tnq0QxBqfG3hKIGsXiz3qrD_4feBqplYeyw2GcVyEIu8pbXGlKdwpFfMGt8wBW95W9x7PN7A7WAERaRnbxKDyyUSsOGVKsKNZG89oqTHlRYBVnifqPsNTYqMvKNMSbOq-JJVepj7YP0MiOEsEb4jr4Y9wgsfmGBmyA-fVjeSR-ynIwfx9sxVoQ3pi0buXeZqWgYOh4VdFuUhA0pYCajhjz-PgshAqlMWenwFXqhOQGnpeLHViWRUMK3RuJIrMF9F1JcM3nu8TpfNR6v4a-U7EBXeAHZ31BVbPzKtl7YUdcz-Ax4xb1pzq2U0COwtVziyLqqmBO-hG-ElRUJwujJuDJCyhedGJaFLQMgC8LBMZ-ArZqmPaggKOkZQlFWbSDCFGSd57rEW8OgvJLB9epQzAiEQLO55L0MfDbteUTRKHB3gaZD6ejioBGdsMuoY-57X0_MCq6OiZKLkJngaV6DzKetAAMlbORjbAWk-mizfsUZ8418LPikic3nh0KChMBgEqsJRnMB-gjTkOrhWoPj9_C7w41y8DhrWxQQpPo1e43UJVi7DH4kPbrs9ahZc4xjYqjx0uGUuSILrGBt5tQR8rG3uonANmNyfSYdUxC9WVb2m-F7YdqmZ6wjY-7s8VEsskWBlOIy_Fh9Xr7esm3tZDChW5C2JDd3s5xGgwGmpCs0MWUneUAJ_WN2v3BhVyQ5QP86V6L16GpwWZPRBS0XnBRkYbUFSmwwQw88fbzRpkqKwLjI_64_dIM2PcyxfY59HrTkjUbY-RX4O4fOwKNBXzjXxdfJbwszkVpgfptzzNLdtNuUYEh7WfxkSTv6a0ZHzIlP0at86Ea2M0v14mG7xWjDZ4FY0ziEmquNvn3iitbkS-p3oMmDTdpaMiRUb4CR3eg9vmMFq3HQeO2cLzFEhjWI5BTeEcQbM4ny306E2tMkfqa7OVYcvSQ5eTGv_2OFu2h_y2xAHbxdT4_khJ0Ig\"]");
            //request.AddParameter("checkConnection", "youtube:93:1");
            //request.AddParameter("checkedDomains", "youtube");
            //request.AddParameter("continue", "https://www.google.com/search?q=youtube&oq=you&aqs=chrome.0.69i59j69i57j0l2j69i60l4.849j0j7&sourceid=chrome&ie=UTF-8");
            //request.AddParameter("cookiesDisabled", "false");
            //request.AddParameter("f.req", "[\"zilainfo@gmail.com\",\"AEThLlzWPr0ILdVvN_AXeDJ374PAPpHG63g1hoq3xJA0zjdTNJ5ruYBDBt4NPn9txnqMzO_Yojk7QWi6clxPdtmqqzTj-BQUzxZLt2nY8NpLx2r1Woi9-cfyX-YW4DHbr6XRXOg2S0sDlhnyMxvOysC7q3BrbotF-WivvL9FqjKihtNSKx_AUAffO2V66N4WVx-uxwb6Q6fI\",[],null,\"UA\",null,null,2,false,true,[null,null,[2,1,null,1,\"https://accounts.google.com/ServiceLogin?hl=ru&passive=true&continue=https%3A%2F%2Fwww.google.com%2Fsearch%3Fq%3Dyoutube%26oq%3Dyou%26aqs%3Dchrome.0.69i59j69i57j0l2j69i60l4.849j0j7%26sourceid%3Dchrome%26ie%3DUTF-8\",null,[],4,[],\"GlifWebSignIn\",null,[]],10,[null,null,[],null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,[5,\"77185425430.apps.googleusercontent.com\",[\"https://www.google.com/accounts/OAuthLogin\"],null,null,\"2b917ecb-8e6d-46de-acf8-009a8277d873\",null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,5,null,null,[],null,null,null,[],[]],null,null,null,null,null,null,[],null,null,null,[],[]],null,null,null,true],\"zilainfo@gmail.com\",null,null,null,true,true,[]]");
            //request.AddParameter("gmscoreversion", "undefined");
            //request.AddParameter("hl", "ru");
            //request.AddParameter("pstMsg", "1");

            //IRestResponse response1 = client.Execute(request);

            // request = new RestRequest("https://accounts.google.com/_/signin/selectchallenge?hl=ru&TL=AM3QAYb9nOs9FBiHjpkWp0Nv5_arNU2lP1_CIdGBopwZKqFBwOT640mIUXsz2nLb&_reqid=238079&rt=j",Method.POST);
            //request.AddHeader("X-Same-Domain", "1");
            //request.AddHeader("Google-Accounts-XSRF", "1");
            //client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36";
            //request.AddHeader("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
            //request.AddHeader("Accept", "*/*");
            //request.AddParameter("azt", "AFoagUVcYj5iSuXscKu_or6zoFIW-B7kdA:1593416074994");
            //request.AddParameter("checkConnection", "youtube:81:1");
            //request.AddParameter("checkedDomains", "youtube");
            //request.AddParameter("continue", "https://myaccount.google.com/webapproval");
            //request.AddParameter("cookiesDisabled", "false");
            //request.AddParameter("deviceinfo", "[null,null,null,[],null,\"UA\",null,null,[],\"GlifWebSignIn\",null,[null,null,[],null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,[5,\"77185425430.apps.googleusercontent.com\",[\"https://www.google.com/accounts/OAuthLogin\"],null,null,\"837d23d1-e831-4fd4-a184-a2da2cc2faf3\",null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,5,null,null,[],null,null,null,[],[]],null,null,null,null,null,null,[],null,null,null,[],[]],null,null,null,null,1]");
            //request.AddParameter("f.req", "[3,null,null,null,[1]]");
            //request.AddParameter("flowEntry", "ServiceLogin");
            //request.AddParameter("flowName", "GlifWebSignIn");
            //request.AddParameter("followup", "https://myaccount.google.com/webapproval");
            //request.AddParameter("gmscoreversion", "undefined");
            //request.AddParameter("osid", "1");
            //request.AddParameter("pstMsg", "1");
            //request.AddParameter("rart", "ANgoxcfakluTduYjeH_XVvoAUb_PueQpGL0K1cypXQvTlB5rbkgg_-tP2Zn96Dhtv2rom67d4ofAZhR9eH_Zk2641u_nT7K5Nw");
            //request.AddParameter("service", "accountsettings");
            //client.Execute(request);


            // request = new RestRequest("https://accounts.google.com/_/signin/challenge?hl=ru&TL=AM3QAYZTzaf4RsJjv4IozGzGrZtDx0T5Y89WlLmQCcy7MGXkun-UWXYBCSDuhMk0&_reqid=437823&rt=j",Method.POST);
            //request.AddHeader("X-Same-Domain", "1");
            //request.AddHeader("Google-Accounts-XSRF", "1");
            //client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36";
            //request.AddHeader("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
            //request.AddHeader("Accept", "*/*");
            //request.AddParameter("azt", "AFoagUWTWLWwPClwpXPGu4ZY7PdsKfGdhw:1593415807884");
            //request.AddParameter("bgRequest", "[\"identifier\",\"!3t2l3fxCZwkElC4pR7NYMD1mAvRoD9YCAAAASVIAAAAKmQN_uM0wtp02_04_0HmaQQg8__4ikkyFpAUFZfTN7fKLoFObe72fCwnMgdyiQ2A9REJ8gfYcqLdr4mxE_xb0IoEo083oGU_3XWmBAnd2Mi1a80vRqVoeXyPAN0MHWvThuVfS4G2QLud6gf1JVgxAdNCwbHSDB4rut4dYAGr-FrwvDRL2kQQCHKa1c72AFWwkZpWMMB2zsKBJw8mFhdeGL_KuAtNAn04udfxFA4ur_UBthGJT4EtRYZuiUs4XIkxnA81Exh_jMphKMy8kojNLL30n96gUHLT5rqZoxvLsgTMhx08jfx837D4oHQMzaswvky1CvCv4qsq9dgkYVD7HxH3_mnckFIqQkqixNPG3JWvVcymq-Zi12Z4DcaIxTCzLpPiHv_3h-hvJANPi5HR9HNVZWsaTbFH8KD4tN9nQ0wXfscnG0J93QmKlf97WK3z8iCB1rIlSUCpssYF7HDvkNgQhwsmu_l96k0CyyDDBCyU1HYUYswIHfXocI3BREsbdq7tzv-S_kKIethDm61gktStI-VFnXAVmHuW9Qh4se8uhDJ-fdnTsPYKKQb8Mb_aWRSPxyfXsFwzmfKKtrczIIJwW4-gl0bwCw0ejckXkVLlykPgtlkHbsl_vPZxMlzxg6P6DzYs83MwPAsaFdGNj3ln3f0RqtpEv3cXSWtqlZtQQTJkJbxTOkPgnYh-S9tp-wW3zK83aYBbyje6VVbHknfSXwiQ1hdVeR1jtKAwtPZ4BPLeKOqLL59KSasy3lSa65jo-pLoSs9s4NsBGwPHoLZz-cQn0RnheqwchSX6kJUKWfcOU0sA7Igvm2XRYUI7DcR6YH_UYnLvQleh0MDB1fDmymSarm67wwTdxbqiUOMaUdHi_1hFUVBL6eZImkQBMqqz8WrsD6lDWpXdeW1kOHxudNCnzBPYQTZs9By8LBQ6gTqdcyTPLZYPhV1gVRmCv6jxyBZXxcGoeYYBm-KwA7tPYvVRHCm-oLCNqFTkU0RY_X88tYsmEZWqKYMRbDtJ1M1uxyoL5msbDyOsglXBZAmyOqvAPk0Hyo0MdvHLIBNHFTLdw1MTtArTWp2VkyVIpKu0IQkKJQrZQ3nMHmr458kqJ0QS9sa9-EX0r9QyT6gsPbSJzzyFnp8bJwp7Z711ybKmFHtU_otytqLogqeY45q3z9vRHU8dgJ37HamBUdZexUQ\"]");
            //request.AddParameter("bghash", "ba6Dn4r_Dk031uZ4qacx0Eex0RxKJrFnWJZeHNR1L3I");
            //request.AddParameter("checkConnection", "youtube:81:1");
            //request.AddParameter("checkedDomains", "youtube");
            //request.AddParameter("continue", "https://www.google.com/search?q=youtube&oq=you&aqs=chrome.0.0j69i57j0l3j69i60l3.2808j0j9&sourceid=chrome&ie=UTF-8");
            //request.AddParameter("cookiesDisabled", "false");
            //request.AddParameter("deviceinfo", "[null,null,null,[],null,\"UA\",null,null,[],\"GlifWebSignIn\",null,[null,null,[],null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,[5,\"77185425430.apps.googleusercontent.com\",[\"https://www.google.com/accounts/OAuthLogin\"],null,null,\"474bda7b-1f2f-48dc-9912-b155b809ca25\",null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,5,null,null,[],null,null,null,[],[]],null,null,null,null,null,null,[],null,null,null,[],[]],null,null,null,null,1]");
            //request.AddParameter("f.req", "[\"AEThLlxwKJgb5niKiC1IKapU4juPIb3CSMEZcfLopbzXKFsypzeGHmh2Y24sVEA78rZABkN5LVrGtU4Ztm6jcvM0BW-GzqM7gEwZOEP5j_VTLFIEjiTIyZ1wCdFy6YhWYa8YP9_h2kXah67M6gmWVzHNz6XvP4dX5Og2fCbwGuKM6onrOjIDq71U_1BDUCd8shXyL5xxg0JGkrXWyeST0vKMx2-7ci4CmduxeeNzD_HdCUmIJUx1UeqoRrRkkiCBfpo_sPcQU5hOE4EWvWuaO6Nu1Ud_Z6_XN_kqdRWfT_-qhK01B_8V1Y1pIWnq5cTTmaw48kdajCTRcJGz-2Sd6xYy5TAKz5BrRWlkUoIbQ58FbhARyTOERfGnrzHx_C2uoiPZ6hra31KPF2MHNrXnAv5Myy096oD0Tyyn1_5tvV3zwpdU7OqzzeQZaF50yKyvHr5AajNZNikNAKmjWH3IhOp9v2z_hnpTswZTM6fn6En-YRvhTy7BtWq66_i5_EFBWM5yj2oIjJWaVPL2BkJUwv9OS6tkqjgsXdf53kYdoI8L0zHmndcA4EdgPzOtpUk3KnEcjJATdcFqhcUKcAQI-5K1NnRKN2qIjgu_wK33DiSGh-gSEgqcIOatx_PJgkQaPkCk2eJNOZYoHKDj5o4h8jFOwOaaiDqZHLNvi2fSEfyo3QcRv8HXwxhNXECiIfzdDuDP3ecqeZNMKmodOtNQNmWMxUyzUBsw2UWZCNr5blmq2UsEvCA95hvgTxka-26AxpglZO7X5D3RBtRt_-vVsiFqqXraaP8D1w3P0ZZzcm3rVXOO8QYR7NI\",null,3,null,[1,null,null,null,[\"5091996KstasNew\",null,true]]]");
            //request.AddParameter("gmscoreversion", "undefined");
            //request.AddParameter("hl", "ru");
            //request.AddParameter("pstMsg", "1");
            //response = client.Execute(request);
            //Console.WriteLine(response.Content);



            //string res = response1.Content.Replace(@")]}'", "");
            //var JSONObj = new JavaScriptSerializer().DeserializeObject(res);

            //res = res;
            //Console.WriteLine(response.Content);


        }














            public void authtori()
        {

























            var client = new RestClient("https://accounts.google.com/signin/v2/identifier?service=youtube&uilel=3&passive=true&continue=https%3A%2F%2Fwww.youtube.com%2Fsignin%3Faction_handle_signin%3Dtrue%26app%3Ddesktop%26hl%3Dru%26next%3Dhttps%253A%252F%252Fwww.youtube.com%252F%253Fgl%253DUA&hl=ru&ec=65620&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
            client.Timeout = -1;
            var request1 = new RestRequest(Method.GET);
            request1.AddHeader("Upgrade-Insecure-Requests", "1");
    
            request1.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            request1.AddHeader("X-Chrome-ID-Consistency-Request", "version=1,client_id=77185425430.apps.googleusercontent.com,device_id=77864d64-58f5-4816-bd2d-23318cb6e626,signin_mode=all_accounts,signout_mode=show_confirmation");
            IRestResponse response1 = client.Execute(request1);
          



            var request = new RestRequest(Method.POST);

     
            request.AddParameter("checkConnection", "youtube:93:1");
            request.AddParameter("checkedDomains", "youtube");
            request.AddParameter("continue", "https://www.google.com/search?q=youtube&oq=you&aqs=chrome.0.69i59j69i57j0l2j69i60l4.849j0j7&sourceid=chrome&ie=UTF-8");
            request.AddParameter("cookiesDisabled", "false");
            request.AddParameter("deviceinfo", "[null,null,null,[],null,\"UA\",null,null,[],\"GlifWebSignIn\",null,[null,null,[],null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,[5,\"77185425430.apps.googleusercontent.com\",[\"https://www.google.com/accounts/OAuthLogin\"],null,null,\"2b917ecb-8e6d-46de-acf8-009a8277d873\",null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,5,null,null,[],null,null,null,[],[]],null,null,null,null,null,null,[],null,null,null,[],[]],null,null,null,null,1]");
            request.AddParameter("f.req", "[\"zilainfo@gmail.com\",\"AEThLlzWPr0ILdVvN_AXeDJ374PAPpHG63g1hoq3xJA0zjdTNJ5ruYBDBt4NPn9txnqMzO_Yojk7QWi6clxPdtmqqzTj-BQUzxZLt2nY8NpLx2r1Woi9-cfyX-YW4DHbr6XRXOg2S0sDlhnyMxvOysC7q3BrbotF-WivvL9FqjKihtNSKx_AUAffO2V66N4WVx-uxwb6Q6fI\",[],null,\"UA\",null,null,2,false,true,[null,null,[2,1,null,1,\"https://accounts.google.com/ServiceLogin?hl=ru&passive=true&continue=https%3A%2F%2Fwww.google.com%2Fsearch%3Fq%3Dyoutube%26oq%3Dyou%26aqs%3Dchrome.0.69i59j69i57j0l2j69i60l4.849j0j7%26sourceid%3Dchrome%26ie%3DUTF-8\",null,[],4,[],\"GlifWebSignIn\",null,[]],10,[null,null,[],null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,[5,\"77185425430.apps.googleusercontent.com\",[\"https://www.google.com/accounts/OAuthLogin\"],null,null,\"2b917ecb-8e6d-46de-acf8-009a8277d873\",null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,5,null,null,[],null,null,null,[],[]],null,null,null,null,null,null,[],null,null,null,[],[]],null,null,null,true],\"zilainfo@gmail.com\",null,null,null,true,true,[]]");
            request.AddParameter("gmscoreversion", "undefined");
            request.AddParameter("hl", "ru");
            request.AddParameter("pstMsg", "1");
            IRestResponse response = client.Execute(request);
    
            Console.WriteLine(response.Content);















            //HttpWebRequest req = new HttpWebRequest();





            //req.AllowAutoRedirect = true;
            //req.IgnoreProtocolErrors = true;
            //req.MaximumAutomaticRedirections = 100;
            //req.Proxy = ProxyClient.Parse(ProxyType.Http, "127.0.0.1:8888");
            //req.Cookies = new CookieDictionary();
            //req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:51.0) Gecko/20100101 Firefox/51.0";
            //string result = null;
            //req["Upgrade-Insecure-Requests"] = "1";
            //req["Keep-Alive"] = "300";
            //req["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            //req["Accept-Language"] = "ru-RU,ru;q=0.8,en-US;q=0.5,en;q=0.3";

            //while (true)
            //{
            //    try
            //    {
            //        result = req.Get("https://accounts.google.com/ServiceLogin?continue=https%3A%2F%2Fwww.youtube.com%2Fsignin%3Fnext%3Dhttps%253A%252F%252Fm.youtube.com%252F%253Frdm%253D2jh9jl5hc%26app%3Dm%26feature%3Dblazerbootstrap%26action_handle_signin%3Dtrue%26hl%3Dru%26noapp%3D1&hl=ru&passive=true&service=youtube&uilel=3").ToString();
            //        break;
            //    }
            //    catch (Exception) { }

            //}
            //string GALX = Utils.pars(result, @"name=""GALX"" value=""(.*?)""");
            //string gfx = Utils.pars(result, @"name=""gxf"" value=""(.*?)""");

            //while (true)
            //{
            //    try
            //    {
            //        req.AddParam("Email", "ТВОЙ ЕМАИЛ");
            //        req.AddParam("requestlocation", "https://accounts.google.com/ServiceLogin?continue=https%3A%2F%2Fwww.youtube.com%2Fsignin%3Fnext%3Dhttps%253A%252F%252Fm.youtube.com%252F%253Frdm%253D2jh9jl5hc%26app%3Dm%26feature%3Dblazerbootstrap%26action_handle_signin%3Dtrue%26hl%3Dru%26noapp%3D1&hl=ru&passive=true&service=youtube&uilel=3#identifier");
            //        req.AddParam("Page", "PasswordSeparationSignIn");
            //        req.AddParam("GALX", GALX);
            //        req.AddParam("gxf", gfx);
            //        req.AddParam("continue", "https://www.youtube.com/signin?next=https%3A%2F%2Fm.youtube.com%2F%3Frdm%3D2jh9jl5hc&app=m&feature=blazerbootstrap&action_handle_signin=true&hl=ru&noapp=1");
            //        req.AddParam("service", "youtube");
            //        req.AddParam("hl", "ru");
            //        req.AddParam("_utf8", "");
            //        req.AddParam("pstMsg", "1");
            //        //req.AddParam("checkConnection", "youtube:656:1");
            //        req.AddParam("checkedDomains", "youtube");
            //        req.AddParam("PersistentCookie", "yes");
            //        //req.AddParam("", "");

            //        result = req.Post("https://accounts.google.com/_/signin/v1/lookup").ToString();
            //        break;
            //    }
            //    catch (Exception) { }
            //}

            //string prof_state = Utils.pars(result, @"""encoded_profile_information"":""(.*?)""");
            //string session_state = Utils.pars(result, @"""session_state"":""(.*?)""");


            //while (true)
            //{
            //    try
            //    {
            //        // req.AddHeader("Referer", "https://accounts.google.com/ServiceLogin?passive=1209600&continue=https://accounts.google.com/o/oauth2/auth?state%3DoFFb6OeFH1OatIt13xSqusB82VA67Uan%26redirect_uri%3Dhttp://smmok-yt.ru/complete/google-oauth2/%26response_type%3Dcode%26client_id%3D881376626299-rmdnjpro3lgd5n17c5cvupc9639t2702.apps.googleusercontent.com%26scope%3Dhttps://www.googleapis.com/auth/userinfo.email%2Bhttps://www.googleapis.com/auth/userinfo.profile%2Bhttps://www.googleapis.com/auth/youtube.readonly%2Bhttps://www.googleapis.com/auth/youtubepartner%2Bhttps://www.googleapis.com/auth/youtube.force-ssl%2Bhttps://www.googleapis.com/auth/youtube%2Bhttps://www.googleapis.com/auth/plus.login%2Bhttps://www.googleapis.com/auth/plus.me%26access_type%3Doffline%26from_login%3D1%26as%3D-d8d28d69f4e1395&ltmpl=nosignup&oauth=1&sarp=1&scc=1");
            //        // req.AddHeader("Upgrade-Insecure-Requests", "1");
            //        req.AddParam("Page", "PasswordSeparationSignIn");//
            //        req.AddParam("GALX", GALX);//
            //        req.AddParam("gxf", gfx);//
            //        req.AddParam("continue", "https://www.youtube.com/signin?next=https%3A%2F%2Fm.youtube.com%2F%3Frdm%3D2jh9jl5hc&app=m&feature=blazerbootstrap&action_handle_signin=true&hl=ru&noapp=1");
            //        req.AddParam("service", "youtube");
            //        req.AddParam("hl", "ru");
            //        req.AddParam("ProfileInformation", prof_state);//
            //        req.AddParam("SessionState", session_state);//
            //        req.AddParam("_utf8", "");//
            //        req.AddParam("pstMsg", "1");
            //        //req.AddParam("checkConnection", "youtube:656:1");
            //        req.AddParam("checkedDomains", "youtube");
            //        req.AddParam("identifiertoken", "");
            //        req.AddParam("identifiertoken_audio", "");
            //        req.AddParam("identifier-captcha-input", "");
            //        req.AddParam("Email", "ТВОЙ ЕМАИЛ");
            //        req.AddParam("Passwd", "ТВОЙ ПАРОЛЬ");
            //        req.AddParam("PersistentCookie", "yes");
            //        result = req.Post("https://accounts.google.com/signin/challenge/sl/password").ToString();
            //        break;
            //    }
            //    catch (Exception e)
            //    {
            //        MessageBox.Show(e.ToString());
            ////    }
            //}
        }




    }



}