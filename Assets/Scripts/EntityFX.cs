using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    private SpriteRenderer sr;

    [Header("Flash FX")]
    [SerializeField] private float flashDuration;
    [SerializeField] private Material hitMat;
    private Material originalMat;

    [Header("Aliment color")]
    [SerializeField] private Color[] chillColor;
    [SerializeField] private Color[] igniteColor;
    [SerializeField] private Color[] schockColor;

    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMat = sr.material;
    }

    public void makeTransparent(bool _transparent)
    {
        if (_transparent)
            sr.color = Color.clear;
        else
            sr.color = Color.white;
    }

    private IEnumerator FlashFX()
    {
        sr.material = hitMat;
        Color currentColor = sr.color;
        sr.color = Color.white;

        yield return new WaitForSeconds(flashDuration);

        sr.color = currentColor;
        sr.material = originalMat;
    }

    private void RedColorBlink()
    {
        if (sr.color != Color.white)
            sr.color = Color.white;
        else
            sr.color = Color.red;
    }

    private void cancelColorChange()
    {
        CancelInvoke();

        sr.color = Color.white;
    }
    public void igniteFxFor(float _seconds)
    {
        InvokeRepeating("igniteColorFx", 0, .3f);
        Invoke("cancelColorChange", _seconds);
    }

    public void chillFxFor(float _seconds)
    {
        InvokeRepeating("chillColorFx", 0, .3f);
        Invoke("cancelColorChange", _seconds);
    }

    public void schockFxFor(float _seconds)
    {
        InvokeRepeating("schockColorFx", 0, .3f);
        Invoke("cancelColorChange", _seconds);
    }

    private void igniteColorFx()
    {
        if (sr.color != igniteColor[0])
            sr.color = igniteColor[0];
        else
            sr.color = igniteColor[1];
    }

    private void schockColorFx()
    {
        if (sr.color != schockColor[0])
            sr.color = schockColor[0];
        else
            sr.color = schockColor[1];
    }

    private void chillColorFx()
    {
        if (sr.color != chillColor[0])
            sr.color = chillColor[0];
        else
            sr.color = chillColor[1];
    }
}
