using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneSoundManager : MonoBehaviour,IService
{
    [SerializeField] private AudioSource _soundPunch;
    [SerializeField] private AudioSource _soundIce;
    [SerializeField] private AudioSource _soundGoal;
    [SerializeField] private AudioSource _soundSifflet;
    [SerializeField] private AudioSource _soundAcceleration;

    public void PlayPunchSound() => _soundPunch.Play();
    public void PlayIceSound() => _soundIce.Play();
    public void PlayGoalSound() => _soundGoal.Play();
    public void PlaySiffletSound() => _soundSifflet.Play();
    public void PlayAccelerationSound() => _soundAcceleration.Play();


    public void StopIceSound() => _soundIce.Stop();
    public void StopAccelerationSound() => _soundAcceleration.Stop();
}
