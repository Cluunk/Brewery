using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    private Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = SoundManager.Instance.Volume;
        slider.onValueChanged.AddListener(delegate(float value) { SoundManager.Instance.Volume = value; });
    }
}
