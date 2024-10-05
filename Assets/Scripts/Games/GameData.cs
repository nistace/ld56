using System;
using UnityEngine;

namespace LD56 {
	[Serializable]
	public class GameData {
		public static GameData Data { get; set; }

		[SerializeField] protected CreatureController[] playerCreatures;

		public CreatureController[] PlayerCreatures => playerCreatures;
	}
}