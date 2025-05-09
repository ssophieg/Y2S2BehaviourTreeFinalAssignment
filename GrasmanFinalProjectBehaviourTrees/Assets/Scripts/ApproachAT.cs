using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class ApproachAT : ActionTask {

		public BBParameter<Transform> target;

		public BBParameter<float> defaultSpeed;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//set destination of navmesh to approach the target
            agent.GetComponent<NavMeshAgent>().enabled = true;
            agent.GetComponent<NavMeshAgent>().SetDestination(target.value.position);
			agent.GetComponent<NavMeshAgent>().speed = defaultSpeed.value;
         
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}