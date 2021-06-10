using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChooseSetting : MonoBehaviour
{
    [SerializeField] private string[] settingOptions;
    [SerializeField] private float[] optionValues;
    [SerializeField] private GameObject settingText;
    [SerializeField] private GameObject leftArrow;
    [SerializeField] private GameObject rightArrow;
    [SerializeField] private int optionSelected;
    private SoundEffectPlayer soundEffect;

    private void SetArrows()
    {
        rightArrow.transform.localPosition = new Vector2(settingText.transform.localPosition.x + (settingText.GetComponent<Text>().preferredWidth / 2) + 30, rightArrow.transform.localPosition.y);
        leftArrow.transform.localPosition = new Vector2(settingText.transform.localPosition.x - (settingText.GetComponent<Text>().preferredWidth / 2) - 30, rightArrow.transform.localPosition.y);
    }

    public float GetValueOption()
    {
        return optionValues[optionSelected];
    }

    // Use this for initialization
    void Start()
    {
        //Sets the position of both arrows//
        SetArrows();
        soundEffect = GameObject.Find("SoundEffects").GetComponent<SoundEffectPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.name == EventSystem.current.currentSelectedGameObject.name)
        {
            if ((Input.GetKeyDown(GameConstants.R) || Input.GetKeyDown(GameConstants.L)) && ((optionSelected == 0) || (optionSelected == settingOptions.Length - 1)))
            {
                soundEffect.PlaySoundEffect("Wrong");
            }
            if (Input.GetKeyDown(GameConstants.L) && (optionSelected != 0))
            {
                soundEffect.PlaySoundEffect("SettingsSlider");
                optionSelected--;
                settingText.GetComponent<Texts>().SetText(settingOptions[optionSelected]);
                if (optionSelected == 0)
                {
                    leftArrow.SetActive(false);
                }
                rightArrow.SetActive(true);
                SetArrows();
            }
            if (Input.GetKeyDown(GameConstants.R) && (optionSelected != settingOptions.Length - 1))
            {
                soundEffect.PlaySoundEffect("SettingsSlider");
                optionSelected++;
                settingText.GetComponent<Texts>().SetText(settingOptions[optionSelected]);
                if (optionSelected == settingOptions.Length - 1)
                {
                    rightArrow.SetActive(false);
                }
                leftArrow.SetActive(true);
                SetArrows();
            }

        }


    }
}
