using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class playsound : MonoBehaviour, IPointerEnterHandler
{

    public void OnPointerEnter(PointerEventData ped)
    {
        FindObjectOfType<AudioManager>().Play("MenuSFX"); // Play sound
    }
}