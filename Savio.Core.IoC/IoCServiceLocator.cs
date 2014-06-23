using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace Savio.Core.IoC
{
    public class IoCServiceLocator : ServiceLocatorImplBase
    {
        public IoCServiceLocator() : base()
        {
            
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            
        }
    }
}
