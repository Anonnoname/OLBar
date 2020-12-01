using System;
using Mirror;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace OLBar
{
    public class User: NetworkBehaviour
    {
        [SyncVar]
        public string userName;

        [SyncVar]
        public int sanity; // sanity system

        [SyncVar]
        public int currency; // currency system

        [SyncVar]
        public float sleepiness; // sleepiness

        [SyncVar]
        public float hunger; // sleepiness

        public GameObject chatBox; // chatbox

        // VISUAL EFFECTS
        PostProcessVolume m_Volume; // post processing filter
        Vignette m_Vignette;
        ColorGrading m_ColorGrading;
        LensDistortion m_LensDistortion;

        // chatwindow


        public override void OnStartLocalPlayer()
        {
            Camera.main.transform.SetParent(transform);
            Camera.main.transform.localPosition = new Vector3(0, 0, -10); // set main camera position


            // initialize user
            this.currency = 1000;
            this.sanity = 100;
            this.hunger = 0;
            this.sleepiness = 0;

            // setup localUser
            ChatWindow window = GameObject.Find("ChatWindow").GetComponent<ChatWindow>();
            window.localUser = this;

            // setup visual effects
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


        private void Tired()
        {
            if (hunger < 100)
            {
                hunger += 0.0001f;
            }
            if (sleepiness < 1)
            {
                sleepiness += 0.000001f;
            }
        }

        void Update()
        {
                m_Vignette.intensity.value = sleepiness;
                m_ColorGrading.saturation.value = -hunger;
                m_LensDistortion.intensity.value = Mathf.Sin(Time.realtimeSinceStartup) * (100 - sanity);
        }


    }

}
