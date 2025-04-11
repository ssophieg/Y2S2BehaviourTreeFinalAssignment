using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class TeleportAT : ActionTask {

		public GameObject visibleModel;
		public Vector3 teleportTargetLocation;
		float teleportTimer = 0;
		public float teleportTime;


		public ParticleSystem poofVisual;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			poofVisual = agent.GetComponent<ParticleSystem>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			//emit poof particles
			poofVisual.Emit(10);
			//become invisible during teleport
			visibleModel.SetActive(false);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//start timer for amount of time teleport takes
			teleportTimer += Time.deltaTime;

			if(teleportTimer >= teleportTime)
			{
				//change location
				agent.transform.position = teleportTargetLocation;
				//reset timer
				teleportTimer = 0;

                //emit poof particles
                poofVisual.Emit(10);

				//become visible in new location
                visibleModel.SetActive(true);
				EndAction(true);
			}
		}
	}
}