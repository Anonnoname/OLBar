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
        private PostProcessVolume m_Volume; // post processing filter
        private Vignette m_Vignette;
        private ColorGrading m_ColorGrading;
        private LensDistortion m_LensDistortion;    


        public override void OnStartLocalPlayer() 
        {
            Camera.main.transform.SetParent(transform);
            Camera.main.transform.localPosition = new Vector3(0, 0, -10); // set main camera position
	
            
            // initialize user
            this.currency = 1000;
            this.sanity = 100;
            this.hunger = 0;
            this.sleepiness = 0;

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
            if (this.hunger < 1)
            {
                this.hunger += 0.0001f;
            }
            if (this.sleepiness < 100)
            {
                this.sleepiness += 0.0001f;
            }
        }
        void Update()
        {

                m_Vignette.intensity.value = this.sleepiness;
                m_ColorGrading.saturation.value = -this.hunger;
                m_LensDistortion.intensity.value = Mathf.Sin(Time.realtimeSinceStartup) * (100 - sanity);
        }


    }

}
