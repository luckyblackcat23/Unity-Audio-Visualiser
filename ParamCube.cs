using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int band;
    public float startScale, scaleMultiplier;
    public bool useBuffer;

    // Update is called once per frame
    void Update()
    {
        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioVisualitionTest._BandBuffer[band] * scaleMultiplier) + startScale, transform.localScale.z);
        }
        if (!useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioVisualitionTest.freqBand[band] * scaleMultiplier) + startScale, transform.localScale.z);
        }
    }
}
