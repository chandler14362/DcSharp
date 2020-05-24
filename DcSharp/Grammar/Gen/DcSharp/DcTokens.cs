//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /Users/chandlerstowell/Documents/git/DcSharp/DcSharp/Grammar/DcTokens.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace DcSharp {
using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public partial class DcTokens : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		DCLASS=1, STRUCT=2, TYPEDEF=3, KEYWORD=4, FROM=5, IMPORT=6, HISTORIC_KW=7, 
		BUILTIN_TYPE=8, STAR=9, FWSLASH=10, MODULUS=11, PERIOD=12, LPAREN=13, 
		RPAREN=14, HYPEN=15, COMMA=16, LSBRACKET=17, RSBRACKET=18, LBRACKET=19, 
		RBRACKET=20, SINGLE_QUOTE=21, DOUBLE_QUOTE=22, EQUALS=23, SEMICOLON=24, 
		COLON=25, DOUBLE_QUOTED_STRING=26, QUOTED_CHAR=27, SINGLE_QUOTED_STRING=28, 
		IDENTIFIER=29, UNSIGNED_NUMBER=30, CHAR=31, SINGLE_LINE_COMMENT=32, WS=33;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"DCLASS", "STRUCT", "TYPEDEF", "KEYWORD", "FROM", "IMPORT", "REQUIRED", 
		"BROADCAST", "OWNRECV", "RAM", "DB", "CLSEND", "CLRECV", "OWNSEND", "AIRECV", 
		"HISTORIC_KW", "UINT32UINT8ARRAY", "INT32ARRAY", "INT16ARRAY", "INT8ARRAY", 
		"UINT32ARRAY", "UINT16ARRAY", "UINT8ARRAY", "UINT64", "UINT32", "UINT16", 
		"UINT8", "INT64", "INT32", "INT16", "INT8", "STRING", "BLOB32", "BLOB", 
		"BUILTIN_TYPE", "STAR", "FWSLASH", "MODULUS", "PERIOD", "LPAREN", "RPAREN", 
		"HYPEN", "COMMA", "LSBRACKET", "RSBRACKET", "LBRACKET", "RBRACKET", "SINGLE_QUOTE", 
		"DOUBLE_QUOTE", "EQUALS", "SEMICOLON", "COLON", "ESCAPED_DOUBLE_QUOTE", 
		"DOUBLE_QUOTED_STRING", "QUOTED_CHAR", "ESCAPED_SINGLE_QUOTE", "SINGLE_QUOTED_STRING", 
		"IDENTIFIER", "UNSIGNED_NUMBER", "CHAR", "SINGLE_LINE_COMMENT", "WS"
	};


	public DcTokens(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public DcTokens(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'dclass'", "'struct'", "'typedef'", "'keyword'", "'from'", "'import'", 
		null, null, "'*'", "'/'", "'%'", "'.'", "'('", "')'", "'-'", "','", "'['", 
		"']'", "'{'", "'}'", "'''", "'\"'", "'='", "';'", "':'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "DCLASS", "STRUCT", "TYPEDEF", "KEYWORD", "FROM", "IMPORT", "HISTORIC_KW", 
		"BUILTIN_TYPE", "STAR", "FWSLASH", "MODULUS", "PERIOD", "LPAREN", "RPAREN", 
		"HYPEN", "COMMA", "LSBRACKET", "RSBRACKET", "LBRACKET", "RBRACKET", "SINGLE_QUOTE", 
		"DOUBLE_QUOTE", "EQUALS", "SEMICOLON", "COLON", "DOUBLE_QUOTED_STRING", 
		"QUOTED_CHAR", "SINGLE_QUOTED_STRING", "IDENTIFIER", "UNSIGNED_NUMBER", 
		"CHAR", "SINGLE_LINE_COMMENT", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "DcTokens.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static DcTokens() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '#', '\x202', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', '\x1D', '\t', 
		'\x1D', '\x4', '\x1E', '\t', '\x1E', '\x4', '\x1F', '\t', '\x1F', '\x4', 
		' ', '\t', ' ', '\x4', '!', '\t', '!', '\x4', '\"', '\t', '\"', '\x4', 
		'#', '\t', '#', '\x4', '$', '\t', '$', '\x4', '%', '\t', '%', '\x4', '&', 
		'\t', '&', '\x4', '\'', '\t', '\'', '\x4', '(', '\t', '(', '\x4', ')', 
		'\t', ')', '\x4', '*', '\t', '*', '\x4', '+', '\t', '+', '\x4', ',', '\t', 
		',', '\x4', '-', '\t', '-', '\x4', '.', '\t', '.', '\x4', '/', '\t', '/', 
		'\x4', '\x30', '\t', '\x30', '\x4', '\x31', '\t', '\x31', '\x4', '\x32', 
		'\t', '\x32', '\x4', '\x33', '\t', '\x33', '\x4', '\x34', '\t', '\x34', 
		'\x4', '\x35', '\t', '\x35', '\x4', '\x36', '\t', '\x36', '\x4', '\x37', 
		'\t', '\x37', '\x4', '\x38', '\t', '\x38', '\x4', '\x39', '\t', '\x39', 
		'\x4', ':', '\t', ':', '\x4', ';', '\t', ';', '\x4', '<', '\t', '<', '\x4', 
		'=', '\t', '=', '\x4', '>', '\t', '>', '\x4', '?', '\t', '?', '\x3', '\x2', 
		'\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', '\x3', '\x2', 
		'\x3', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', '\x4', 
		'\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', 
		'\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', 
		'\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', 
		'\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x3', 
		'\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', 
		'\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', 
		'\b', '\x3', '\b', '\x3', '\b', '\x3', '\b', '\x3', '\t', '\x3', '\t', 
		'\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', 
		'\t', '\x3', '\t', '\x3', '\t', '\x3', '\n', '\x3', '\n', '\x3', '\n', 
		'\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', 
		'\v', '\x3', '\v', '\x3', '\v', '\x3', '\v', '\x3', '\f', '\x3', '\f', 
		'\x3', '\f', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', 
		'\r', '\x3', '\r', '\x3', '\r', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', 
		'\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xF', 
		'\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\xF', 
		'\x3', '\xF', '\x3', '\xF', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', 
		'\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x11', 
		'\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', 
		'\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x5', '\x11', '\xF2', '\n', 
		'\x11', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', 
		'\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', 
		'\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', 
		'\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x13', '\x3', '\x13', '\x3', 
		'\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x3', 
		'\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x14', '\x3', 
		'\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', 
		'\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', 
		'\x15', '\x3', '\x15', '\x3', '\x15', '\x3', '\x15', '\x3', '\x15', '\x3', 
		'\x15', '\x3', '\x15', '\x3', '\x15', '\x3', '\x15', '\x3', '\x15', '\x3', 
		'\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\x3', 
		'\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\x3', 
		'\x16', '\x3', '\x16', '\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x3', 
		'\x17', '\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x3', 
		'\x17', '\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x3', '\x18', '\x3', 
		'\x18', '\x3', '\x18', '\x3', '\x18', '\x3', '\x18', '\x3', '\x18', '\x3', 
		'\x18', '\x3', '\x18', '\x3', '\x18', '\x3', '\x18', '\x3', '\x18', '\x3', 
		'\x19', '\x3', '\x19', '\x3', '\x19', '\x3', '\x19', '\x3', '\x19', '\x3', 
		'\x19', '\x3', '\x19', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', 
		'\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1B', '\x3', 
		'\x1B', '\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1B', '\x3', 
		'\x1B', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1C', '\x3', 
		'\x1C', '\x3', '\x1C', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', 
		'\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1E', '\x3', '\x1E', '\x3', 
		'\x1E', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1E', '\x3', '\x1F', '\x3', 
		'\x1F', '\x3', '\x1F', '\x3', '\x1F', '\x3', '\x1F', '\x3', '\x1F', '\x3', 
		' ', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x3', '!', '\x3', 
		'!', '\x3', '!', '\x3', '!', '\x3', '!', '\x3', '!', '\x3', '!', '\x3', 
		'\"', '\x3', '\"', '\x3', '\"', '\x3', '\"', '\x3', '\"', '\x3', '\"', 
		'\x3', '\"', '\x3', '#', '\x3', '#', '\x3', '#', '\x3', '#', '\x3', '#', 
		'\x3', '$', '\x3', '$', '\x3', '$', '\x3', '$', '\x3', '$', '\x3', '$', 
		'\x3', '$', '\x3', '$', '\x3', '$', '\x3', '$', '\x3', '$', '\x3', '$', 
		'\x3', '$', '\x3', '$', '\x3', '$', '\x3', '$', '\x3', '$', '\x3', '$', 
		'\x5', '$', '\x19F', '\n', '$', '\x3', '%', '\x3', '%', '\x3', '&', '\x3', 
		'&', '\x3', '\'', '\x3', '\'', '\x3', '(', '\x3', '(', '\x3', ')', '\x3', 
		')', '\x3', '*', '\x3', '*', '\x3', '+', '\x3', '+', '\x3', ',', '\x3', 
		',', '\x3', '-', '\x3', '-', '\x3', '.', '\x3', '.', '\x3', '/', '\x3', 
		'/', '\x3', '\x30', '\x3', '\x30', '\x3', '\x31', '\x3', '\x31', '\x3', 
		'\x32', '\x3', '\x32', '\x3', '\x33', '\x3', '\x33', '\x3', '\x34', '\x3', 
		'\x34', '\x3', '\x35', '\x3', '\x35', '\x3', '\x36', '\x3', '\x36', '\x3', 
		'\x36', '\x3', '\x37', '\x3', '\x37', '\x3', '\x37', '\a', '\x37', '\x1C9', 
		'\n', '\x37', '\f', '\x37', '\xE', '\x37', '\x1CC', '\v', '\x37', '\x3', 
		'\x37', '\x3', '\x37', '\x3', '\x38', '\x3', '\x38', '\x3', '\x38', '\x3', 
		'\x38', '\x3', '\x39', '\x3', '\x39', '\x3', '\x39', '\x3', ':', '\x3', 
		':', '\x3', ':', '\a', ':', '\x1DA', '\n', ':', '\f', ':', '\xE', ':', 
		'\x1DD', '\v', ':', '\x3', ':', '\x3', ':', '\x3', ';', '\x3', ';', '\a', 
		';', '\x1E3', '\n', ';', '\f', ';', '\xE', ';', '\x1E6', '\v', ';', '\x3', 
		'<', '\x6', '<', '\x1E9', '\n', '<', '\r', '<', '\xE', '<', '\x1EA', '\x3', 
		'=', '\x3', '=', '\x3', '>', '\x3', '>', '\x3', '>', '\x3', '>', '\a', 
		'>', '\x1F3', '\n', '>', '\f', '>', '\xE', '>', '\x1F6', '\v', '>', '\x3', 
		'>', '\x3', '>', '\x3', '>', '\x3', '>', '\x3', '?', '\x6', '?', '\x1FD', 
		'\n', '?', '\r', '?', '\xE', '?', '\x1FE', '\x3', '?', '\x3', '?', '\x5', 
		'\x1CA', '\x1DB', '\x1F4', '\x2', '@', '\x3', '\x3', '\x5', '\x4', '\a', 
		'\x5', '\t', '\x6', '\v', '\a', '\r', '\b', '\xF', '\x2', '\x11', '\x2', 
		'\x13', '\x2', '\x15', '\x2', '\x17', '\x2', '\x19', '\x2', '\x1B', '\x2', 
		'\x1D', '\x2', '\x1F', '\x2', '!', '\t', '#', '\x2', '%', '\x2', '\'', 
		'\x2', ')', '\x2', '+', '\x2', '-', '\x2', '/', '\x2', '\x31', '\x2', 
		'\x33', '\x2', '\x35', '\x2', '\x37', '\x2', '\x39', '\x2', ';', '\x2', 
		'=', '\x2', '?', '\x2', '\x41', '\x2', '\x43', '\x2', '\x45', '\x2', 'G', 
		'\n', 'I', '\v', 'K', '\f', 'M', '\r', 'O', '\xE', 'Q', '\xF', 'S', '\x10', 
		'U', '\x11', 'W', '\x12', 'Y', '\x13', '[', '\x14', ']', '\x15', '_', 
		'\x16', '\x61', '\x17', '\x63', '\x18', '\x65', '\x19', 'g', '\x1A', 'i', 
		'\x1B', 'k', '\x2', 'm', '\x1C', 'o', '\x1D', 'q', '\x2', 's', '\x1E', 
		'u', '\x1F', 'w', ' ', 'y', '!', '{', '\"', '}', '#', '\x3', '\x2', '\b', 
		'\x4', '\x2', '\f', '\f', '\xF', '\xF', '\x5', '\x2', '\x43', '\\', '\x61', 
		'\x61', '\x63', '|', '\x6', '\x2', '\x32', ';', '\x43', '\\', '\x61', 
		'\x61', '\x63', '|', '\x3', '\x2', '\x32', ';', '\x4', '\x2', '\x43', 
		'\\', '\x63', '|', '\x5', '\x2', '\v', '\f', '\xF', '\xF', '\"', '\"', 
		'\x2', '\x205', '\x2', '\x3', '\x3', '\x2', '\x2', '\x2', '\x2', '\x5', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x2', '!', '\x3', '\x2', '\x2', 
		'\x2', '\x2', 'G', '\x3', '\x2', '\x2', '\x2', '\x2', 'I', '\x3', '\x2', 
		'\x2', '\x2', '\x2', 'K', '\x3', '\x2', '\x2', '\x2', '\x2', 'M', '\x3', 
		'\x2', '\x2', '\x2', '\x2', 'O', '\x3', '\x2', '\x2', '\x2', '\x2', 'Q', 
		'\x3', '\x2', '\x2', '\x2', '\x2', 'S', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'U', '\x3', '\x2', '\x2', '\x2', '\x2', 'W', '\x3', '\x2', '\x2', '\x2', 
		'\x2', 'Y', '\x3', '\x2', '\x2', '\x2', '\x2', '[', '\x3', '\x2', '\x2', 
		'\x2', '\x2', ']', '\x3', '\x2', '\x2', '\x2', '\x2', '_', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x61', '\x3', '\x2', '\x2', '\x2', '\x2', '\x63', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x65', '\x3', '\x2', '\x2', '\x2', 
		'\x2', 'g', '\x3', '\x2', '\x2', '\x2', '\x2', 'i', '\x3', '\x2', '\x2', 
		'\x2', '\x2', 'm', '\x3', '\x2', '\x2', '\x2', '\x2', 'o', '\x3', '\x2', 
		'\x2', '\x2', '\x2', 's', '\x3', '\x2', '\x2', '\x2', '\x2', 'u', '\x3', 
		'\x2', '\x2', '\x2', '\x2', 'w', '\x3', '\x2', '\x2', '\x2', '\x2', 'y', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '{', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'}', '\x3', '\x2', '\x2', '\x2', '\x3', '\x7F', '\x3', '\x2', '\x2', '\x2', 
		'\x5', '\x86', '\x3', '\x2', '\x2', '\x2', '\a', '\x8D', '\x3', '\x2', 
		'\x2', '\x2', '\t', '\x95', '\x3', '\x2', '\x2', '\x2', '\v', '\x9D', 
		'\x3', '\x2', '\x2', '\x2', '\r', '\xA2', '\x3', '\x2', '\x2', '\x2', 
		'\xF', '\xA9', '\x3', '\x2', '\x2', '\x2', '\x11', '\xB2', '\x3', '\x2', 
		'\x2', '\x2', '\x13', '\xBC', '\x3', '\x2', '\x2', '\x2', '\x15', '\xC4', 
		'\x3', '\x2', '\x2', '\x2', '\x17', '\xC8', '\x3', '\x2', '\x2', '\x2', 
		'\x19', '\xCB', '\x3', '\x2', '\x2', '\x2', '\x1B', '\xD2', '\x3', '\x2', 
		'\x2', '\x2', '\x1D', '\xD9', '\x3', '\x2', '\x2', '\x2', '\x1F', '\xE1', 
		'\x3', '\x2', '\x2', '\x2', '!', '\xF1', '\x3', '\x2', '\x2', '\x2', '#', 
		'\xF3', '\x3', '\x2', '\x2', '\x2', '%', '\x104', '\x3', '\x2', '\x2', 
		'\x2', '\'', '\x10F', '\x3', '\x2', '\x2', '\x2', ')', '\x11A', '\x3', 
		'\x2', '\x2', '\x2', '+', '\x124', '\x3', '\x2', '\x2', '\x2', '-', '\x130', 
		'\x3', '\x2', '\x2', '\x2', '/', '\x13C', '\x3', '\x2', '\x2', '\x2', 
		'\x31', '\x147', '\x3', '\x2', '\x2', '\x2', '\x33', '\x14E', '\x3', '\x2', 
		'\x2', '\x2', '\x35', '\x155', '\x3', '\x2', '\x2', '\x2', '\x37', '\x15C', 
		'\x3', '\x2', '\x2', '\x2', '\x39', '\x162', '\x3', '\x2', '\x2', '\x2', 
		';', '\x168', '\x3', '\x2', '\x2', '\x2', '=', '\x16E', '\x3', '\x2', 
		'\x2', '\x2', '?', '\x174', '\x3', '\x2', '\x2', '\x2', '\x41', '\x179', 
		'\x3', '\x2', '\x2', '\x2', '\x43', '\x180', '\x3', '\x2', '\x2', '\x2', 
		'\x45', '\x187', '\x3', '\x2', '\x2', '\x2', 'G', '\x19E', '\x3', '\x2', 
		'\x2', '\x2', 'I', '\x1A0', '\x3', '\x2', '\x2', '\x2', 'K', '\x1A2', 
		'\x3', '\x2', '\x2', '\x2', 'M', '\x1A4', '\x3', '\x2', '\x2', '\x2', 
		'O', '\x1A6', '\x3', '\x2', '\x2', '\x2', 'Q', '\x1A8', '\x3', '\x2', 
		'\x2', '\x2', 'S', '\x1AA', '\x3', '\x2', '\x2', '\x2', 'U', '\x1AC', 
		'\x3', '\x2', '\x2', '\x2', 'W', '\x1AE', '\x3', '\x2', '\x2', '\x2', 
		'Y', '\x1B0', '\x3', '\x2', '\x2', '\x2', '[', '\x1B2', '\x3', '\x2', 
		'\x2', '\x2', ']', '\x1B4', '\x3', '\x2', '\x2', '\x2', '_', '\x1B6', 
		'\x3', '\x2', '\x2', '\x2', '\x61', '\x1B8', '\x3', '\x2', '\x2', '\x2', 
		'\x63', '\x1BA', '\x3', '\x2', '\x2', '\x2', '\x65', '\x1BC', '\x3', '\x2', 
		'\x2', '\x2', 'g', '\x1BE', '\x3', '\x2', '\x2', '\x2', 'i', '\x1C0', 
		'\x3', '\x2', '\x2', '\x2', 'k', '\x1C2', '\x3', '\x2', '\x2', '\x2', 
		'm', '\x1C5', '\x3', '\x2', '\x2', '\x2', 'o', '\x1CF', '\x3', '\x2', 
		'\x2', '\x2', 'q', '\x1D3', '\x3', '\x2', '\x2', '\x2', 's', '\x1D6', 
		'\x3', '\x2', '\x2', '\x2', 'u', '\x1E0', '\x3', '\x2', '\x2', '\x2', 
		'w', '\x1E8', '\x3', '\x2', '\x2', '\x2', 'y', '\x1EC', '\x3', '\x2', 
		'\x2', '\x2', '{', '\x1EE', '\x3', '\x2', '\x2', '\x2', '}', '\x1FC', 
		'\x3', '\x2', '\x2', '\x2', '\x7F', '\x80', '\a', '\x66', '\x2', '\x2', 
		'\x80', '\x81', '\a', '\x65', '\x2', '\x2', '\x81', '\x82', '\a', 'n', 
		'\x2', '\x2', '\x82', '\x83', '\a', '\x63', '\x2', '\x2', '\x83', '\x84', 
		'\a', 'u', '\x2', '\x2', '\x84', '\x85', '\a', 'u', '\x2', '\x2', '\x85', 
		'\x4', '\x3', '\x2', '\x2', '\x2', '\x86', '\x87', '\a', 'u', '\x2', '\x2', 
		'\x87', '\x88', '\a', 'v', '\x2', '\x2', '\x88', '\x89', '\a', 't', '\x2', 
		'\x2', '\x89', '\x8A', '\a', 'w', '\x2', '\x2', '\x8A', '\x8B', '\a', 
		'\x65', '\x2', '\x2', '\x8B', '\x8C', '\a', 'v', '\x2', '\x2', '\x8C', 
		'\x6', '\x3', '\x2', '\x2', '\x2', '\x8D', '\x8E', '\a', 'v', '\x2', '\x2', 
		'\x8E', '\x8F', '\a', '{', '\x2', '\x2', '\x8F', '\x90', '\a', 'r', '\x2', 
		'\x2', '\x90', '\x91', '\a', 'g', '\x2', '\x2', '\x91', '\x92', '\a', 
		'\x66', '\x2', '\x2', '\x92', '\x93', '\a', 'g', '\x2', '\x2', '\x93', 
		'\x94', '\a', 'h', '\x2', '\x2', '\x94', '\b', '\x3', '\x2', '\x2', '\x2', 
		'\x95', '\x96', '\a', 'm', '\x2', '\x2', '\x96', '\x97', '\a', 'g', '\x2', 
		'\x2', '\x97', '\x98', '\a', '{', '\x2', '\x2', '\x98', '\x99', '\a', 
		'y', '\x2', '\x2', '\x99', '\x9A', '\a', 'q', '\x2', '\x2', '\x9A', '\x9B', 
		'\a', 't', '\x2', '\x2', '\x9B', '\x9C', '\a', '\x66', '\x2', '\x2', '\x9C', 
		'\n', '\x3', '\x2', '\x2', '\x2', '\x9D', '\x9E', '\a', 'h', '\x2', '\x2', 
		'\x9E', '\x9F', '\a', 't', '\x2', '\x2', '\x9F', '\xA0', '\a', 'q', '\x2', 
		'\x2', '\xA0', '\xA1', '\a', 'o', '\x2', '\x2', '\xA1', '\f', '\x3', '\x2', 
		'\x2', '\x2', '\xA2', '\xA3', '\a', 'k', '\x2', '\x2', '\xA3', '\xA4', 
		'\a', 'o', '\x2', '\x2', '\xA4', '\xA5', '\a', 'r', '\x2', '\x2', '\xA5', 
		'\xA6', '\a', 'q', '\x2', '\x2', '\xA6', '\xA7', '\a', 't', '\x2', '\x2', 
		'\xA7', '\xA8', '\a', 'v', '\x2', '\x2', '\xA8', '\xE', '\x3', '\x2', 
		'\x2', '\x2', '\xA9', '\xAA', '\a', 't', '\x2', '\x2', '\xAA', '\xAB', 
		'\a', 'g', '\x2', '\x2', '\xAB', '\xAC', '\a', 's', '\x2', '\x2', '\xAC', 
		'\xAD', '\a', 'w', '\x2', '\x2', '\xAD', '\xAE', '\a', 'k', '\x2', '\x2', 
		'\xAE', '\xAF', '\a', 't', '\x2', '\x2', '\xAF', '\xB0', '\a', 'g', '\x2', 
		'\x2', '\xB0', '\xB1', '\a', '\x66', '\x2', '\x2', '\xB1', '\x10', '\x3', 
		'\x2', '\x2', '\x2', '\xB2', '\xB3', '\a', '\x64', '\x2', '\x2', '\xB3', 
		'\xB4', '\a', 't', '\x2', '\x2', '\xB4', '\xB5', '\a', 'q', '\x2', '\x2', 
		'\xB5', '\xB6', '\a', '\x63', '\x2', '\x2', '\xB6', '\xB7', '\a', '\x66', 
		'\x2', '\x2', '\xB7', '\xB8', '\a', '\x65', '\x2', '\x2', '\xB8', '\xB9', 
		'\a', '\x63', '\x2', '\x2', '\xB9', '\xBA', '\a', 'u', '\x2', '\x2', '\xBA', 
		'\xBB', '\a', 'v', '\x2', '\x2', '\xBB', '\x12', '\x3', '\x2', '\x2', 
		'\x2', '\xBC', '\xBD', '\a', 'q', '\x2', '\x2', '\xBD', '\xBE', '\a', 
		'y', '\x2', '\x2', '\xBE', '\xBF', '\a', 'p', '\x2', '\x2', '\xBF', '\xC0', 
		'\a', 't', '\x2', '\x2', '\xC0', '\xC1', '\a', 'g', '\x2', '\x2', '\xC1', 
		'\xC2', '\a', '\x65', '\x2', '\x2', '\xC2', '\xC3', '\a', 'x', '\x2', 
		'\x2', '\xC3', '\x14', '\x3', '\x2', '\x2', '\x2', '\xC4', '\xC5', '\a', 
		't', '\x2', '\x2', '\xC5', '\xC6', '\a', '\x63', '\x2', '\x2', '\xC6', 
		'\xC7', '\a', 'o', '\x2', '\x2', '\xC7', '\x16', '\x3', '\x2', '\x2', 
		'\x2', '\xC8', '\xC9', '\a', '\x66', '\x2', '\x2', '\xC9', '\xCA', '\a', 
		'\x64', '\x2', '\x2', '\xCA', '\x18', '\x3', '\x2', '\x2', '\x2', '\xCB', 
		'\xCC', '\a', '\x65', '\x2', '\x2', '\xCC', '\xCD', '\a', 'n', '\x2', 
		'\x2', '\xCD', '\xCE', '\a', 'u', '\x2', '\x2', '\xCE', '\xCF', '\a', 
		'g', '\x2', '\x2', '\xCF', '\xD0', '\a', 'p', '\x2', '\x2', '\xD0', '\xD1', 
		'\a', '\x66', '\x2', '\x2', '\xD1', '\x1A', '\x3', '\x2', '\x2', '\x2', 
		'\xD2', '\xD3', '\a', '\x65', '\x2', '\x2', '\xD3', '\xD4', '\a', 'n', 
		'\x2', '\x2', '\xD4', '\xD5', '\a', 't', '\x2', '\x2', '\xD5', '\xD6', 
		'\a', 'g', '\x2', '\x2', '\xD6', '\xD7', '\a', '\x65', '\x2', '\x2', '\xD7', 
		'\xD8', '\a', 'x', '\x2', '\x2', '\xD8', '\x1C', '\x3', '\x2', '\x2', 
		'\x2', '\xD9', '\xDA', '\a', 'q', '\x2', '\x2', '\xDA', '\xDB', '\a', 
		'y', '\x2', '\x2', '\xDB', '\xDC', '\a', 'p', '\x2', '\x2', '\xDC', '\xDD', 
		'\a', 'u', '\x2', '\x2', '\xDD', '\xDE', '\a', 'g', '\x2', '\x2', '\xDE', 
		'\xDF', '\a', 'p', '\x2', '\x2', '\xDF', '\xE0', '\a', '\x66', '\x2', 
		'\x2', '\xE0', '\x1E', '\x3', '\x2', '\x2', '\x2', '\xE1', '\xE2', '\a', 
		'\x63', '\x2', '\x2', '\xE2', '\xE3', '\a', 'k', '\x2', '\x2', '\xE3', 
		'\xE4', '\a', 't', '\x2', '\x2', '\xE4', '\xE5', '\a', 'g', '\x2', '\x2', 
		'\xE5', '\xE6', '\a', '\x65', '\x2', '\x2', '\xE6', '\xE7', '\a', 'x', 
		'\x2', '\x2', '\xE7', ' ', '\x3', '\x2', '\x2', '\x2', '\xE8', '\xF2', 
		'\x5', '\xF', '\b', '\x2', '\xE9', '\xF2', '\x5', '\x11', '\t', '\x2', 
		'\xEA', '\xF2', '\x5', '\x13', '\n', '\x2', '\xEB', '\xF2', '\x5', '\x15', 
		'\v', '\x2', '\xEC', '\xF2', '\x5', '\x17', '\f', '\x2', '\xED', '\xF2', 
		'\x5', '\x19', '\r', '\x2', '\xEE', '\xF2', '\x5', '\x1B', '\xE', '\x2', 
		'\xEF', '\xF2', '\x5', '\x13', '\n', '\x2', '\xF0', '\xF2', '\x5', '\x1F', 
		'\x10', '\x2', '\xF1', '\xE8', '\x3', '\x2', '\x2', '\x2', '\xF1', '\xE9', 
		'\x3', '\x2', '\x2', '\x2', '\xF1', '\xEA', '\x3', '\x2', '\x2', '\x2', 
		'\xF1', '\xEB', '\x3', '\x2', '\x2', '\x2', '\xF1', '\xEC', '\x3', '\x2', 
		'\x2', '\x2', '\xF1', '\xED', '\x3', '\x2', '\x2', '\x2', '\xF1', '\xEE', 
		'\x3', '\x2', '\x2', '\x2', '\xF1', '\xEF', '\x3', '\x2', '\x2', '\x2', 
		'\xF1', '\xF0', '\x3', '\x2', '\x2', '\x2', '\xF2', '\"', '\x3', '\x2', 
		'\x2', '\x2', '\xF3', '\xF4', '\a', 'w', '\x2', '\x2', '\xF4', '\xF5', 
		'\a', 'k', '\x2', '\x2', '\xF5', '\xF6', '\a', 'p', '\x2', '\x2', '\xF6', 
		'\xF7', '\a', 'v', '\x2', '\x2', '\xF7', '\xF8', '\a', '\x35', '\x2', 
		'\x2', '\xF8', '\xF9', '\a', '\x34', '\x2', '\x2', '\xF9', '\xFA', '\a', 
		'w', '\x2', '\x2', '\xFA', '\xFB', '\a', 'k', '\x2', '\x2', '\xFB', '\xFC', 
		'\a', 'p', '\x2', '\x2', '\xFC', '\xFD', '\a', 'v', '\x2', '\x2', '\xFD', 
		'\xFE', '\a', ':', '\x2', '\x2', '\xFE', '\xFF', '\a', '\x63', '\x2', 
		'\x2', '\xFF', '\x100', '\a', 't', '\x2', '\x2', '\x100', '\x101', '\a', 
		't', '\x2', '\x2', '\x101', '\x102', '\a', '\x63', '\x2', '\x2', '\x102', 
		'\x103', '\a', '{', '\x2', '\x2', '\x103', '$', '\x3', '\x2', '\x2', '\x2', 
		'\x104', '\x105', '\a', 'k', '\x2', '\x2', '\x105', '\x106', '\a', 'p', 
		'\x2', '\x2', '\x106', '\x107', '\a', 'v', '\x2', '\x2', '\x107', '\x108', 
		'\a', '\x35', '\x2', '\x2', '\x108', '\x109', '\a', '\x34', '\x2', '\x2', 
		'\x109', '\x10A', '\a', '\x63', '\x2', '\x2', '\x10A', '\x10B', '\a', 
		't', '\x2', '\x2', '\x10B', '\x10C', '\a', 't', '\x2', '\x2', '\x10C', 
		'\x10D', '\a', '\x63', '\x2', '\x2', '\x10D', '\x10E', '\a', '{', '\x2', 
		'\x2', '\x10E', '&', '\x3', '\x2', '\x2', '\x2', '\x10F', '\x110', '\a', 
		'k', '\x2', '\x2', '\x110', '\x111', '\a', 'p', '\x2', '\x2', '\x111', 
		'\x112', '\a', 'v', '\x2', '\x2', '\x112', '\x113', '\a', '\x33', '\x2', 
		'\x2', '\x113', '\x114', '\a', '\x38', '\x2', '\x2', '\x114', '\x115', 
		'\a', '\x63', '\x2', '\x2', '\x115', '\x116', '\a', 't', '\x2', '\x2', 
		'\x116', '\x117', '\a', 't', '\x2', '\x2', '\x117', '\x118', '\a', '\x63', 
		'\x2', '\x2', '\x118', '\x119', '\a', '{', '\x2', '\x2', '\x119', '(', 
		'\x3', '\x2', '\x2', '\x2', '\x11A', '\x11B', '\a', 'k', '\x2', '\x2', 
		'\x11B', '\x11C', '\a', 'p', '\x2', '\x2', '\x11C', '\x11D', '\a', 'v', 
		'\x2', '\x2', '\x11D', '\x11E', '\a', ':', '\x2', '\x2', '\x11E', '\x11F', 
		'\a', '\x63', '\x2', '\x2', '\x11F', '\x120', '\a', 't', '\x2', '\x2', 
		'\x120', '\x121', '\a', 't', '\x2', '\x2', '\x121', '\x122', '\a', '\x63', 
		'\x2', '\x2', '\x122', '\x123', '\a', '{', '\x2', '\x2', '\x123', '*', 
		'\x3', '\x2', '\x2', '\x2', '\x124', '\x125', '\a', 'w', '\x2', '\x2', 
		'\x125', '\x126', '\a', 'k', '\x2', '\x2', '\x126', '\x127', '\a', 'p', 
		'\x2', '\x2', '\x127', '\x128', '\a', 'v', '\x2', '\x2', '\x128', '\x129', 
		'\a', '\x35', '\x2', '\x2', '\x129', '\x12A', '\a', '\x34', '\x2', '\x2', 
		'\x12A', '\x12B', '\a', '\x63', '\x2', '\x2', '\x12B', '\x12C', '\a', 
		't', '\x2', '\x2', '\x12C', '\x12D', '\a', 't', '\x2', '\x2', '\x12D', 
		'\x12E', '\a', '\x63', '\x2', '\x2', '\x12E', '\x12F', '\a', '{', '\x2', 
		'\x2', '\x12F', ',', '\x3', '\x2', '\x2', '\x2', '\x130', '\x131', '\a', 
		'w', '\x2', '\x2', '\x131', '\x132', '\a', 'k', '\x2', '\x2', '\x132', 
		'\x133', '\a', 'p', '\x2', '\x2', '\x133', '\x134', '\a', 'v', '\x2', 
		'\x2', '\x134', '\x135', '\a', '\x33', '\x2', '\x2', '\x135', '\x136', 
		'\a', '\x38', '\x2', '\x2', '\x136', '\x137', '\a', '\x63', '\x2', '\x2', 
		'\x137', '\x138', '\a', 't', '\x2', '\x2', '\x138', '\x139', '\a', 't', 
		'\x2', '\x2', '\x139', '\x13A', '\a', '\x63', '\x2', '\x2', '\x13A', '\x13B', 
		'\a', '{', '\x2', '\x2', '\x13B', '.', '\x3', '\x2', '\x2', '\x2', '\x13C', 
		'\x13D', '\a', 'w', '\x2', '\x2', '\x13D', '\x13E', '\a', 'k', '\x2', 
		'\x2', '\x13E', '\x13F', '\a', 'p', '\x2', '\x2', '\x13F', '\x140', '\a', 
		'v', '\x2', '\x2', '\x140', '\x141', '\a', ':', '\x2', '\x2', '\x141', 
		'\x142', '\a', '\x63', '\x2', '\x2', '\x142', '\x143', '\a', 't', '\x2', 
		'\x2', '\x143', '\x144', '\a', 't', '\x2', '\x2', '\x144', '\x145', '\a', 
		'\x63', '\x2', '\x2', '\x145', '\x146', '\a', '{', '\x2', '\x2', '\x146', 
		'\x30', '\x3', '\x2', '\x2', '\x2', '\x147', '\x148', '\a', 'w', '\x2', 
		'\x2', '\x148', '\x149', '\a', 'k', '\x2', '\x2', '\x149', '\x14A', '\a', 
		'p', '\x2', '\x2', '\x14A', '\x14B', '\a', 'v', '\x2', '\x2', '\x14B', 
		'\x14C', '\a', '\x38', '\x2', '\x2', '\x14C', '\x14D', '\a', '\x36', '\x2', 
		'\x2', '\x14D', '\x32', '\x3', '\x2', '\x2', '\x2', '\x14E', '\x14F', 
		'\a', 'w', '\x2', '\x2', '\x14F', '\x150', '\a', 'k', '\x2', '\x2', '\x150', 
		'\x151', '\a', 'p', '\x2', '\x2', '\x151', '\x152', '\a', 'v', '\x2', 
		'\x2', '\x152', '\x153', '\a', '\x35', '\x2', '\x2', '\x153', '\x154', 
		'\a', '\x34', '\x2', '\x2', '\x154', '\x34', '\x3', '\x2', '\x2', '\x2', 
		'\x155', '\x156', '\a', 'w', '\x2', '\x2', '\x156', '\x157', '\a', 'k', 
		'\x2', '\x2', '\x157', '\x158', '\a', 'p', '\x2', '\x2', '\x158', '\x159', 
		'\a', 'v', '\x2', '\x2', '\x159', '\x15A', '\a', '\x33', '\x2', '\x2', 
		'\x15A', '\x15B', '\a', '\x38', '\x2', '\x2', '\x15B', '\x36', '\x3', 
		'\x2', '\x2', '\x2', '\x15C', '\x15D', '\a', 'w', '\x2', '\x2', '\x15D', 
		'\x15E', '\a', 'k', '\x2', '\x2', '\x15E', '\x15F', '\a', 'p', '\x2', 
		'\x2', '\x15F', '\x160', '\a', 'v', '\x2', '\x2', '\x160', '\x161', '\a', 
		':', '\x2', '\x2', '\x161', '\x38', '\x3', '\x2', '\x2', '\x2', '\x162', 
		'\x163', '\a', 'k', '\x2', '\x2', '\x163', '\x164', '\a', 'p', '\x2', 
		'\x2', '\x164', '\x165', '\a', 'v', '\x2', '\x2', '\x165', '\x166', '\a', 
		'\x38', '\x2', '\x2', '\x166', '\x167', '\a', '\x36', '\x2', '\x2', '\x167', 
		':', '\x3', '\x2', '\x2', '\x2', '\x168', '\x169', '\a', 'k', '\x2', '\x2', 
		'\x169', '\x16A', '\a', 'p', '\x2', '\x2', '\x16A', '\x16B', '\a', 'v', 
		'\x2', '\x2', '\x16B', '\x16C', '\a', '\x35', '\x2', '\x2', '\x16C', '\x16D', 
		'\a', '\x34', '\x2', '\x2', '\x16D', '<', '\x3', '\x2', '\x2', '\x2', 
		'\x16E', '\x16F', '\a', 'k', '\x2', '\x2', '\x16F', '\x170', '\a', 'p', 
		'\x2', '\x2', '\x170', '\x171', '\a', 'v', '\x2', '\x2', '\x171', '\x172', 
		'\a', '\x33', '\x2', '\x2', '\x172', '\x173', '\a', '\x38', '\x2', '\x2', 
		'\x173', '>', '\x3', '\x2', '\x2', '\x2', '\x174', '\x175', '\a', 'k', 
		'\x2', '\x2', '\x175', '\x176', '\a', 'p', '\x2', '\x2', '\x176', '\x177', 
		'\a', 'v', '\x2', '\x2', '\x177', '\x178', '\a', ':', '\x2', '\x2', '\x178', 
		'@', '\x3', '\x2', '\x2', '\x2', '\x179', '\x17A', '\a', 'u', '\x2', '\x2', 
		'\x17A', '\x17B', '\a', 'v', '\x2', '\x2', '\x17B', '\x17C', '\a', 't', 
		'\x2', '\x2', '\x17C', '\x17D', '\a', 'k', '\x2', '\x2', '\x17D', '\x17E', 
		'\a', 'p', '\x2', '\x2', '\x17E', '\x17F', '\a', 'i', '\x2', '\x2', '\x17F', 
		'\x42', '\x3', '\x2', '\x2', '\x2', '\x180', '\x181', '\a', '\x64', '\x2', 
		'\x2', '\x181', '\x182', '\a', 'n', '\x2', '\x2', '\x182', '\x183', '\a', 
		'q', '\x2', '\x2', '\x183', '\x184', '\a', '\x64', '\x2', '\x2', '\x184', 
		'\x185', '\a', '\x35', '\x2', '\x2', '\x185', '\x186', '\a', '\x34', '\x2', 
		'\x2', '\x186', '\x44', '\x3', '\x2', '\x2', '\x2', '\x187', '\x188', 
		'\a', '\x64', '\x2', '\x2', '\x188', '\x189', '\a', 'n', '\x2', '\x2', 
		'\x189', '\x18A', '\a', 'q', '\x2', '\x2', '\x18A', '\x18B', '\a', '\x64', 
		'\x2', '\x2', '\x18B', '\x46', '\x3', '\x2', '\x2', '\x2', '\x18C', '\x19F', 
		'\x5', '#', '\x12', '\x2', '\x18D', '\x19F', '\x5', '%', '\x13', '\x2', 
		'\x18E', '\x19F', '\x5', '\'', '\x14', '\x2', '\x18F', '\x19F', '\x5', 
		')', '\x15', '\x2', '\x190', '\x19F', '\x5', '+', '\x16', '\x2', '\x191', 
		'\x19F', '\x5', '-', '\x17', '\x2', '\x192', '\x19F', '\x5', '/', '\x18', 
		'\x2', '\x193', '\x19F', '\x5', '\x31', '\x19', '\x2', '\x194', '\x19F', 
		'\x5', '\x33', '\x1A', '\x2', '\x195', '\x19F', '\x5', '\x35', '\x1B', 
		'\x2', '\x196', '\x19F', '\x5', '\x37', '\x1C', '\x2', '\x197', '\x19F', 
		'\x5', '\x39', '\x1D', '\x2', '\x198', '\x19F', '\x5', ';', '\x1E', '\x2', 
		'\x199', '\x19F', '\x5', '=', '\x1F', '\x2', '\x19A', '\x19F', '\x5', 
		'?', ' ', '\x2', '\x19B', '\x19F', '\x5', '\x41', '!', '\x2', '\x19C', 
		'\x19F', '\x5', '\x43', '\"', '\x2', '\x19D', '\x19F', '\x5', '\x45', 
		'#', '\x2', '\x19E', '\x18C', '\x3', '\x2', '\x2', '\x2', '\x19E', '\x18D', 
		'\x3', '\x2', '\x2', '\x2', '\x19E', '\x18E', '\x3', '\x2', '\x2', '\x2', 
		'\x19E', '\x18F', '\x3', '\x2', '\x2', '\x2', '\x19E', '\x190', '\x3', 
		'\x2', '\x2', '\x2', '\x19E', '\x191', '\x3', '\x2', '\x2', '\x2', '\x19E', 
		'\x192', '\x3', '\x2', '\x2', '\x2', '\x19E', '\x193', '\x3', '\x2', '\x2', 
		'\x2', '\x19E', '\x194', '\x3', '\x2', '\x2', '\x2', '\x19E', '\x195', 
		'\x3', '\x2', '\x2', '\x2', '\x19E', '\x196', '\x3', '\x2', '\x2', '\x2', 
		'\x19E', '\x197', '\x3', '\x2', '\x2', '\x2', '\x19E', '\x198', '\x3', 
		'\x2', '\x2', '\x2', '\x19E', '\x199', '\x3', '\x2', '\x2', '\x2', '\x19E', 
		'\x19A', '\x3', '\x2', '\x2', '\x2', '\x19E', '\x19B', '\x3', '\x2', '\x2', 
		'\x2', '\x19E', '\x19C', '\x3', '\x2', '\x2', '\x2', '\x19E', '\x19D', 
		'\x3', '\x2', '\x2', '\x2', '\x19F', 'H', '\x3', '\x2', '\x2', '\x2', 
		'\x1A0', '\x1A1', '\a', ',', '\x2', '\x2', '\x1A1', 'J', '\x3', '\x2', 
		'\x2', '\x2', '\x1A2', '\x1A3', '\a', '\x31', '\x2', '\x2', '\x1A3', 'L', 
		'\x3', '\x2', '\x2', '\x2', '\x1A4', '\x1A5', '\a', '\'', '\x2', '\x2', 
		'\x1A5', 'N', '\x3', '\x2', '\x2', '\x2', '\x1A6', '\x1A7', '\a', '\x30', 
		'\x2', '\x2', '\x1A7', 'P', '\x3', '\x2', '\x2', '\x2', '\x1A8', '\x1A9', 
		'\a', '*', '\x2', '\x2', '\x1A9', 'R', '\x3', '\x2', '\x2', '\x2', '\x1AA', 
		'\x1AB', '\a', '+', '\x2', '\x2', '\x1AB', 'T', '\x3', '\x2', '\x2', '\x2', 
		'\x1AC', '\x1AD', '\a', '/', '\x2', '\x2', '\x1AD', 'V', '\x3', '\x2', 
		'\x2', '\x2', '\x1AE', '\x1AF', '\a', '.', '\x2', '\x2', '\x1AF', 'X', 
		'\x3', '\x2', '\x2', '\x2', '\x1B0', '\x1B1', '\a', ']', '\x2', '\x2', 
		'\x1B1', 'Z', '\x3', '\x2', '\x2', '\x2', '\x1B2', '\x1B3', '\a', '_', 
		'\x2', '\x2', '\x1B3', '\\', '\x3', '\x2', '\x2', '\x2', '\x1B4', '\x1B5', 
		'\a', '}', '\x2', '\x2', '\x1B5', '^', '\x3', '\x2', '\x2', '\x2', '\x1B6', 
		'\x1B7', '\a', '\x7F', '\x2', '\x2', '\x1B7', '`', '\x3', '\x2', '\x2', 
		'\x2', '\x1B8', '\x1B9', '\a', ')', '\x2', '\x2', '\x1B9', '\x62', '\x3', 
		'\x2', '\x2', '\x2', '\x1BA', '\x1BB', '\a', '$', '\x2', '\x2', '\x1BB', 
		'\x64', '\x3', '\x2', '\x2', '\x2', '\x1BC', '\x1BD', '\a', '?', '\x2', 
		'\x2', '\x1BD', '\x66', '\x3', '\x2', '\x2', '\x2', '\x1BE', '\x1BF', 
		'\a', '=', '\x2', '\x2', '\x1BF', 'h', '\x3', '\x2', '\x2', '\x2', '\x1C0', 
		'\x1C1', '\a', '<', '\x2', '\x2', '\x1C1', 'j', '\x3', '\x2', '\x2', '\x2', 
		'\x1C2', '\x1C3', '\a', '^', '\x2', '\x2', '\x1C3', '\x1C4', '\a', '$', 
		'\x2', '\x2', '\x1C4', 'l', '\x3', '\x2', '\x2', '\x2', '\x1C5', '\x1CA', 
		'\a', '$', '\x2', '\x2', '\x1C6', '\x1C9', '\x5', 'k', '\x36', '\x2', 
		'\x1C7', '\x1C9', '\n', '\x2', '\x2', '\x2', '\x1C8', '\x1C6', '\x3', 
		'\x2', '\x2', '\x2', '\x1C8', '\x1C7', '\x3', '\x2', '\x2', '\x2', '\x1C9', 
		'\x1CC', '\x3', '\x2', '\x2', '\x2', '\x1CA', '\x1CB', '\x3', '\x2', '\x2', 
		'\x2', '\x1CA', '\x1C8', '\x3', '\x2', '\x2', '\x2', '\x1CB', '\x1CD', 
		'\x3', '\x2', '\x2', '\x2', '\x1CC', '\x1CA', '\x3', '\x2', '\x2', '\x2', 
		'\x1CD', '\x1CE', '\a', '$', '\x2', '\x2', '\x1CE', 'n', '\x3', '\x2', 
		'\x2', '\x2', '\x1CF', '\x1D0', '\a', ')', '\x2', '\x2', '\x1D0', '\x1D1', 
		'\x5', 'y', '=', '\x2', '\x1D1', '\x1D2', '\a', ')', '\x2', '\x2', '\x1D2', 
		'p', '\x3', '\x2', '\x2', '\x2', '\x1D3', '\x1D4', '\a', '^', '\x2', '\x2', 
		'\x1D4', '\x1D5', '\a', ')', '\x2', '\x2', '\x1D5', 'r', '\x3', '\x2', 
		'\x2', '\x2', '\x1D6', '\x1DB', '\a', ')', '\x2', '\x2', '\x1D7', '\x1DA', 
		'\x5', 'q', '\x39', '\x2', '\x1D8', '\x1DA', '\n', '\x2', '\x2', '\x2', 
		'\x1D9', '\x1D7', '\x3', '\x2', '\x2', '\x2', '\x1D9', '\x1D8', '\x3', 
		'\x2', '\x2', '\x2', '\x1DA', '\x1DD', '\x3', '\x2', '\x2', '\x2', '\x1DB', 
		'\x1DC', '\x3', '\x2', '\x2', '\x2', '\x1DB', '\x1D9', '\x3', '\x2', '\x2', 
		'\x2', '\x1DC', '\x1DE', '\x3', '\x2', '\x2', '\x2', '\x1DD', '\x1DB', 
		'\x3', '\x2', '\x2', '\x2', '\x1DE', '\x1DF', '\a', ')', '\x2', '\x2', 
		'\x1DF', 't', '\x3', '\x2', '\x2', '\x2', '\x1E0', '\x1E4', '\t', '\x3', 
		'\x2', '\x2', '\x1E1', '\x1E3', '\t', '\x4', '\x2', '\x2', '\x1E2', '\x1E1', 
		'\x3', '\x2', '\x2', '\x2', '\x1E3', '\x1E6', '\x3', '\x2', '\x2', '\x2', 
		'\x1E4', '\x1E2', '\x3', '\x2', '\x2', '\x2', '\x1E4', '\x1E5', '\x3', 
		'\x2', '\x2', '\x2', '\x1E5', 'v', '\x3', '\x2', '\x2', '\x2', '\x1E6', 
		'\x1E4', '\x3', '\x2', '\x2', '\x2', '\x1E7', '\x1E9', '\t', '\x5', '\x2', 
		'\x2', '\x1E8', '\x1E7', '\x3', '\x2', '\x2', '\x2', '\x1E9', '\x1EA', 
		'\x3', '\x2', '\x2', '\x2', '\x1EA', '\x1E8', '\x3', '\x2', '\x2', '\x2', 
		'\x1EA', '\x1EB', '\x3', '\x2', '\x2', '\x2', '\x1EB', 'x', '\x3', '\x2', 
		'\x2', '\x2', '\x1EC', '\x1ED', '\t', '\x6', '\x2', '\x2', '\x1ED', 'z', 
		'\x3', '\x2', '\x2', '\x2', '\x1EE', '\x1EF', '\a', '\x31', '\x2', '\x2', 
		'\x1EF', '\x1F0', '\a', '\x31', '\x2', '\x2', '\x1F0', '\x1F4', '\x3', 
		'\x2', '\x2', '\x2', '\x1F1', '\x1F3', '\v', '\x2', '\x2', '\x2', '\x1F2', 
		'\x1F1', '\x3', '\x2', '\x2', '\x2', '\x1F3', '\x1F6', '\x3', '\x2', '\x2', 
		'\x2', '\x1F4', '\x1F5', '\x3', '\x2', '\x2', '\x2', '\x1F4', '\x1F2', 
		'\x3', '\x2', '\x2', '\x2', '\x1F5', '\x1F7', '\x3', '\x2', '\x2', '\x2', 
		'\x1F6', '\x1F4', '\x3', '\x2', '\x2', '\x2', '\x1F7', '\x1F8', '\a', 
		'\f', '\x2', '\x2', '\x1F8', '\x1F9', '\x3', '\x2', '\x2', '\x2', '\x1F9', 
		'\x1FA', '\b', '>', '\x2', '\x2', '\x1FA', '|', '\x3', '\x2', '\x2', '\x2', 
		'\x1FB', '\x1FD', '\t', '\a', '\x2', '\x2', '\x1FC', '\x1FB', '\x3', '\x2', 
		'\x2', '\x2', '\x1FD', '\x1FE', '\x3', '\x2', '\x2', '\x2', '\x1FE', '\x1FC', 
		'\x3', '\x2', '\x2', '\x2', '\x1FE', '\x1FF', '\x3', '\x2', '\x2', '\x2', 
		'\x1FF', '\x200', '\x3', '\x2', '\x2', '\x2', '\x200', '\x201', '\b', 
		'?', '\x2', '\x2', '\x201', '~', '\x3', '\x2', '\x2', '\x2', '\r', '\x2', 
		'\xF1', '\x19E', '\x1C8', '\x1CA', '\x1D9', '\x1DB', '\x1E4', '\x1EA', 
		'\x1F4', '\x1FE', '\x3', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace DcSharp
