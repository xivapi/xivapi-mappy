using Sharlayan.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Mappy.Entities;
using Mappy.Helpers;

namespace Mappy
{
    public partial class MapViewer : Form
    {
        // Map Icons
        private MapIcon MapPlayer;
        private ActorItem player;
        private MapIcon MapCameraHeading;
        private float cameraHeading;
        private List<MapIcon> MapTrail = new List<MapIcon>();
        private List<MapIcon> MapTrailMini = new List<MapIcon>();
        private List<MapIcon> MapIcons = new List<MapIcon>();

        private List<int> xPositions = new List<int>();
        private List<int> yPositions = new List<int>();
        private List<int> MarkerIds = new List<int>();
        private int SelectedMarker = 0;

        // Random Variables
        public dynamic Map;
        public Bitmap MapBackground = null;
        public bool Scanning = false;
        
        // init
        public MapViewer()
        {
            InitializeComponent();
            MapBackground = new Bitmap("assets\\map_default.png");
        }

        public void SetMapCountdown(string text)
        {
            mapCountdown.Text = text;
        }

        //
        // Player position update
        //
        private void UpdateTicker_Tick(object sender, EventArgs e)
        {
            UpdateTicker.Enabled = false;
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            // create timer
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += (sender, e) => {
                if (Scanning)
                {
                    SetPlayerPosition();
                    mapvisual.Invalidate();
                }
            };
            aTimer.Interval = Properties.Settings.Default.MapPlayerTimerSpeed;
            aTimer.Enabled = true;
        }

        //
        // set player position
        //
        private void SetPlayerPosition()
        {
            if (!Scanning) {
                return;
            }

            player = GameMemory.GetPlayer();
            cameraHeading = GameMemory.GetCameraHeading();
            if (player.Name.Length > 0 && (int)Map.ID > 0) {
                SetPlayerIcon(player, cameraHeading);

                try
                {
                    double x = Math.Round(MapHelper.ConvertCoordinatesIntoMapPosition((double)Map.SizeFactor, (double)Map.OffsetX, player.X), 2);
                    double y = Math.Round(MapHelper.ConvertCoordinatesIntoMapPosition((double)Map.SizeFactor, (double)Map.OffsetY, player.Y), 2);

                    // set map pos
                    mappos.Text = String.Format("x {0} / y {1}  -  [{2} / {3}]   -   [OX: {4} / OY: {5}]",
                        x, y, player.X, player.Y, Map.OffsetX, Map.OffsetY
                    );
                }
                catch { }
            }
        }

        //
        // Set scanning state, disabled if querying
        //
        public void SetScanningState(bool state)
        {
            Scanning = state;
        }

        //
        // Set the map image
        //
        public void SetMapVisual(dynamic newMap) 
        {
            try
            {
                // clear icons
                ClearMapIcons();

                // set map
                Map = newMap;
                string hightRestricted = (int)Map.LayerCount > 1 ? "Height Axis Restricted" : "Height Axis Tracking Unrestricted";

                // apply downloaded map to background
                Logger.Add($"Loading map: {Map.LocalFilename}");
                MapBackground = AppHelper.createBitmap((string)Map.LocalFilename);

                // set map status
                mapstatus.Text = String.Format("#{0} - {1} - {2} - {3} (Layers: {4} - {5})",
                    Map.ID, Map.PlaceNameRegion.Name, Map.PlaceName.Name, Map.TerritoryType.PlaceNameZone.Name, Map.LayerCount, hightRestricted
                );

                // set map info
                mapinfo.Text = String.Format("{0} - Marker Range {1} - Scale {2} - Territory ID {3}",
                    Map.LocalFilename, Map.MapMarkerRange, Map.SizeFactor, Map.TerritoryType.ID
                );

                // update status
                App.Instance.SetStatus($"Currently mapping: #{Map.ID} - {Map.PlaceName.Name} - {Map.TerritoryType.PlaceNameZone.Name} - {hightRestricted}");
            }
            catch (Exception ex)
            {
                Logger.Exception(ex, "MapViewer -> setMapVisual");
            }
        }

        /// <summary>
        /// Request the latest map
        /// </summary>
        public void RequestLatestMap()
        {
            // show loading
            uint MapId = GameMemory.GetPlayer().MapID;
            API.GetMapImage(MapId);
        }

        #region Auto-gen

        private void MapViewer_Load(object sender, EventArgs e)
        {
            TopMost = Properties.Settings.Default.AlwaysOnTop;
        }

        private void MapViewer_Closing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void MapViewer_Focused(object sender, EventArgs e)
        {
            TopMost = Properties.Settings.Default.AlwaysOnTop;
        }

        #endregion

        #region Icons!

