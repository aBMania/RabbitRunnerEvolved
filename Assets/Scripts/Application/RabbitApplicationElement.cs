﻿using UnityEngine;

namespace Application
{
    public class RabbitApplicationElement : MonoBehaviour
    {
        public RabbitApplication App { get { return FindObjectOfType<RabbitApplication>(); } }
    }
}