using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Language {
	public enum language {Spanish = 0, English = 1};
	public static language currentLanguage = language.English;

	public static void changeLanguage(int changedLanguage){
		currentLanguage = (language) changedLanguage;
	}

	public static int GetLanguage(){
		return (int) currentLanguage;
	}

}
