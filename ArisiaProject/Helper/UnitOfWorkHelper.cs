using System;
using System.Reflection;
using ArisiaProject.Domain;

namespace ArisiaProject.Helper
{
    public static class UnitOfWorkHelper
    {
        #region Public Method

        public static bool IsRepositoryMethod(MethodInfo methodInfo)
        {
            return IsRepositoryClass(methodInfo.DeclaringType);
        }

        public static bool IsRepositoryClass(Type type)
        {
            return typeof (IRepository).IsAssignableFrom(type);
        }

        public static bool HasUnitOfWorkAttribute(MethodInfo methodInfo)
        {
            return methodInfo.IsDefined(typeof (UnitOfWorkAttribute), true);
        }

        #endregion
    }
}