using Reqnroll.BoDi;
using Reqnroll.Infrastructure;

namespace Reqnroll
{
    public abstract class Steps : IContainerDependentObject
    {
        private IObjectContainer objectContainer;

        void IContainerDependentObject.SetObjectContainer(IObjectContainer container)
        {
            if (objectContainer != null)
                throw new ReqnrollException("Container of the steps class has already initialized!");

            objectContainer = container;
        }

        protected ITestRunner TestRunner
        {
            get
            {
                AssertInitialized();
                return objectContainer.Resolve<ITestRunner>();
            }
        }

        protected ISyncTestRunner SyncTestRunner
        {
            get
            {
                AssertInitialized();
                return objectContainer.Resolve<ISyncTestRunner>();
            }
        }

        public ScenarioContext ScenarioContext
        {
            get
            {
                AssertInitialized();
                return objectContainer.Resolve<ScenarioContext>();
            }
        }

        public FeatureContext FeatureContext
        {
            get
            {
                AssertInitialized();
                return objectContainer.Resolve<FeatureContext>();
            }
        }

        public TestThreadContext TestThreadContext
        {
            get
            {
                AssertInitialized();
                return objectContainer.Resolve<TestThreadContext>();
            }
        }

        public ScenarioStepContext StepContext
        {
            get
            {
                AssertInitialized();
                var contextManager = objectContainer.Resolve<IContextManager>();
                return contextManager.StepContext;
            }
        }

        protected void AssertInitialized()
        {
            if (objectContainer == null)
                throw new ReqnrollException("Container of the steps class has not been initialized!");
        }
    }
}
