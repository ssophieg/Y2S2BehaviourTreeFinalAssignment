using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class DetectCT : ConditionTask {

		public BBParameter<GameObject> Target;

		public float searchRadius;

		public LayerMask detectLayer;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

			//detect anything in the detectLayer with overlap sphere
            Collider[] frontliners = Physics.OverlapSphere(agent.transform.position, searchRadius, detectLayer);

            foreach (Collider targetCollider in frontliners)
            {
				//set the target to detected object
                Target.value = targetCollider.gameObject;
            }

            //end action when object is found
            if (frontliners.Length > 0)
            {
                return true;
            }
			return false;
		}
	}
}