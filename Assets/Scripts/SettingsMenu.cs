using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public MouseLook playerCam;
    public PauseGame pg;

    public GameObject VHS;
    public GameObject pauseMenu;
    public GameObject settingsMenu;

    public Slider sensSlider;
    public Toggle VHSToggle;
    public Slider VHSSlider;

    public bool settingsOpen = false;
    public float sens;

    private void Start()
    {
        sens = playerCam.mouseSens;
        Debug.Log(sens);
        sensSlider.value = playerCam.mouseSens;
    }

    private void Update()
    {
        sens = sensSlider.value;
        playerCam.mouseSens = sens;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            closeSettings();
        }
    }

    public void closeSettings()
    {
        if (settingsOpen)
        {
            settingsMenu.SetActive(false);
            settingsOpen = false;
            pauseMenu.SetActive(true);
            settingsMenu.SetActive(false);
        }
    }

    public void toggleVHS()
    {
        if (VHSToggle.isOn)
        {
            VHS.SetActive(true);
        }
        else
        {
            VHS.SetActive(false);
        }
    }

}
