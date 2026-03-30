using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer synth;

    public float frequency = 64f; // actually using MIDI values here
    public float lfo_freq = 1.0f;

    public static AudioManager S;

    void Awake()
    {
        S = this;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFrequency(float freq){
        frequency = MapXToFreq(freq, 64f, .05f);
        synth.SetFloat("frequency", frequency);
        Debug.Log("Frequency: " + frequency);
    }

    public void SetLFOFreq(float freq){
        lfo_freq = MapXToFreq(freq, 0f, .1f);
        synth.SetFloat("lfo_freq", lfo_freq);
        Debug.Log("LFO Frequency: " + lfo_freq);
    }

    float MapXToFreq(float input, float baseFreq, float hzPerUnit){
        return baseFreq + Mathf.Abs(input) * hzPerUnit;
    }

    
    
}
