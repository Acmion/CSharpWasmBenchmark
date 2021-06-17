class CSharp
{
	// This functionality was implicitly extracted from the file "uno-bootstrap.js" and function "mainInit".

	static CallMethod(fullyQualifiedStaticMethodName, args)
	{
		if (args == null)
		{
			args = [];
		}

		var method = BINDING.resolve_method_fqn(CSharp.BindingBracketArgument + " " + fullyQualifiedStaticMethodName);
		var result = MonoRuntime.call_method(method, null, [BINDING.js_array_to_mono_array(args)]);

		return BINDING.unbox_mono_obj(result);
	}
}

// Extracts the thing within the brackets in config.uno_main. For example:
// config.uno_main = "[CSharpWasmAot] CSharpWasmBenchmark.Program:Main" 
// =>
// CSharp.BindingBracketArgument = "[CSharpWasmAot]"
// The exact meaning of this "parameter" is unknow to me, but this just works.
CSharp.BindingBracketArgument = config.uno_main.substring(0, config.uno_main.indexOf("]") + 1);