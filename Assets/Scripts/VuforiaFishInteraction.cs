using UnityEngine;

public class VuforiaFishInteraction : MonoBehaviour
{
    [Header("Balığa dokunulduğunda açılacak UI Paneli")]
    public GameObject informationPanel;

    void Update()
    {
        // Ekrana dokunulup dokunulmadığını kontrol et
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            // Dokunulan yerde bu balık var mı?
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == this.transform || hit.transform.IsChildOf(this.transform))
                {
                    // Balığa dokunuldu! Paneli aç/kapat
                    if (informationPanel != null)
                    {
                        bool isActive = informationPanel.activeSelf;
                        informationPanel.SetActive(!isActive);
                    }
                }
            }
        }
    }
}