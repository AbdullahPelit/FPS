using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DvmFPS.UserInput
{
    [CreateAssetMenu(menuName ="FPS/Input/Input Settings")]
    public class ScInputSystem : ScriptableObject
    {
        public float Horizontal;
        public float Vertical;


        [Header("Axis Base Control")]
        [SerializeField] private bool _axisActive;
        [SerializeField] private string AxisNameHorizontal;
        [SerializeField] private string AxisNameVertical;

        [SerializeField] private float _increaseAmount = 0.01f;

        [Header("Key Base Control")]
        [SerializeField] private bool _keyBaseHorizontalActive;
        [SerializeField] private KeyCode PositiveHorizontalKeyKod;
        [SerializeField] private KeyCode NegativeHorizontalKeyKod;
        [SerializeField] private bool _keyBaseVerticalActive;
        [SerializeField] private KeyCode NegativeVerticalKeyKod;
        [SerializeField] private KeyCode PositiveVerticalKeyKod;

        public void ProcessInput()
        {
            if (_axisActive)
            {
                Horizontal = Input.GetAxis(AxisNameHorizontal);
                Vertical = Input.GetAxis(AxisNameVertical);
            }
            else
            {
                if (_keyBaseHorizontalActive)
                {
                    KeyBaseHorizontal(ref Horizontal, PositiveHorizontalKeyKod, NegativeHorizontalKeyKod);
                }
                if (_keyBaseVerticalActive)
                {
                    KeyBaseHorizontal(ref Vertical, PositiveVerticalKeyKod, NegativeVerticalKeyKod);
                }
            }
        }

        private void KeyBaseHorizontal(ref float value, KeyCode Pozitive, KeyCode Negative)
        {
            bool positiveActive = Input.GetKey(Pozitive);
            bool negativeActive = Input.GetKey(Negative);
            if (positiveActive)
            {
                value += _increaseAmount;

            }
            else if (negativeActive)
            {
                value -= _increaseAmount;

            }
            else
            {
                value = 0;
            }
            value = Mathf.Clamp(value, -1, 1);

        }

    }
}
