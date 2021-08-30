using Business.Constants;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Extensions;
using Microsoft.AspNetCore.Http;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.BusinessAspect.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();//kullanıcının rollerini al
            foreach (var role in _roles)//onları sırayla gez
            {
                if (roleClaims.Contains(role))//claimlerinin içinde ilgili role varsa
                {
                    return;//çalıştırmaya devam et
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
