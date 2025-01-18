using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Animator animator { get; private set; }

    public GunStateMachine gunStateMachine { get; private set; }
    
    public GunStopState gunStopState { get; private set; }

    public GunShootState gunShootState { get; private set; }

    private void Awake()
    {
        gunStateMachine = new GunStateMachine();

        gunStopState = new GunStopState(this, gunStateMachine,"gunStop");

        gunShootState = new GunShootState(this,gunStateMachine,"gunShoot");

    }

    public void Update()
    {
        gunStateMachine.currentState.Update();
    }
}
