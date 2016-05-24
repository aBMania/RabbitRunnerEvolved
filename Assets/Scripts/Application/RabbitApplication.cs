using Application.Controller;
using Application.Model;
using Application.Service;
using Application.View;
using UnityEngine;

namespace Application
{
    public class RabbitApplication : MonoBehaviour
    {
        private RabbitModel _model;
        private RabbitView _view;
        private RabbitController _controller;
        private RabbitService _service;

        public void Awake()
        {
            _model = GetComponentInChildren<RabbitModel>();
            _view = GetComponentInChildren<RabbitView>();
            _controller = GetComponentInChildren<RabbitController>();
            _service = GetComponentInChildren<RabbitService>();
        }

        public RabbitModel Model
        {
            get { return _model; }
        }

        public RabbitView View
        {
            get { return _view; }
        }

        public RabbitController Controller
        {
            get { return _controller; }
        }

        public RabbitService Service
        {
            get { return _service; }
        }
    }
}