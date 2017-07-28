using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TireloAPI.App_Start {
    public class NinjectScope : System.Web.Http.Dependencies.IDependencyScope {
        protected Ninject.Syntax.IResolutionRoot resolutionRoot;
        public NinjectScope(Ninject.Syntax.IResolutionRoot kernel) {
            resolutionRoot = kernel;
        }
        public void Dispose() {
            IDisposable disposable = (IDisposable)resolutionRoot;
            if (disposable != null) disposable.Dispose();
            resolutionRoot = null;
        }

        public object GetService(Type serviceType) {
            IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Ninject.Parameters.Parameter[0], true, true);
            return resolutionRoot.Resolve(request).SingleOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Ninject.Parameters.Parameter[0], true, true);
            return resolutionRoot.Resolve(request).ToList();
        }
    }
}