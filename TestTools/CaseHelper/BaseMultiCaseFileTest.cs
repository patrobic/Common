using System.Collections.Generic;
using TestTools.Base;
using Xunit.Abstractions;

namespace TestTools.CaseHelper
{
    public abstract class BaseMultiCaseFileTest<Parameters, Case, Input> : BaseTest<Parameters>
        where Case : List<(Input Input, string Path)>
    {
        public BaseMultiCaseFileTest(Parameters parameters, ITestOutputHelper output)
            : base(parameters, output)
        {
        }

        public void TestAssertFile(Parameters parameters, Input input, string expected)
        {
            var result = Run(parameters, input);
            _testHelper.AssertByte(result, expected);
        }

        public void TestAssertFile((Parameters Parameters, Case Case) scenario)
        {
            var results = TestScenario(scenario);
            _testHelper.AssertByte(results);
        }

        public void TestAssertFile(List<(Parameters Parameters, Case Case)> scenarios)
        {
            var results = new List<(byte[], string)>();
            foreach (var scenario in scenarios)
            {
                var result = TestScenario(scenario);
                results.AddRange(result);
            }
            _testHelper.AssertByte(results);
        }

        protected abstract byte[] Run(Parameters parameters, Input input);

        private List<(byte[], string)> TestScenario((Parameters Parameters, Case Case) scenario)
        {
            var results = new List<(byte[], string)>();
            foreach (var c in scenario.Case)
            {
                var result = Run(scenario.Parameters, c.Input);
                results.Add((result, c.Path));
            }
            return results;
        }
    }
}
