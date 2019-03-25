using System.Net.Http;
using System;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Mappy.Helpers;
using System.Net;
using System.IO;
using Mappy.Entities;
using System.Collections.Generic;

namespace Mappy
{
    static class API
    {
        private static int total = 0;
        private static bool requestInAction = false;
        private static bool enabled = false;

        /// <summary>
        /// Toggle the submitting of map data to XIVAPI
        /// </summary>
        public static void ToggleMapSubmissions()
        {
            enabled = !enabled;
        }

        public static bool IsEnabled()
        {
            return enabled;
        }

        /// <summary>
        /// Check an API key can submit data to XIVAPI
        /// </summary>
        public static async void CheckApiKey()
        {
            try 
            {
                Logger.Add("Validating XIVAPI key...");

                dynamic response = await $"{Properties.Settings.Default.ApiUrl}/mappy/check-key?private_key={Properties.Settings.Default.ApiKey}".GetJsonAsync();
                App.Instance.HandleKeyVerification(response.ok, response.user);
            } 
            catch (Exception ex) 
            {
                Logger.Exception(ex, "Mappy -> CheckApiKey");
                App.Instance.HandleKeyVerification(false, null);
            }
        }


        /// <summary>
        /// Submit some data (Even if you hard code this, there are server checks XD)
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        public static async void SubmitData(string type, List<Entity> data)
        {
            // if submit turned off
            if (!enabled || String.IsNullOrEmpty(Properties.Settings.Default.ApiKey)) {
                return;
            }

            total++;
            App.Instance.labelTotalSubmits.Text = total.ToString();

            // assign a payload id
            Random random = new Random();
            int id = 100000 + random.Next(899999);

            // log payload information
            Logger.Add($"---> [#{id}] Submitting json data to xivapi");
            App.Instance.labelSubmitStatus.Text = $"(API) Sending payload: #{id}";

            try {
                // submit to api
                await $"{Properties.Settings.Default.ApiUrl}/mappy/submit?private_key={Properties.Settings.Default.ApiKey}".PostJsonAsync(new
                {
                    id,
                    type,
                    data,
                });
                Logger.Add($"---> [#{id}] Json data submitted successfully");
                App.Instance.labelSubmitStatus.Text = $"(API) Payload #{id} sent";
            } catch (Exception ex) {
                Logger.Add($"Error: {ex.Message}");
                Logger.Exception(ex, $"COULD NOT SAVE PAYLOAD: [#{id}]");
            }
        }

        /// <summary>
        /// Get map image from XIVAPI
        /// </summary>
        /// <param name="id"></param>
        public static async void GetMapImage(uint id)
        {
            // if a request is in action or id is zero, do nothing
            if (requestInAction || id == 0) {
                return;
            }

            requestInAction = true;

            try
            {
                // get map json
                Logger.Add($"[GET] {Properties.Settings.Default.ApiUrl}/Map/{id}");
                HttpResponseMessage mapRequest = await new Url($"{Properties.Settings.Default.ApiUrl}/Map/{id}?t=123").GetAsync();
                dynamic Map = JsonConvert.DeserializeObject(mapRequest.Content.ReadAsStringAsync().Result);
                Logger.Add($"[RESPONSE] MapID: {Map.ID}");

                // get placename json
                Logger.Add($"[GET] {Properties.Settings.Default.ApiUrl}/PlaceName/{Map.PlaceName.ID}");
                HttpResponseMessage placeNameRequest = await new Url($"{Properties.Settings.Default.ApiUrl}/PlaceName/{Map.PlaceName.ID}").GetAsync();
                dynamic PlaceName = JsonConvert.DeserializeObject(placeNameRequest.Content.ReadAsStringAsync().Result);
                Logger.Add($"[RESPONSE] PlaceNameID: {PlaceName.ID}");

                try
                {
                    Logger.Add("Deserializing map data");
                    requestInAction = false;

                    try
                    {
                        // set size factor and layer count
                        Map.SizeFactor = (double)(Map.SizeFactor / 100.0);
                        Map.LayerCount = PlaceName.GameContentLinks.Map.PlaceName.Count;

                        // download map and set it on the map visual
                        Logger.Add($"[DOWNLOAD] {Properties.Settings.Default.ApiUrl}{Map.MapFilename}");
                        Map.LocalFilename = DownloadImage($"{Properties.Settings.Default.ApiUrl}{Map.MapFilename}");
                        App.Instance.MapViewer.SetMapVisual(Map);

                        // set axis restriction
                        App.Instance.TrackingEnemies.SetAxisRestriction((int)Map.LayerCount > 1);
                        App.Instance.TrackingNpcs.SetAxisRestriction((int)Map.LayerCount > 1);

                        // enable memory timer
                        App.Instance.StartZonedTimerCountdown();
                    }
                    catch (Exception ex)
                    {
                        Logger.Exception(ex, "Viewer -> getMapImage (1)");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Exception(ex, "Viewer -> getMapImage (2)");
                }
            }
            catch (Exception ex)
            {
                Logger.Exception(ex, "Viewer -> getMapImage (3)");
            }
        }

        /// <summary>
        /// Download the image
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string DownloadImage(string filename)
        {
            if (!Directory.Exists(AppHelper.getApplicationPath() + "/maps/"))
            {
                Directory.CreateDirectory(AppHelper.getApplicationPath() + "/maps/");
            }

            var saveto = AppHelper.getApplicationPath() + "/maps/" + Path.GetFileName(filename);

            // if file does not exist, download it
            if (!File.Exists(saveto))
            {
                Logger.Add("downloading: " + Path.GetFileName(filename));
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(filename, saveto);
                }
            }

            return saveto;
        }
    }
}
