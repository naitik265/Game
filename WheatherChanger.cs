using UnityEngine;

public class WeatherChanger : MonoBehaviour
{
    public Material morningTerrain;
    public Material eveningTerrain;
    public Material nightTerrain;
    public Light sun;

    void Update()
    {
        float time = System.DateTime.Now.Hour;
        if (time >= 6 && time < 18) // Daytime
        {
            RenderSettings.skybox = morningTerrain;
            sun.intensity = 1f;
        }
        else if (time >= 18 && time < 21) // Evening
        {
            RenderSettings.skybox = eveningTerrain;
            sun.intensity = 0.5f;
        }
        else // Night
        {
            RenderSettings.skybox = nightTerrain;
            sun.intensity = 0.2f;
        }
    }
}