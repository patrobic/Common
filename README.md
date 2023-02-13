

# INOXydable <!-- omit in toc -->

INOXydable is a collection of generic module classes, utilities and test tools to be used in other projects.

The title is derived from [**IN**]put, [**O**]utput, e[**X**]pected, which allude to the test data convention of input (source) files, output (result) files, and expected (reference) files. The full name is a play on the french word for "stainless", which is synonymous with "resilient" or "durable".

# Table of Contents <!-- omit in toc -->

- [Shared Components](#shared-components)
  - [Base Tool/Module Classes](#base-toolmodule-classes)
  - [Parameter Manager](#parameter-manager)
  - [Logger](#logger)
  - [CSV De/Serializer](#csv-deserializer)
- [Test Tools](#test-tools)
  - [Base Test Classes](#base-test-classes)
  - [Test Helper](#test-helper)
  - [Path Helper](#path-helper)
  - [Comparators](#comparators)


# Shared Components

The Shared Components can be imported as a dependency to another project, and used throughout the application.

## Base Tool/Module Classes

The Base Tool/Module Classes provide useful functionality to various processing classes (i.e. classes that have distinct input and/or output data types) used in a multitude of scenarios, when used as base classes for such classes.

- Tools: All variations accept a Logger as constructor parameter, and Parameter class as function call parameter.
  - BaseTool<TParameters, TInput>: Processing class with 1 input and no outputs.
  - BaseTool<TParameters, TInput1, TInput2>: Processing class with 2 inputs and no outputs.
  - BaseToolOut<TParameters, TOutput>: Processing class with no inputs and 1 output.
  - BaseToolOut<TParameters, TInput, TOutput>: Processing class with 1 input and 1 output.
  - BaseToolOut<TParameters, TInput1, TInput2, TOutput>: Processing class with 2 inputs and 1 output.
- Modules: All variations accept a Database Context, Parameter Manager, and Logger as constructor parameters, and Parameter class as function call parameter.
  - BaseModule<TParameters>: Module with no inputs or outputs.
  - BaseModule<TParameters, TOutput>: Module with no inputs and 1 output.

## Parameter Manager

The Parameter Manager singleton class provides a mechanism to load parameters classes from a  Parameters folder path where these parameters classes have been serialized to JSON text files. It is used by Module/Tool classes, and can be injected into a project using the .NET Dependency Injection (DI) Framework.

## Logger

The Logger singleton class provides a mechanism for modules to log  It is used by Module/Tool classes, and can be injected into a project using the .NET Dependency Injection (DI) Framework.

## CSV De/Serializer

The CsvSerializer & CsvDeserializer provide generic implementations of CsvHelper functions for the de/serialization of table object classes from/to CSV text files.

# Test Tools

The Test Tools can be imported as a dependency to the test classes of another project, and used throughout the tests.

## Base Test Classes



## Test Helper



## Path Helper



## Comparators


