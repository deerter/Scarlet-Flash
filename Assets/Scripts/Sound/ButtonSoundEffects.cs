using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundEffects : MonoBehaviour, IMoveHandler {
	private SoundEffectPlayer soundEffect;
	

	// Use this for initialization
	void Start () {
		soundEffect = GameObject.Find("SoundEffects").GetComponent<SoundEffectPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		/*if (gameObject.name == "VersusButton"){
			print (gameObject.GetComponentInParent<Button>().navigation.selectOnUp);
		}*/
	}

	public void PlayButtonSoundEffect(string currentSoundEffect){
		soundEffect.PlaySoundEffect(currentSoundEffect);
	}

	public void OnMove(AxisEventData eventData){
		string movement = eventData.moveDir.ToString();
		if (!(gameObject.tag=="MainButton" && (movement=="Right" || movement=="Left"))){
			if (((gameObject.GetComponentInParent<Button>().navigation.selectOnUp==null)&&(movement=="Up"))
				|| ((gameObject.GetComponentInParent<Button>().navigation.selectOnDown==null)&&(movement=="Down"))
				|| ((gameObject.GetComponentInParent<Button>().navigation.selectOnRight==null)&&(movement=="Right"))
				|| ((gameObject.GetComponentInParent<Button>().navigation.selectOnLeft==null)&&(movement=="Left"))) {
				PlayButtonSoundEffect("Wrong");
			}else{
				PlayButtonSoundEffect("Cursor");
			}
		}
	}
}
