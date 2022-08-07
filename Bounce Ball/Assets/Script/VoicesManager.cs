using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoicesManager : MonoBehaviour
{
    [Header("Voices Operation")]
    [SerializeField] AudioSource[] BoxVoice;
    [SerializeField] AudioSource[] FailVoice;
    [SerializeField] AudioSource[] PlatformBounceVoice;
    [SerializeField] AudioSource[] WoodBounceVoice;
    public AudioSource[] GeneralVoice;
    int Box; int Fail; int Platform; int Wood;
    public void SoundOperation(string Value)
    {
        switch (Value)
        {
            case"Box":
              Box= PoolOperation(Box, BoxVoice);
                break;
            case "Fail":
                Fail = PoolOperation(Fail, FailVoice);
                break;
            case "Platform":
                Platform = PoolOperation(Platform, PlatformBounceVoice);
                break;
            case "Wood":
                Wood = PoolOperation(Wood, WoodBounceVoice);
                break;
        }
    }

     int PoolOperation(int Value, AudioSource[] Pool)
    {
        Pool[Value].Play();
        if (Value == Pool.Length - 1)
        {
            Value = 0;
        }
        else
        {
            Value++;
        }
        return Value;
    }
}
