using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace TestTools.Base
{
    public abstract class BaseMultiCaseTest<Parameters, Case, Input, Output> : BaseTest<Parameters>
        where Case : List<(Input, Output)>
    {
        public BaseMultiCaseTest(Parameters parameters, ITestOutputHelper output)
            : base(parameters, output)
        {
        }

        public void TestAssert(Parameters parameters, Input input, Output expected)
        {
            var result = Run(parameters, input);
            var success = Validate(expected, result);
            var message = success ? string.Empty : GetCaseMessage((expected, result, 0));
            _output.WriteLine(message);
            Assert.True(success);
        }

        public void TestAssert((Parameters Parameters, Case Case) scenario)
        {
            var failures = TestScenario(scenario);
            var message = GetScenarioMessage(failures);
            _output.WriteLine($"{failures.Count} cases failed.\n{message}");
            Assert.True(failures.Count == 0);
        }

        public void TestAssert(List<(Parameters Parameters, Case Case)> scenarios)
        {
            var failures = TestScenarios(scenarios);
            var message = GetScenariosMessage(failures);
            _output.WriteLine($"{failures.Count} scenarios & {failures.Sum(x => x.Case.Count)} cases failed.\n{message}");
            Assert.True(failures.Count == 0);
        }

        public void TestAssertFile(Parameters parameters, Input input, Output expected)
        {
            var result = Run(parameters, input);
            var success = Validate(expected, result);
            var message = success ? string.Empty : GetCaseMessage((expected, result, 0));
            _output.WriteLine(message);
            Assert.True(success);
        }

        public void TestAssertFile((Parameters Parameters, Case Case) scenario)
        {
            var failures = TestScenario(scenario);
            var message = GetScenarioMessage(failures);
            _output.WriteLine($"{failures.Count} cases failed.\n{message}");
            Assert.Empty(failures);
        }

        protected abstract Output Run(Parameters parameters, Input input);

        private bool Validate(Output expected, Output result)
        {
            var e = Serialize(expected);
            var r = Serialize(result);
            var output = e == r;
            return output;
        }

        protected abstract string Serialize(Output output);

        private IList<(Parameters Parameters, IList<(Output Expected, Output Result, int Case)> Case, int Scenario)>
          TestScenarios(IList<(Parameters Parameters, Case Case)> scenarios)
        {
            var failedScenarios = new List<(Parameters Parameters, IList<(Output Expected, Output Result, int Case)> Case, int Scenario)>();
            for (int i = 0; i < scenarios.Count; ++i)
            {
                var scenario = scenarios[i];
                var failures = TestScenario(scenario);
                if (failures.Count > 0)
                {
                    failedScenarios.Add((scenario.Parameters, failures, i));
                }
            }

            return failedScenarios;
        }

        private IList<(Output Expected, Output Result, int Case)> TestScenario((Parameters Parameters, IList<(Input Input, Output Expected)> Case) scenario)
        {
            var failures = new List<(Output Expected, Output Result, int Case)>();
            for (int i = 0; i < scenario.Case.Count; ++i)
            {
                var test = scenario.Case[i];
                var result = Run(scenario.Parameters, test.Input);
                var correct = Validate(test.Expected, result);
                if (!correct)
                {
                    failures.Add((test.Expected, result, i));
                }
            }

            return failures;
        }

        private string GetScenariosMessage(IList<(Parameters Parameters, IList<(Output Expected, Output Result, int Case)> Case, int Scenario)> failures)
        {
            var message = string.Empty;
            foreach (var failure in failures)
            {
                message += $"Scenario #{failure.Scenario + 1}: {failure.Case.Count} failures.\n";
                message += GetScenarioMessage(failure.Case);
            }
            return message;
        }

        private string GetScenarioMessage(IList<(Output Expected, Output Result, int Case)> failures)
        {
            var message = string.Empty;
            foreach (var failure in failures)
            {
                message += GetCaseMessage(failure);
            }
            return message;
        }

        private string GetCaseMessage((Output Expected, Output Result, int Case) failure)
        {
            var expected = Serialize(failure.Expected);
            var result = Serialize(failure.Result);
            var message = $"  Case #{failure.Case + 1}: expected [{expected}], but got [{result}].\n";
            return message;
        }
    }
}
