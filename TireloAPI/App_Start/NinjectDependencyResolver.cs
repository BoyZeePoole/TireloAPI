using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Ninject;
using TireloAPI.App_Start;

namespace WoolworthsInterfaceAPI.App_Start {

    public class NinjectDependencyResolver : NinjectScope, IDependencyResolver {

        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
            : base(kernel) {
            _kernel = kernel;
        }

        public IDependencyScope BeginScope() {
            return new NinjectScope(_kernel.BeginBlock());
        }

    }

}