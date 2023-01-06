using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingmapControl : MonoBehaviour
{
    public Texture2D[] lm = new Texture2D[5];

    bool isDay = true;

    Material daySkybox;
    Material nightSkybox;

    // Start is called before the first frame update
    void Start()
    {
        LightmapData[] data = new LightmapData[LightmapSettings.lightmaps.Length];
        print("222:" + data.Length);

        //for (int i = 0; i < data.Length; i++)
        //{
        //    data[i] = LightmapSettings.lightmaps[i];
        //    data[i].shadowMask = lm[i];
        //}
        //LightmapSettings.lightmaps = data;

        daySkybox = Resources.Load<Material>("Materials/DaySky");
        nightSkybox = Resources.Load<Material>("Materials/NightSky");
    }

    public void Test1122() {
        LightmapData data = new LightmapData();
        string path = "LightingData/";
        if (isDay)
        {
            path += "Day/";
        }
        else {
            path += "Night/";
        }

        data.lightmapColor = Resources.Load<Texture2D>(path + "ReflectionProbe-0");
        data.lightmapDir = Resources.Load<Texture2D>(path + "Lightmap-0_comp_dir");
        data.lightmapColor = Resources.Load<Texture2D>(path + "Lightmap-0_comp_light");
        //data.lightmapLight = greenLightMap;
        LightmapSettings.lightmaps = new LightmapData[1] { data };

        RenderSettings.skybox = isDay ? daySkybox : nightSkybox;

        isDay = !isDay;
    }
}