        /// <summary>
        /// Set the player icon on the map
        /// </summary>
        /// <param name="player"></param>
        private void SetPlayerIcon(ActorItem player, float cameraHeading)
        {
            // convert to game positions
            double x = MapHelper.ConvertCoordinatesIntoMapPosition((double)Map.SizeFactor, (double)Map.OffsetX, player.Coordinate.X);
            double y = MapHelper.ConvertCoordinatesIntoMapPosition((double)Map.SizeFactor, (double)Map.OffsetY, player.Coordinate.Y);

            // check if a player icon already exists or not
            if (MapPlayer.id == 0)
            {
                // Create new player icon bitmap
                MapPlayer = new MapIcon
                {
                    id = 1
                };
            }

            // reset graphic
            Bitmap bitmap = AppHelper.createBitmap("assets\\playerOnly.png");
            MapPlayer.icon = bitmap;
            MapPlayer.width = bitmap.Width;
            MapPlayer.height = bitmap.Height;

            // work out pixel position
            int pixelX = Convert.ToInt32((x - 1) * 50 * (double)Map.SizeFactor) - (MapPlayer.icon.Size.Width / 2);
            int pixelY = Convert.ToInt32((y - 1) * 50 * (double)Map.SizeFactor) - (MapPlayer.icon.Size.Height / 2); 

            // set position and direction
            MapPlayer.x = pixelX;
            MapPlayer.y = pixelY;
            MapPlayer.angle = Math.Abs(player.Heading * (180 / Math.PI) - 180);
            MapPlayer.setRotation();


            // reset graphic
            Bitmap bitmap2 = AppHelper.createBitmap("assets\\camera.png");
            MapCameraHeading.icon = bitmap2;
            MapCameraHeading.width = bitmap.Width;
            MapCameraHeading.height = bitmap.Height;

            // work out pixel position
            int pixelX2 = Convert.ToInt32((x - 1) * 50 * (double)Map.SizeFactor) - (MapCameraHeading.icon.Size.Width / 2);
            int pixelY2 = Convert.ToInt32((y - 1) * 50 * (double)Map.SizeFactor) - (MapCameraHeading.icon.Size.Height / 2);

            // set position and direction
            MapCameraHeading.x = pixelX2;
            MapCameraHeading.y = pixelY2;
            MapCameraHeading.angle = (Math.Abs(cameraHeading * (180 / Math.PI) - 180) + 180) % 360;
            MapCameraHeading.setRotation();

            // add trail, this is done by just dividing the pixel

            int trailDistance = 120;
            int trailDistanceMax = 200;
            int xDistance = 0;
            int yDistance = 0;

            if (MapTrail.Count > 0)
            {
                xDistance = Math.Abs(MapTrail[MapTrail.Count - 1].x - pixelX);
                yDistance = Math.Abs(MapTrail[MapTrail.Count - 1].y - pixelY);
            }

            // if map trail empty or either x or y distance traved is above 100, draw new trail
            if (MapTrail.Count == 0 || (xDistance > trailDistance || yDistance > trailDistance))
            {
                MapIcon MapTrailIcon = new MapIcon
                {
                    icon = AppHelper.createBitmap("assets\\trail.png"),
                    id = (MapTrail.Count + 1),
                    x = pixelX,
                    y = pixelY,
                    angle = 0
                };

                MapTrail.Add(MapTrailIcon);

                // set trail sizes
                MapTrailSizeWidth = MapTrailIcon.icon.Width;
                MapTrailSizeHeight = MapTrailIcon.icon.Height;
            }

            // work out pixel position
            pixelX = Convert.ToInt32((x - 1) * 50 * (double)Map.SizeFactor) - 10;
            pixelY = Convert.ToInt32((y - 1) * 50 * (double)Map.SizeFactor) - 10;

            trailDistance = 20;
            trailDistanceMax = 35;
            xDistance = 0;
            yDistance = 0;

            if (MapTrailMini.Count > 0)
            {
                xDistance = Math.Abs(MapTrailMini[MapTrailMini.Count - 1].x - pixelX);
                yDistance = Math.Abs(MapTrailMini[MapTrailMini.Count - 1].y - pixelY);
            }

            // if map trail empty or either x or y distance traved is above 100, draw new trail
            if (MapTrailMini.Count == 0 || (xDistance > trailDistance || yDistance > trailDistance))
            {
                // Ignore big jumps
                if (xDistance > trailDistanceMax || yDistance > trailDistanceMax)
                {
                    return;
                }

                xPositions.Add(pixelX);
                yPositions.Add(pixelY);

                MapIcon MapTrailMiniIcon = new MapIcon
                {
                    icon = AppHelper.createBitmap("assets\\trailmini.png"),
                    id = (MapTrailMini.Count + 1),
                    x = pixelX,
                    y = pixelY,
                    angle = 0
                };

                MapTrailMini.Add(MapTrailMiniIcon);

                // set trail sizes
                MapTrailMiniSizeWidth = MapTrailMiniIcon.icon.Width;
                MapTrailMiniSizeHeight = MapTrailMiniIcon.icon.Height;
            }
        }

