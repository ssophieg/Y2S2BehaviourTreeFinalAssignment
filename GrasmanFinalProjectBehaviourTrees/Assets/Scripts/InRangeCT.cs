using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class InRangeCT : ConditionTask {

		public BBParameter<Transform> target;
		public float detectionRange;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			//If character is within range of target, return true
			if (Vector3.Distance(agent.transform.position, target.value.position) <= detectionRange)
			{
                return true;
            }
			return false;
		}
	}
}