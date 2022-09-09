using UnityEngine;

namespace Patterns
{
	public class CharacterState 
	{
		private Vector3 position;
		private Vector3 scale;
		private Color color;

		public CharacterState (Vector3 position, Vector3 scale, Color color)
		{
			this.position = position;
			this.scale = scale;
			this.color = color;
		}

		public static CharacterState Build (Transform character)
		{
			Vector3 position = character.position;
			Vector3 scale = character.localScale;
			Color color = character.GetComponent<Renderer> ().material.color;
			return new CharacterState (position, scale, color);
		}

		public void Restore (Transform character)
		{
			character.position = position;
			character.localScale = scale;
			character.GetComponent<Renderer> ().material.color = color;
		}
		
	}
}