        /// <summary>
        /// Add a enemy icon to the map
        /// </summary>
        /// <param name="entity"></param>
        public void AddEnemyIcon(ActorItem entity)
        {
            string file = "assets\\enemy.png";
            AddIcon(entity, file);
        }

        /// <summary>
        /// Add an NPC icon to the map
        /// </summary>
        /// <param name="entity"></param>
        public void AddNpcIcon(ActorItem entity)
        {
            string file = "assets\\npc.png";
            if (entity.Type.ToString() == "Gathering")
            {
                file = "assets\\gathering.png";
            }
            else if (entity.Type.ToString() == "EObj")
            {
                file = "assets\\object.png";
            }
            else if (entity.Type.ToString() == "Unknown")
            {
                file = "assets\\unknown.png";
            }

            AddIcon(entity, file);
        }

        /// <summary>
        /// Add an icon to the map
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="iconfile"></param>
        private void AddIcon(ActorItem entity, string iconfile)
        {
            try
            {
                if ((double)Map.SizeFactor == 0) {
                    return;
                }

                // convert to game entity
                double x = MapHelper.ConvertCoordinatesIntoMapPosition((double)Map.SizeFactor, (double)Map.OffsetX, entity.Coordinate.X);
                double y = MapHelper.ConvertCoordinatesIntoMapPosition((double)Map.SizeFactor, (double)Map.OffsetY, entity.Coordinate.Y);

                // if positionscome back nothing, skip
                if (x == 0 || y == 0) {
                    return;
                }

                // create bitmap
                Bitmap bitmap = AppHelper.createBitmap(iconfile);
                MapIcon MapIcon = new MapIcon
                {
                    entity = entity,
                    icon = bitmap,
                    id = (MapIcons.Count + 1),
                    width = bitmap.Width,
                    height = bitmap.Height
                };

                // work out pixel position
                double pixelX = Math.Round(((x - 1) * 50 * (double)Map.SizeFactor) - 16, 6);
                double pixelY = Math.Round(((y - 1) * 50 * (double)Map.SizeFactor) - 16, 6);

                if (pixelX == 0 || pixelY == 0) {
                    return;
                }

                MapIcon.x = Convert.ToInt32(pixelX);
                MapIcon.y = Convert.ToInt32(pixelY);
                MapIcons.Add(MapIcon);
            }
            catch (Exception ex)
            {
                Logger.Exception(ex, "MapViewer -> addIcon");
            }
        }

        /// <summary>
        /// Clear map icons
        /// </summary>
        private void ClearMapIcons()
        {
            // clear icons
            MapIcons.Clear();
            MapTrail.Clear();
            MapTrailMini.Clear();
            xPositions.Clear();
            yPositions.Clear();

            // clear list
            MarkerIds.Clear();
            SelectedMarker = 0;
        }

        #endregion

        #region Map Movement

        //
        // Drag the map
        //
        private int offsetX = 0, offsetY = 0;
        private int oldX, oldY;
        private int playerpos = 0;
        private bool mousemovement = false;

        private void VisualMouseDown(object sender, MouseEventArgs e)
        {
            mousemovement = true;

            if (MapPlayer.id == 1) {
                playerpos = MapPlayer.x + MapPlayer.y;
            }
        }

        private void VisualMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                offsetX += e.X - oldX;
                offsetY += e.Y - oldY;
            }

            // prevent out of bounds
            if (Properties.Settings.Default.MapBounds)
            {
                int y = mapvisual.Size.Height - MapBackground.Size.Height;
                int x = mapvisual.Size.Width - MapBackground.Size.Width;
                int boundOffset = 0;

                if (offsetY < (y - boundOffset))
                {
                    offsetY = (y - boundOffset);
                }
                if (offsetX < (x - boundOffset))
                {
                    offsetX = (x - boundOffset);
                }

                if (offsetX > (0 + boundOffset))
                {
                    offsetX = (0 + boundOffset);
                }
                if (offsetY > (0 + boundOffset))
                {
                    offsetY = (0 + boundOffset);
                }
            }

            oldX = e.X;
            oldY = e.Y;

