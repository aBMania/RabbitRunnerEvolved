using Application.Controller;
using Application.Model;
using Application.Service;
using Application.View;
using UnityEngine;

namespace Application
{
    public class RabbitApplication : MonoBehaviour
    {
        public RabbitModel Model
        {
            get { return GetComponentInChildren<RabbitModel>(); }
        }

        public RabbitView View
        {
            get { return GetComponentInChildren<RabbitView>(); }
        }

        public RabbitController Controller
        {
            get { return GetComponentInChildren<RabbitController>(); }
        }

        public RabbitService Service
        {
            get { return GetComponentInChildren<RabbitService>(); }
        }
    }
}