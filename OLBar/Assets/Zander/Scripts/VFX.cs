using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VFX : MonoBehaviour
{
    User user;
    PostProcessVolume m_Volume; // post processing filter
    Vignette m_Vignette;
    ColorGrading m_ColorGrading;
    LensDistortion m_LensDistortion;


    // Start is called before the first frame update
    void Start()
    {
        user = GetComponent<User>();
        m_Vignette = ScriptableObject.CreateInstance<Vignette>();
        m_Vignette.enabled.Override(true);
        m_Vignette.intensity.Override(0f);

        m_ColorGrading = ScriptableObject.CreateInstance<ColorGrading>();
        m_ColorGrading.enabled.Override(true);
        m_ColorGrading.saturation.Override(0f);

        m_LensDistortion = ScriptableObject.CreateInstance<LensDistortion>();
        m_LensDistortion.enabled.Override(true);
        m_LensDistortion.intensity.Override(0f);
        m_LensDistortion.scale.Override(1f);

        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_ColorGrading, m_Vignette, m_LensDistortion);
        InvokeRepeating("Tired", 5.0f, 0.0001f);
    }

    // Update is called once per frame
    void Update()
    {
        m_Vignette.intensity.value = user.sleepiness;
        m_ColorGrading.saturation.value = user.hunger;
        m_LensDistortion.intensity.value = Mathf.Sin(Time.realtimeSinceStartup) * (100 - user.sanity);

    }
}
