/**
*   @file VFX.cs
*   @brief visual effect script. Attached to user prefab
*   
*   This file contains functions to handle visual effects. When user property
*   (e.g. getting hungry/drunk/tired), add camera visual effects.
*
*   @author Zander Mao
*   @bug values need to be kept in the proper range.
*   @todo bind to users
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Rendering.PostProcessing;

public class VFX : NetworkBehaviour
{
    // Start is called before the first frame update
    public User user;
    PostProcessVolume m_Volume; // post processing filter
    Vignette m_Vignette;
    ColorGrading m_ColorGrading;
    LensDistortion m_LensDistortion;


    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        if (user != null)
        {
            m_Vignette.intensity.value = user.sleepiness;
            m_ColorGrading.saturation.value = -user.hunger;
            m_LensDistortion.intensity.value = Mathf.Sin(Time.realtimeSinceStartup) * (100 - user.sanity);
        }
    }
}
