using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider brightnessSlider;
    // public Slider movementSpeedSlider;

    void Start()
    {
        volumeSlider.minValue = 0f;
        volumeSlider.maxValue = 10f;
        brightnessSlider.minValue = 0f;
        brightnessSlider.maxValue = 10f;
        // movementSpeedSlider.minValue = 1f;
        // movementSpeedSlider.maxValue = 10f;

        volumeSlider.value = SettingsManager.Instance.volume;
        brightnessSlider.value = SettingsManager.Instance.brightness;
        // movementSpeedSlider.value = SettingsManager.Instance.movementSpeed;

        volumeSlider.onValueChanged.AddListener(SettingsManager.Instance.SetVolume);
        brightnessSlider.onValueChanged.AddListener(SettingsManager.Instance.SetBrightness);
        // movementSpeedSlider.onValueChanged.AddListener(SettingsManager.Instance.SetMovementSpeed);
    }
}
