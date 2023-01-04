using System;
using DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure;

namespace Tests
{
    
    public class TestBase
    {
        protected configIoc _config;
        protected Startup _startUp;
        protected IServiceCollection services;
        
        public TestBase()
        {
            _config = new configIoc();
            _startUp = new Startup();
        }
        [ClassInitialize]
        public void TestFixtureSetup()
        {
            _config.injectConfig(services);
            _startUp.ConfigureServices(services);
        }
    }
}
