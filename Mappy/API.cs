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

        //
        // Submit data
        //
        public static async void SubmitData(List<Entity> data)
        {
            // if submit turned off
            if (!Properties.Settings.Default.Submit || String.IsNullOrEmpty(Properties.Settings.Default.ApiKey)) {
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
                await "http://xivapi.local/data/submit".PostJsonAsync(new
                {
                    key = Properties.Settings.Default.ApiKey,
                    id,
                    data,
                });
                Logger.Add($"---> [#{id}] Json data submitted successfully");
                App.Instance.labelSubmitStatus.Text = $"(API) Payload #{id} sent";
            } catch (Exception ex) {
                Logger.Exception(ex, "API Submit");
            }
        }

        //
        // Get map image list
        //
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
                Logger.Add($"[GET] http://xivapi.com/Map/{id}");
                HttpResponseMessage mapRequest = await new Url($"http://xivapi.com/Map/{id}").GetAsync();
                dynamic Map = JsonConvert.DeserializeObject(mapRequest.Content.ReadAsStringAsync().Result);
                Logger.Add($"[RESPONSE] MapID: {Map.ID}");

                // get placename json
                Logger.Add($"[GET] http://xivapi.com/PlaceName/{Map.PlaceName.ID}");
                HttpResponseMessage placeNameRequest = await new Url($"http://xivapi.com/PlaceName/{Map.PlaceName.ID}").GetAsync();
                dynamic PlaceName = JsonConvert.DeserializeObject(placeNameRequest.Content.ReadAsStringAsync().Result);
                Logger.Add($"[RESPONSE] PlaceNameID: {PlaceName.ID}");

                try
                {
                    Logger.Add("Deserializing map data");
                    requestInAction = false;

                    try
                    {
                        // set size factor and layer count
                        Map.SizeFactor = (double)Map.SizeFactor / 100.0;
                        Map.LayerCount = PlaceName.GameContentLinks.Map.PlaceName.Count;

                        // download map and set it on the map visual
                        Logger.Add($"[DOWNLOAD] http://xivapi.com{Map.MapFilename}");
                        Map.LocalFilename = DownloadImage($"http://xivapi.com{Map.MapFilename}");
                        App.Instance.MapViewer.SetMapVisual(Map);

                        // set axis restriction
                        App.Instance.TrackingEnemies.setAxisRestriction((int)Map.LayerCount > 1);
                        App.Instance.TrackingNpcs.setAxisRestriction((int)Map.LayerCount > 1);

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
