using ChristmasLearningProject.Runtime.Domain;
using UnityEngine;
using Zenject;

namespace ChristmasLearningProject.Runtime.View
{
    public class Turret : MonoBehaviour
    {
        [Inject] Fleet fleet;
        
        Domain.Turret turret;
        
        void Start()
        {
            transform.up = transform.position - Vector3.zero;
            turret = Domain.Turret.Ensemble(transform.position, transform.up);
        }

        void Update()
        {
            turret.Attack(fleet, Time.deltaTime);
        }
    }
}