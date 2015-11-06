using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
[AddComponentMenu("RayShooter")]
public class RayShooter : MonoBehaviour {

	private Camera _camera;

	private float _size = 12;

	// Use this for initialization
	void Start () {
		_camera = GetComponent<Camera> ();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void OnGUI(){
		float _pointerOffset = _size / 4;
		float posX = _camera.pixelWidth / 2 - _pointerOffset;
		float posY = _camera.pixelHeight / 2 - _pointerOffset;
		GUI.Label (new Rect (posX, posY, _size, _size), "*");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
			Ray ray = _camera.ScreenPointToRay(point);
			RaycastHit hit;
			if(Physics.Raycast (ray, out hit)){
				GameObject hitObject = hit.transform.gameObject;
				HitReaction enemyReaction = hitObject.GetComponent<HitReaction>();

				if(enemyReaction != null){
					enemyReaction.ReactToHit();
				}else{
					StartCoroutine(PlaceSphereIndicator(hit.point));
				}
			}
		}	
	}


	private IEnumerator PlaceSphereIndicator(Vector3 pos){
		GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		sphere.transform.position = pos;

		yield return new WaitForSeconds (1);

		Destroy (sphere);
	}
}
