using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
using System.Drawing;
using System.Drawing.Imaging;
using UnityEngine.Experimental.Rendering;

public class TargetComponent : MonoBehaviour
{

        [SerializeField]
        private Sprite inactiveSprite;

        [SerializeField] private Sprite activeSprite;

        private UnityEngine.UI.Image image;


            // Start is called before the first frame update
        void Start()
        {
            image = GetComponent<UnityEngine.UI.Image>();
        }

        // Update is called once per frame
        void Update()
        {
            SendRay();
        }
        
        private void SendRay()
        {
            bool hitSomething =
                Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out var hitInfo);
            if (hitSomething && hitInfo.transform.CompareTag("Enemy"))
            {
                image.sprite = activeSprite;
            }
            else
            {
                image.sprite = inactiveSprite;
            }
        }
    
}
