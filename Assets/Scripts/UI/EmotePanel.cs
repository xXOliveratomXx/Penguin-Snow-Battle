using UnityEngine;

public class EmotePanel : MonoBehaviour
{
    public GameObject emotePanel;
    private bool seleccionar_emote = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            seleccionar_emote = !seleccionar_emote;
            activarEmote();
        }
    }

    public void activarEmote()
    {
        if (seleccionar_emote)
        {

            emotePanel.SetActive(true);
        }
        else
        {

            emotePanel.SetActive(false);
        }
    }
}
