using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class DetectCT : ConditionTask {

		public BBParameter<GameObject> frontlineTarget;

		public float searchRadius;

		public LayerMask frontlinersLayer;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

            Collider[] frontliners = Physics.OverlapSphere(agent.transform.position, searchRadius, frontlinersLayer);

            //store rodent location and object when rodent is found
            foreach (Collider frontlineCollider in frontliners)
            {
                frontlineTarget.value = frontlineCollider.gameObject;
            }

            //end action when rodent is found
            if (frontliners.Length > 0)
            {
                return true;
            }
			return false;
		}
	}
}