            mapvisual.Invalidate();
        }

        //
        // Draw graphics
        //
        int MapPlayerIconSizeWidth = 0,
            MapPlayerIconSizeHeight = 0,
            MapTrailSizeWidth = 0,
            MapTrailSizeHeight = 0,
            MapTrailMiniSizeWidth = 0,
            MapTrailMiniSizeHeight = 0;

        private void VisualPaint(object sender, PaintEventArgs e)
        {
            // draw the map at the new position
            e.Graphics.CompositingMode = CompositingMode.SourceOver;
            e.Graphics.InterpolationMode = InterpolationMode.Bilinear;

            if ((MapPlayer.x + MapPlayer.y) != playerpos) {
                mousemovement = false;
            }

            if (!mousemovement && MapPlayer.id == 1)
            {
                if (MapPlayerIconSizeWidth == 0)
                {
                    MapPlayerIconSizeWidth = MapPlayer.icon.Size.Width;
                    MapPlayerIconSizeHeight = MapPlayer.icon.Size.Height;
                }

                //  ClientRectangle.Width
                offsetX = 0 - (MapPlayer.x + (MapPlayerIconSizeWidth / 2)) + ((ClientRectangle.Width) / 2);
                offsetY = 0 - (MapPlayer.y + (MapPlayerIconSizeHeight / 2)) + (ClientRectangle.Height / 2);
            }

            try
            {
                lock (MapBackground)
                e.Graphics.DrawImage(MapBackground, offsetX, offsetY, MapBackground.Size.Width, MapBackground.Size.Height);
            } catch { }

            // add trails
            if (MapTrail.Count > 0)
            {
                try
                {
                    foreach (MapIcon icon in MapTrail)
                    {
                        // get new position
                        int new_x = icon.x + offsetX;
                        int new_y = icon.y + offsetY;

                        // draw player icon
                        lock (icon.icon)
                        e.Graphics.DrawImage(icon.icon, new_x, new_y, MapTrailSizeWidth, MapTrailSizeHeight);
                    }
                }
                catch { }
            }

            // add mini trails
            if (MapTrailMini.Count > 0)
            {
                // only show line when more than 1 entry (need a previous entry)
                if (xPositions.Count > 2)
                {
                    try
                    {
                        for (int i = 1; i < xPositions.Count; i++)
                        {
                            int newX = xPositions[i] + offsetX + (MapTrailMiniSizeWidth / 2),
                                newY = yPositions[i] + offsetY + (MapTrailMiniSizeHeight / 2),
                                oldX = xPositions[i - 1] + offsetX + (MapTrailMiniSizeWidth / 2),
                                oldY = yPositions[i - 1] + offsetY + (MapTrailMiniSizeHeight / 2);

                            Pen myPen = new Pen(Color.DodgerBlue)
                            {
                                Width = 3
                            };

                            e.Graphics.DrawLine(myPen, newX, newY, oldX, oldY);

                        }
                    }
                    catch { }
                }
                
                // print mini map trail, blue dots
                try
                {
                    foreach (MapIcon icon in MapTrailMini)
                    {
                        // get new position
                        int new_x = icon.x + offsetX;
                        int new_y = icon.y + offsetY;

                        // draw player icon
                        lock (icon.icon)
                        e.Graphics.DrawImage(icon.icon, new_x, new_y, MapTrailMiniSizeWidth, MapTrailMiniSizeHeight);
                    }
                }
                catch { }
            }

            // if player icon set
            if (MapPlayer.id == 1)
            {
                try
                {
                    int new_x = MapCameraHeading.x + offsetX;
                    int new_y = MapCameraHeading.y + offsetY;

                    lock (MapCameraHeading.icon)
                    e.Graphics.DrawImage(MapCameraHeading.icon, new_x, new_y, MapPlayerIconSizeWidth, MapPlayerIconSizeHeight);
                }
                catch { }

                try
                {
                    // get new position
                    int new_x = MapPlayer.x + offsetX;
                    int new_y = MapPlayer.y + offsetY;

                    // draw player icon
                    lock (MapPlayer.icon)
                    e.Graphics.DrawImage(MapPlayer.icon, new_x, new_y, MapPlayerIconSizeWidth, MapPlayerIconSizeHeight);
                } catch { }
            }

            // if map icons
            if (MapIcons.Count > 0)
            {
                try {
                    foreach (MapIcon icon in MapIcons)
                    {
                        // get new position
                        int new_x = icon.x + offsetX;
                        int new_y = icon.y + offsetY;

                        // draw player icon
                        lock(icon.icon)
                        e.Graphics.DrawImage(icon.icon, new_x, new_y, icon.icon.Size.Width, icon.icon.Size.Height);

                        // highlight selected icon
                        if (SelectedMarker == icon.id)
                        {
                            // draw highlight graphic
                            Bitmap highlight = new Bitmap("assets\\highlight.png");
                            lock(highlight)
                            e.Graphics.DrawImage(highlight, new_x, new_y, highlight.Size.Width, highlight.Size.Height);

                            // add name
                            Font stringFont = new Font("Verdana", 10, FontStyle.Bold);
                            e.Graphics.DrawString(icon.entity.Name, stringFont, Brushes.Black, new_x + 36, new_y + 6);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Logger.Exception(ex, "MapViewer -> VisualPaint");
                }
            }
        }

        #endregion
    }
}
