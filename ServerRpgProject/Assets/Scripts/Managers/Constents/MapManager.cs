using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MapManager
{
    /*public Grid CurrentGrid { get; private set; }*/
    CameraController cam;

/*    public int MinX { get; set; }
    public int MaxX { get; set; }
    public int MinY { get; set; }
    public int MaxY { get; set; }

    bool[,] collision;*/

/*    public bool CanGo(Vector3Int cellPos)
    {
        if (cellPos.x < MinX || cellPos.x > MaxX)
            return false;
        if (cellPos.y < MinY || cellPos.y > MaxY)
            return false;

        int x = cellPos.x - MinX;
        int y = MaxY - cellPos.y;
        return !collision[y, x];
    }*/

    public void LoadMap(int mapId)
    {
        DestroyMap();

        string mapName = "Map_" + mapId.ToString("000");
        GameObject map = Managers.Resource.Instantiate($"Map/{mapName}");
        map.name = "Map";

        /*CurrentGrid = go.GetComponent<Grid>();*/

        TextAsset txt = Managers.Resource.Load<TextAsset>($"Map/{mapName}");



        if (cam == null)
             cam = GameObject.Find("Main Camera").GetComponent<CameraController>();
        Transform border = map.transform.Find("Border");

        cam.BorderSetting(border.Find("MinPosition"), border.Find("MaxPosition"));

        /*StringReader reader = new StringReader(txt.text);

        MinX = int.Parse(reader.ReadLine());
        MaxX = int.Parse(reader.ReadLine());
        MinY = int.Parse(reader.ReadLine());
        MaxY = int.Parse(reader.ReadLine());
        int xCount = MaxX - MinX + 1;
        int yCount = MaxY - MinY + 1;
        this.collision = new bool[yCount, xCount];
        for (int y= 0; y < yCount; y++)
        {
            string line = reader.ReadLine();
            for (int x = 0; x < xCount; x++)
            {
                this.collision[y, x] = (line[x] == '1');
            }
        }*/
    }

    public void DestroyMap()
    {
        GameObject map = GameObject.Find("Map");
        if (map != null)
        {
            GameObject.Destroy(map);
        }
    }
}
