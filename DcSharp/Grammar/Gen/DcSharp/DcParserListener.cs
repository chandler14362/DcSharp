//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /Users/chandlerstowell/Documents/git/DcSharp/DcSharp/Grammar/DcParser.g4 by ANTLR 4.7.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace DcSharp {
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="DcParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public interface IDcParserListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.init"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInit([NotNull] DcParser.InitContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.init"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInit([NotNull] DcParser.InitContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.dc_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDc_declaration([NotNull] DcParser.Dc_declarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.dc_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDc_declaration([NotNull] DcParser.Dc_declarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.import_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterImport_statement([NotNull] DcParser.Import_statementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.import_statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitImport_statement([NotNull] DcParser.Import_statementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.module_path"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterModule_path([NotNull] DcParser.Module_pathContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.module_path"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitModule_path([NotNull] DcParser.Module_pathContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.module_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterModule_name([NotNull] DcParser.Module_nameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.module_name"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitModule_name([NotNull] DcParser.Module_nameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.module_extension"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterModule_extension([NotNull] DcParser.Module_extensionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.module_extension"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitModule_extension([NotNull] DcParser.Module_extensionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.class_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterClass_declaration([NotNull] DcParser.Class_declarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.class_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitClass_declaration([NotNull] DcParser.Class_declarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.parent_class_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParent_class_list([NotNull] DcParser.Parent_class_listContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.parent_class_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParent_class_list([NotNull] DcParser.Parent_class_listContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.class_field"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterClass_field([NotNull] DcParser.Class_fieldContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.class_field"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitClass_field([NotNull] DcParser.Class_fieldContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.struct_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStruct_declaration([NotNull] DcParser.Struct_declarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.struct_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStruct_declaration([NotNull] DcParser.Struct_declarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.struct_field"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStruct_field([NotNull] DcParser.Struct_fieldContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.struct_field"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStruct_field([NotNull] DcParser.Struct_fieldContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.atomic_field"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAtomic_field([NotNull] DcParser.Atomic_fieldContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.atomic_field"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAtomic_field([NotNull] DcParser.Atomic_fieldContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.field_parameters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterField_parameters([NotNull] DcParser.Field_parametersContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.field_parameters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitField_parameters([NotNull] DcParser.Field_parametersContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.molecular_field"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMolecular_field([NotNull] DcParser.Molecular_fieldContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.molecular_field"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMolecular_field([NotNull] DcParser.Molecular_fieldContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.molecular_field_members"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMolecular_field_members([NotNull] DcParser.Molecular_field_membersContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.molecular_field_members"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMolecular_field_members([NotNull] DcParser.Molecular_field_membersContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.keyword_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterKeyword_declaration([NotNull] DcParser.Keyword_declarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.keyword_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitKeyword_declaration([NotNull] DcParser.Keyword_declarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.keyword_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterKeyword_list([NotNull] DcParser.Keyword_listContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.keyword_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitKeyword_list([NotNull] DcParser.Keyword_listContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.typedef_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTypedef_declaration([NotNull] DcParser.Typedef_declarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.typedef_declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTypedef_declaration([NotNull] DcParser.Typedef_declarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParameter([NotNull] DcParser.ParameterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParameter([NotNull] DcParser.ParameterContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.array_specification"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArray_specification([NotNull] DcParser.Array_specificationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.array_specification"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArray_specification([NotNull] DcParser.Array_specificationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.parameter_range"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParameter_range([NotNull] DcParser.Parameter_rangeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.parameter_range"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParameter_range([NotNull] DcParser.Parameter_rangeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.range_arguments"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRange_arguments([NotNull] DcParser.Range_argumentsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.range_arguments"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRange_arguments([NotNull] DcParser.Range_argumentsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.range_argument"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRange_argument([NotNull] DcParser.Range_argumentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.range_argument"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRange_argument([NotNull] DcParser.Range_argumentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.default_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDefault_value([NotNull] DcParser.Default_valueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.default_value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDefault_value([NotNull] DcParser.Default_valueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.value_constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterValue_constant([NotNull] DcParser.Value_constantContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.value_constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitValue_constant([NotNull] DcParser.Value_constantContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.number_constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumber_constant([NotNull] DcParser.Number_constantContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.number_constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumber_constant([NotNull] DcParser.Number_constantContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.string_constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterString_constant([NotNull] DcParser.String_constantContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.string_constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitString_constant([NotNull] DcParser.String_constantContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.struct_constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStruct_constant([NotNull] DcParser.Struct_constantContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.struct_constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStruct_constant([NotNull] DcParser.Struct_constantContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.struct_value_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStruct_value_list([NotNull] DcParser.Struct_value_listContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.struct_value_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStruct_value_list([NotNull] DcParser.Struct_value_listContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.array_constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArray_constant([NotNull] DcParser.Array_constantContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.array_constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArray_constant([NotNull] DcParser.Array_constantContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.array_value_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArray_value_list([NotNull] DcParser.Array_value_listContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.array_value_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArray_value_list([NotNull] DcParser.Array_value_listContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="DcParser.array_value_constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArray_value_constant([NotNull] DcParser.Array_value_constantContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="DcParser.array_value_constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArray_value_constant([NotNull] DcParser.Array_value_constantContext context);
}
} // namespace DcSharp
