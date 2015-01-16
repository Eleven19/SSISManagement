using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlServer.Management.IntegrationServices.Data;

namespace SqlServer.Management.IntegrationServices.Core
{
    public interface ISsisApplicationServices
    {
        IDbAccessorFactory DbAccessorFactory { get; }

    }

    internal class SsisApplicationServices : ISsisApplicationServices
    {
        private IDbAccessorFactory _dbAccessorFactory;

        public SsisApplicationServices()
        {
            _dbAccessorFactory = new DbAccessorFactory();
        }
        public IDbAccessorFactory DbAccessorFactory
        {
            get { return _dbAccessorFactory; }
        }

        public void SetDbAccessorFactory(IDbAccessorFactory factory)
        {
            if (factory == null) throw new ArgumentNullException("factory");
            _dbAccessorFactory = factory;
        }
    }

    public class SsisApplicationServicesBuilder
    {
        private readonly SsisApplicationServices _applicationServices;

        public SsisApplicationServicesBuilder()
        {
            _applicationServices = new SsisApplicationServices();
        }
        public ISsisApplicationServices Build()
        {
            return _applicationServices;
        }
    }
}
