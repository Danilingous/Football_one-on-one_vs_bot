using UnityEngine;

public class SoundMasterMenuScene : MonoBehaviour, IService
{
    [SerializeField] private AudioSource _clickUISound;

    public void PlayClickUISound() => _clickUISound.Play();


}
