using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldSpriteDrawer : MonoBehaviour
{
    [SerializeField] private GameObject _field1;
    [SerializeField] private GameObject _field2;
    [SerializeField] private SpriteRenderer _backGroundSprite;

    private void Start()
    {
        ChooseField();
    }

    private void ChooseField()
    {
        switch(ServiceLocator.CurrentSericeLocator.GetServise<GameParametrs>().NumberChosenField)
        {
            case 0:
                _field1.SetActive(true);
                _field2.SetActive(false);
               // FindObjectOfType<Camera>().backgroundColor = new Color(1, 102, 49,255);
                _backGroundSprite.color = new Color(0, 0.4f, 0.19f, 1);
                break;

            case 1:
                _field1.SetActive(false);
                _field2.SetActive(true);
                // FindObjectOfType<Camera>().backgroundColor = new Color(1, 102, 49, 255);
                _backGroundSprite.color = new Color(0.12f, 0.31f, 0, 1);
                break;
        }
    }
}
