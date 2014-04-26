using UnityEngine;
using System.Collections;

public class GameObjectUtils : MonoBehaviour 
{
	public static GameObject AddAndPosition(GameObject prefab,GameObject parent, Vector3 pos)
	{
		GameObject go = Instantiate (prefab) as GameObject;
		go.transform.parent = parent.transform;
		go.transform.localPosition = pos;
		return go;
	}

}
