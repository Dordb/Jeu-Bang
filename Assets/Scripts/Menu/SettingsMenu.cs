using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public Dropdown resolutionDropdown;
    Resolution[] resolutions;



    void Start()
    {  
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> listOptions = new List<string>();

        int currentResIndex = 0;
        for(int i = 0; i <resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            listOptions.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }
        resolutionDropdown.AddOptions(listOptions);
        resolutionDropdown.value = currentResIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }


    public void setFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

    }
}
