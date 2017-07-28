using BusinessLayer;
using BusinessLayer.interfaces;
using Ninject;
using ServiceLayer;
using ServiceLayer.Interfaces;

namespace NinjectRegistration {
    public static class NinjectRegistration {

        public static void Register(IKernel kernel) {
            RegisterService(kernel);
            RegisterBusiness(kernel);
        }

        private static void RegisterBusiness(IKernel kernel) {
            kernel.Bind<IRoleBu>().To<RoleBu>();
            kernel.Bind<IPersonBu>().To<PersonBu>();
            kernel.Bind<ICourseBu>().To<CourseBu>();
        }
        private static void RegisterService(IKernel kernel) {
            kernel.Bind<IRoleRepo>().To<RoleRepo>();
            kernel.Bind<IPersonRepo>().To<PersonRepo>();
            kernel.Bind<ICourseRepo>().To<CourseRepo>();
        }
    }
}
