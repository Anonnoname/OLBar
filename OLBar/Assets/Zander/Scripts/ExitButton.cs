using UnityEngine;
using UnityEngine.UI;

namespace OLBar
{
    public class ExitButton : MonoBehaviour
    {
        // Start is called before the first frame update
        public Button button;

        void Start()
        {
            Button btn = button.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }
        public void TaskOnClick()
        {
            Debug.Log("Clicked");
            OLBarNetworkManager manager = GetComponent<OLBarNetworkManager>();
            manager.StopHost();
        }
    }

}
