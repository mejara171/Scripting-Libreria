using UnityEngine;
using UnityEngine.UI;

namespace Patterns
{
	public class Guardian : MonoBehaviour 
	{
		public Princess princess;
		public Text dialogue;

		private void Start () 
		{
			princess.OnDead += Mourn;	
		}
		
		private void Mourn ()
		{
			dialogue.gameObject.SetActive (true);
			dialogue.text = "No!!!";
		}
	}
}