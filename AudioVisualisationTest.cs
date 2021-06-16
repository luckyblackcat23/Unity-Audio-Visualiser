using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioVisualisationTest : MonoBehaviour
{
    public AudioSource Music;
    public static float[] samples = new float[512];
    public static float[] freqBand = new float[8];
    public static float[] _BandBuffer = new float[8];
    float[] bufferDeacrease = new float[8];
    public AudioClip _AudioClip;
    public bool UseMic;
    public string SelectedDevice;
    public AudioMixerGroup mixerGropMicrophone, MixerGroupMaster;

    // Start is called before the first frame update
    void Start()
    {
        Music = GetComponent<AudioSource>();
        if (UseMic)
        {
            if (Microphone.devices.Length > 0)
            {
                
                SelectedDevice = Microphone.devices[0].ToString();
                Music.outputAudioMixerGroup = mixerGropMicrophone;
                Music.clip = Microphone.Start(SelectedDevice, true, 10, AudioSettings.outputSampleRate);
            }
            else
            {
                UseMic = false;
            }
        }
        else
        {
            Music.outputAudioMixerGroup = MixerGroupMaster;
            Music.clip = _AudioClip;
        }

        Music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpecturmAudioSource();
        MakeFrequencyBands();
        BandBuffer();
    }

    void BandBuffer()
    {
        for (int g = 0; g < 8; g++)
        {
            if(freqBand [g] > _BandBuffer[g])
            {
                _BandBuffer[g] = freqBand[g];
                bufferDeacrease[g] = 0.005f;
            }

            if (freqBand[g] < _BandBuffer[g])
            {
                _BandBuffer[g] -= bufferDeacrease[g];
                bufferDeacrease[g] *= 1.5f;
            }
        }
    }

    void GetSpecturmAudioSource()
    {
        Music.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;

            freqBand[i] = average * 10;
        }
    }
}
