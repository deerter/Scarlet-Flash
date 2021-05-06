using UnityEngine;
using System.Collections;

public static class GameConstants
{

	///All this should be a dictionary///
	public static KeyCode U = KeyCode.UpArrow;
	public static KeyCode D = KeyCode.DownArrow;
	public static KeyCode L = KeyCode.LeftArrow;
	public static KeyCode R = KeyCode.RightArrow;
	public static KeyCode LP = KeyCode.A;   //Light punch
	public static KeyCode LK = KeyCode.Z;   //Light kick
	public static KeyCode HP = KeyCode.S;   //Heavy punch
	public static KeyCode HK = KeyCode.X;   //Heavy kick
	public static KeyCode A1 = KeyCode.D;   //Assist 1
	public static KeyCode A2 = KeyCode.C;   //Assist 2
    public const KeyCode ACCEPT = KeyCode.Return;
    public const KeyCode BACK = KeyCode.Escape;

	private static KeyCode[] buttonsAssigned = new KeyCode[]{U,D,L,R,LP,LK,HP,HK,A1,A2,ACCEPT,BACK};
	private static KeyCode[] buttonsAssignedProxy = new KeyCode[]{U,D,L,R,LP,LK,HP,HK,A1,A2,ACCEPT,BACK};

	//Keys used for special attacks///
	/*public static string DL = "down left";
	public static string DR = "down right";
	public static string UL = "up left";
	public static string UR = "up right";*/

	public static bool CheckButtonExists(KeyCode button){
		for (int i = 0; i < buttonsAssigned.Length; i++){
			if (button == buttonsAssigned[i]){
				return true;
			}
		}
		return false;
	}

	public static void ReloadButtonsAsigned(){
		buttonsAssigned = new KeyCode[]{U,D,L,R,LP,LK,HP,HK,A1,A2,ACCEPT,BACK};
	}

	public static void SetButtonsAssignedProxy(){
		buttonsAssignedProxy = buttonsAssigned;
	}

	public static void ResetButtonsAssigned(){
		buttonsAssigned = buttonsAssignedProxy;
		U = buttonsAssigned[0];
		D =	buttonsAssigned[1];
		L = buttonsAssigned[2];
		R = buttonsAssigned[3];
		LP = buttonsAssigned[4];
		LK = buttonsAssigned[5];
		HP = buttonsAssigned[6];
		HK = buttonsAssigned[7];
		A1 = buttonsAssigned[8];
		A2 = buttonsAssigned[9];
	}
}

