using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class PersistentScore{
	private static int maxLevel = 2;
	private static int[] Score;

	public static void Save() {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/highscore.gd");
		bf.Serialize(file, Score);
		file.Close();
	}   
	
	public static void Load() {
		if (File.Exists (Application.persistentDataPath + "/highscore.gd")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/highscore.gd", FileMode.Open);
			Score = (int[]) bf.Deserialize (file);
			file.Close ();
		} else {
			Score = new int[maxLevel];
			for(int i=0; i<maxLevel; i++)
				Score[i]=0;
		}
	}

	public static void addHighScore(int level, int newScore){
		if (Score == null)
			Load ();
		if (level >= 1 && level <= maxLevel) {
			if(newScore > Score[level-1]){
				Score[level-1] = newScore;
				Save ();
			}
		}
	}

	public static int getHighScore(int level){
		if (Score == null)
			Load ();
		if (level >= 1 && level <= maxLevel) {
			return Score[level-1];
		}
		return 0;
	}
}
