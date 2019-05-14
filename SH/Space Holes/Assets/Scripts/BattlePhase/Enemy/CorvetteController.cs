using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorvetteController : MonoBehaviour
{

    public CorvetteHealth _CorvetteHealth;
    public AudioHandler _Audio;
    public CorvetteMovement _CorvetteMovement;

    // Use this for initialization
    void Awake()
    {
        _CorvetteHealth = this.GetComponent<CorvetteHealth>();
        _CorvetteMovement = this.GetComponent<CorvetteMovement>();

        _Audio = this.GetComponent<AudioHandler>();
    }

}