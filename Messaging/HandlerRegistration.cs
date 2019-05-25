using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccounts.Messaging
{
    public static class HandlerRegistration
    {
        public static void AddHandlers(this IServiceCollection services, Assembly assemblyToScann)
        {
            List<Type> handlerTypes = assemblyToScann.GetTypes()
                .Where(x => x.GetInterfaces().Any(y => IsHandlerInterface(y)))
                .Where(x => x.Name.EndsWith("Handler"))
                .ToList();

            foreach (Type type in handlerTypes)
            {
                Type interfaceType = type.GetInterfaces().Single(y => IsHandlerInterface(y));
                services.AddTransient(interfaceType, type);
            }
        }

        private static bool IsHandlerInterface(Type type)
        {
            if (!type.IsGenericType)
                return false;

            Type typeDefinition = type.GetGenericTypeDefinition();

            return typeDefinition == typeof(ICommandHandler<>) || typeDefinition == typeof(IQueryHandler<,>);
        }
    }
}