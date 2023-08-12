using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource click;
    public AudioSource found;

    public void Clicky()
    {
        click.Play(0);
    }

    public void Found()
    {
        found.Play(0);
    }
}
