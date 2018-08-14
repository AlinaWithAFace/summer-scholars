using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _SCRIPTS
{
    public class ShipManager : MonoBehaviour, IGameManager
    {
        public ManagerStatus status { get; private set; }
        public int health { get; private set; }
        public int maxHealth { get; private set; }

        public static int thrust { get; private set; }
        public static int maxThrust { get; private set; }

        public static Transform ShipTransform;

        private static bool _thrustModifiable = true;

        public void Startup()
        {
            Debug.Log("Ship manager starting...");

            health = 50;
            maxHealth = 100;
            thrust = 0;
            maxThrust = 6;

            status = ManagerStatus.Started;
        }

        public static IEnumerator ChangeThrust(int value)
        {
            Debug.Log("Trying to Thrust!");
            if (_thrustModifiable)
                Debug.Log("Increasing Thrust!");
            {
                _thrustModifiable = false;
                thrust += value;
                if (thrust > maxThrust)
                {
                    thrust = maxThrust;
                }
                else if (thrust < 0)
                {
                    thrust = 0;
                }

                yield return new WaitForSeconds(.4f);
                _thrustModifiable = true;
            }
        }
    }
}