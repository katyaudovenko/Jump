using System;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Services.ServiceLocator
{
    public class ServiceLocator : IServiceLocator<IService>
    {

        private static ServiceLocator _instance;
        public static ServiceLocator Instance => _instance ??= new ServiceLocator();

        private readonly Dictionary<Type, IService> _servicesMap;

        private ServiceLocator() => 
            _servicesMap = new Dictionary<Type, IService>();

        public T Register<T>(T newService) where T : IService
        {
            var type = typeof(T);

            if (_servicesMap.ContainsKey(type))
                return (T)_servicesMap[type];
            
            _servicesMap.Add(type, newService);
            return newService;
        }

        public T GetService<T>() where T : IService
        {
            var type = typeof(T);
            if (_servicesMap.ContainsKey(type))
                return (T)_servicesMap[type];
            
            Debug.LogError($"Service {type.Name} does not contains.");
            return default;
        }
    }
}