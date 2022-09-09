using UnityEngine;
using UnityEngine.UI;

namespace Patterns
{
	public class Score : MonoBehaviour 
	{
		public Text label;

		public int Points
		{
			get; private set;
		}

		public static Score Instance
		{
			get; private set;
		}

		private void Awake ()
		{
			if (Instance != null)
				Destroy (gameObject);
			else
				Instance = this;
		}

		public void AddPoints (int points)
		{
			Points += points;
			label.text = Points.ToString ();
		}
	}
}